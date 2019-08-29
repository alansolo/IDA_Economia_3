using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.MercadoCapital
{
    public class BDCapital:BD
    {
        public DataTable ObtenerUsuario(string spName, List<Parametro> listParametro)
        {
            DataTable dtUsuario = new DataTable();
            List<SqlParameter> listParametrosSQL = new List<SqlParameter>();

            try
            {
                listParametrosSQL = listParametro.Select(n => new SqlParameter
                {
                    ParameterName = "@" + n.Nombre,
                    Value = n.Valor
                }).ToList();

                dtUsuario = ExecuteDataTable(spName, listParametrosSQL);
            }
            catch (Exception ex)
            {
            }

            return dtUsuario;
        }
    }
}
