using data_access.model;
using Microsoft.Data.SqlClient;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.repositories
{
    public class EstadosRepository : IEstadosRepository
    {
        private SqlConnection connection;
        public EstadosRepository()
        {
            connection = new SqlConnection("Data Source=localhost\\sqlexpress; user id=sa; password=a1pqsllN;Initial Catalog=prueba;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        public IEnumerable<Estados> Lista()
        {
            return connection.QueryAll<Estados>();
        }
    }
}
