using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPANUAL.Jobs
{
    public class JobCompra : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {
            Organizacion organizacion = (Organizacion)context.JobDetail.JobDataMap.Get("organizacion");

            foreach (OperacionDeEgreso operacion in organizacion.OperacionesDeEgreso)
            {
                await operacion.TipoEgreso.validar();
            }

            Console.WriteLine("Corrio el scheduler");
        }
    }
}
