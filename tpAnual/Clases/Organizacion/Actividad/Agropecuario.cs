
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Agropecuario : Actividad {

        public Agropecuario()
        {
            CantidadPersonalMax = new int[4] { 5, 10, 50, 215 };
            PromedioVentasMax = new float[4] { 12890000, 48480000, 345430000, 547890000 };
        }

	}//end Agropecuario

}//end namespace TPANUAL