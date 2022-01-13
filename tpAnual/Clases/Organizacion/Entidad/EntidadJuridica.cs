
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {
    [Table("entidadjuridica")]
	public class EntidadJuridica : TipoEntidad {

        [Column("CodigoInscripcion")]
		public string CodigoInscripcion { get; set; }

        [Column("CUIT")]
        public string CUIT { get; set; }

        [Column("RazonSocial")]
        public string RazonSocial { get; set; }
        public List<EntidadBase> BasesAsociadas { get; set; }
        public EntidadJuridica(List<EntidadBase> basesAsociadas, string codigoInscripcion, string CUIT, Direccion direccionPostal, string razonSocial)
        {
            BasesAsociadas = basesAsociadas;
            CodigoInscripcion = codigoInscripcion;
            this.CUIT = CUIT;
            DireccionPostal = direccionPostal;
            ID_Direccion = direccionPostal.ID_Direccion;
            RazonSocial = razonSocial;
        }

        public EntidadJuridica() { }

    }//end Entidad Juridica

}//end namespace TPANUAL