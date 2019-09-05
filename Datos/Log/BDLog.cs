using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Log
{
    public class BDLog:BD
    {
        public object ObtenerLog(string spName, List<Parametro> listParametro)
        {
            object Resultado = new object();
            List<SqlParameter> listParametrosSQL = new List<SqlParameter>();

            try
            {
                listParametrosSQL = listParametro.Select(n => new SqlParameter
                {
                    ParameterName = "@" + n.Nombre,
                    Value = n.Valor
                }).ToList();

                Resultado = ExecuteScalar(spName, listParametrosSQL);
            }
            catch (Exception ex)
            {
            }

            return Resultado;
        }
        public object ObtenerLogDetalle(string spName, List<Parametro> listParametro)
        {
            object Resultado = new object();
            List<SqlParameter> listParametrosSQL = new List<SqlParameter>();

            try
            {
                listParametrosSQL = listParametro.Select(n => new SqlParameter
                {
                    ParameterName = "@" + n.Nombre,
                    Value = n.Valor
                }).ToList();

                Resultado = ExecuteScalar(spName, listParametrosSQL);
            }
            catch (Exception ex)
            {
            }

            return Resultado;
        }
        public object InsertLog(string spName, List<Parametro> listParametro, string spNameDetalle, List<GrupoParametro> listParametroDetalle)
        {
            object Resultado = new object();
            List<SqlParameter> listParametrosSQL = new List<SqlParameter>();
            List<SqlParameterGroup> listParametrosDetalleSQL = new List<SqlParameterGroup>();

            try
            {
                listParametrosSQL = listParametro.Select(n => new SqlParameter
                {
                    ParameterName = "@" + n.Nombre,
                    Value = n.Valor
                }).ToList();

                listParametroDetalle.ForEach(n =>
                {
                    SqlParameterGroup group = new SqlParameterGroup();

                    group.ListSqlParameter =
                        n.ListGrupoParametro.Select(m => new SqlParameter
                        {
                            ParameterName = "@" + m.Nombre,
                            Value = m.Valor
                        }).ToList();

                    listParametrosDetalleSQL.Add(group);
                });

               

                Resultado = ExecuteScalar(spName, listParametrosSQL, spNameDetalle, listParametrosDetalleSQL);
            }
            catch (Exception ex)
            {
            }

            return Resultado;
        }
        public object InsertLog(string spName, List<Parametro> listParametro)
        {
            object Resultado = new object();
            List<SqlParameter> listParametrosSQL = new List<SqlParameter>();

            try
            {
                listParametrosSQL = listParametro.Select(n => new SqlParameter
                {
                    ParameterName = "@" + n.Nombre,
                    Value = n.Valor
                }).ToList();

                Resultado = ExecuteScalar(spName, listParametrosSQL);
            }
            catch (Exception ex)
            {
            }

            return Resultado;
        }
        public object InsertLogDetalle(string spName, List<Parametro> listParametro)
        {
            object Resultado = new object();
            List<SqlParameter> listParametrosSQL = new List<SqlParameter>();

            try
            {
                listParametrosSQL = listParametro.Select(n => new SqlParameter
                {
                    ParameterName = "@" + n.Nombre,
                    Value = n.Valor
                }).ToList();

                Resultado = ExecuteScalar(spName, listParametrosSQL);
            }
            catch (Exception ex)
            {
            }

            return Resultado;
        }
    }
}
