using ClosedXML.Excel;
using Entidades;
using IDA_Economia.Models;
using IDA_Economia.Models.MercadoDinero;
using Negocio.MercadoDinero;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace IDA_Economia.Controllers
{
    public class MercadoDineroController : Controller
    {
        // GET: MercadoDinero
        [HttpGet]
        public ActionResult MercadoDinero()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public JsonResult ObtenerCatDinero()
        {
            List<CatDinero> ListCatDinero = new List<CatDinero>();

            MercadoDinero mercadoDinero = new MercadoDinero();
            List<Parametro> ListParametro = new List<Parametro>();

            ListCatDinero = mercadoDinero.ObtenerCatDinero(ListParametro);

            return Json(ListCatDinero, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerEstadistico(string strFechaInicio, string strFechaFinal)
        {
            ResultadoMercadoDinero resultadoMercadoDinero = new ResultadoMercadoDinero();
            resultadoMercadoDinero.ListaDatos = new List<DatosDinero>();
            DatosDinero datosDinero = new DatosDinero();

            try
            {
                //Se solicita la información al cliente para definir el código que realizará la petición al API:
                //string valor = "";
                string seriesID = "";
                string fechainicio = "";
                string fechafinal = "";

                seriesID = "SF43936";

                fechainicio = Convert.ToDateTime(strFechaInicio).ToString("yyyy-MM-dd");

                fechafinal = Convert.ToDateTime(strFechaFinal).ToString("yyyy-MM-dd");

                string url = "https://www.banxico.org.mx/SieAPIRest/service/v1/series/" + seriesID + "/datos/" + fechainicio + "/" + fechafinal;


                //Se crea una cadena con los valores que se requiera consumir
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Accept = "application/json; charset=utf-8";
                request.Headers["Bmx-Token"] = "6af6e6645653ed1cb3ecb5165c3d30df2d5289600811f7067b2169c9ff030eb4";
                //request.Method = "GET";
                request.PreAuthenticate = true;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));

                //De esta forma se obtiene el JSON de la respuesta en una cadena. Esta cadena puede ser mapeada a objetos de la siguiente forma:
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));


                object c = jsonSerializer.ReadObject(response.GetResponseStream());

                Response resBan = (Response)c;

                var uno1 = resBan.seriesResponse.series[0];

                //LINQ C#
                //PARA BUSCAR MAS INFORMACION
                //var dos1 = uno1.Data.Where(n => (Convert.ToDecimal(n.Data)) > 9).ToList();

                var dos1 = uno1.Data.ToList();

                DataTable dt1 = new DataTable();

                dt1.Columns.Add("Fecha");
                dt1.Columns.Add("Valor");


                int cont = 0;
                dos1.ForEach(m =>
                {
                    dt1.Rows.Add(m.Date, Convert.ToDouble(m.Data).ToString("0.00##"));

                    datosDinero = new DatosDinero();
                    datosDinero.Fecha = m.Date;
                    datosDinero.Valor = Convert.ToDouble(m.Data);

                    resultadoMercadoDinero.ListaDatos.Add(datosDinero);

                    cont++;
                });


                Session["dtInformacionDinero"] = dt1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return Json(resultadoMercadoDinero, JsonRequestBehavior.AllowGet);
        }
        public void ExportarExcel()
        {
            string nombreArchivo = "Historico_Dinero.xlsx";
            string hojaArchivo = "Dinero";
            DataTable dtInformacion = (DataTable)Session["dtInformacionDinero"];

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dtInformacion, hojaArchivo);

                Response.ClearContent();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition", "attachment; filename=" + nombreArchivo);

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }

            }
        }
    }
}