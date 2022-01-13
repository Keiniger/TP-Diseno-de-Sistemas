using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INTERFAZ.Controllers
{
    public class VinculadorController : Controller
    {
        [HttpPost]
        public ActionResult FormVincular(
            string _IdOrganizacion,
            string _BotonSubmit,
            string _TipoVinculador,
            string _PeriodoDeVinculacion,
            string[] _TipoCriterio)
        {
            // Creo condiciones
            List<Condicion> condiciones = new List<Condicion>() { new PeriodoDeAceptabilidad(int.Parse(_PeriodoDeVinculacion)) };
            // Creo el vinculador con sus parametros
            Vinculador vinculador = new Vinculador(condiciones);

            if (_BotonSubmit == "desvincular") 
            { 
                Vinculador.desvincular(int.Parse(_IdOrganizacion));
                return RedirectToAction("Egresos", "Home");
            }
            
            else if (_BotonSubmit == "simple")
            {
                if (_TipoVinculador == "ovpi")
                {
                    CriterioVinculador criterio = new Orden_Valor_PrimeroIngreso();
                    criterio.Vinculador = vinculador;
                    vinculador.cambiarCriterio(criterio);
                    vinculador.vincular(int.Parse(_IdOrganizacion));
                    return RedirectToAction("Egresos", "Home");
                }
                else if (_TipoVinculador == "ovpe")
                {
                    CriterioVinculador criterio = new Orden_Valor_PrimeroEgreso();
                    criterio.Vinculador = vinculador;
                    vinculador.cambiarCriterio(criterio);
                    vinculador.vincular(int.Parse(_IdOrganizacion));
                    return RedirectToAction("Egresos", "Home");
                }
                else if (_TipoVinculador == "fecha")
                {
                    CriterioVinculador criterio = new Fecha();
                    criterio.Vinculador = vinculador;
                    vinculador.cambiarCriterio(criterio);
                    vinculador.vincular(int.Parse(_IdOrganizacion));
                    return RedirectToAction("Egresos", "Home");
                }
            }

            else if (_BotonSubmit == "mix")
            {
                List<CriterioVinculador> criterios = new List<CriterioVinculador>() { };
                for (int i = 0; i < _TipoCriterio.Length; i++)
                {
                    if (_TipoCriterio[i] == "ovpe")
                        criterios.Add(new Orden_Valor_PrimeroEgreso());

                    else if (_TipoCriterio[i] == "ovpi")
                        criterios.Add(new Orden_Valor_PrimeroIngreso());

                    else if (_TipoCriterio[i] == "fecha")
                        criterios.Add(new Fecha());
                }
                CriterioVinculador criterio = new Mix(criterios);

                foreach (CriterioVinculador c in criterios)
                    c.Vinculador = vinculador;
                
                criterio.Vinculador = vinculador;
                vinculador.cambiarCriterio(criterio);
                vinculador.vincular(int.Parse(_IdOrganizacion));
                return RedirectToAction("Egresos", "Home");
            }

            return RedirectToAction("Egresos", "Home");
        }
    }
}