
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {

    [Table("organizacion")]
    public class OSC : Organizacion{
        public OSC(Actividad actividad, int cantidadPersonal, string nombreFicticio, float promedioVentasAnuales, EntidadBase EntidadBase_, EntidadJuridica EntidadJuridica_, List<Usuario> usuarios)
        {
            Actividad = actividad;
            CantidadPersonal = cantidadPersonal;
            EsActividadComisionistaoAgenciaDeViaje = false;
            NombreFicticio = nombreFicticio;
            OperacionesDeEgreso = new List<OperacionDeEgreso>();
            OperacionesDeIngreso = new List<OperacionDeIngreso>();
            PromedioVentasAnuales = promedioVentasAnuales;
            EntidadBase = EntidadBase_;
            EntidadJuridica = EntidadJuridica_;
            Usuarios = usuarios;
            Proyectos = new List<Proyecto>();
        }

        public OSC() { }

    }//end OSC

}//end namespace TPANUAL