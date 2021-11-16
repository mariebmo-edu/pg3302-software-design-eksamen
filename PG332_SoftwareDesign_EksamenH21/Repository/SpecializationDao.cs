using Microsoft.EntityFrameworkCore;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public class SpecializationDao : AbstractDao<Specialization>, ISpecializationDao
    {
        protected override DbSet<Specialization> RetrieveDbSet(TrackerContext trackerContext)
        {
            return trackerContext.Specializations;
        }

        public Specialization RetrieveByName(string name)
        {
            return RetrieveOneByField(s => s.Name == name);
        }

        public Specialization RetrieveByCode(string code)
        {
            return RetrieveOneByField(s => s.Code == code);
        }
    }
}
