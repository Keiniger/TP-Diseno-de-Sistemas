using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPANUAL
{
    [Table("proyecto")]
    public class Proyecto
    {
        [Key]
        [Column("ID_Proyecto")]
        public int ID_Proyecto { get; set; }

        public Usuario Director_Responsable { get; set; }

        public List<OperacionDeIngreso> IngresosAsociados { get; set; }

        public List<OperacionDeEgreso> EgresosAsociados { get; set; }

        [Column("Monto_Ingresos")]
        public float Monto_Ingresos { get; set; }

        [Column("Monto_Egresos")]
        public float Monto_Egresos { get; set; }

        [Column("Monto_Maximo_Presupuestos")]
        public float Monto_Maximo_Presupuestos { get; set; }

        [Column("Cant_presupuestos")]
        public int Cant_presupuestos { get; set; }

        public Proyecto(List<OperacionDeIngreso> ingAs, List<OperacionDeEgreso> egAs, Usuario director, float monto_max, int cant_pres)
        {
            IngresosAsociados = ingAs;
            Director_Responsable = director;
            foreach(OperacionDeIngreso ingreso in ingAs)
            {
                this.Monto_Ingresos += ingreso.Monto;
            }
            Monto_Maximo_Presupuestos = monto_max;
            Cant_presupuestos = cant_pres;
            EgresosAsociados = egAs;
            foreach (OperacionDeEgreso egreso in egAs)
            {
                this.Monto_Egresos += egreso.ValorTotal;
            }
        }

        public void agregarEgresoAsociado(OperacionDeEgreso operacion)
        {
            EgresosAsociados.Add(operacion);
            Monto_Egresos += operacion.ValorTotal;
        }

        public void agregarIngresoAsociado(OperacionDeIngreso operacion)
        {
            IngresosAsociados.Add(operacion);
            Monto_Ingresos += operacion.Monto;
        }

        public void validar()
        {
            foreach(OperacionDeEgreso ope in EgresosAsociados)
            {
                ValidadorDeCompra.getInstanceValidadorCompra.validarEgreso(ope);
            }
            
        }

    }
}
