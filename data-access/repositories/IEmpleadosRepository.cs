using data_access.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.repositories
{
    public interface IEmpleadosRepository
    {
        IEnumerable<Empleados> Buscar(Empleados parametros);
        void Guardar(Empleados empleado);
        void Eliminar(int id);
        void Actualizar(Empleados empleado);
        Empleados Detalles(int id);
    }
}
