namespace MemeBot.Core
{
    using System.Diagnostics;

    using MemeBot.Modules;

    internal class Resources
    {
        internal static readonly Stopwatch Stopwatch = new Stopwatch();

        /// <summary>
        /// Initializes the <see cref="Resources"/> class.
        /// </summary>
        internal static void Initialize()
        {
            Resources.Stopwatch.Start();
            
            MemeFactory.Initialize();
            DiscordBot.Initialize();

            Resources.Stopwatch.Stop();
        }
    }
}
