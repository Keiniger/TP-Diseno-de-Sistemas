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
    public class PersonaProveedoraDAO
    {
        private PersonaProveedoraDAO() { }

        public static PersonaProveedora obtenerPersonaProveedora(int _ID) //no busca por id (PK) -> busca por el dni
        {
            var contexto = new DB_Context();
            var personaProveedora = contexto.personaProveedora.Find(_ID);
            return personaProveedora;
        }

        public static List<PersonaProveedora> obtenerPersonasProveedoras()
        {
            var contexto = new DB_Context();
            var personasProveedoras = contexto.personaProveedora.ToList();
            return personasProveedoras;
        }
    }
}
