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
    public class CareerController : Controller
    {
        private readonly IApplicationRepository<Career> careerRepository;

        public CareerController(IApplicationRepository<Career> CareerRepository)
        {
            careerRepository = CareerRepository;
        }
        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                Careers=careerRepository.List().ToList()
            };
            return View(model);
        }
    }
}
