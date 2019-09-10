using Datos.Log;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Log
{
    public class Log
    {
        public List<Entidades.Log> ObtenerLog(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerLog";
            List<Entidades.Log> ListLog = new List<Entidades.Log>();
            BDLog bdLog = new BDLog();
            DataSet dsResultado = new DataSet();
            DataTable dtResultado = new DataTable();
            DataTable dtResultadoDetalle = new DataTable();
            StringBuilder sbResultado = new StringBuilder();
            List<Entidades.LogDetalleDivisa> ListLogDetalleDivisa = new List<Entidades.LogDetalleDivisa>();
            List<Entidades.LogDetalleDinero> ListLogDetalleDinero = new List<Entidades.LogDetalleDinero>();
            List<Entidades.LogDetalleCapital> ListLogDetalleCapital = new List<Entidades.LogDetalleCapital>();

            try
            {
                Resultado = bdLog.ObtenerLog(spName, listParametro);

                dsResultado = (DataSet)Resultado;

                if (dsResultado.Tables[0].Rows.Count > 0)
                {
                    dtResultado = dsResultado.Tables[0];

                    sbResultado.Append("[");

                    dtResultado.Rows.Cast<DataRow>().ToList().ForEach(n =>
                    {
                        sbResultado.Append(n[0].ToString());
                    });

                    sbResultado.Append("]");

                    var jsonLog = JsonConvert.DeserializeObject<Entidades.Log[]>(sbResultado.ToString());
                    ListLog = jsonLog.ToList();

                    if (dsResultado.Tables[1].Rows.Count > 0)
                    {
                        dtResultadoDetalle = dsResultado.Tables[1];

                        sbResultado = new StringBuilder();

                        sbResultado.Append("[");

                        dtResultadoDetalle.Rows.Cast<DataRow>().ToList().ForEach(n =>
                        {
                            sbResultado.Append(n[0].ToString());
                        });

                        sbResultado.Append("]");

                        var jsonLogDetalleDivisa = JsonConvert.DeserializeObject<Entidades.LogDetalleDivisa[]>(sbResultado.ToString());
                        ListLogDetalleDivisa = jsonLogDetalleDivisa.ToList();
                    }
                    else if (dsResultado.Tables[2].Rows.Count > 0)
                    {
                        dtResultadoDetalle = dsResultado.Tables[2];

                        sbResultado = new StringBuilder();

                        sbResultado.Append("[");

                        dtResultadoDetalle.Rows.Cast<DataRow>().ToList().ForEach(n =>
                        {
                            sbResultado.Append(n[0].ToString());
                        });

                        sbResultado.Append("]");

                        var jsonLogDetalleDinero = JsonConvert.DeserializeObject<Entidades.LogDetalleDinero[]>(sbResultado.ToString());
                        ListLogDetalleDinero = jsonLogDetalleDinero.ToList();
                    }
                    else if (dsResultado.Tables[3].Rows.Count > 0)
                    {
                        dtResultadoDetalle = dsResultado.Tables[3];

                        sbResultado = new StringBuilder();

                        sbResultado.Append("[");

                        dtResultadoDetalle.Rows.Cast<DataRow>().ToList().ForEach(n =>
                        {
                            sbResultado.Append(n[0].ToString());
                        });

                        sbResultado.Append("]");

                        var jsonLogDetalleCapital = JsonConvert.DeserializeObject<Entidades.LogDetalleCapital[]>(sbResultado.ToString());
                        ListLogDetalleCapital = jsonLogDetalleCapital.ToList();
                    }

                    ListLog.ForEach(n =>
                    {
                        n.DetalleCapital = ListLogDetalleCapital.Where(m => m.IdLog == n.Id).ToList();
                    });
                }
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public Log InsertLog(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "InsertLog";
            Log log = new Log();
            BDLog bdLog = new BDLog();
            DataTable dtResultado = new DataTable();

            try
            {
                Resultado = bdLog.InsertLog(spName, listParametro);
                dtResultado = (DataTable)Resultado;

                if (dtResultado.Rows.Count > 0)
                {
                    var jsonLog = JsonConvert.DeserializeObject<Log>(dtResultado.Rows[0][0].ToString());
                    log = jsonLog;
                }
                
            }
            catch (Exception ex)
            {
            }

            return log;
        }
        public List<Log> InsertLogDivisa(List<Parametro> listParametro, List<GrupoParametro> listParametroDetalle)
        {
            object Resultado = new object();
            const string spName = "InsertLog";
            const string spNameDetalle = "InsertLogDetalleDivisa";
            List<Log> ListLog = new List<Log>();
            BDLog bdLog = new BDLog();
            DataTable dtResultado = new DataTable();
            StringBuilder sbResultado = new StringBuilder();

            try
            {
                Resultado = bdLog.InsertLog(spName, listParametro, spNameDetalle, listParametroDetalle);

                dtResultado = (DataTable)Resultado;

                if (dtResultado.Rows.Count > 0)
                {
                    sbResultado.Append("[");

                    dtResultado.Rows.Cast<DataRow>().ToList().ForEach(n =>
                    {
                        sbResultado.Append(n[0].ToString());
                    });

                    sbResultado.Append("]");

                    var jsonLog = JsonConvert.DeserializeObject<Log[]>(sbResultado.ToString());
                    ListLog = jsonLog.ToList();
                }
                    
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public List<Log> InsertLogDinero(List<Parametro> listParametro, List<GrupoParametro> listParametroDetalle)
        {
            object Resultado = new object();
            const string spName = "InsertLog";
            const string spNameDetalle = "InsertLogDetalleDinero";
            List<Log> ListLog = new List<Log>();
            BDLog bdLog = new BDLog();
            DataTable dtResultado = new DataTable();
            StringBuilder sbResultado = new StringBuilder();

            try
            {
                Resultado = bdLog.InsertLog(spName, listParametro, spNameDetalle, listParametroDetalle);

                dtResultado = (DataTable)Resultado;

                if (dtResultado.Rows.Count > 0)
                {
                    sbResultado.Append("[");

                    dtResultado.Rows.Cast<DataRow>().ToList().ForEach(n =>
                    {
                        sbResultado.Append(n[0].ToString());
                    });

                    sbResultado.Append("]");

                    var jsonLog = JsonConvert.DeserializeObject<Log[]>(sbResultado.ToString());
                    ListLog = jsonLog.ToList();
                }
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public List<Log> InsertLogCapital(List<Parametro> listParametro, List<GrupoParametro> listParametroDetalle)
        {
            object Resultado = new object();
            const string spName = "InsertLog";
            const string spNameDetalle = "InsertLogDetalleCapital";
            List<Log> ListLog = new List<Log>();
            BDLog bdLog = new BDLog();
            DataTable dtResultado = new DataTable();
            StringBuilder sbResultado = new StringBuilder();

            try
            {
                Resultado = bdLog.InsertLog(spName, listParametro, spNameDetalle, listParametroDetalle);

                dtResultado = (DataTable)Resultado;

                if (dtResultado.Rows.Count > 0)
                {
                    sbResultado.Append("[");

                    dtResultado.Rows.Cast<DataRow>().ToList().ForEach(n =>
                    {
                        sbResultado.Append(n[0].ToString());
                    });

                    sbResultado.Append("]");

                    var jsonLog = JsonConvert.DeserializeObject<Log[]>(sbResultado.ToString());
                    ListLog = jsonLog.ToList();
                }
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public List<LogDetalleDivisa> InsertLogDetalleDivisa(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerLogDetalleDivisa";
            List<LogDetalleDivisa> ListLog = new List<LogDetalleDivisa>();
            BDLog bdLog = new BDLog();


            try
            {
                Resultado = bdLog.InsertLogDetalle(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonLogDetalle = JsonConvert.DeserializeObject<LogDetalleDivisa[]>(Resultado.ToString());
                ListLog = jsonLogDetalle.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public List<LogDetalleDinero> InsertLogDetalleDinero(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerLogDetalleDinero";
            List<LogDetalleDinero> ListLog = new List<LogDetalleDinero>();
            BDLog bdLog = new BDLog();


            try
            {
                Resultado = bdLog.InsertLogDetalle(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonLogDetalle = JsonConvert.DeserializeObject<LogDetalleDinero[]>(Resultado.ToString());
                ListLog = jsonLogDetalle.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
    }
}
