using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDA_Economia.Models.Log
{
     
    public class ResultadoLog
    {
        public List<Entidades.Log> ListaLog { get; set; }
        public string Mensaje { get; set; }
    }
}