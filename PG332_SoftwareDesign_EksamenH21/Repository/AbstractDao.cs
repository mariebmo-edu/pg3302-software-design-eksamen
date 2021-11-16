using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public abstract class AbstractDao<T> : ICrudDao<T> where T : class
    {
        public void Update(T m)
        {
            using TrackerContext trackerContext = new TrackerContext();
            trackerContext.Update(m);
            trackerContext.SaveChanges();
        }

        public void Save(T m)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Add(m);
            trackerContext.SaveChanges();
        }

        public T RetrieveById(long id)
        {
            using TrackerContext trackerContext = new();
            return GetDbSet(trackerContext).Find(id);
        }

        public abstract DbSet<T> GetDbSet(TrackerContext trackerContext);
        
        public List<T> ListAll()
        {
            using TrackerContext trackerContext = new();
            return GetDbSet(trackerContext).ToList();
        }

        public void Delete(long id)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Remove(GetDbSet(trackerContext).Find(id));
            trackerContext.SaveChanges();
        }

        public T RetrieveOneByField(Func<T, bool> predicate)
        {
            using TrackerContext trackerContext = new();
            return GetDbSet(trackerContext).FirstOrDefault(predicate);
        }
    }
}