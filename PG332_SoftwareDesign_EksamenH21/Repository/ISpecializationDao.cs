using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    interface ISpecializationDao : ICrudDao<Specialization>
    {
        public Specialization RetrieveByName(string name);
        public Specialization RetrieveByCode(string code);
    }
}
