using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL
{
    [Table("operaciondeingreso")]
    public class OperacionDeIngreso
    {
        [Key]

        [Column("ID_OperacionDeIngreso")]
        public int ID_OperacionDeIngreso { get; set; }

        [Column("ID_Organizacion")]
        public int ID_Organizacion { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; }

        [Column("Monto")]
        public float Monto { get; set; }
        
        public Proyecto ProyectoAsociado { get; set; }

        public List<OperacionDeEgreso> EgresosAsociados { get; set; }
        public OperacionDeIngreso(string descripcion, List<OperacionDeEgreso> egresosAsociados, float monto, DateTime fecha)
        {
            this.Descripcion = descripcion;
            this.EgresosAsociados = egresosAsociados;
            this.Monto = monto;
            this.Fecha = fecha;
        }
        public OperacionDeIngreso() { }

        public void agregarOperacionDeEgreso(OperacionDeEgreso operacion)
        {
            EgresosAsociados.Add(operacion);
        }
    }
}
