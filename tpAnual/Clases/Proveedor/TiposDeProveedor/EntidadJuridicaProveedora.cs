
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {
    [Table("entidadjuridicaproveedora")]
	public class EntidadJuridicaProveedora : Proveedor {

        [Column("CodigoInscripcion")]
        public string CodigoInscripcion { get; set; }

        [Column("RazonSocial")]
        public string RazonSocial { get; set; }

        [Column("CUIT")]     // dni para persona, cuit para entidad juridica
        public string CUIT { get; set; }
        public List<Compra> compras { get; set; }
        public List<Presupuesto> presupuestos { get; set; }

        public EntidadJuridicaProveedora(Direccion direccionPostal, string codigoInscripcion, string _CUIT, string razonSocial)
        {
            DireccionPostal = direccionPostal;
            CodigoInscripcion = codigoInscripcion;
            CUIT = _CUIT;
            RazonSocial = razonSocial;
            // ID_Direccion = direccionPostal.ID_Direccion; // Que es esto? tira error, no tiene sentido
        }

        public EntidadJuridicaProveedora() { }

    }//end EntidadJuridicaProveedora

}//end namespace TPANUAL