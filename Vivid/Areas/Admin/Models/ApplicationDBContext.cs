using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vivid.Areas.Admin.Models
{
    public class ApplicationDBContext:IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Award> Awards { get; set; }

    }
}
