using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public class RequestRepository : IApplicationRepository<Request>
    {
        private readonly ApplicationDBContext db;

        public RequestRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Request entity)
        {
            db.Requests.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var request = Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
        }

        public Request Find(int id)
        {
            return db.Requests.FirstOrDefault(m => m.ID == id);
        }

        public IList<Request> List()
        {
            return db.Requests.ToList();
        }

        public void Update(int id, Request entity)
        {
            var request = Find(id);
            request.Name = entity.Name;
            request.Email = entity.Email;
            request.Subject = entity.Subject;
            request.Message = entity.Message;
            db.SaveChanges();
        }
    }
}
