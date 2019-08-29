using Entidades;
using Negocio.MercadoCapital;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDA_Economia.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ValidarLogin(string usuario, string password)
        {
            string mensejeError = string.Empty;
            string userDefault = string.Empty;
            string passwordDefault = string.Empty;
            List<Parametro> listParametro = new List<Parametro>();
            Parametro parametro = new Parametro();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                mensejeError = "Agregue el usuario y el password correctamente.";
            }
            else
            {
                DataTable dtUsuario = new DataTable();

                parametro.Nombre = "Usuario";
                parametro.Valor = usuario;

                listParametro.Add(parametro);

                MercadoCapital mercadoCapital = new MercadoCapital();
                dtUsuario = mercadoCapital.ObtenerUsuario(listParametro);

                userDefault = dtUsuario.Rows.Cast<DataRow>().ToList().Select(n => n["Usuario"].ToString()).FirstOrDefault();
                passwordDefault = dtUsuario.Rows.Cast<DataRow>().ToList().Select(n => n["Password"].ToString()).FirstOrDefault();

                //userDefault = ConfigurationManager.AppSettings["usuario"].ToString();
                //passwordDefault = ConfigurationManager.AppSettings["password"].ToString();

                if (usuario == userDefault && password == passwordDefault)
                {
                    Session["Usuario"] = usuario;
                    mensejeError = "OK";
                }
                else
                {
                    mensejeError = "El usuario y password son incorrectos.";
                }
            }

            return Json(mensejeError, JsonRequestBehavior.AllowGet);
        }
    }
}