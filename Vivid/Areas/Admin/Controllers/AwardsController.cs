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
    public class AwardsController : Controller
    {
        private readonly IApplicationRepository<Award> repository;
        private readonly IHostingEnvironment hosting;

        public AwardsController(IApplicationRepository<Award> repository,IHostingEnvironment hosting)
        {
            this.repository = repository;
            this.hosting = hosting;
        }
        // GET: AwardsController
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
        public ActionResult Create(CreateAwardViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File) ?? string.Empty;
                if(ModelState.IsValid)
                {
                    var award = new Award
                    {
                        Name = model.Name,
                        Image = FileName
                    };
                    repository.Add(award);
                    return RedirectToAction("index");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        
        public ActionResult Edit(int id)
        {
            var award = repository.Find(id);
            if(award==null)
            {
                return NotFound();
            }
            var model = new EditAwardViewModel
            {
                Id = award.ID,
                Name = award.Name,
                ImageUrl = award.Image
            };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditAwardViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File, model.ImageUrl);
                if(ModelState.IsValid)
                {
                    var award = new Award
                    {
                        Name=model.Name,
                        Image=FileName
                    };
                    repository.Update(model.Id, award);
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
            var award = repository.Find(id);
            return View(award);
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

        string UploadFile(IFormFile file)
        {
            //check if there is a file or not coming from the view
            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "images/awards");
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
                string uploads = Path.Combine(hosting.WebRootPath, "images/awards");
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
