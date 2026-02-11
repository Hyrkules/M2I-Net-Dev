using GestionProduits.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP_asp.netMVS.Models;
using TP_asp.netMVS.Services;
using TP_asp.netMVS.ViewModel.Produits;
using TP_asp.netMVS.ViewModels.Produits;

namespace TP_asp.netMVS.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly IProduitService _service;

        public ProduitsController(IProduitService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var ProduitsViewmodels = _service.GetAll();

            return View(ProduitsViewmodels.ToList());
        }

        public IActionResult Details(int id)
        {
            var viewModel = _service.GetById(id);
            if(viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {

            var model = _service.GetFormViewModel(null);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProduitFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CategoriesSelectList = _service.GetFormViewModel(null).CategoriesSelectList;
                return View(model);
            }
            var success = _service.Create(model);

            if (success)
            {
                TempData["SuccessMessage"] = "OK";
                return RedirectToAction("Index", "Produits");
            }
            model.CategoriesSelectList = _service.GetFormViewModel(null).CategoriesSelectList;
            return View(model);


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ViewModel = _service.GetFormViewModel(id);
            if (ViewModel.Id == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProduitFormViewModel produitModifie) 
        {
            if (!ModelState.IsValid)
            {
                produitModifie.CategoriesSelectList = _service.GetFormViewModel(id).CategoriesSelectList;
                return View(produitModifie);
            }

            var success = _service.Update(id, produitModifie);

            if (success)
            {
                TempData["SuccessMessage"] = "OK";
                return RedirectToAction("Index", "Produits");

            }
            return NotFound();



        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id) {
            var success = _service.Delete(id);
            if (success == null)
            {
                TempData["SuccessMessage"] = "OK";
                return RedirectToAction("Index", "Produits");
            }

            return NotFound();
        }

    }
}

