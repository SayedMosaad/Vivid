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
    public class ProjectsController : Controller
    {
        private readonly IApplicationRepository<Category> categoryRepository;
        private readonly IApplicationRepository<Project> projectRepository;

        public ProjectsController(IApplicationRepository<Category> CategoryRepository,IApplicationRepository<Project> ProjectRepository)
        {
            categoryRepository = CategoryRepository;
            projectRepository = ProjectRepository;
        }
        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                Categories=categoryRepository.List().ToList(),
                Projects=projectRepository.List().ToList()
            };
            return View(model);
        }

        public IActionResult ProjectDetails(int id)
        {
            var model = new IndexViewModel
            {
                Project = projectRepository.Find(id)
            };
            return View(model);
        }
    }
}
