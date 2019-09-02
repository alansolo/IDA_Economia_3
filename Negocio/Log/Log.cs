using Datos.Log;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Log
{
    public class Log
    {
        public List<Log> ObtenerLog(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerLog";
            List<Log> ListLog = new List<Log>();
            BDLog bdLog = new BDLog();


            try
            {
                Resultado = bdLog.ObtenerLog(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonLog = JsonConvert.DeserializeObject<Log[]>(Resultado.ToString());
                ListLog = jsonLog.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public List<LogDetalle> ObtenerLogDetalle(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerLogDetalle";
            List<LogDetalle> ListLog = new List<LogDetalle>();
            BDLog bdLog = new BDLog();


            try
            {
                Resultado = bdLog.ObtenerLogDetalle(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonLogDetalle = JsonConvert.DeserializeObject<LogDetalle[]>(Resultado.ToString());
                ListLog = jsonLogDetalle.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public List<Log> InsertLog(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerLog";
            List<Log> ListLog = new List<Log>();
            BDLog bdLog = new BDLog();


            try
            {
                Resultado = bdLog.InsertLog(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonLog = JsonConvert.DeserializeObject<Log[]>(Resultado.ToString());
                ListLog = jsonLog.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public List<Log> InsertLog(List<Parametro> listParametro, List<Parametro> listParametroDetalle)
        {
            object Resultado = new object();
            const string spName = "ObtenerLog";
            const string spNameDetalle = "ObtenerLogDetalle";
            List<Log> ListLog = new List<Log>();
            BDLog bdLog = new BDLog();


            try
            {
                Resultado = bdLog.InsertLog(spName, listParametro, spNameDetalle, listParametroDetalle);

                Resultado = "[" + Resultado + "]";

                var jsonLog = JsonConvert.DeserializeObject<Log[]>(Resultado.ToString());
                ListLog = jsonLog.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public List<LogDetalle> InsertLogDetalle(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerLogDetalle";
            List<LogDetalle> ListLog = new List<LogDetalle>();
            BDLog bdLog = new BDLog();


            try
            {
                Resultado = bdLog.InsertLogDetalle(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonLogDetalle = JsonConvert.DeserializeObject<LogDetalle[]>(Resultado.ToString());
                ListLog = jsonLogDetalle.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
    }
}
