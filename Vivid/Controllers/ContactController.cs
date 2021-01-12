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
    public class ContactController : Controller
    {
        private readonly IApplicationRepository<Request> requestRepository;

        public ContactController(IApplicationRepository<Request> requestRepository)
        {
            this.requestRepository = requestRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = new Request
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
                };
                requestRepository.Add(request);
                return View("Confirmation");
            }
            return View(model);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
