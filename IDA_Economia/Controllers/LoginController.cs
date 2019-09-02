using Entidades;
using Negocio.Login;
using Negocio.MercadoCapital;
using Negocio.MercadoDivisa;
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
                Entidades.Usuario Usuario = new Usuario();

                parametro.Nombre = "Usuario";
                parametro.Valor = usuario;

                listParametro.Add(parametro);

                Login login = new Login();

                Usuario = login.ObtenerUsuario(listParametro);

                userDefault = Usuario.Login;
                passwordDefault = Usuario.Password;

                if (usuario == userDefault && password == passwordDefault)
                {
                    Session["Usuario"] = usuario;
                    mensejeError = "OK";

                    //INSERTAR INFORMACION LOG
                    listParametro = new List<Parametro>();

                    parametro = new Parametro();
                    parametro.Nombre = "Usuario";
                    parametro.Valor = userDefault;

                    listParametro.Add(parametro);

                    parametro = new Parametro();
                    parametro.Nombre = "Modulo";
                    parametro.Valor = "Login";

                    listParametro.Add(parametro);

                    parametro = new Parametro();
                    parametro.Nombre = "Resumen";
                    parametro.Valor = "Inicio sesion";

                    listParametro.Add(parametro);

                    Negocio.Log.Log log = new Negocio.Log.Log();
                    log.InsertLog(listParametro);
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