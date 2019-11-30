// --------------------------------------------------------------------------------------------------------------------
// <summary>
// Classe de cenários para testes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ProdutosAPI.Teste.Scenarios
{
    using FluentAssertions;
    using System.Net;
    using System.Threading.Tasks;
    using ProdutosAPI.Teste.Fixtures;
    using Xunit;

    // <summary>
    // Classe de cenários para testes
    // </summary>
    public class ProdutosTest
    {
        // <summary>
        // Contexto dos testes
        // </summary>
        private readonly TestContext _testContext;

        // <summary>
        // Construtor de classe de cenários para testes
        // </summary>
        public ProdutosTest()
        {
            _testContext = new TestContext();
        }

        /// <summary>
        /// Teste: Deve retornar resposta OK ao consultar produtos
        /// </summary>       
        /// <param name="limite">
        /// Limite de produtos por consulta.
        /// </param>
        /// <param name="pagina">
        /// Página.
        /// </param>        
        /// <param name="nome"> 
        /// Obtém ou define o nome dos produtos.
        /// </param>
        /// <param name="categoria"> 
        /// Obtém ou define a categoria dos produtos.
        /// </param>
        /// <param name="marca"> 
        /// Obtém ou define a marca dos produtos.
        /// </param>
        /// <param name="preco"> 
        /// Obtém ou define o preço dos produtos.
        /// </param>        
        [Theory]
        [InlineData(10, 1, null, null, null, null)]
        [InlineData(2, 1, null, null, null, null)]
        [InlineData(2, 1, "Produto1", null, null, null)]
        [InlineData(2, 1, null, "Objeto", null, null)]
        [InlineData(2, 1, null, null, "FaberCastell", null)]
        [InlineData(2, 1, null, null, null, 2.27)]
        public async Task DeveRetornarRespostaOKAoConsultarProdutos(int limite, int pagina, string nome, string categoria, string marca, double? preco)
        {
            var response = await _testContext.Client.GetAsync("/api/produtos");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        /// <summary>
        /// Teste: Deve retornar resposta OK ao consultar produto pelo identificador
        /// </summary>       
        [Fact]
        public async Task DeveRetornarRespostaOKAoConsultarProdutoPeloIdentificador()
        {
            var response = await _testContext.Client.GetAsync("/api/produtos/5dcf3ef3314bbb238e4e84cb");            
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        /// <summary>
        /// Teste: Deve retornar resposta Not Found ao consultar produto por identificador inexistente
        /// </summary>       
        [Fact]
        public async Task DeveRetornarRespostaNotFoundAoConsultarProdutoPorIdentificadorInexistente()
        {
            var response = await _testContext.Client.GetAsync("/api/produtos/5dcf3ef3314bbb238e4e84aa");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }     


    }
}
