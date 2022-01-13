
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {
	public abstract class Proveedor {

        [Key]
        [Column("ID_Proveedor")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Proveedor { get; set; }

		[Column("ID_Direccion")]
		public int? ID_Direccion { get; set; }
		public Direccion DireccionPostal { get; set; }



	}//end Proveedor

}//end namespace TPANUAL