namespace MemeBot
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;

    using MemeBot.Core;

    internal class Loader
    {
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        public void Configure(IApplicationBuilder app)
        {
            Resources.Initialize();

            app.Run(context => context.Response.WriteAsync($"MemeBot has been started in {Resources.Stopwatch.ElapsedMilliseconds}ms!"));
        }
    }
}
