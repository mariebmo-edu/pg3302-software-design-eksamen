using System;
using Microsoft.EntityFrameworkCore;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    // https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
    public class TrackerContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TaskSet> TaskSets { get; set; }
        public string DbPath { get; private set; }

        public TrackerContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}tracker.db";
        }
        
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}