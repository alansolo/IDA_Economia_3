using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class BDCapital:BD
    {
        public DataTable ObtenerUsuario(string spName, string usuario)
        {
            DataTable dtUsuario = new DataTable();

            List<SqlParameter> listaUsuario = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@Usuario";
            parametro.Value = usuario;
            listaUsuario.Add(parametro);

            dtUsuario = ExecuteDataTable(spName, listaUsuario);           

            return dtUsuario;
        }
    }
}
