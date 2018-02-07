namespace MemeBot.Modules
{
    using System;
    using System.Threading.Tasks;

    using DSharpPlus.CommandsNext;
    using DSharpPlus.CommandsNext.Attributes;
    using DSharpPlus.Entities;
    
    using MemeBot.Core.Consoles;

    internal class Commands
    {
        [Command("meme"), Description("Pulls a random meme from a folder in a GitHub repository.")]
        public async Task PlsMeme(CommandContext context)
        {
            await context.TriggerTypingAsync();

            var meme = MemeFactory.RandomMeme;

            Logger.Debug(typeof(Commands), $"Meme Chosen : {meme}");
            
            if (context.Channel.Name.Equals("memes", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.RespondAsync(embed: new DiscordEmbedBuilder
                {
                    ImageUrl = $"https://raw.githubusercontent.com/kylecourounis/Patch/master/Memes/{meme}",
                    Color = DiscordColor.Aquamarine
                });
            }
            else
            {
                await context.RespondAsync("You cannot use that command here!");
            }
        }
    }
}
