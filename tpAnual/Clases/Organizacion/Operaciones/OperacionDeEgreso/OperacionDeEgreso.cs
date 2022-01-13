
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {

	[Table("operaciondeegreso")]
	public class OperacionDeEgreso {

		[Key, ForeignKey("Compra")]
		[Column("ID_OperacionDeEgreso")]
		public int ID_OperacionDeEgreso { get; set; }
		public OperacionDeIngreso IngresoAsociado { get; set; }

		public Proyecto ProyectoAsociado { get; set; }

		[Column("ID_Organizacion")]
		public int ID_Organizacion { get; set; }

		[Column("Fecha")]
		public DateTime Fecha { get; set; }

		[Column("ValorTotal")]
		public float ValorTotal { get; set; }

		public MedioDePago MedioDePago { get; set; }
		
		public virtual Compra Compra { get; set; }
        public List<DocumentoComercial> DocumentosComerciales { get; set; }

		public OperacionDeEgreso(Compra compra, MedioDePago medio, List<DocumentoComercial> documentos, DateTime fecha)
		{
			DocumentosComerciales = documentos;
			Fecha = fecha;
			MedioDePago = medio;
			Compra = compra;
			ValorTotal = valorTotal();
		}
		public OperacionDeEgreso() { }

		public float valorTotal(){
			ValorTotal = Compra.valorTotal();
			return ValorTotal;
		}

		public void agregarDocumentoComercial(DocumentoComercial documento)
        {
			DocumentosComerciales.Add(documento);
        }

    }//end OperacionDeEgreso

}//end namespace TPANUAL