using System.Data.SqlClient;
using System.Data;

using FiapSmartCity.Models;
using FiapSmartCity.Repository.Context;

namespace FiapSmartCity.Repository
{
    public class ProductTypeEFRepository
    {
        private readonly DataBaseContext context;

        public ProductTypeEFRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework (relacionando ao BD)
            context = new DataBaseContext();
        }

        public IList<ProductTypeEF> GetAll()
        {
            return context.ProductTypeEF.ToList();
        }

        public IList<ProductTypeEF> ListOrderedByName() // Listar Ordenado Por Nome
        {
            var list =
                context.ProductTypeEF.OrderBy(t => t.TypeDescription).ToList<ProductTypeEF>();

            return list;
        }

        public IList<ProductTypeEF> ListOrderedByNameDescending() // Listar Ordenado Por Nome Descendente
        {
            var list =
                context.ProductTypeEF.OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

            return list;
        }
        public IList<ProductTypeEF> ListMarketedTypes() // Listar Tipos Comercializados
        {
            // Filtro com Where
            var list =
                context.ProductTypeEF.Where(t => t.Marketed == false)
                        .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

            return list;
        }

        public IList<ProductTypeEF> ListTypesSoldCriterion(bool selection) // Listar Tipos Comercializados Critério
        {
            // Filtro com Where
            var list =
                context.ProductTypeEF.Where(t => t.Marketed == selection)
                        .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

            return list;
        }

        public IList<ProductTypeEF> ListMarketedTypes(bool selection) // Listar Tipos Comercializados
        {
            // Filtro com Where
            var list =
                context.ProductTypeEF.Where(t => t.Marketed == selection && t.TypeId > 2)
                        .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

            return list;
        }

        public ProductTypeEF QueryByDescription(string description) // Consulta Por Descrição
        {
            // Retorno único
            ProductTypeEF type =
                context.ProductTypeEF.Where(t => t.TypeDescription == description)
                    .FirstOrDefault<ProductTypeEF>();

            return type;
        }

        public IList<ProductTypeEF> ListTypesPartDescription(string partDescription) // Listar Tipos Parte Descrição
        {
            // Filtro com Where e Contains
            var list =
                context.ProductTypeEF.Where(t => t.TypeDescription.Contains(partDescription))
                        .ToList<ProductTypeEF>();

            return list;
        }

        public ProductTypeEF Read(int id)
        {
            return context.ProductTypeEF.Find(id);
        }

        public void Create(ProductTypeEF productType)
        {
            context.ProductTypeEF.Add(productType);
            context.SaveChanges();
        }

        public void Update(ProductTypeEF productType)
        {
            context.ProductTypeEF.Update(productType);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Criar um tipo produto apenas com o Id
            var productType = new ProductTypeEF()
            {
                TypeId = id
            };

            context.ProductTypeEF.Remove(productType);
            context.SaveChanges();
        }

    }
}