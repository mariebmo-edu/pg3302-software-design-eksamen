using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    class CourseDao : ICrudDao<Course>
    {
        public void Update(Course m)
        {
            using TrackerContext trackerContext = new TrackerContext();
            trackerContext.Courses.Update(m);
            trackerContext.SaveChanges();
        }

        public void Save(Course m)
        {
            using TrackerContext trackerContext = new TrackerContext();
            trackerContext.Add(m);
            trackerContext.SaveChanges();
        }

        public Course RetrieveById(long id)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Courses.Find(id);
        }

        public List<Course> ListAll()
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Courses.ToList();
        }

        public void Delete(long id)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Remove(trackerContext.Courses.Find(id));
            trackerContext.SaveChanges();
        }


        public Course RetrieveOneByField(Func<Course, bool> predicate)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Courses.FirstOrDefault(predicate);
        }
    }
}
