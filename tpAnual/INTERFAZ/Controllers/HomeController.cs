using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPANUAL;
using TPANUAL.Clases.DAO;

namespace INTERFAZ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<String> erroresFormSesion = (List<String>) Session["erroresFormSesion"];
            String _usuario = (String) Session["_usuario"];
            String _contraseña = (String) Session["_contraseña"];
            Session.Clear();
            Session["erroresFormSesion"] = erroresFormSesion;
            Session["_usuario"] = _usuario;
            return View();
        }

        public ActionResult Egresos()
        {
            if (Session["Usuario"] != null)
            {
                Session["Egresos"] = OperacionDeEgresoDAO.obtenerEgresos((Usuario)Session["Usuario"]);
                Session["Organizacion"] = OrganizacionDAO.obtenerOrganizacion((Usuario)Session["Usuario"]);
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult NuevaCompra()
        {
            if (Session["Usuario"] != null)
            {
                Session["Egresos"] = OperacionDeEgresoDAO.obtenerEgresos((Usuario)Session["Usuario"]);
                Session["Organizacion"] = OrganizacionDAO.obtenerOrganizacion((Usuario)Session["Usuario"]);
                Session["Paises"] = Pais.obtenerPaises();
                Session["PersonasProveedoras"] = PersonaProveedoraDAO.obtenerPersonasProveedoras();
                Session["EntidadesJuridicasProveedoras"] = EntidadJuridicaProveedoraDAO.obtenerEntidadesJuridicasProveedoras();
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult NuevoPresupuesto()
        {
            if (Session["Usuario"] != null)
            {
                Session["PersonasProveedoras"] = PersonaProveedoraDAO.obtenerPersonasProveedoras();
                Session["EntidadesJuridicasProveedoras"] = EntidadJuridicaProveedoraDAO.obtenerEntidadesJuridicasProveedoras();
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Ingresos()
        {
            if (Session["Usuario"] != null)
            {
                Session["Ingresos"] = OperacionDeIngresoDAO.obtenerIngresos((Usuario)Session["Usuario"]);
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Organizacion()
        {
            if (Session["Usuario"] != null)
            {
                Session["Organizacion"] = OrganizacionDAO.obtenerOrganizacion((Usuario)Session["Usuario"]);
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Vinculador()
        {
            if (Session["Usuario"] != null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }
    }
}