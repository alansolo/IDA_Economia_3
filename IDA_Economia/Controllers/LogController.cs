using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDA_Economia.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        [HttpGet]
        public ActionResult Log()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public JsonResult ObtenerUsuario()
        {
            List<Log> ListLog = new List<Log>();

            Negocio.Log.Log log = new Negocio.Log.Log();
            List<Parametro> ListParametro = new List<Parametro>();

            try
            {
                ListLog = log.ObtenerLog(ListParametro);
            }
            catch (Exception ex)
            {
            }


            return Json(ListLog.OrderBy(n => n.Creado), JsonRequestBehavior.AllowGet);
        }
    }
}