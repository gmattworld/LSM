using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.Files;
using EmbedIO.WebApi;
using LSM.Engine.Controllers;
using Swan.Logging;
using System;
using System.IO;

namespace LSM.Engine.Utilities
{
    public class ServerManager
    {
        private const bool OpenBrowser = true;
        private const bool UseFileCache = true;
        private WebServer Server = null;

        public ServerManager()
        {
        }

        public void Start()
        {
            startServer(8050);
        }

        public void Stop()
        {
            StopServer();
        }


        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void startServer(int port = 8050)
        {
            // create URL
            var url = $"http://localhost:{port}/";

            try
            {
                LogManager.NoteLogger("Starting server");
                Server = CreateWebServer(url);
                // Our web server is disposable.
                //using (Server = CreateWebServer(url))
                //{
                    // Once we've registered our modules and configured them, we call the RunAsync() method.
                    Server.RunAsync();

                    var browser = new System.Diagnostics.Process()
                    {
                        StartInfo = new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true }
                    };
                    browser.Start();
                    // Wait for any key to be pressed before disposing of our web server.
                    // In a service, we'd manage the lifecycle of our web server using
                    // something like a BackgroundWorker or a ManualResetEvent.
                    //Console.ReadKey(true);
                //}
                LogManager.NoteLogger("Server running");
                //OpenBrowser("127.0.0.1:8050");
            }
            catch (Exception ex)
            {
                LogManager.NoteLogger(ex.Message);
                StopServer();
            }
        }

        public void StopServer()
        {
            try
            {
                LogManager.NoteLogger("Server stop action trigered");
                if (Server != null)
                {
                    Server.Dispose();
                }
                LogManager.NoteLogger("Server stopped");
            }
            catch (Exception ex)
            {
                LogManager.NoteLogger(ex.Message);
            }
        }

        // Create and configure our web server.
        private WebServer CreateWebServer(string url)
        {
            var server = new WebServer(o => o
                    .WithUrlPrefix(url)
                    .WithMode(HttpListenerMode.EmbedIO))

                // First, we will configure our web server by adding Modules.
                .WithLocalSessionManager()
                .WithWebApi("/api", m => m.WithController<ManageController>())
                .WithStaticFolder("/", HtmlRootPath, true, m => m.WithContentCaching(UseFileCache)) // Add static files after other modules to avoid conflicts
                .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));

            LogManager.NoteLogger(HtmlRootPath);
            // Listen for state changes.
            server.StateChanged += (s, e) => $"WebServer New State - {e.NewState}".Info();

            return server;
        }

        // Gets the local path of shared files.
        // When debugging, take them directly from source so we can edit and reload.
        // Otherwise, take them from the deployment directory.
        public string HtmlRootPath
        {
            get
            {

                string path = AppDomain.CurrentDomain.BaseDirectory;

#if DEBUG
                return Path.Combine(path, @"Views");
#else
                return Path.Combine(path, @"Views");
#endif
            }
        }
    }
}