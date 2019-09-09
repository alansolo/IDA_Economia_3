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
        public JsonResult ObtenerLog(string usuario, DateTime fechaInicio, DateTime fechaFinal)
        {
            List<Log> ListLog = new List<Log>();

            Negocio.Log.Log log = new Negocio.Log.Log();
            List<Parametro> listParametro = new List<Parametro>();
            Parametro parametro = new Parametro();

            try
            {
                parametro = new Parametro();
                parametro.Nombre = "Usuario";
                parametro.Valor = usuario;

                listParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "FechaInicio";
                parametro.Valor = fechaInicio;

                listParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "FechaFinal";
                parametro.Valor = fechaFinal;

                listParametro.Add(parametro);

                ListLog = log.ObtenerLog(listParametro);
            }
            catch (Exception ex)
            {
            }


            return Json(ListLog.OrderBy(n => n.Creado), JsonRequestBehavior.AllowGet);
        }
    }
}