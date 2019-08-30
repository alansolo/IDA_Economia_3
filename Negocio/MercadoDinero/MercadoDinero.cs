using Datos.MercadoDinero;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.MercadoDinero
{
    public class MercadoDinero
    {
        public List<CatDinero> ObtenerCatDivisa(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerCatDinero";
            List<CatDinero> ListCatDinero = new List<CatDinero>();
            BDMercadoDinero bdMercadoDivisa = new BDMercadoDinero();


            try
            {
                Resultado = bdMercadoDivisa.ObtenerCatDinero(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonCatDinero = JsonConvert.DeserializeObject<CatDinero[]>(Resultado.ToString());
                ListCatDinero = jsonCatDinero.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListCatDinero;
        }
    }
}
