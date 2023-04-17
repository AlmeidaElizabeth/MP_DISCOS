using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DISCOS
{
    internal class DISCOS_DATOS
    {
        public List<DISCO> Listar()
        {

            List<DISCO> lista = new List<DISCO>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Titulo, FechaLanzamiento, UrlImagenTapa from DISCOS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    DISCO aux = new DISCO();
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaDeLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.UrlImagen = (string)lector["UrlImagenTapa"];

                    lista.Add(aux);


                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally { conexion.Close(); }

        }
    }
}
