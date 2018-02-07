namespace MemeBot.Core
{
    using System.Threading.Tasks;

    using DSharpPlus;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.EventArgs;

    using MemeBot.Core.Consoles;
    using MemeBot.Modules;

    internal class DiscordBot
    {
        private static DiscordClient Discord;
        private static CommandsNextModule Commands;
        
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DiscordBot"/> has been initialized.
        /// </summary>
        internal static bool Initialized
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the <see cref="DiscordBot"/> class.
        /// </summary>
        internal static async void Initialize()
        {
            if (DiscordBot.Initialized)
            {
                return;
            }

            Logger.Info(typeof(DiscordBot), $"Initializing the {nameof(DiscordBot)}.");
            
            DiscordBot.Discord = new DiscordClient(new DiscordConfiguration
            {
                AutoReconnect  = true,
                Token          = Constants.BotToken,
                TokenType      = TokenType.Bot,
                DateTimeFormat = "dd-MM-yyyy HH:mm:ss"
            });

            DiscordBot.Discord.MessageCreated += DiscordBot.OnMessageSent;
            DiscordBot.Discord.MessageDeleted += DiscordBot.OnMessageDeleted;

            await DiscordBot.Discord.ConnectAsync();
            
            var cmdCfg = new CommandsNextConfiguration
            {
                EnableDms            = false,
                EnableMentionPrefix  = true,
                CaseSensitive        = false,
                IgnoreExtraArguments = true,
                StringPrefix         = Constants.CommandPrefix
            };

            DiscordBot.Commands = DiscordBot.Discord.UseCommandsNext(cmdCfg);
            DiscordBot.Commands.RegisterCommands(typeof(Commands));
            DiscordBot.Commands.CommandExecuted += DiscordBot.OnCommandExecuted;

            DiscordBot.Initialized = true;
        }

        /// <summary>
        /// Raised when a command has been executed.
        /// </summary>
        private static Task OnCommandExecuted(CommandExecutionEventArgs args)
        {
            Logger.Debug(typeof(DiscordBot), $"{args.Context.User.Username} executed {args.Command.Name}.");
            return Task.CompletedTask;
        }

        /// <summary>
        /// Raised when a message has been sent.
        /// </summary>
        private static Task OnMessageSent(MessageCreateEventArgs args)
        {
            Logger.Debug(typeof(DiscordBot), $"{args.Author.Username} executed {args.Message}.");
            return Task.CompletedTask;
        }

        /// <summary>
        /// Raised when a message has been deleted.
        /// </summary>
        private static Task OnMessageDeleted(MessageDeleteEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
