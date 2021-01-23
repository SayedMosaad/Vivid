using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.ViewModels;
using Vivid.Areas.Admin.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Vivid.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly IApplicationRepository<Category> repository;
        private readonly IHostingEnvironment hosting;

        public CategoriesController(IApplicationRepository<Category> repository,  IHostingEnvironment hosting)
        {
            this.repository = repository;
            this.hosting = hosting;
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
                string FileName = UploadFile(model.File) ?? string.Empty;
                if (ModelState.IsValid)
                {
                    var category = new Category
                    {
                        Name = model.Name,
                        Image=FileName
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
                Name = category.Name,
                ImageUrl=category.Image
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCategoryViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File, model.ImageUrl);
                if (ModelState.IsValid)
                {
                    var category = new Category
                    {
                        Name = model.Name,
                        Image=FileName
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
        string UploadFile(IFormFile File)
        {
            if (File != null)
            {
                string Uploads = Path.Combine(hosting.WebRootPath, "images/categories");
                string FileName = File.FileName;
                string FullPath = Path.Combine(Uploads, FileName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
                return File.FileName;
            }
            return null;
        }

        string UploadFile(IFormFile File, string ImageUrl)
        {
            if (File != null)
            {
                string Uploads = Path.Combine(hosting.WebRootPath, "images/categories");
                string FileName = File.FileName;
                string NewPath = Path.Combine(Uploads, FileName);
                string OldFileName = ImageUrl;
                string OldPath = Path.Combine(Uploads, OldFileName);
                if (NewPath != OldPath)
                {
                    System.IO.File.Delete(OldPath);
                    File.CopyTo(new FileStream(NewPath, FileMode.Create));
                }
                return File.FileName;
            }
            return ImageUrl;
        }
    }
}
