﻿using Entidades;
using Herramientas;
using IDA_Economia.Models.Usuario;
using Seguridad;
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
            Parametro parametro = new Parametro();

            Negocio.Usuario.Rol Rol = new Negocio.Usuario.Rol();
            List<Entidades.CatRol> ListCatRol = new List<CatRol>();

            ResultadoUsuario resultadoUsuario = new Models.Usuario.ResultadoUsuario();

            Entidades.Usuario usuario = new Entidades.Usuario();
            bool esSistema = false;

            string mensaje = string.Empty;

            const int idRolSistema = 1;
            const string key = "idaeconomia";

            try
            {
                ListCatRol = Rol.ObtenerCatRol(ListParametro);

                usuario = (Usuario)Session["Usuario"];

                ListParametro = new List<Parametro>();

                if (usuario.IdRol != idRolSistema)
                {
                    parametro = new Parametro();
                    parametro.Nombre = "Usuario";
                    parametro.Valor = usuario.Login;

                    ListParametro.Add(parametro);

                    esSistema = false;
                }
                else
                {
                    esSistema = true;
                }

                ListUsuario = Usuario.ObtenerUsuario(ListParametro);

                if (usuario.IdRol == 1)
                {
                    ListUsuario.ForEach(n =>
                    {
                        n.PasswordVisible = EncripDecrip.Desencriptar(n.Password, key);
                    });
                }

                resultadoUsuario.ListaUsuario = ListUsuario.OrderBy(n => n.Nombre).ToList();
                resultadoUsuario.ListaCatRol = ListCatRol.OrderBy(n => n.Id).ToList();
                resultadoUsuario.Usuario = new Usuario();
                resultadoUsuario.EsSistema = esSistema;
                
                Session["ListCatRol"] = ListCatRol;
                Session["ListUsuario"] = ListUsuario;
                Session["EsSistema"] = esSistema;

                resultadoUsuario.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                mensaje = "ERROR: Metodo: ObtenerEstadistico_Dinero, Source: " + ex.Source + ", Mensaje: " + ex.Message;
                ArchivoLog.EscribirLog(null, mensaje);

                resultadoUsuario.Mensaje = mensaje;
            }

            return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult BuscarUsuario(string usuario, string nombre, CatRol rol)
        {
            ResultadoUsuario resultadoUsuario = new ResultadoUsuario();
            List<Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario usuarioNegocio = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();
            Parametro parametro = new Parametro();

            string mensaje = string.Empty;
            Entidades.Usuario Usuario = new Entidades.Usuario();
            const string key = "idaeconomia";

            ///////////////////////
            //PROCESAMIENTO BASE///

            try
            {
                Usuario = (Entidades.Usuario)Session["Usuario"];

                parametro = new Parametro();
                parametro.Nombre = "Usuario";
                parametro.Valor = usuario;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Nombre";
                parametro.Valor = nombre;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "IdRol";
                if (rol.Id > 0)
                {
                    parametro.Valor = rol.Id;
                }
                ListParametro.Add(parametro);

                ListUsuario = usuarioNegocio.BuscarUsuario(ListParametro);

                if (Usuario.IdRol == 1)
                {
                    ListUsuario.ForEach(n =>
                    {
                        n.PasswordVisible = EncripDecrip.Desencriptar(n.Password, key);
                    });
                }

                Session["ListUsuario"] = ListUsuario;

                resultadoUsuario.ListaUsuario = ListUsuario.OrderBy(n => n.Nombre).ToList();
                resultadoUsuario.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                mensaje = "ERROR: Metodo: ObtenerEstadistico_Dinero, Source: " + ex.Source + ", Mensaje: " + ex.Message;
                ArchivoLog.EscribirLog(null, mensaje);

                resultadoUsuario.Mensaje = mensaje;
            }

            ///////////////////////

            return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MostrarAgregarUsuario()
        {
            ResultadoUsuarioDefault resultadoUsuario = new Models.Usuario.ResultadoUsuarioDefault();
            List<CatRol> listaCatRol = new List<CatRol>();
            Entidades.Usuario usuario = new Entidades.Usuario();
            string mensaje = string.Empty;

            try
            {
                resultadoUsuario.Usuario = usuario;

                listaCatRol = (List<CatRol>)Session["ListCatRol"];

                if (listaCatRol.Count > 0)
                {
                    resultadoUsuario.CatRol = listaCatRol.FirstOrDefault();
                }

                resultadoUsuario.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                mensaje = "ERROR: Metodo: ObtenerEstadistico_Dinero, Source: " + ex.Source + ", Mensaje: " + ex.Message;
                ArchivoLog.EscribirLog(null, mensaje);

                resultadoUsuario.Mensaje = mensaje;
            }

            return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MostrarEditarUsuario(Entidades.Usuario usuario)
        {
            ResultadoUsuario resultadoUsuario = new ResultadoUsuario();
            Entidades.CatRol catRol = new Entidades.CatRol();

            List<CatRol> listaCatRol = new List<CatRol>();
            const string key = "idaeconomia";

            string mensaje = string.Empty;

            try
            {
                listaCatRol = (List<CatRol>)Session["ListCatRol"];

                usuario.Password = EncripDecrip.Desencriptar(usuario.Password, key);
                usuario.ConfirmarPassword = usuario.Password;

                resultadoUsuario.Usuario = usuario;

                catRol = listaCatRol.Where(n => n.Id == usuario.IdRol).FirstOrDefault();

                if (catRol != null)
                {                      
                    resultadoUsuario.CatRol = catRol;              
                }

                resultadoUsuario.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                mensaje = "ERROR: Metodo: ObtenerEstadistico_Dinero, Source: " + ex.Source + ", Mensaje: " + ex.Message;
                ArchivoLog.EscribirLog(null, mensaje);

                resultadoUsuario.Mensaje = mensaje;
            }            

            return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditarUsuario(Entidades.Usuario usuario, Entidades.CatRol rol)
        {
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();
            Parametro parametro = new Parametro();
            ResultadoUsuario resultadoUsuario = new Models.Usuario.ResultadoUsuario();
            const string key = "idaeconomia";

            try
            {
                usuario.Password = EncripDecrip.Encriptar(usuario.Password, key);
                usuario.ConfirmarPassword = usuario.Password;
                usuario.IdRol = rol.Id;
                usuario.Rol = rol.Rol;

                parametro = new Parametro();
                parametro.Nombre = "Id";
                parametro.Valor = usuario.Id;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Nombre";
                parametro.Valor = usuario.Nombre;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Usuario";
                parametro.Valor = usuario.Login;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Password";
                parametro.Valor = usuario.Password;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "IdRol";
                parametro.Valor = usuario.IdRol;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Estatus";
                parametro.Valor = 1;
                ListParametro.Add(parametro);

                usuario = Usuario.EditarUsuario(ListParametro);

                ListUsuario = (List<Entidades.Usuario>)Session["ListUsuario"];

                ListUsuario.RemoveAll(n => n.Id == usuario.Id);

                ListUsuario.Add(usuario);

                Session["ListUsuario"] = ListUsuario;

                resultadoUsuario.ListaUsuario = ListUsuario.OrderBy(n => n.Nombre).ToList();
                resultadoUsuario.Mensaje = "OK";
            }
            catch (Exception ex)
            {
            }

            return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AgregarUsuario(Entidades.Usuario usuario, Entidades.CatRol rol)
        {
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();
            Parametro parametro = new Parametro();
            //Entidades.Usuario usuario = new Entidades.Usuario();
            ResultadoUsuario resultadoUsuario = new Models.Usuario.ResultadoUsuario();
            const string key = "idaeconomia";

            try
            {
                usuario.Password = EncripDecrip.Encriptar(usuario.Password, key);
                usuario.ConfirmarPassword = usuario.Password;
                usuario.IdRol = rol.Id;
                usuario.Rol = rol.Rol;

                parametro = new Parametro();
                parametro.Nombre = "Nombre";
                parametro.Valor = usuario.Nombre;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Usuario";
                parametro.Valor = usuario.Login;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Password";
                parametro.Valor = usuario.Password;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "IdRol";
                parametro.Valor = usuario.IdRol;
                ListParametro.Add(parametro);

                usuario = Usuario.AgregarUsuario(ListParametro);

                ListUsuario = (List<Entidades.Usuario>)Session["ListUsuario"];

                ListUsuario.Add(usuario);

                Session["ListUsuario"] = ListUsuario;

                resultadoUsuario.ListaUsuario = ListUsuario.OrderBy(n => n.Nombre).ToList();
                resultadoUsuario.Mensaje = "OK";
            }
            catch (Exception ex)
            {
            }

            return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InactivarUsuario(Entidades.Usuario usuario)
        {
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();
            Parametro parametro = new Parametro();
            ResultadoUsuario resultadoUsuario = new Models.Usuario.ResultadoUsuario();

            try
            {
                parametro = new Parametro();
                parametro.Nombre = "Id";
                parametro.Valor = usuario.Id;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Nombre";
                parametro.Valor = usuario.Nombre;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Usuario";
                parametro.Valor = usuario.Login;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Password";
                parametro.Valor = usuario.Password;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "IdRol";
                parametro.Valor = usuario.IdRol;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Estatus";
                parametro.Valor = 0;
                ListParametro.Add(parametro);

                usuario = Usuario.EditarUsuario(ListParametro);

                ListUsuario = (List<Entidades.Usuario>)Session["ListUsuario"];

                Entidades.Usuario usuarioNew = ListUsuario.Where(n => n.Id == usuario.Id).FirstOrDefault();

                if(usuarioNew != null)
                {
                    usuarioNew.Estatus = false;
                    usuarioNew.StrEstatus = "Inactivo";
                }

                Session["ListUsuario"] = ListUsuario;

                resultadoUsuario.ListaUsuario = ListUsuario.OrderBy(n => n.Nombre).ToList();
                resultadoUsuario.Mensaje = "OK";
            }
            catch (Exception ex)
            {
            }

            return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ActivarUsuario(Entidades.Usuario usuario)
        {
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            Negocio.Usuario.Usuario Usuario = new Negocio.Usuario.Usuario();
            List<Parametro> ListParametro = new List<Parametro>();
            Parametro parametro = new Parametro();
            ResultadoUsuario resultadoUsuario = new Models.Usuario.ResultadoUsuario();

            try
            {
                parametro = new Parametro();
                parametro.Nombre = "Id";
                parametro.Valor = usuario.Id;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Nombre";
                parametro.Valor = usuario.Nombre;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Usuario";
                parametro.Valor = usuario.Login;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Password";
                parametro.Valor = usuario.Password;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "IdRol";
                parametro.Valor = usuario.IdRol;
                ListParametro.Add(parametro);

                parametro = new Parametro();
                parametro.Nombre = "Estatus";
                parametro.Valor = 1;
                ListParametro.Add(parametro);

                usuario = Usuario.EditarUsuario(ListParametro);

                ListUsuario = (List<Entidades.Usuario>)Session["ListUsuario"];

                Entidades.Usuario usuarioNew = ListUsuario.Where(n => n.Id == usuario.Id).FirstOrDefault();

                if (usuarioNew != null)
                {
                    usuarioNew.Estatus = true;
                    usuarioNew.StrEstatus = "Activo";
                }

                Session["ListUsuario"] = ListUsuario;

                resultadoUsuario.ListaUsuario = ListUsuario.OrderBy(n => n.Nombre).ToList();
                resultadoUsuario.Mensaje = "OK";
            }
            catch (Exception ex)
            {
            }

            return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
        }
    }
}