using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly ProductTypeRepository productTypeRepository;

        public ProductTypeController()
        {
            productTypeRepository = new ProductTypeRepository();
        }

        // ACTION INDEX
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Index()
        {
            var listType = productTypeRepository.GetAll();

            // Retornando para View a lista de Tipos
            return View(listType);
        }

        // ACTION CREATE
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductType());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Create(ProductType productType)
        {
            // Se o ModelState não tem nenhum erro
            if (ModelState.IsValid)
            {
                productTypeRepository.Create(productType);

                // Gravação efetuada com sucesso.
                // Gravando mensagem de sucesso na TempData
                @TempData["message"] = "Tipo cadastrado com sucesso!";

                return RedirectToAction("Index", "ProductType");

                // Encontrou um erro no preenchimento do campo descriçao
            }
            else
            {
                // retorna para tela do formulário
                return View(productType);
            }
        }

        // ACTION UPDATE
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var productType = productTypeRepository.GetOne(Id);

            // Retorna para a View o objeto modelo 
            // com as propriedades preenchidas com dados do banco de dados 
            return View(productType);
        }

        [HttpPost]
        public IActionResult Update(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                productTypeRepository.Update(productType);

                @TempData["message"] = "Tipo alterado com sucesso!";

                return RedirectToAction("Index", "ProductType");
            }
            else
            {
                return View(productType);
            }
        }

        // ACTION READ
        [HttpGet]
        public IActionResult Read(int Id)
        {
            var productType = productTypeRepository.GetOne(Id);

            // Retorna para a View o objeto modelo 
            // com as propriedades preenchidas com dados do banco de dados 
            return View(productType);
        }

        // ACTION DELETE
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            productTypeRepository.Delete(Id);

            @TempData["message"] = "Tipo removido com sucesso!";

            // Substituímos o return View()
            // pelo método de redirecionamento
            return RedirectToAction("Index", "ProductType");
        }
    }
}
