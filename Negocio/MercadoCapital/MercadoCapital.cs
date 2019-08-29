using Datos.MercadoCapital;
using Entidades;
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
        public DataTable ObtenerUsuario(List<Parametro> listParametro)
        {
            DataTable dtUsuario = new DataTable();
            const string spName = "ObtenerUsuario";
            BDCapital bdCapital = new BDCapital();

            try
            {
                dtUsuario = bdCapital.ObtenerUsuario(spName, listParametro);
            }
            catch (Exception ex)
            {
            }

            return dtUsuario;
        }
    }
}
