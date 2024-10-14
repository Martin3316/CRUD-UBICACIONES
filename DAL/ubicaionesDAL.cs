using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class ubicaionesDAL
    {
        SQLDBHelper oConexion;
        //Inicializar la conexion con la BD (Constructor)
        public ubicaionesDAL() 
        {
          oConexion = new SQLDBHelper();
        }
        public bool Agregar(ubicaciones_BLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "INSERT INTO Direcciones (Ubicacion, Latitud, Longitud) VALUES (@Ubicacion, @Latitud, @Longitud)";
            cmdComando.Parameters.Add("@Ubicacion",SqlDbType.VarChar).Value=OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return oConexion.EjecutarComandoSQL(cmdComando);

        }

        public bool Eliminar(int ID)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "DELETE FROM Direcciones WHERE ID = @ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            return oConexion.EjecutarComandoSQL(cmdComando);


        }

        public bool Modificar(ubicaciones_BLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "UPDATE Direcciones SET Ubicacion = @Ubicacion, Latitud = @Latitud, Longitud = @Longitud WHERE ID = @ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = OubicacionesBLL.ID;
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return oConexion.EjecutarComandoSQL(cmdComando);

        }
        //Seleccionar los registros de la tabla mediante un SELECT
        public DataTable Listar()
        {
            SqlCommand cmdComando = new SqlCommand();
           //Sentencia SQL para traer todos los registros de la tabla "Direcciones"
            cmdComando.CommandText = "SELECT * FROM Direcciones"; 
            //Tipo de comando, ya sea texto, sp, etc.
            cmdComando.CommandType = CommandType.Text;

            DataTable TablaResultante = oConexion.EjecutarSentenciaSQL(cmdComando);

            return TablaResultante;
        }
    }
}
