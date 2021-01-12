using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.Models.Repositories;
using Vivid.Areas.Admin.ViewModels;

namespace Vivid.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MediaCategoriesController : Controller
    {
        private readonly IApplicationRepository<MediaCategory> repository;

        public MediaCategoriesController(IApplicationRepository<MediaCategory> repository)
        {
            this.repository = repository;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            return View(repository.List());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMediaCategoriesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = new MediaCategory
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
            var model = new EditMediaCategoriesViewModel
            {
                Id = category.ID,
                Name = category.Name
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditMediaCategoriesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = new MediaCategory
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
