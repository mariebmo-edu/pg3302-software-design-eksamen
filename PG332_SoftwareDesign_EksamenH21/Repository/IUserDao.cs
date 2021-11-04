using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    interface IUserDao<TModel> : ICrudDao<TModel>
    {
        public TModel RetrieveByEmail(string email);
        public TModel RetrieveByLastName(string lastName);

    }
}
