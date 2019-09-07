﻿using Entidades;
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

            try
            {
                ListUsuario = Usuario.ObtenerUsuario(ListParametro);

                Session["ListUsuario"] = ListUsuario;
            }
            catch (Exception ex)
            {
            }


            return Json(ListUsuario.OrderBy(n => n.Nombre), JsonRequestBehavior.AllowGet);
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
            }
            catch (Exception ex)
            {
            }

            return Json(ListUsuario.OrderBy(n => n.Nombre), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditarUsuario(Entidades.Usuario usuario)
        {
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();

            try
            {
                ListUsuario = (List<Entidades.Usuario>)Session["ListUsuario"];

                usuario = Usuario.AgregarUsuario(ListParametro);

                ListUsuario.RemoveAll(n => n.Id == usuario.Id);

                ListUsuario.Add(usuario);
            }
            catch (Exception ex)
            {
            }

            return Json(ListUsuario.OrderBy(n => n.Nombre), JsonRequestBehavior.AllowGet);
        }

    }
}