using System;
using System.Collections.Generic;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public interface ICrudDao<TModel>
    {
        void Update(TModel m);

        void Save(TModel m);

        TModel RetrieveById(int id);
        List<TModel> ListAll();
        void Delete(long id);
        TModel RetrieveOneByField(Func<TModel, bool> predicate);
    }
}