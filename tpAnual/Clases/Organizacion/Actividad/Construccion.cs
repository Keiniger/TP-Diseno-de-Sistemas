
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Construccion : Actividad {

        public Construccion()
        {
            CantidadPersonalMax = new int[4] { 12, 45, 200, 590 };
            PromedioVentasMax = new float[4] { 15230000, 90310000, 503880000, 755740000 };
        }

	}//end Construccion

}//end namespace TPANUAL