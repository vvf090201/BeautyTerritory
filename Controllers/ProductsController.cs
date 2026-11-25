using Microsoft.AspNetCore.Mvc;
using Lab4_MVC_App.Models;
using Lab4_MVC_App.Repositories;

namespace Lab4_MVC_App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // Список всех товаров
        public IActionResult Index() => View(_repository.GetAll());

        // Просмотр одного товара
        public IActionResult Details(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // Добавление (Форма)
        public IActionResult Create() => View();

        // Добавление (Сохранение)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Редактирование (Форма)
        public IActionResult Edit(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // Редактирование (Сохранение)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _repository.Update(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Удаление
        public IActionResult Delete(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // Удаление (Подтверждение)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}