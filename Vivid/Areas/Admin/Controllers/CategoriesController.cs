using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.ViewModels;
using Vivid.Areas.Admin.Models.Repositories;

namespace Vivid.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IApplicationRepository<Category> repository;

        public CategoriesController(IApplicationRepository<Category> repository)
        {
            this.repository = repository;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            return View(repository.List());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = new Category
                    {
                        Name = model.Name
                    };
                    repository.Add(category);
                    return RedirectToAction("index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = repository.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            var model = new EditCategoryViewModel
            {
                Id = category.ID,
                Name = category.Name
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = new Category
                    {
                        Name = model.Name
                    };
                    repository.Update(model.Id, category);
                    return RedirectToAction("index");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = repository.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
