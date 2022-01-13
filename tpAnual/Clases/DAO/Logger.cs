using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPANUAL.Clases.DAO
{
    class Logger
    {
        private List<string> logs = new List<string>();

        private static Logger logger = null;
        protected Logger() { }
        public static Logger getInstance
        {
            get
            {
                if(logger == null)
                {
                    logger = new Logger();
                }

                return logger;
            }
        }

        public void update(string log)
        {
            logs.Add(log);
        }
        //ACA IRIA LA LOGICA PARA PERSISTIR EN MONGO DB
    }
}
