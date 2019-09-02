using Datos.MercadoCapital;
using Datos.Usuario;
using Entidades;
using Negocio.MercadoCapital;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.MercadoCapital
{
    public class MercadoCapital
    {
        public List<CatCapital> ObtenerCatCapital(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerCatDivisa";
            List<CatCapital> ListCatCapital = new List<CatCapital>();
            BDMercadoCapital bdMercadoCapital = new BDMercadoCapital();


            try
            {
                Resultado = bdMercadoCapital.ObtenerCatCapital(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonCatCapital = JsonConvert.DeserializeObject<CatCapital[]>(Resultado.ToString());
                ListCatCapital = jsonCatCapital.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListCatCapital;
        }
    }
}
