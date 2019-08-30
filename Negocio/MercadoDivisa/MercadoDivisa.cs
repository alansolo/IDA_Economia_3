using Datos.MercadoDivisa;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio.MercadoDivisa
{
    public class MercadoDivisa
    {
        public List<CatDivisa> ObtenerCatDivisa(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerCatDivisa";
            List<CatDivisa> ListCatDivisa = new List<CatDivisa>();
            BDMercadoDivisa bdMercadoDivisa = new BDMercadoDivisa();


            try
            {
                Resultado = bdMercadoDivisa.ObtenerCatDivisa(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonCatDivisa = JsonConvert.DeserializeObject<CatDivisa[]>(Resultado.ToString());
                ListCatDivisa = jsonCatDivisa.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListCatDivisa;
        }
    }
}
