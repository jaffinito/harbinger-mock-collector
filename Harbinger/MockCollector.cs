//using Harbinger.Controllers;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json;
using System.Text;
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
                var payload = await TryDecompress(request.Body, request.Headers["CONTENT-ENCODING"]);
                return JsonConvert.SerializeObject(ConnectionHandler.HandleConnection(method, license_key, protocol_version, payload));
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

        private static async Task<string> TryDecompress(Stream stream, string compressionsType)
        {
            var payloadMemoryStream = new MemoryStream();
            stream.CopyTo(payloadMemoryStream);

            if (compressionsType == "identity")
            {
                using (var reader = new StreamReader(payloadMemoryStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }

            return await Decompress(payloadMemoryStream);
        }

        private static async Task<string> Decompress(MemoryStream payloadMemoryStream)
        {
            var compressedBuffer = payloadMemoryStream.ToArray();
            var inStream = new MemoryStream(compressedBuffer);
            var outStream = new MemoryStream(compressedBuffer.Length);
            var inflateStream = new InflaterInputStream(inStream);

            inStream.Position = 0;
            byte[] resBuffer = null;
            try
            {
                var tmpBuffer = new byte[compressedBuffer.Length];
                int read = 0;

                do
                {
                    read = await inflateStream.ReadAsync(tmpBuffer, 0, tmpBuffer.Length);
                    if (read > 0)
                    {
                        await outStream.WriteAsync(tmpBuffer, 0, read);
                    }

                } while (read > 0);

                resBuffer = outStream.ToArray();
            }
            finally
            {
                inflateStream.Close();
                inStream.Close();
                outStream.Close();
            }

            return Encoding.UTF8.GetString(resBuffer);
        }
    }
}
