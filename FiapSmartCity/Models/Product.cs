namespace FiapSmartCity.Models
{
 public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string Features { get; set; } // Características
            public double AveragePrice { get; set; } // preço médio
            public string Logotipo { get; set; }
            public bool Active { get; set; } // ativos

            // Referência para classe TipoProduto/ProductType
            public ProductType Type { get; set; }
        }
   }


