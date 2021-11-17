using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    class SemesterDao : AbstractDao<Semester>, ISemesterDao
    {
        protected override DbSet<Semester> RetrieveDbSet(TrackerContext trackerContext)
        {
            return trackerContext.Semesters;
        }

        public long GetSemesterIdByUserIdAndSemesterEnum(long id, SemesterEnum semester)
        {
            using TrackerContext trackerContext = new();

            return trackerContext.Semesters.Where(s => s.User.UserId == id && s.SemesterEnum == semester).ToList()[0].Id;
        }
    }
}
