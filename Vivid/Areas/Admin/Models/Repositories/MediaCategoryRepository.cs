using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public class MediaCategoryRepository : IApplicationRepository<MediaCategory>
    {
        private readonly ApplicationDBContext db;

        public MediaCategoryRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(MediaCategory entity)
        {
            db.MediaCategories.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = Find(id);
            db.MediaCategories.Remove(category);
            db.SaveChanges();
        }

        public MediaCategory Find(int id)
        {
            var category = db.MediaCategories.Include(m=>m.Medias).FirstOrDefault(m => m.ID == id);
            return category;
        }

        public IList<MediaCategory> List()
        {
            return db.MediaCategories.Include(m=>m.Medias).ToList();
        }

        public void Update(int id, MediaCategory entity)
        {
            var category = Find(id);
            category.Name = entity.Name;
            db.SaveChanges();
        }
    }
}
