using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FiapSmartCity.Models
{

    // Quando não estamos trabalhando com o oracle e sim diretamente com SQL Server, não se faz necessário usar as anotações [TABLE], [KEY] e [COLUMN]
    // Porque a EF por convenção, associa tabelas e campos pelo nome da classe e atributos
    [Table("PRODUCTEF")]
    public class ProductEF
    {
        [Key]
        [Column("PRODUCTID")]
        public int ProductId { get; set; }

        [Column("PRODUCTNAME")]
        public string ProductName { get; set; }

        [Column("FEATURES")]
        public string Features { get; set; } // Características

        [Column("AVERAGEPRIVE")]
        public double AveragePrice { get; set; } // preço médio

        [Column("LOGOTIPO")]
        public string Logotipo { get; set; }

        [Column("ACTIVE")]
        public bool Active { get; set; } // ativos

        // Foreing Key
        [Column("TYPEID")]
        // Referência para classe TipoProduto/ProductType
        public int TypeId { get; set; }

        // Navigation Property
        public ProductTypeEF Type { get; set; }
    }
}
