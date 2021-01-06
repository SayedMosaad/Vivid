using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public interface IPhotoRepository : IApplicationRepository<Photo>
    {
        public IList<Photo> GetImages(int id);
    }

    public class PhotosRepository : IPhotoRepository
    {
        private readonly ApplicationDBContext db;

        public PhotosRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Photo entity)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var photo = Find(id);
            db.Photos.Remove(photo);
            db.SaveChanges();
        }

        public Photo Find(int id)
        {
            var photo = db.Photos.Include(a => a.Project).FirstOrDefault(m => m.ID == id);
            return photo;
        }

        public IList<Photo> GetImages(int id)
        {
            var images = db.Photos.Where(m => m.ProjectId == id).ToList();
            return images;
        }

        public IList<Photo> List()
        {
            return db.Photos.Include(a => a.Project).ToList();
        }

        public void Update(int id, Photo entity)
        {
            var photo = Find(id);
            photo.Image = entity.Image;
            photo.Project = entity.Project;
            db.SaveChanges();
        }
    }
}