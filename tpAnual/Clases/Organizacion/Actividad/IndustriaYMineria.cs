
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class IndustriaYMineria : Actividad {

		public IndustriaYMineria(){
            CantidadPersonalMax = new int[4] { 15, 60, 235, 655 };
            PromedioVentasMax = new float[4] { 25540000, 190410000, 1190330000, 1739590000 };
        }

	}//end IndustriaYMineria

}//end namespace TPANUAL