﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    class CourseDao : AbstractDao<Course>, ICourseDao
    {
        
        public override DbSet<Course> GetDbSet(TrackerContext trackerContext)
        {
            return trackerContext.Courses;
        }
        
        public List<Course> RetrieveCourseBySemesterIdAndUser(long semesterId, long userId)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Courses.Where(c => c.SemesterId == semesterId && c.UserId == userId).ToList();
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
    }
}
