using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    class CourseDao : AbstractDao<Course>, ICourseDao
    {
        
        protected override DbSet<Course> RetrieveDbSet(TrackerContext trackerContext)
        {
            return trackerContext.Courses;
        }
        
        public Course RetrieveOneByField(Func<Course, bool> predicate)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Courses.FirstOrDefault(predicate);
        }

        public Course retrieveByCode(string code)
        {
            return RetrieveOneByField(c => c.CourseCode == code);
        }

        public List<Course> RetrieveCoursesBySemesterId(long id)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Courses.Where(c => c.SemesterId ==  id).ToList();
        }
    }
}
