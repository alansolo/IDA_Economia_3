﻿using Datos.Log;
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
        public List<Entidades.Log> ObtenerLog(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "ObtenerLog";
            List<Entidades.Log> ListLog = new List<Entidades.Log>();
            BDLog bdLog = new BDLog();


            try
            {
                Resultado = bdLog.ObtenerLog(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonLog = JsonConvert.DeserializeObject<Entidades.Log[]>(Resultado.ToString());
                ListLog = jsonLog.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListLog;
        }
        public List<Log> InsertLog(List<Parametro> listParametro)
        {
            object Resultado = new object();
            const string spName = "InsertLog";
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
        public List<Log> InsertLogDivisa(List<Parametro> listParametro, List<GrupoParametro> listParametroDetalle)
        {
            object Resultado = new object();
            const string spName = "InsertLog";
            const string spNameDetalle = "InsertLogDetalleDivisa";
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
        public List<Log> InsertLogDinero(List<Parametro> listParametro, List<GrupoParametro> listParametroDetalle)
        {
            object Resultado = new object();
            const string spName = "InsertLog";
            const string spNameDetalle = "InsertLogDetalleDinero";
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
        public List<Log> InsertLogCapital(List<Parametro> listParametro, List<GrupoParametro> listParametroDetalle)
        {
            object Resultado = new object();
            const string spName = "InsertLog";
            const string spNameDetalle = "InsertLogDetalleCapital";
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
