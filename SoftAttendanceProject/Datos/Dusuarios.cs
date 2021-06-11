using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SoftAttendanceProject.Logica;
namespace SoftAttendanceProject.Datos
{
   public  class Dusuarios
    {
		public bool InsertarUsuarios(Lusuarios parametros)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("insertar_usuario", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@nombres", parametros.Nombre);
				cmd.Parameters.AddWithValue("@Login", parametros.Login);
				cmd.Parameters.AddWithValue("@Password", parametros.Password);
				cmd.Parameters.AddWithValue("@Icono", parametros.Icono);
				cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}

		}
		public void mostrar_Usuarios(ref DataTable dt)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlDataAdapter da = new SqlDataAdapter("Select * from Usuarios", CONEXIONMAESTRA.conectar);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace);
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}
	}
}
