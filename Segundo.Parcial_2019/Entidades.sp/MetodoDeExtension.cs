using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Entidades.sp
{
    public static class MetodoDeExtension
    {
        //Agregar un método de extensión a la clase Cajon que:
        //Reciba como parámetro un entero (será usado como valor del campo ID)
        //Elimine de la base de datos la fruta cuyo ID coincida con el parámetro recibido
        //Retorne un booleano que indique: 
        //TRUE, si se ha eliminado la fruta. 
        //FALSE, si no se elimino.
        //Excepción, si se probocó algún error en la base de datos

        public static bool EliminarFruta(this Cajon<Manzana> cajon,int id)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Entidades.sp.Properties.Settings.Default.Conexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "delete from [sp_lab_II].[dbo].[frutas] where id = " + id.ToString();                
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
                
            }
            return false;
        }
    }
}
