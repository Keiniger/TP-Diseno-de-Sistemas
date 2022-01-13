
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class MenorValor : CriterioCompra {

		public MenorValor() {}
		public override bool cumpleCriterio(Compra compra){

            float valorMinimo = float.MaxValue;
            Presupuesto presupuestoMinimo = compra.Presupuestos[0]; //en caso de que no entre en el if

            foreach(Presupuesto presupuesto in compra.Presupuestos)
            {
                if(presupuesto.valorTotal() <= valorMinimo)
                {
                    presupuestoMinimo = presupuesto;
                    valorMinimo = presupuesto.valorTotal();
                }
            }

            return compra.valorTotal() <= presupuestoMinimo.valorTotal();
		}

	}//end MenorValor

}//end namespace TPANUAL