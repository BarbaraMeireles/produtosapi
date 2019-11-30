namespace ProdutosApi.Models
{
    public class ProdutosDatabaseSettings : IProdutosDatabaseSettings
    { 
        public string ProdutosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProdutosDatabaseSettings
    {
        string ProdutosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}