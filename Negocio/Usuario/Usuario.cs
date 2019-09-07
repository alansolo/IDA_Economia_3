using Datos.Usuario;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Usuario
{
    public class Usuario
    {
        public List<Entidades.Usuario> ObtenerUsuario(List<Parametro> listParametro)
        {
            object Resultado = new object();
            List<Entidades.Usuario> ListUsuario = new List<Entidades.Usuario>();
            const string spName = "ObtenerUsuario";
            BDUsuario bdUsuario = new BDUsuario();

            try
            {
                Resultado = bdUsuario.ObtenerUsuario(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonListUsuario = JsonConvert.DeserializeObject<Entidades.Usuario[]>(Resultado.ToString());
                ListUsuario = jsonListUsuario.ToList();
            }
            catch (Exception ex)
            {
            }

            return ListUsuario;
        }
        public Entidades.Usuario AgregarUsuario(List<Parametro> listParametro)
        {
            object Resultado = new object();
            Entidades.Usuario usuario = new Entidades.Usuario();
            const string spName = "InsertUsuario";
            BDUsuario bdUsuario = new BDUsuario();

            try
            {
                Resultado = bdUsuario.InsertUsuario(spName, listParametro);

                Resultado = "[" + Resultado + "]";

                var jsonListUsuario = JsonConvert.DeserializeObject<Entidades.Usuario>(Resultado.ToString());
                usuario = jsonListUsuario;
            }
            catch (Exception ex)
            {
            }

            return usuario;
        }
    }
}
