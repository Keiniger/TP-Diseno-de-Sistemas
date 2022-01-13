
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TPANUAL {
    [Table("mediodepago")]
	public class MedioDePago {
        [Key]
        [Column("ID_MedioDePago")]
        public int ID_MedioDePago { get; set; }

        [Column("ID_Pais")]
        public string ID_Pais { get; set; }
        public Pais Pais { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }

        [Column("TipoPago")]
        public string TipoPago { get; set; }

        public MedioDePago(string IDpais, string numero, string tipoPago)
        {
            this.ID_Pais = IDpais;
            Numero = numero;
            TipoPago = tipoPago;
        }

        public MedioDePago() { }

    }//end Medio de Pago

}//end namespace TPANUAL