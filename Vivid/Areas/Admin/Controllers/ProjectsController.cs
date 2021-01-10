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
    public class ProjectsController : Controller
    {
        private readonly IApplicationRepository<Project> repository;
        private readonly IApplicationRepository<Category> categoryRepository;
        private readonly IPhotoRepository photoRepository;
        private readonly IHostingEnvironment hosting;

        public ProjectsController(IApplicationRepository<Project> repository,
                                    IApplicationRepository<Category> CategoryRepository,
                                    IPhotoRepository photoRepository,
                                    IHostingEnvironment hosting)
        {
            this.repository = repository;
            categoryRepository = CategoryRepository;
            this.photoRepository = photoRepository;
            this.hosting = hosting;
        }
        // GET: ProjectsController
        public ActionResult Index()
        {

            return View(repository.List());
        }

        // GET: ProjectsController/Details/5
        public ActionResult Details(int id)
        {
            var project = repository.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: ProjectsController/Create
        public ActionResult Create()
        {
            CreateProjectViewModel model = new CreateProjectViewModel
            {
                Categories = FillCategory()
            };
            return View(model);
        }

        // POST: ProjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProjectViewModel model)
        {
            try
            {
                string Coverfile = UploadFile(model.CoverFile);
                string ConceptFile = UploadFile(model.ConceptFile);
                string planningFile = UploadFile(model.PlanningFile);
                string realizationFile = UploadFile(model.RealizationFile);
                if (ModelState.IsValid)
                {
                    if (model.CategoryId == -1)
                    {
                        ModelState.AddModelError("", "Please select the Category");
                        return View(GetAllCategories());
                    }
                    var Category = categoryRepository.Find(model.CategoryId);
                    var Project = new Project
                    {
                        Name = model.Name,
                        Photographer = model.Photographer,
                        Description = model.Description,
                        Location = model.Location,
                        Area = model.Area,
                        Team = model.Team,
                        CoverPhoto = Coverfile,
                        Concepts = model.Concepts,
                        ConceptPhoto = ConceptFile,
                        Planning = model.Planning,
                        PlanningPhoto = planningFile,
                        Realizatiion = model.Realizatiion,
                        RealizationPhoto = realizationFile,
                        Category = Category
                    };
                    repository.Add(Project);
                    return RedirectToAction("index");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id)
        {
            var project = repository.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            var categoryId = project.CategoryId;
            var model = new EditProjectViewModel
            {
                Id = project.ID,
                Name = project.Name,
                Description = project.Description,
                Location = project.Location,
                Photographer = project.Photographer,
                Area = project.Area,
                Date = project.Date,
                Team = project.Team,
                CoverImageUrl = project.CoverPhoto,
                ConceptImageUrl = project.ConceptPhoto,
                Concepts = project.Concepts,
                Planning = project.Planning,
                PlanningImageUrl = project.PlanningPhoto,
                Realizatiion = project.Realizatiion,
                RealiztionImageUrl = project.RealizationPhoto,
                CategoryId = categoryId,
                Categories = FillCategory()
            };
            return View(model);
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditProjectViewModel model)
        {
            try
            {
                string Coverfile = UploadFile(model.CoverFile);
                string ConceptFile = UploadFile(model.ConceptFile);
                string planningFile = UploadFile(model.PlanningFile);
                string realizationFile = UploadFile(model.RealizationFile);
                if (ModelState.IsValid)
                {
                    var category = categoryRepository.Find(model.CategoryId);
                    if (model.CategoryId == -1)
                    {
                        ModelState.AddModelError("", "Please select the Category");
                        return View(GetAllCategories());
                    }
                    var project = new Project
                    {

                        Name = model.Name,
                        Description = model.Description,
                        Location = model.Location,
                        Photographer = model.Photographer,
                        Area = model.Area,
                        Date = model.Date,
                        Team = model.Team,
                        CoverPhoto = Coverfile,
                        ConceptPhoto = ConceptFile,
                        Concepts = model.Concepts,
                        Planning = model.Planning,
                        PlanningPhoto = planningFile,
                        Realizatiion = model.Realizatiion,
                        RealizationPhoto = realizationFile,
                        Category = category
                    };
                    repository.Update(model.Id, project);
                    model.Categories = FillCategory();
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
            var project = repository.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var images = photoRepository.GetImages(id);
            foreach(var item in images)
            {
                photoRepository.Delete(item.ID);
            }
            repository.Delete(id);
            
            

            return RedirectToAction("index");
        }

        List<Category> FillCategory()
        {
            var categories = categoryRepository.List().ToList();
            categories.Insert(0, new Category { ID = -1, Name = "---- Select Project Category ----" });
            return categories;
        }

        // if the client didn't select or select -1 value and submit the form then the form will return back
        // so we need to send the view model again with the categories
        CreateProjectViewModel GetAllCategories()
        {
            CreateProjectViewModel model = new CreateProjectViewModel
            {
                Categories = FillCategory()
            };
            return model;
        }

        string UploadFile(IFormFile File)
        {
            if (File != null)
            {
                string Uploads = Path.Combine(hosting.WebRootPath, "images/project");
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
                string Uploads = Path.Combine(hosting.WebRootPath, "images/project");
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
