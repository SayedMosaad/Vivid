using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models.Repositories
{
    public class ProfileRepository : IApplicationRepository<Profile>
    {
        private readonly ApplicationDBContext db;

        public ProfileRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Profile entity)
        {
            db.Profile.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var profile = Find(id);
        }

        public Profile Find(int id)
        {
            var Profile=db.Profile.FirstOrDefault(m => m.ID == id);
            return Profile;
        }

        public IList<Profile> List()
        {
            return db.Profile.ToList();
        }

        public void Update(int id, Profile entity)
        {
            var profile = Find(id);
            profile.AboutUs = entity.AboutUs;
            profile.Image1 = entity.Image1;
            profile.Image2 = entity.Image2;
            profile.Image3 = entity.Image3;
            profile.Vission = entity.Vission;
            profile.Mission = entity.Mission;
            profile.Plan1 = entity.Plan1;
            profile.Plan2 = entity.Plan2;
            profile.Address1 = entity.Address1;
            profile.Address2 = entity.Address2;
            profile.Address3 = entity.Address3;
            profile.Email = entity.Email;
            profile.Phone = entity.Phone;
            profile.FindUs = entity.FindUs;
            profile.UniqueProject = entity.UniqueProject;
            profile.Parts = entity.Parts;
            profile.Achivements = entity.Achivements;
            profile.Countries = entity.Countries;
            profile.ProjectInProgress = entity.ProjectInProgress;
            db.SaveChanges();
        }
    }
}
