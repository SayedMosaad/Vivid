using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.ViewModels;

namespace Vivid.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IApplicationRepository<Profile> repository;
        private readonly IHostingEnvironment hosting;

        public ProfileController(IApplicationRepository<Profile> repository, IHostingEnvironment hosting)
        {
            this.repository = repository;
            this.hosting = hosting;
        }
        // GET: ProfileController
        public ActionResult Index()
        {
            return View(repository.List());
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            var profile = repository.Find(id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // GET: ProfileController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ProfileController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(CreateProfileViewModel model)
        //{
        //    try
        //    {
        //        string FileName1 = UploadFile(model.File1) ?? string.Empty;
        //        string FileName2 = UploadFile(model.File2) ?? string.Empty;
        //        string FileName3 = UploadFile(model.File3) ?? string.Empty;
        //        if(ModelState.IsValid)
        //        {
        //            var profile = new Profile
        //            {
        //                AboutUs = model.AboutUs,
        //                Image1 = FileName1,
        //                Image2 = FileName2,
        //                Image3 = FileName3,
        //                Vission = model.Vission,
        //                Mission = model.Mission,
        //                Plan1 = model.Plan1,
        //                Plan2 = model.Plan2,
        //                Address1 = model.Address1,
        //                Address2 = model.Address2,
        //                Address3 = model.Address3,
        //                Email = model.Email,
        //                Phone = model.Phone,
        //                FindUs = model.FindUs,
        //                UniqueProject = model.UniqueProject,
        //                Parts = model.Parts,
        //                Achivements = model.Achivements,
        //                Countries = model.Countries,
        //                ProjectInProgress = model.ProjectInProgress
        //            };
        //            repository.Add(profile);
        //            return RedirectToAction("index");
        //        }
        //        return View(model);
        //    }
        //    catch
        //    {
        //        return View(model);
        //    }
        //}

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            var profile = repository.Find(id);
            var model = new EditProfileViewModel
            {
                Id=profile.ID,
                AboutUs = profile.AboutUs,
                image1Url = profile.Image1,
                image2Url = profile.Image2,
                image3Url = profile.Image3,
                Address1 = profile.Address1,
                Address2 = profile.Address2,
                Address3 = profile.Address3,
                Email = profile.Email,
                Phone = profile.Phone,
                Mission = profile.Mission,
                Vission = profile.Vission,
                Plan1 = profile.Plan1,
                Plan2 = profile.Plan2,
                FindUs=profile.FindUs,
                UniqueProject=profile.UniqueProject,
                Parts=profile.Parts,
                Achivements=profile.Achivements,
                Countries=profile.Countries,
                ProjectInProgress=profile.ProjectInProgress
                
            };
            return View(model);
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditProfileViewModel model)
        {
            try
            {
                string FileName1 = UploadFile(model.File1, model.image1Url);
                string FileName2 = UploadFile(model.File2, model.image2Url);
                string FileName3 = UploadFile(model.File3, model.image3Url);
                if(ModelState.IsValid)
                {
                    var profile = new Profile
                    {
                        AboutUs = model.AboutUs,
                        Image1 = FileName1,
                        Image2 = FileName2,
                        Image3 = FileName3,
                        Address1 = model.Address1,
                        Address2 = model.Address2,
                        Address3 = model.Address3,
                        Email = model.Email,
                        Phone = model.Phone,
                        Mission = model.Mission,
                        Vission = model.Vission,
                        Plan1 = model.Plan1,
                        Plan2 = model.Plan2,
                        FindUs = model.FindUs,
                        UniqueProject = model.UniqueProject,
                        Parts = model.Parts,
                        Achivements = model.Achivements,
                        Countries = model.Countries,
                        ProjectInProgress = model.ProjectInProgress
                    };
                    repository.Update(model.Id, profile);
                    return RedirectToAction("index");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
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
                string uploads = Path.Combine(hosting.WebRootPath, "images/about");
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
                string uploads = Path.Combine(hosting.WebRootPath, "images/about");
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
