using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public class CategoryRepository : IApplicationRepository<Category>
    {
        private readonly ApplicationDBContext db;

        public CategoryRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public Category Find(int id)
        {
            var category = db.Categories.FirstOrDefault(m => m.ID == id);
            return category;
        }

        public IList<Category> List()
        {
            return db.Categories.ToList();
        }

        public void Update(int id, Category entity)
        {
            var category = Find(id);
            category.Name = entity.Name;
            db.SaveChanges();
        }
    }
}
