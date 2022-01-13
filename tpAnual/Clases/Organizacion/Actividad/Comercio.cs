
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Comercio : Actividad {

        public Comercio()
        {
            CantidadPersonalMax = new int[4] { 7, 35, 125, 345 };
            PromedioVentasMax = new float[4] { 29740000, 178860000, 1502750000, 2146810000 };
        }

	}//end Comercio

}//end namespace TPANUAL