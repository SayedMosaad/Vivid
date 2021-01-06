using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivid.Areas.Admin.Models.Repositories;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Vivid.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly IApplicationRepository<Team> repository;
        private readonly IHostingEnvironment hosting;

        public TeamController(IApplicationRepository<Team> repository,IHostingEnvironment hosting)
        {
            this.repository = repository;
            this.hosting = hosting;
        }
        
        public ActionResult Index()
        {
            return View(repository.List());
        }

        
        public ActionResult Details(int id)
        {
            var team = repository.Find(id);
            if(team==null)
            {
                return NotFound();
            }
            return View(team);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTeamViewModel model)
        {
            try
            {
                string FileName = UploadFile(model.File) ?? string.Empty;
                if(ModelState.IsValid)
                {
                    var team = new Team
                    {
                        Name=model.Name,
                        Job=model.Job,
                        Bio=model.Bio,
                        Image=FileName,
                        Facebook=model.Facebook,
                        Twitter=model.Twitter,
                        Instagram=model.Instagram
                    };
                    repository.Add(team);
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
            var team = repository.Find(id);
            var model = new EditTeamViewModel
            {
                Id =team.ID,
                Name=team.Name,
                Job=team.Job,
                Bio=team.Bio,
                ImageUrl=team.Image,
                Facebook=team.Facebook,
                Twitter=team.Twitter,
                Instagram=team.Instagram
            };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditTeamViewModel Model)
        {
            try
            {
                string FileName = UploadFile(Model.File, Model.ImageUrl);
                if(ModelState.IsValid)
                {
                    var team = new Team
                    {
                        Name = Model.Name,
                        Job = Model.Job,
                        Bio = Model.Bio,
                        Image = FileName,
                        Facebook = Model.Facebook,
                        Twitter = Model.Twitter,
                        Instagram = Model.Instagram
                    };
                    repository.Update(Model.Id, team);
                    return RedirectToAction("index");
                }
                return View(Model);
            }
            catch
            {
                return View(Model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var team = repository.Find(id);
            if(team==null)
            {
                return NotFound();
            }
            return View(team);
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
                string uploads = Path.Combine(hosting.WebRootPath, "images/team");
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
                string uploads = Path.Combine(hosting.WebRootPath, "images/team");
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
