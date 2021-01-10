using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivid.Areas.Admin.Models;
using Vivid.Areas.Admin.Models.Repositories;
using Vivid.Areas.Admin.ViewModels;

namespace Vivid.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RequestsController : Controller
    {
        private readonly IApplicationRepository<Request> repository;

        public RequestsController(IApplicationRepository<Request> repository)
        {
            this.repository = repository;
        }
        // GET: RequestsController
        public ActionResult Index(int PageNumber = 1)
        {
            int PageSize = 6;
            int excludeRecord = (PageSize * PageNumber) - PageSize;
            var requests = repository.List().Skip(excludeRecord).Take(PageSize);

            var r = repository.List();
            var result = new PagedResult<Request>
            {
                Data = requests.ToList(),
                TotalItems = repository.List().Count(),
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            return View(result);
        }

        // GET: RequestsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequestsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: RequestsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: RequestsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestsController/Delete/5
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
    }
}
