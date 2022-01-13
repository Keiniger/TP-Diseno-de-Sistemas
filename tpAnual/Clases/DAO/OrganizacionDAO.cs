using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;

namespace TPANUAL.Clases.DAO
{
    public class OrganizacionDAO
    {
        private OrganizacionDAO() { }


        public static dynamic obtenerOrganizacion(Usuario _usuario)
        {
            using var contexto = new DB_Context();
            Empresa e = null;
            int id_org = (int)_usuario.ID_organizacion;

            try
            {
                e = contexto.empresas.Find(id_org);
            }
            catch { }

            if (e != null)
                return obtenerEmpresa(id_org);
            else
                return obtenerOSC(id_org);
        }

        /* Busca org con un id*/

        public static dynamic obtenerOrganizacion(int _org)
        {
            using var contexto = new DB_Context();
            Empresa e = null;

            try
            {
                e = contexto.empresas.Find(_org);
            }
            catch { }

            if (e != null)
                return obtenerEmpresa(_org);
            else
                return obtenerOSC(_org);
        }

        private static OSC obtenerOSC(int _org)
        {
            using var contexto = new DB_Context();
            var osc = contexto.oscs
                .Where(osc => osc.ID_Organizacion == _org)
                .Include(osc => osc.Usuarios)
                .Include(osc => osc.OperacionesDeEgreso)
                .Include(osc => osc.OperacionesDeIngreso)
                .Include(osc => osc.EntidadBase)
                .Include(osc => osc.EntidadJuridica)
                .FirstOrDefault();

            return osc;
        }

        private static Empresa obtenerEmpresa(int _org)
        {
            using var contexto = new DB_Context();
            var empresa = contexto.empresas
                .Where(e => e.ID_Organizacion == _org)
                .Include(e => e.Usuarios)
                .Include(e => e.OperacionesDeEgreso)
                .Include(e => e.OperacionesDeIngreso)
                .Include(e => e.EntidadBase)
                .Include(e => e.EntidadJuridica)
                .FirstOrDefault();

            return empresa;
        }
    }
}
