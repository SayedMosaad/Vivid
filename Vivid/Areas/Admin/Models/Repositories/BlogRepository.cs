using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public class BlogRepository : IApplicationRepository<Blog>
    {
        private readonly ApplicationDBContext db;

        public BlogRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Blog entity)
        {
            db.Blogs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var blog = Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
        }

        public Blog Find(int id)
        {
            var blog = db.Blogs.FirstOrDefault(m => m.ID == id);
            return blog;
        }

        public IList<Blog> List()
        {
            return db.Blogs.ToList();
        }

        public void Update(int id, Blog entity)
        {
            var blog = Find(id);
            blog.Title = entity.Title;
            blog.Description = entity.Description;
            blog.Image = entity.Image;
            blog.Body = entity.Body;
            db.SaveChanges();
        }
    }
}
