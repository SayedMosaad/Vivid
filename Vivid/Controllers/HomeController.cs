using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vivid.ViewModels;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.Models.Repositories;

namespace Vivid.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationRepository<Profile> profileRepository;
        private readonly IApplicationRepository<Slider> sliderRepository;
        private readonly IApplicationRepository<Category> categoryRepository;
        private readonly IApplicationRepository<Project> projectRepository;
        private readonly IApplicationRepository<Career> careerRepository;

        public HomeController(IApplicationRepository<Profile> ProfileRepository,
                                IApplicationRepository<Slider> SliderRepository,
                                IApplicationRepository<Category> CategoryRepository,
                                IApplicationRepository<Project> ProjectRepository,
                                IApplicationRepository<Career> CareerRepository)
        {
            profileRepository = ProfileRepository;
            sliderRepository = SliderRepository;
            categoryRepository = CategoryRepository;
            projectRepository = ProjectRepository;
            careerRepository = CareerRepository;
        }
        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                Profiles = profileRepository.List().ToList(),
                Sliders = sliderRepository.List().ToList(),
                Categories = categoryRepository.List().ToList(),
                Projects = projectRepository.List().ToList(),
                Careers = careerRepository.List().ToList()
                
            };
            return View(model);
        }
        public IActionResult bigfooter()
        {
            return View();
        }
    }
}
