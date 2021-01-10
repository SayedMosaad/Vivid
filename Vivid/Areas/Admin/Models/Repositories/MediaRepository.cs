using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public class MediaRepository : IApplicationRepository<Media>
    {
        private readonly ApplicationDBContext db;

        public MediaRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Media entity)
        {
            db.Medias.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var Media = Find(id);
            db.Medias.Remove(Media);
            db.SaveChanges();
        }

        public Media Find(int id)
        {
            return db.Medias.Include(m=>m.MediaCategory).FirstOrDefault(m => m.ID == id);
        }

        public IList<Media> List()
        {
            return db.Medias.Include(m => m.MediaCategory).ToList();
        }

        public void Update(int id, Media entity)
        {
            var media = Find(id);
            media.Name = entity.Name;
            media.Image = entity.Image;
            media.MediaCategory = entity.MediaCategory;
            db.SaveChanges();
        }
    }
}
