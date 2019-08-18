using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDA_Economia.Models.MercadoCapital
{
    public class ResultadoMercadoCapital
    {
        public List<Empresa> ListaEmpresa { get; set; }
        public List<CurvaVarianza> ListaCurvaVarianza { get; set; }
        public List<CalculoMercadoCapital> ListaCalculoMercadoCapital { get; set; }
    }
}