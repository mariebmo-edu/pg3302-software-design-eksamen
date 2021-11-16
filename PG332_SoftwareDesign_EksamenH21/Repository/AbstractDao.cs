using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public abstract class AbstractDao<TModel> : ICrudDao<TModel> where TModel : class
    {
        public void Update(TModel m)
        {
            using TrackerContext trackerContext = new TrackerContext();
            trackerContext.Update(m);
            trackerContext.SaveChanges();
        }

        public void Save(TModel m)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Add(m);
            trackerContext.SaveChanges();
        }

        public TModel RetrieveById(long id)
        {
            using TrackerContext trackerContext = new();
            return RetrieveDbSet(trackerContext).Find(id);
        }

        protected abstract DbSet<TModel> RetrieveDbSet(TrackerContext trackerContext);
        
        public List<TModel> ListAll()
        {
            using TrackerContext trackerContext = new();
            return RetrieveDbSet(trackerContext).ToList();
        }

        public void Delete(long id)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Remove(RetrieveDbSet(trackerContext).Find(id));
            trackerContext.SaveChanges();
        }

        public TModel RetrieveOneByField(Func<TModel, bool> predicate)
        {
            using TrackerContext trackerContext = new();
            return RetrieveDbSet(trackerContext).FirstOrDefault(predicate);
        }
    }
}