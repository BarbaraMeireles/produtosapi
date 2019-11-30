// --------------------------------------------------------------------------------------------------------------------
// <summary>
// Controller de produto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ProdutosApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using ProdutosApi.Models;
    using ProdutosAPI.Services;

    /// <summary>
    /// Controller de produto.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary> 
        /// Obtém os produtos de forma paginada por nome e/ou por categoria e/ou marca e/ou preço
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
        /// <returns>
        /// Retorna a lista de produtos consultados.
        /// </returns>
        [HttpGet]        
        public ActionResult<List<Produto>> Get(int limite, int pagina, string nome, string categoria, string marca, double? preco)
        {
            var produtos = _produtoService.Consultar(limite, pagina, nome, categoria, marca, preco);
            return Ok(produtos);
        }

        /// <summary> 
        /// Obtém o produto por identificador
        /// </summary>
        /// <param name="id">
        /// Identificador do produto
        /// </param>        
        /// <returns>
        /// Retorna o produto consultado.
        /// </returns>
        [HttpGet("{Id}")]
        public ActionResult<Produto> Get(string id)
        {
            var produto = _produtoService.ConsultarPorIdentificador(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        /// <summary> 
        /// Adiciona um produto
        /// </summary>
        /// <param name="produto">
        /// O produto
        /// </param>        
        /// <returns>
        /// Retorna o produto adicionado
        /// </returns>
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _produtoService.Adicionar(produto);

            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        /// <summary> 
        /// Edita um produto
        /// </summary>
        /// <param name="id">
        /// Identificador do produto a ser editado
        /// </param>        
        /// <param name="produto">
        /// Produto com informações atualizadas
        /// </param>
        /// <returns>
        /// Retorna resposta se foi editado ou não
        /// </returns>
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Produto produtoAtualizado)
        {
            var produto = _produtoService.ConsultarPorIdentificador(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtoService.Editar(id, produtoAtualizado);

            return NoContent();
        }

        /// <summary> 
        /// Exclui um produto
        /// </summary>
        /// <param name="id">
        /// Identificador do produto a ser excluído
        /// </param>                
        /// <returns>
        /// Retorna resposta se foi excluído ou não
        /// </returns>
        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            var produto = _produtoService.ConsultarPorIdentificador(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtoService.Excluir(produto.Id);

            return Ok();
        }
    }
}