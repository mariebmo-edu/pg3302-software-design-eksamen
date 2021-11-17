using Microsoft.EntityFrameworkCore;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    // https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
    public class TrackerContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TaskSet> TaskSets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Semester> Semesters { get; set; }

        public string DbPath { get; private set; }

        public TrackerContext()
        {
            DbPath = $"{ConfigFile.programFilesDir}tracker.db";
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}