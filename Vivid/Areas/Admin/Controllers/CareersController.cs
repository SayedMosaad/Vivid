using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.Models.Repositories;
using Vivid.Areas.Admin.ViewModels;

namespace Vivid.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CareersController : Controller
    {
        private readonly IApplicationRepository<Career> repository;

        public CareersController(IApplicationRepository<Career> repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.List());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var career = repository.Find(id);
            if(career==null)
            {
                return NotFound();
            }
            return View(career);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCareerViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var career = new Career
                    {
                        Title=model.Title,
                        Location=model.Location,
                        Specification=model.Specification,
                        Responsibilities=model.Responsibilities
                    };
                    repository.Add(career);
                    return RedirectToAction("Index");
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
            var career = repository.Find(id);
            if(career==null)
            {
                return NotFound();
            }
            var model = new EditCareerViewModel
            {
                Id=career.ID,
                Title=career.Title,
                Location=career.Location,
                Specification=career.Specification,
                Responsibilities=career.Responsibilities
            };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCareerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var career = new Career
                    {
                        Title = model.Title,
                        Location = model.Location,
                        Specification = model.Specification,
                        Responsibilities = model.Responsibilities
                    };
                    repository.Update(model.Id,career);
                    return RedirectToAction("Index");
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
            var career = repository.Find(id);
            if(career==null)
            {
                return NotFound();
            }
            return View(career);
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
