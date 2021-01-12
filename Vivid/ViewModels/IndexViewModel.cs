using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivid.Areas.Admin.Models;
namespace Vivid.ViewModels
{
    public class IndexViewModel
    {
        public List<Profile> Profiles { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Category> Categories { get; set; }
        public List<Project> Projects { get; set; }
        public Project Project { get; set; }
        public List<Career> Careers { get; set; }
        public List<Team> Team { get; set; }
        public List<Award> Awards { get; set; }
        public List<MediaCategory> MediaCategories { get; set; }
        public List<Media> Medias { get; set; }
        public List<Blog> Blogs { get; set; }
        public Blog Blog { get; set; }

    }
}
