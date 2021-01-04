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
    public class SliderController : Controller
    {
        private readonly IApplicationRepository<Slider> repository;
        private readonly IHostingEnvironment hosting;

        public SliderController(IApplicationRepository<Slider> repository, IHostingEnvironment hosting)
        {
            this.repository = repository;
            this.hosting = hosting;
        }
        public IActionResult Index()
        {
            var sliders = repository.List();
            return View(sliders);
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            var slider = repository.Find(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSliderViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File) ?? string.Empty;
                if (ModelState.IsValid)
                {
                    var slider = new Slider
                    {
                        Title = model.Title,
                        Photo = FileName
                    };
                    repository.Add(slider);
                    return RedirectToAction("Index", "Slider");
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
            var slider = repository.Find(id);
            if (slider == null)
            {
                return NotFound();
            }
            var ViewModel = new EditSliderViewModel
            {
                Id = slider.ID,
                Title = slider.Title,
                ImageUrl=slider.Photo
            };
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditSliderViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File, model.ImageUrl);
                if (ModelState.IsValid)
                {
                    Slider slider = new Slider
                    {
                        Title = model.Title,
                        Photo = FileName
                    };
                    repository.Update(model.Id, slider);
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
            var slider = repository.Find(id);
            return View(slider);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(repository.Find(id));
            }
        }
        string UploadFile(IFormFile file)
        {
            //check if there is a file or not coming from the view
            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "images/slider");
                string filename = file.FileName;
                string fullpath = Path.Combine(uploads, filename);
                file.CopyTo(new FileStream(fullpath, FileMode.Create));
                return file.FileName;
            }
            return null;
        }

        string UploadFile(IFormFile file, string ImageUrl)
        {
            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "images/slider");
                string FileName = file.FileName;
                string newpath = Path.Combine(uploads, FileName);
                string OldFileName = ImageUrl;
                string oldpath = Path.Combine(uploads, OldFileName);
                if (newpath != oldpath)
                {
                    System.IO.File.Delete(oldpath);
                    file.CopyTo(new FileStream(newpath, FileMode.Create));
                }
                return file.FileName;
            }
            return ImageUrl;
        }
    }
}
