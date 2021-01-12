using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.Models.Repositories;
using Vivid.ViewModels;
namespace Vivid.Controllers
{
    public class MediaController : Controller
    {
        private readonly IApplicationRepository<MediaCategory> repository;
        private readonly IApplicationRepository<Media> mediaRepository;

        public MediaController(IApplicationRepository<MediaCategory> repository,IApplicationRepository<Media> MediaRepository)
        {
            this.repository = repository;
            mediaRepository = MediaRepository;
        }
        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                MediaCategories=repository.List().ToList(),
                Medias=mediaRepository.List().ToList()
            };
            return View(model);
        }
    }
}
