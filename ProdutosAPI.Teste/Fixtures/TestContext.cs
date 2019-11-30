// --------------------------------------------------------------------------------------------------------------------
// <summary>
// Classe de contexto para testes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ProdutosAPI.Teste.Fixtures
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using System.Net.Http;
    using ProdutosAPI;
    using Microsoft.Extensions.Configuration;

    // <summary>
    // Classe de contexto para testes
    // </summary>
    public class TestContext
    {
        // <summary>
        // Client
        // </summary>
        public HttpClient Client { get; set; }

        // <summary>
        // Server
        // </summary>
        private TestServer _server;

        // <summary>
        // construtor da classe de contexto para testes
        // </summary>
        public TestContext()
        {
            SetupClient();
        }

        // <summary>
        // Metodo de setup client
        // </summary>
        private void SetupClient()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            _server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Startup>());
            
            Client = _server.CreateClient();
        }
    }
}
