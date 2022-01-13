using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL
{
    [Table ("Criterio")]
    public class Criterio
    {
        [Key]
        [Column ("ID_Criterio")]
        public int ID_Criterio { get; set; }
        [Column("Nombre")]
        private string nombre;
        [Column("Criterio_Padre")]
        private Criterio criterioPadre;

        public Criterio(string nombre, Criterio criterioPadre)
        {
            this.nombre = nombre;
            this.criterioPadre = criterioPadre;
        }

        public Criterio() { }

        public string Nombre { get => nombre; set => nombre = value; }
        public Criterio CriterioPadre { get => criterioPadre; set => criterioPadre = value; }
    }
}
