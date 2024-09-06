using data_access.model;
using Microsoft.Data.SqlClient;
using RepoDb;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.repositories
{
    public class EmpleadosRepository : IEmpleadosRepository
    {
        private SqlConnection connection;
        public EmpleadosRepository()
        {
            connection = new SqlConnection("Data Source=localhost\\sqlexpress; user id=sa; password=a1pqsllN;Initial Catalog=prueba;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        public void Actualizar(Empleados empleado)
        {
            connection.Update(empleado);
        }

        public Empleados Detalles(int id)
        {
            return connection.Query<Empleados>(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Empleados> Buscar(Empleados parametros)
        {
            string sql = "SELECT e.*, p.Nombre as Puesto, est.Nombre as Estado FROM Empleados e " +
                "inner join Puestos p on p.Id = e.PuestoId " +
                "inner join Estados est on est.Id = e.EstadoId " +
                "WHERE 1 = 1 ";

            Dictionary<string, object> parametrosQuery = new Dictionary<string, object>();

            if (!String.IsNullOrEmpty(parametros.Nombre))
            {
                sql += " AND e.Nombre like @Nombre ";
                parametrosQuery.Add("@Nombre", "%" + parametros.Nombre + "%");
            }

            if (!String.IsNullOrEmpty(parametros.Apellido))
            {
                sql += " AND Apellido like @Apellido ";
                parametrosQuery.Add("@Apellido", "%" + parametros.Apellido +"%");

            }

            if (!String.IsNullOrEmpty(parametros.CorreoElectronico))
            {
                sql += " AND CorreoElectronico like @CorreoElectronico ";
                parametrosQuery.Add("@CorreoElectronico", "%" + parametros.CorreoElectronico + "%");

            }

            if (parametros.PuestoId > 0)
            {
                sql += " AND PuestoId = @PuestoId ";
                parametrosQuery.Add("@PuestoId", parametros.PuestoId);

            }

            if (parametros.EstadoId > 0)
            {
                sql += " AND EstadoId = @EstadoId ";
                parametrosQuery.Add("@EstadoId", parametros.EstadoId);

            }

            if (parametros.FechaNacimiento != null)
            {
                sql += " AND FechaNacimiento = @FechaNacimiento ";
                parametrosQuery.Add("@FechaNacimiento", parametros.FechaNacimiento);
            }

            return connection.ExecuteQuery<Empleados>(sql, parametrosQuery);
        }

        public void Eliminar(int id)
        {
            connection.Delete<Empleados>(id);
        }

        public void Guardar(Empleados empleado)
        {
            connection.Insert(empleado);
        }
    }
}
