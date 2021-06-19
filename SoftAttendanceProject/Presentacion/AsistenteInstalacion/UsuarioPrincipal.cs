using SoftAttendanceProject.Datos;
using SoftAttendanceProject.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftAttendanceProject.Presentacion.AsistenteInstalacion
{
    public partial class UsuarioPrincipal : Form
    {
        public UsuarioPrincipal()
        {
            InitializeComponent();

            txtContraseña.KeyPress += ContraseñaKeyPress;
            txtConfirmarContraseña.KeyPress += ContraseñaKeyPress;
        }
        int idUsuario;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (!string.IsNullOrEmpty(txtContraseña.Text))
                {
                    if(txtContraseña.Text == txtConfirmarContraseña.Text)
                    {
                        InsertarUsuarioDefecto();
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Falta ingresar la contraseña", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Falta ingresar el Nombre", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InsertarUsuarioDefecto()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.Nombre = txtNombre.Text;
            parametros.Login = txtUsuario.Text;
            parametros.Password = txtContraseña.Text;
            MemoryStream ms = new MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();
            if(funcion.InsertarUsuarios(parametros) == true)
            {
                Insertar_Modulos();
                ObtenerIdUsusario();
                InsertarPermisos();
            }

        }
        private void InsertarPermisos()
        {
            DataTable dt = new DataTable();
            Dmodulos funcionModulos = new Dmodulos();
            funcionModulos.mostrar_Modulos(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                int idModulo = Convert.ToInt32(row["IdModulo"]);
                Lpermisos parametros = new Lpermisos();
                Dpermisos funcion = new Dpermisos();
                parametros.IdModulo = idModulo;
                parametros.IdUsuario = idUsuario;
                funcion.Insertar_Permisos(parametros);

            }
            MessageBox.Show("!LISTO¡ RECUERDA que para Iniciar Sesión tu Usuario es: " + txtUsuario.Text + " y tu Contraseña es: " + txtContraseña.Text, "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
            Login frm = new Login();
            frm.ShowDialog();
        }

        private void ObtenerIdUsusario()
        {
            Dusuarios funcion = new Dusuarios();
            funcion.ObtenerIdUsuario(ref idUsuario, txtUsuario.Text);
        }

        private void Insertar_Modulos()
        {
            Lmodulos parametros = new Lmodulos();
            Dmodulos funcion = new Dmodulos();
            var Modulos = new List<string> { "Usuarios", "Respaldos", "Personal", "PrePlanillas"};
            foreach (var Modulo in Modulos)
            {
                parametros.Modulo = Modulo;
                funcion.Insertar_Modulos(parametros);
            }
        }


        private void ContraseñaKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
