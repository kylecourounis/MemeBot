namespace MemeBot.Modules
{
    using System;
    using System.Collections.Generic;

    using MemeBot.Core.Consoles;

    using Octokit;
    
    internal class MemeFactory
    {
        private static Random Random;

        internal static readonly List<string> Memes = new List<string>();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MemeFactory"/> has been initialized.
        /// </summary>
        internal static bool Initialized
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the <see cref="MemeFactory"/> class.
        /// </summary>
        internal static async void Initialize()
        {
            if (MemeFactory.Initialized)
            {
                return;
            }

            MemeFactory.Random = new Random();

            var github         = new GitHubClient(new ProductHeaderValue("Patch"));
            var repository     = await github.Repository.Content.GetAllContents("kylecourounis", "Patch", "Memes");
            
            foreach (var file in repository)
            {
                MemeFactory.Memes.Add(file.Name.Replace(" ", "%20"));
            }

            Logger.Info(typeof(MemeFactory), $"Loaded {MemeFactory.Memes.Count} memes.");

            MemeFactory.Initialized = true;
        }

        /// <summary>
        /// Gets a random meme.
        /// </summary>
        internal static string RandomMeme
        {
            get
            {
                return MemeFactory.Memes[MemeFactory.Random.Next(MemeFactory.Memes.Count)];
            }
        }
    }
}
