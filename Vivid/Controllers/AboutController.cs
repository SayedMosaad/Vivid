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

    public class AboutController : Controller
    {
        private readonly IApplicationRepository<Profile> profileRepository;
        private readonly IApplicationRepository<Team> TeamRepository;
        private readonly IApplicationRepository<Award> awardRepository;

        public AboutController(IApplicationRepository<Profile> ProfileRepository,
                                IApplicationRepository<Team> TeamRepository,
                                IApplicationRepository<Award> AwardRepository)
        {
            profileRepository = ProfileRepository;
            this.TeamRepository = TeamRepository;
            awardRepository = AwardRepository;
        }
        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                Profiles = profileRepository.List().ToList(),
                Team = TeamRepository.List().ToList(),
                Awards=awardRepository.List().ToList()
            };
            return View(model);
        }
    }
}
