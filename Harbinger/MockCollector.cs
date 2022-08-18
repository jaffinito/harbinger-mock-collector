using Harbinger.Controllers;
using Harbinger.Logging;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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

            // Add services to the container.
            builder.Services.AddMvc()
                .AddApplicationPart(typeof(AgentListenerController).Assembly)
                .AddControllersAsServices();

            builder.Services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

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
