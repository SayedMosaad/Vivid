using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivid.Areas.Admin.Models;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public class AwardsRepository : IApplicationRepository<Award>
    {
        private readonly ApplicationDBContext db;

        public AwardsRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Award entity)
        {
            db.Awards.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var award = Find(id);
            db.Awards.Remove(award);
            db.SaveChanges();
        }

        public Award Find(int id)
        {
            var award = db.Awards.FirstOrDefault(m => m.ID == id);
            return award;
        }

        public IList<Award> List()
        {
            return db.Awards.ToList();
        }

        public void Update(int id, Award entity)
        {
            var award = Find(id);
            award.Image = entity.Image;
            award.Name = entity.Name;
            db.SaveChanges();
        }
    }
}
