
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {
	public abstract class TipoEntidad {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Entidad { get; set; }

        [Column("ID_Direccion")]
		public int? ID_Direccion { get; set; }
		public Direccion DireccionPostal { get; set; }

		public TipoEntidad() { }

	}//end TipoEntidad

}//end namespace TPANUAL