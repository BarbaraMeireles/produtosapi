// --------------------------------------------------------------------------------------------------------------------
// <summary>
// Modelo de produto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ProdutosApi.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Modelo de Produto
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Identificador do produto.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        [BsonElement("Nome")]
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        /// <summary>
        /// URL da imagem do produto.
        /// </summary>
        [BsonElement("URLImagem")]
        public string URLImagem { get; set; }

        /// <summary>
        /// Categoria do produto.
        /// </summary>
        [BsonElement("Categoria")]
        public string Categoria { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        [BsonElement("Preco")]
        public double Preco { get; set; }

        /// <summary>
        /// Marca do produto.
        /// </summary>
        [BsonElement("Marca")]
        public string Marca { get; set; }
    }
}