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
    public class ImagesController : Controller
    {
        private readonly IPhotoRepository PhotoRepository;
        private readonly IApplicationRepository<Project> projectRepository;
        private readonly IHostingEnvironment hosting;

        public ImagesController(IPhotoRepository PhotoRepository, IApplicationRepository<Project> projectRepository, IHostingEnvironment hosting)
        {
            this.PhotoRepository = PhotoRepository;
            this.projectRepository = projectRepository;
            this.hosting = hosting;
        }

        public ActionResult Index()
        {
            var projects = projectRepository.List();
            return View(projects);
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {

            var model = new CreatePhotosViewModel
            {
                Projects = FillProjects()
            };
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePhotosViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File) ?? string.Empty;
                if (ModelState.IsValid)
                {
                    if (model.ProjectId == -1)
                    {
                        ModelState.AddModelError("", "please review the input fileds");
                        return View(GetAllProjects());
                    }
                    var projects = projectRepository.Find(model.ProjectId);
                    var photo = new Photo
                    {
                        Image = FileName,
                        Project = projects
                    };
                    PhotoRepository.Add(photo);
                    return RedirectToAction("index");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        List<Project> FillProjects()
        {
            var projects = projectRepository.List().ToList();
            projects.Insert(0, new Project { ID = -1, Name = "---- Please Select Project ----" });
            return projects;
        }
        CreatePhotosViewModel GetAllProjects()
        {
            var model = new CreatePhotosViewModel
            {
                Projects = FillProjects()
            };
            return model;
        }

        public ActionResult GetImages(int id)
        {
            List<Photo> photos = PhotoRepository.GetImages(id).ToList();
            return View(photos);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var image = PhotoRepository.Find(id);
            if (image == null)
            {
                return NotFound();
            }

            var projectid = image.Project == null ? image.Project.ID = 0 : image.Project.ID;
            var model = new EditPhotosViewModel
            {
                Id = image.ID,
                ImageUrl = image.Image,
                ProjectId = projectid,
                Projects = FillProjects()
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditPhotosViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File, model.ImageUrl);
                if (ModelState.IsValid)
                {
                    var Projects = projectRepository.Find(model.ProjectId);
                    if (Projects == null)
                    {
                        ModelState.AddModelError("", "please review the input fileds");
                        return View(GetAllProjects());
                    }
                    var photo = new Photo
                    {
                        Image = FileName,
                        Project = Projects
                    };
                    PhotoRepository.Update(model.Id, photo);
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
            var photo = PhotoRepository.Find(id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                PhotoRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        string UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "images/project");
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
                string uploads = Path.Combine(hosting.WebRootPath, "images/project");
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
