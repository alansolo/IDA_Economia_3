using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDA_Economia.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        // GET: Usuario
        public ActionResult Usuario()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
    }
}