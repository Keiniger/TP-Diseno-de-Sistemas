using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPANUAL;

namespace TPANUAL
{
    [Table("mensaje")]
    public class Mensaje
    {
        [Key]
        [Column("ID_Mensaje")]
        public int ID_Mensaje { get; set; }

        [Column("Texto")]
        public string texto { get; set; }

        public Mensaje(string Texto)
        {
            texto = Texto;
        }
        public Mensaje() { }

        public void mostrarMensaje()
        {
            Console.WriteLine(texto);
        }
    }
}
