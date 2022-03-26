using System;
using Gremlin.Net.Driver;
using Gremlin.Net.Structure.IO.GraphSON;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sherlock.Apps.Api.DI
{
    public static class GremlinExtension
    {
        public static void CreateGremlinClient(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddSingleton<GremlinClient>(
                (serviceProvider) =>
                {
                    var gremlinServer = new GremlinServer(
                        hostname: configuration["CosmosConnection:Host"],
                        port: Port,
                        enableSsl: EnableSSL,
                        username: "/dbs/" + configuration["CosmosConnection:Database"] + "/colls/" + configuration["CosmosConnection:Container"],
                        password: configuration["CosmosConnection:PrimaryKey"]
                    );

                    var connectionPoolSettings = new ConnectionPoolSettings
                    {
                        MaxInProcessPerConnection = 32,
                        PoolSize = 4,
                        ReconnectionAttempts = 4,
                        ReconnectionBaseDelay = TimeSpan.FromSeconds(1)
                    };

                    var webSocketConfiguration =
                    new Action<System.Net.WebSockets.ClientWebSocketOptions>(options =>
                    {
                        options.KeepAliveInterval = TimeSpan.FromSeconds(10);
                    });
                    return new GremlinClient(gremlinServer, new GraphSON2MessageSerializer());
                }
            );

        }

        static bool EnableSSL
        {
            get
            {
                if (Environment.GetEnvironmentVariable("EnableSSL") == null)
                {
                    return true;
                }

                if (!bool.TryParse(Environment.GetEnvironmentVariable("EnableSSL"), out bool value))
                {
                    throw new ArgumentException("Invalid env var: EnableSSL is not a boolean");
                }

                return value;
            }
        }

        static int Port
        {
            get
            {
                if (Environment.GetEnvironmentVariable("Port") == null)
                {
                    return 443;
                }

                if (!int.TryParse(Environment.GetEnvironmentVariable("Port"), out int port))
                {
                    throw new ArgumentException("Invalid env var: Port is not an integer");
                }

                return port;
            }
        }
    }
}