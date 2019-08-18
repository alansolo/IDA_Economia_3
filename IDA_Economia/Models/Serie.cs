using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IDA_Economia.Models
{
    public class Serie
    {
        public string Title { get; set; }

        public string IdSerie { get; set; }


        public DataSerie[] Data { get; set; }
    }
}