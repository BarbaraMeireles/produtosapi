// --------------------------------------------------------------------------------------------------------------------
// <summary>
// Interface de serviço do produto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ProdutosAPI.Services
{
    using ProdutosApi.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Interface de serviço de Produto
    /// </summary>
    public interface IProdutoService
    {
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
        List<Produto> Consultar(int limite, int pagina, string nome, string categoria, string marca, double? preco);

        /// <summary> 
        /// Obtém o produto por identificador
        /// </summary>
        /// <param name="id">
        /// Identificador do produto
        /// </param>        
        /// <returns>
        /// Retorna o produto consultado.
        /// </returns>
        Produto ConsultarPorIdentificador(string id);

        /// <summary> 
        /// Adiciona um produto
        /// </summary>
        /// <param name="produto">
        /// O produto
        /// </param>        
        /// <returns>
        /// Retorna o produto adicionado
        /// </returns>
        Produto Adicionar(Produto produto);

        /// <summary> 
        /// Edita um produto
        /// </summary>
        /// <param name="id">
        /// Identificador do produto a ser editado
        /// </param>        
        /// <param name="produtoAtualizado">
        /// Produto com informações atualizadas
        /// </param>        
        void Editar(string id, Produto produtoAtualizado);

        /// <summary> 
        /// Exclui um produto
        /// </summary>
        /// <param name="produtoRemovido">
        /// Produto a ser excluido
        /// </param>                        
        void Excluir(Produto produtoRemovido);

        /// <summary> 
        /// Exclui um produto
        /// </summary>
        /// <param name="id">
        /// Identificador do produto a ser excluido
        /// </param>                        
        void Excluir(string id);       
    }
}
