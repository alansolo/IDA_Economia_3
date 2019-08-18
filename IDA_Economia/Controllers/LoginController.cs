using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDA_Economia.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                mensejeError = "Agregue el usuario y el password correctamente.";
            }
            else
            {
                userDefault = ConfigurationManager.AppSettings["usuario"].ToString();
                passwordDefault = ConfigurationManager.AppSettings["password"].ToString();

                if (usuario == userDefault && password == passwordDefault)
                {
                    Session["usuario"] = usuario;
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