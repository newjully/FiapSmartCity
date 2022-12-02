using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    public class ProductTypeEFController : Controller
    {
        private readonly ProductTypeEFRepository productTypeEFRepository;
        private readonly ProductEFRepository productEFRepository;

        public ProductTypeEFController()
        {
            productTypeEFRepository = new ProductTypeEFRepository();
            productEFRepository = new ProductEFRepository();
        }

        // ACTION INDEX
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Index()
        {
            var listType = productTypeEFRepository.GetAll();

            // Retornando para View a lista de Tipos
            return View(listType);
        }

        // ACTION CREATE
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductTypeEF());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Create(ProductTypeEF productTypeEF)
        {
            // Se o ModelState não tem nenhum erro
            if (ModelState.IsValid)
            {
                productTypeEFRepository.Create(productTypeEF);

                // Gravação efetuada com sucesso.
                // Gravando mensagem de sucesso na TempData
                @TempData["message"] = "Tipo cadastrado com sucesso!";

                return RedirectToAction("Index", "ProductTypeEF");

                // Encontrou um erro no preenchimento do campo descriçao
            }
            else
            {
                // retorna para tela do formulário
                return View(productTypeEF);
            }
        }

        // ACTION UPDATE
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var productTypeEF = productTypeEFRepository.Read(Id);

            // Retorna para a View o objeto modelo 
            // com as propriedades preenchidas com dados do banco de dados 
            return View(productTypeEF);
        }

        [HttpPost]
        public IActionResult Update(ProductTypeEF productTypeEF)
        {
            if (ModelState.IsValid)
            {
                productTypeEFRepository.Update(productTypeEF);

                @TempData["message"] = "Tipo alterado com sucesso!";

                return RedirectToAction("Index", "ProductTypeEF");
            }
            else
            {
                return View(productTypeEF);
            }
        }

        // ACTION READ
        [HttpGet]
        public IActionResult Read(int Id)
        {
            var productTypeEF = productTypeEFRepository.Read(Id);

            // Retorna para a View o objeto modelo 
            // com as propriedades preenchidas com dados do banco de dados 
            return View(productTypeEF);
        }

        [HttpGet]
        public ActionResult RedProduct(int Id) // consultar um produto
        {
            var productEF = productEFRepository.Read(Id);
            return View(productEF);
        }

        // ACTION DELETE
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            productTypeEFRepository.Delete(Id);

            @TempData["message"] = "Tipo removido com sucesso!";

            // Substituímos o return View()
            // pelo método de redirecionamento
            return RedirectToAction("Index", "ProductTypeEF");
        }
    }
}
