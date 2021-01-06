using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public class ProjectRepository : IApplicationRepository<Project>
    {
        private readonly ApplicationDBContext db;

        public ProjectRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Project entity)
        {
            db.Projects.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
        }

        public Project Find(int id)
        {
            return db.Projects.Include(m=>m.Category).Include(m => m.Photos).FirstOrDefault(p => p.ID == id);
        }

        public IList<Project> List()
        {
            return db.Projects.Include(m => m.Category).Include(m=>m.Photos).ToList();
        }

        public void Update(int id, Project entity)
        {
            var project = Find(id);
            project.Name = entity.Name;
            project.Description = entity.Description;
            project.Photographer = entity.Photographer;
            project.Location = entity.Location;
            project.Area = entity.Area;
            project.Date = entity.Date;
            project.Team = entity.Team;
            project.ConceptPhoto = entity.ConceptPhoto;
            project.Concepts = entity.Concepts;
            project.ConceptPhoto = entity.ConceptPhoto;
            project.Planning = entity.Planning;
            project.PlanningPhoto = entity.PlanningPhoto;
            project.Realizatiion = entity.Realizatiion;
            project.RealizationPhoto = entity.RealizationPhoto;
            project.Category = entity.Category;
            db.SaveChanges();
        }
    }
}