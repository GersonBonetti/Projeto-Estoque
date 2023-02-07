using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sln.Estoque.Application.Service.SQLServerServices;
using Sln.Estoque.Domain.DTO;
using Sln.Estoque.Domain.Entities;
using Sln.Estoque.Domain.IServices;
using Sln.Estoque.Domain.Util;

namespace Sln.Estoque.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categorias = _categoryService.FindAll();
            ViewBag.Categorias = categorias;
            return View(_service.FindAll());
        }

        public JsonResult ListJson()
        {
            return Json(_service.FindAll());
        }

        // Disponibilizar essa informação da hora da abertura da página
        // Quando abre o create do produto
        public IActionResult Create()
        {
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name", "Select...");
            return View();
        }

        // Apenas para o post
        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, codigoProduto, nome, quantidade, preco, categoryId")] ProductDTO product)
        {
            product.horaAtualizada = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (await _service.Save(product) > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name", product.categoryId);
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _service.FindById(id);
            ViewBag.Categorias = new SelectList(_categoryService.FindAll(), "id", "name", product.categoryId);

            /*ViewBag.Id = id;

            var categorias = _categoryService.FindAll();
            ViewBag.Categorias = categorias;*/
            //penso que seja a seção para aparecer a classe pelo nome na view de edição

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, codigoProduto, nome, quantidade, preco, categoryId")] ProductDTO product)
        {
            var sPreco = product.preco.ToString();
            if (!(id == product.id))
            {
                return NotFound();
            }
            if (sPreco.Length > 2)
            {
                sPreco.Insert(2, ".");
                product.preco = Decimal.Parse(sPreco);
            }
            product.horaAtualizada = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (await _service.Save(product) > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(product);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDel
            {
                status = "Success",
                code = "200"
            };
            try
            {
                if (await _service.Delete(id ?? 0) <= 0)
                {
                    retDel = new ReturnJsonDel
                    {
                        status = "Error",
                        code = "400"
                    };
                }
            }
            catch (Exception ex)
            {
                retDel = new ReturnJsonDel
                {
                    status = ex.Message,
                    code = "500"
                };
            }
            return Json(retDel);
        }


    }
}

