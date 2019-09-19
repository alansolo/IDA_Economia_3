using Entidades;
using IDA_Economia.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDA_Economia.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult Usuario()
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
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();

            Negocio.Usuario.Rol Rol = new Negocio.Usuario.Rol();
            List<Entidades.CatRol> ListCatRol = new List<CatRol>();

            ResultadoUsuario resultadoUsuario = new Models.Usuario.ResultadoUsuario();

            try
            {
                ListCatRol = Rol.ObtenerCatRol(ListParametro);

                ListUsuario = Usuario.ObtenerUsuario(ListParametro);

                resultadoUsuario.ListaUsuario = ListUsuario.OrderBy(n => n.Nombre).ToList();
                resultadoUsuario.ListaCatRol = ListCatRol.OrderBy(n => n.Id).ToList();

                Session["ListCatRol"] = ListCatRol;
                Session["ListUsuario"] = ListUsuario;

            }
            catch (Exception ex)
            {
            }

            return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AgregarUsuario()
        {
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();

            Entidades.Usuario usuario = new Entidades.Usuario();

            try
            {
                ListUsuario = (List<Entidades.Usuario>)Session["ListUsuario"];

                usuario = Usuario.AgregarUsuario(ListParametro);

                ListUsuario.Add(usuario);

                Session["ListUsuario"] = ListUsuario;
            }
            catch (Exception ex)
            {
            }

            return Json(ListUsuario.OrderBy(n => n.Nombre), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MostrarAgregarUsuario()
        {
            Entidades.Usuario usuario = new Entidades.Usuario();

            return Json(usuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MostrarEditarUsuario(Entidades.Usuario usuario)
        {
            Entidades.CatRol catRol = new Entidades.CatRol();

            List<CatRol> listaCatRol = new List<CatRol>();

            try
            {
                listaCatRol = (List<CatRol>)Session["ListCatRol"];

                catRol = listaCatRol.Where(n => n.Id == usuario.IdRol).FirstOrDefault();

                if (catRol == null)
                {
                    if (listaCatRol.Count > 0)
                    {
                        catRol = listaCatRol.FirstOrDefault();
                    }                 
                }
            }
            catch (Exception ex)
            {
            }            

            return Json(catRol, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditarUsuario(Entidades.Usuario usuario)
        {
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();

            try
            {
                //ListUsuario = (List<Entidades.Usuario>)Session["ListUsuario"];

                usuario = Usuario.AgregarUsuario(ListParametro);

                //ListUsuario.RemoveAll(n => n.Id == usuario.Id);

                //ListUsuario.Add(usuario);
            }
            catch (Exception ex)
            {
            }

            return Json(ListUsuario.OrderBy(n => n.Nombre), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InactivarUsuario(Entidades.Usuario usuario)
        {
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();

            try
            {
                //ListUsuario = (List<Entidades.Usuario>)Session["ListUsuario"];

                usuario.Estatus = false;
                usuario = Usuario.EditarUsuario(ListParametro);

                //ListUsuario.RemoveAll(n => n.Id == usuario.Id);
            }
            catch (Exception ex)
            {
            }

            return Json(ListUsuario.OrderBy(n => n.Nombre), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ActivarUsuario(Entidades.Usuario usuario)
        {
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();

            try
            {
                //ListUsuario = (List<Entidades.Usuario>)Session["ListUsuario"];

                usuario.Estatus = true;
                usuario = Usuario.EditarUsuario(ListParametro);

                //ListUsuario.RemoveAll(n => n.Id == usuario.Id);
            }
            catch (Exception ex)
            {
            }

            return Json(ListUsuario.OrderBy(n => n.Nombre), JsonRequestBehavior.AllowGet);
        }
    }
}