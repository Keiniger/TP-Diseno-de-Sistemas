
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {

    [Table("entidadbase")]
	public class EntidadBase : TipoEntidad {

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        public EntidadJuridica JuridicaAsociada { get; set; }

        public EntidadBase(string descripcion, EntidadJuridica juridicaAsociada, Direccion direccion)
        {
            this.Descripcion = descripcion;
            this.JuridicaAsociada = juridicaAsociada;
            this.DireccionPostal = direccion;
            this.ID_Direccion = direccion.ID_Direccion;
        }
        public EntidadBase() { }

    }//end Entidad base

}//end namespace TPANUAL