using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Gremlin.Net.Driver;
using Gremlin.Net.Driver.Exceptions;
using Gremlin.Net.Structure.IO.GraphSON;
using Newtonsoft.Json;
using Sherlock.Apps.Repository.Contract;

namespace Sherlock.Apps.Repository.Implementation;
public class GremlinHelper : IGremlinHelper
{
    private readonly Dictionary<string, string> _gremlinQueries;
    public Dictionary<string, string> GremlinQueries { 
        get 
        {
            return _gremlinQueries;
        } 
    }
    private readonly GremlinServer _gremlinServer;
    private readonly ConnectionPoolSettings _connectionPoolSettings;
    private readonly Action<ClientWebSocketOptions> _webSocketConfiguration;

    public GremlinHelper(string host, string primaryKey, string dataBase, string container)
    {
        var containerLink =  "/dbs/" + dataBase + "/colls/" + container;

        _gremlinServer = new GremlinServer(host, Port, enableSsl: EnableSSL, 
                                                    username: containerLink, 
                                                    password: primaryKey);
        _connectionPoolSettings = new ConnectionPoolSettings()
            {
                MaxInProcessPerConnection = 10,
                PoolSize = 30, 
                ReconnectionAttempts= 3,
                ReconnectionBaseDelay = TimeSpan.FromMilliseconds(500)
            };

        _webSocketConfiguration =
                new Action<ClientWebSocketOptions>(options =>
                {
                    options.KeepAliveInterval = TimeSpan.FromSeconds(10);
                });
        _gremlinQueries = new Dictionary<string, string>();
        
    }
    private bool EnableSSL
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
    private int Port
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
    public async Task<int> SubmitRequest()
    {
        using(var gremlinClient = new GremlinClient(
                _gremlinServer, 
                new GraphSON2Reader(), 
                new GraphSON2Writer(), 
                "application/vnd.gremlin-v2.0+json", 
                _connectionPoolSettings, 
                _webSocketConfiguration))
                {
                    // return await gremlinClient.SubmitAsync<dynamic>(query);
                    foreach (var query in _gremlinQueries)
                    {
                        await gremlinClient.SubmitAsync(query.Value);
                    }
                }
        return 0;
        
    }
    
}