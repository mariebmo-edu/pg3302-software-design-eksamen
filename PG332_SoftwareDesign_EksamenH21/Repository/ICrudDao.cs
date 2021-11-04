using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public interface ICrudDao<TModel>
    {
        void Update(TModel m)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Update(m);
            trackerContext.SaveChanges();
        }

        void Save(TModel m)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Add(m);
            trackerContext.SaveChanges();
        }

        TModel RetrieveById(long id);
        List<TModel> ListAll();
        void Delete(long id);
        TModel RetrieveOneByField(Func<TModel, bool> predicate);
    }
}
