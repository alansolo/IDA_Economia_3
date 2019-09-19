using Datos.Usuario;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
            DataTable dtResultado = new DataTable();
            StringBuilder sbResultado = new StringBuilder();

            try
            {
                Resultado = bdUsuario.ObtenerUsuario(spName, listParametro);

                dtResultado = (DataTable)Resultado;

                if (dtResultado.Rows.Count > 0)
                {
                    sbResultado.Append("[");

                    dtResultado.Rows.Cast<DataRow>().ToList().ForEach(n =>
                    {
                        sbResultado.Append(n[0].ToString());
                    });

                    sbResultado.Append("]");
                }

                var jsonListUsuario = JsonConvert.DeserializeObject<Entidades.Usuario[]>(sbResultado.ToString());
                ListUsuario = jsonListUsuario.ToList();

                ListUsuario.ForEach(n =>
                {
                    if (n.Estatus)
                    {
                        n.StrEstatus = "Activo";
                    }
                    else
                    {
                        n.StrEstatus = "Inactivo";
                    }
                });
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
            DataTable dtResultado = new DataTable();

            try
            {
                Resultado = bdUsuario.InsertUsuario(spName, listParametro);

                if (dtResultado.Rows.Count > 0)
                {
                    var jsonListUsuario = JsonConvert.DeserializeObject<Entidades.Usuario>(dtResultado.Rows[0][0].ToString());
                    usuario = jsonListUsuario;
                }
                
            }
            catch (Exception ex)
            {
            }

            return usuario;
        }
        public Entidades.Usuario EditarUsuario(List<Parametro> listParametro)
        {
            object Resultado = new object();
            Entidades.Usuario usuario = new Entidades.Usuario();
            const string spName = "UpdateUsuario";
            BDUsuario bdUsuario = new BDUsuario();
            DataTable dtResultado = new DataTable();

            try
            {
                Resultado = bdUsuario.EditarUsuario(spName, listParametro);

                if (dtResultado.Rows.Count > 0)
                {
                    var jsonListUsuario = JsonConvert.DeserializeObject<Entidades.Usuario>(dtResultado.Rows[0][0].ToString());
                    usuario = jsonListUsuario;
                }

            }
            catch (Exception ex)
            {
            }

            return usuario;
        }
        public Entidades.Usuario EliminarUsuario(List<Parametro> listParametro)
        {
            object Resultado = new object();
            Entidades.Usuario usuario = new Entidades.Usuario();
            const string spName = "UpdateUsuario";
            BDUsuario bdUsuario = new BDUsuario();
            DataTable dtResultado = new DataTable();

            try
            {
                Resultado = bdUsuario.EliminarUsuario(spName, listParametro);

                if (dtResultado.Rows.Count > 0)
                {
                    var jsonListUsuario = JsonConvert.DeserializeObject<Entidades.Usuario>(dtResultado.Rows[0][0].ToString());
                    usuario = jsonListUsuario;
                }

            }
            catch (Exception ex)
            {
            }

            return usuario;
        }

    }
}
