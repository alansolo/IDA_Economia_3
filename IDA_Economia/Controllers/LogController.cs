using Entidades;
using IDA_Economia.Models.Log;
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
        public JsonResult ObtenerLog(string usuario, string strFechaInicio, string strFechaFinal)
        {
            ResultadoLog resultadoLog = new Models.Log.ResultadoLog();
            List<Log> ListaLog = new List<Log>();

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
                parametro.Valor = strFechaInicio;

                listParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "FechaFinal";
                parametro.Valor = strFechaFinal;

                listParametro.Add(parametro);

                ListaLog = log.ObtenerLog(listParametro);
                
                resultadoLog.ListaLog = ListaLog.OrderBy(n => n.Creado).ToList();
                resultadoLog.ListaLog.ForEach(n =>
                {
                    n.StrCreado = n.Creado.ToString("dd/MM/yyyy hh:mm:ss");
                    n.DetalleCapital.ForEach(m =>
                    {
                        m.StrCreado = m.Creado.ToString("dd/MM/yyyy hh:mm:ss");
                    });
                });
                resultadoLog.Mensaje = "";
            }
            catch (Exception ex)
            {
            }


            return Json(resultadoLog, JsonRequestBehavior.AllowGet);
        }
    }
}