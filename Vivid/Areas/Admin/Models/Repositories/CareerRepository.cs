using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public class CareerRepository : IApplicationRepository<Career>
    {
        private readonly ApplicationDBContext db;

        public CareerRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Career entity)
        {
            db.Careers.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var career = Find(id);
            db.Careers.Remove(career);
            db.SaveChanges();
        }

        public Career Find(int id)
        {
            return db.Careers.FirstOrDefault(m => m.ID == id);
        }

        public IList<Career> List()
        {
            return db.Careers.ToList();
        }

        public void Update(int id, Career entity)
        {
            var career = Find(id);
            career.Title = entity.Title;
            career.Location = entity.Location;
            career.Specification = entity.Specification;
            career.Responsibilities = entity.Responsibilities;
            db.SaveChanges();
        }
    }
}
