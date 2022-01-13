using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPANUAL;
using TPANUAL.Clases.DAO;


namespace INTERFAZ.Controllers
{
    public class IngresosController : Controller
    {
        public ActionResult FormRegistrarIngreso()
        {
            return RedirectToAction("Ingresos", "Home");
        }
    }
}