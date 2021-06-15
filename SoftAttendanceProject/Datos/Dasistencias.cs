﻿using SoftAttendanceProject.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftAttendanceProject.Datos
{
  public class Dasistencias
    {
		public void buscarAsistenciasId(ref DataTable dt, int Idpersonal)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlDataAdapter da = new SqlDataAdapter("buscarAsistenciasId", CONEXIONMAESTRA.conectar);
				da.SelectCommand.CommandType = CommandType.StoredProcedure;
				da.SelectCommand.Parameters.AddWithValue("@Idpersonal", Idpersonal);
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
		public bool InsertarAsistencias(Lasistencias parametros)
		{
			try 
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("Insertar_ASISTENCIAS", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Id_personal", parametros.Id_personal);
				cmd.Parameters.AddWithValue("@Fecha_entrada", parametros.Fecha_entrada);
				cmd.Parameters.AddWithValue("@Fecha_salida", parametros.Fecha_salida);
				cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
				cmd.Parameters.AddWithValue("@Horas", parametros.Horas);
				cmd.Parameters.AddWithValue("@Observacion", parametros.Observacion);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace);
				return false;
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}
		public bool ConfirmarSalida(Lasistencias parametros)
		{
			try
			{
				CONEXIONMAESTRA.abrir();

				SqlCommand cmd = new SqlCommand("ConfirmarSalida", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Id_personal", parametros.Id_personal);
				cmd.Parameters.AddWithValue("@Fecha_salida", parametros.Fecha_salida);
				cmd.Parameters.AddWithValue("@Horas", parametros.Horas);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace);
				return false;
			}
			finally
			{
				CONEXIONMAESTRA.cerrar();
			}
		}

	}
}
