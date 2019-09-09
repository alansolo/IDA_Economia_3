using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Log
    {
        public long Id { get; set; }
        public string Usuario { get; set; }
        public DateTime Creado { get; set; }
        public string Modulo { get; set; }
        public string Empresa { get; set; }
        public string Resumen { get; set; }
        public string Detalle { get; set; }
        public LogDetalleDivisa DetalleDivisa { get; set; }
        public LogDetalleDinero DetalleDinero { get; set; }
        public LogDetalleCapital DetalleCapital { get; set; }
    }
}
