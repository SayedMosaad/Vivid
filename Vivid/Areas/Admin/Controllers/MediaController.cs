using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.Models.Repositories;
using Vivid.Areas.Admin.ViewModels;

namespace Vivid.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MediaController : Controller
    {
        private readonly IApplicationRepository<Media> repository;
        private readonly IApplicationRepository<MediaCategory> categoryRepository;
        private readonly IHostingEnvironment hosting;

        public MediaController(IApplicationRepository<Media> repository, IApplicationRepository<MediaCategory> CategoryRepository
            ,IHostingEnvironment hosting)
        {
            this.repository = repository;
            categoryRepository = CategoryRepository;
            this.hosting = hosting;
        }
        
        public ActionResult Index()
        {
            return View(repository.List());
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateMediaViewModel
            {
                Categories = FillCategory()
            };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMediaViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File) ?? string.Empty;
                if (ModelState.IsValid)
                {
                    if(model.CategoryId==-1)
                    {
                        ModelState.AddModelError("", "Please review the input fields");
                        return View(GetAllCategories());
                    }
                    var Category = categoryRepository.Find(model.CategoryId);
                    var media = new Media
                    {
                        Name=model.Name,
                        Image=FileName,
                        MediaCategory=Category
                    };
                    repository.Add(media);
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
        public ActionResult Edit(int id)
        {
            var category = repository.Find(id);
            if(category==null)
            {
                return NotFound();
            }
            var model = new EditMediaViewModel
            {
                Id=category.ID,
                Name=category.Name,
                ImageUrl=category.Image,
                CategoryId=category.MediaCategoryId,
                Categories=FillCategory()
            };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditMediaViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File, model.ImageUrl);
                if(ModelState.IsValid)
                {
                    var category = categoryRepository.Find(model.CategoryId);
                    if (model.CategoryId == -1)
                    {
                        ModelState.AddModelError("", "Please select the Category");
                        return View(GetAllCategories());
                    }
                    var media = new Media
                    {
                        Name=model.Name,
                        Image=FileName,
                        MediaCategory=category
                    };
                    repository.Update(model.Id, media);
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
        public ActionResult Delete(int id)
        {
            var media = repository.Find(id);
            if(media==null)
            {
                return NotFound();
            }
            return View(media);
        }

        // POST: MediaController/Delete/5
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


        List<MediaCategory> FillCategory()
        {
            var categories = categoryRepository.List().ToList();
            categories.Insert(0, new MediaCategory { ID = -1, Name = "---- Select Category ----" });
            return categories;
        }

        // if the client didn't select or select -1 value and submit the form then the form will return back
        // so we need to send the view model again with the categories
        CreateMediaViewModel GetAllCategories()
        {
            CreateMediaViewModel model = new CreateMediaViewModel
            {
                Categories = FillCategory()
            };
            return model;
        }

        string UploadFile(IFormFile File)
        {
            if (File != null)
            {
                string Uploads = Path.Combine(hosting.WebRootPath, "images/media");
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
                string Uploads = Path.Combine(hosting.WebRootPath, "images/media");
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
