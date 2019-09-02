using Datos.Usuario;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Login
{
    public class Login
    {
        public Entidades.Usuario ObtenerUsuario(List<Parametro> listParametro)
        {
            object Resultado = new object();
            Entidades.Usuario Usuario = new Entidades.Usuario();
            const string spName = "ObtenerUsuario";
            BDUsuario bdUsuario = new BDUsuario();

            try
            {
                Resultado = bdUsuario.ObtenerUsuario(spName, listParametro);

                var jsonUsuario = JsonConvert.DeserializeObject<Entidades.Usuario>(Resultado.ToString());
                Usuario = jsonUsuario;
            }
            catch (Exception ex)
            {
            }

            return Usuario;
        }
    }
}
