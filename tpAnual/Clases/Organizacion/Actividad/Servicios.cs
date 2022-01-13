
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Servicios : Actividad {

		public Servicios(){

        CantidadPersonalMax = new int[4] { 7, 30, 165, 535 };
        PromedioVentasMax = new float[4] { 8500000, 50950000, 425170000, 607210000 };
        
        }

	}//end Servicios

}//end namespace TPANUAL