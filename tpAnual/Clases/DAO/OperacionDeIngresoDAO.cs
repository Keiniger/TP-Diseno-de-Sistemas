using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TPANUAL.Clases.DAO
{
    public class OperacionDeIngresoDAO
    {
        private OperacionDeIngresoDAO() { }

        public static List<OperacionDeIngreso> obtenerIngresos(Usuario _usuario)
        {
            using (var contexto = new DB_Context())
            {
                var operacionesDeIngreso = contexto.operacionDeIngreso
                    .Where(oi => oi.ID_Organizacion == _usuario.ID_organizacion)
                    .Include(oi => oi.EgresosAsociados)
                    .Include(oi => oi.EgresosAsociados
                        .Select(ea => ea.MedioDePago))
                    .ToList();

                return operacionesDeIngreso;
            }
        }

    }
}
