//using Harbinger.Controllers;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace Harbinger
{
    public class MockCollector
    {
        private CancellationTokenSource _cancellationTokenSource;

        public MockCollector()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            LoggerAdapter.Instance.WriteLine("Logging has been initialized");
        }

        public MockCollector(ILogger logger) : this()
        {
            LoggerAdapter.Instance.SetLogger(logger);
        }

        public MockCollector(ITestOutputHelper logger) : this()
        {
            LoggerAdapter.Instance.SetLogger(logger);
        }

        public async Task StartCollector(string uri)
        {
            var builder = WebApplication.CreateBuilder();
            builder.Logging.AddConsole();

            builder.Services.AddAuthorization();

            builder.Services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            var app = builder.Build();

            app.MapPost("/agent_listener/invoke_raw_method", async (HttpRequest request, string method, string license_key, string protocol_version) => 
            {
                var payload = await ConnectMethodHandler.TryDecompress(request.Body, request.Headers["CONTENT-ENCODING"]);
                return JsonConvert.SerializeObject(ConnectMethodHandler.HandleConnection(method, license_key, protocol_version, payload));
            });

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Urls.Add(uri);

            await app.RunAsync(_cancellationTokenSource.Token);
        }

        public void StopCollector()
        {
            LoggerAdapter.Instance.WriteLine("Stopping mock collector host");
            _cancellationTokenSource.Cancel();
        }
    }
}
