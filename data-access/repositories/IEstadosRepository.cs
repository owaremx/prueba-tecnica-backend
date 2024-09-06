using data_access.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.repositories
{
    public interface IEstadosRepository
    {
        IEnumerable<Estados> Lista();
    }
}
