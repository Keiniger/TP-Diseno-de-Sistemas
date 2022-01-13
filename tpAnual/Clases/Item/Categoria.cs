using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Column ("ID_Categoria")]
        public int ID_Categoria { get; set; }

        [Column("Nombre")]
        private string nombre;

        public List<Item> Items { get; set; }

        [Column("Criterio")]
        private Criterio criterio;
        public Categoria(string nombre, Criterio criterio)
        {
            this.nombre = nombre;
            this.criterio = criterio;
        }

        public Categoria() { }

        public string Nombre { get => nombre; set => nombre = value; }
        public Criterio Criterio { get => criterio; set => criterio = value; }
    }
}
