using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    class SemesterDao : AbstractDao<Semester>, ICrudDao<Semester>
    {
        protected override DbSet<Semester> GetDbSet(TrackerContext trackerContext)
        {
            return trackerContext.Semesters;
        }
    }
}
