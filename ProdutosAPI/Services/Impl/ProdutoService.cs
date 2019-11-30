// --------------------------------------------------------------------------------------------------------------------
// <summary>
// Serviço do produto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ProdutosApi.Services
{
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq;
    using ProdutosApi.Models;
    using ProdutosAPI.Services;

    /// <summary>
    /// Serviço de Produto
    /// </summary>
    public class ProdutoService: IProdutoService
    {
        /// <summary>
        /// Lista de produtos
        /// </summary>
        private readonly IMongoCollection<Produto> _produtos;

        /// <summary>
        /// Construtor de serviço de produto
        /// </summary>
        public ProdutoService(IProdutosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produtos = database.GetCollection<Produto>(settings.ProdutosCollectionName);
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
        public List<Produto> Consultar(int limite, int pagina, string nome, string categoria, string marca, double? preco)
        {   
            int skip = limite * (pagina - 1);

            FilterDefinition<Produto> filter = FilterDefinition<Produto>.Empty;

            if (nome != null)
            {
                filter = filter & (Builders<Produto>.Filter.Eq(x => x.Nome, nome));
            }

            if (categoria != null)
            {
                filter = filter & (Builders<Produto>.Filter.Eq(x => x.Categoria, categoria));
            }

            if (marca != null)
            {
                filter = filter & (Builders<Produto>.Filter.Eq(x => x.Marca, marca));
            }
            
            if (preco > 0.0)
            {
                filter = filter & (Builders<Produto>.Filter.Eq(x => x.Preco, preco));
            }
            
            return _produtos.Find(filter).Skip(skip).Limit(limite).ToList();
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
        public Produto ConsultarPorIdentificador(string id)
        {
            return _produtos.Find<Produto>(produto => produto.Id == id).FirstOrDefault();
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
        public Produto Adicionar(Produto produto)
        {
            _produtos.InsertOne(produto);
            return produto;
        }

        /// <summary> 
        /// Edita um produto
        /// </summary>
        /// <param name="id">
        /// Identificador do produto a ser editado
        /// </param>        
        /// <param name="produtoAtualizado">
        /// Produto com informações atualizadas
        /// </param>        
        public void Editar(string id, Produto produtoAtualizado)
        {
            _produtos.ReplaceOne(produto => produto.Id == id, produtoAtualizado);
        }

        /// <summary> 
        /// Exclui um produto
        /// </summary>
        /// <param name="produtoRemovido">
        /// Produto a ser excluido
        /// </param>                        
        public void Excluir(Produto produtoRemovido)
        {
            _produtos.DeleteOne(produto => produto.Id == produtoRemovido.Id);
        }

        /// <summary> 
        /// Exclui um produto
        /// </summary>
        /// <param name="id">
        /// Identificador do produto a ser excluido
        /// </param>  
        public void Excluir(string id) 
        {
            _produtos.DeleteOne(produto => produto.Id == id);
        }            
    }
}