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
    public class BlogsController : Controller
    {
        private readonly IApplicationRepository<Blog> blogRepository;

        public BlogsController(IApplicationRepository<Blog> BlogRepository)
        {
            blogRepository = BlogRepository;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                Blogs = blogRepository.List().ToList()
            };
            return View(model);
        }
        public IActionResult BlogDetails(int id)
        {
            var model = new IndexViewModel
            {
                Blog = blogRepository.Find(id)
            };
            return View(model);
        }
    }
}
