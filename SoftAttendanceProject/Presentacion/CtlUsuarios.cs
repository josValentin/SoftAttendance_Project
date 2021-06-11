using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoftAttendanceProject.Datos;
using SoftAttendanceProject.Logica;
using System.IO;

namespace SoftAttendanceProject.Presentacion
{
    public partial class CtlUsuarios : UserControl
    {
        public CtlUsuarios()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Limpiar();
            habilitarPaneles();
            MostrarModulos();
        }
        private void Limpiar()
        {
            txtnombre.Clear();
            txtcontraseña.Clear();
            txtusuario.Clear();
        }
        private void habilitarPaneles()
        {
            panelRegistro.Visible = true;
            lblanuncioIcono.Visible = true;
            panelIcono.Visible = false;
            panelRegistro.Dock = DockStyle.Fill;
            panelRegistro.BringToFront();
            btnguardar.Visible = true;
            btnActualizar.Visible = false;
        }
        private void MostrarModulos()
        {
            Dmodulos funcion = new Dmodulos();
            DataTable dt = new DataTable();
            funcion.mostrar_Modulos(ref dt);
            datalistadoModulos.DataSource = dt;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtnombre.Text))
            {
                if (!string.IsNullOrEmpty(txtusuario.Text))
                {
                    if (!string.IsNullOrEmpty(txtcontraseña.Text))
                    {
                        if (lblanuncioIcono.Visible == false)
                        {
                            insertarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un Icono");
                           
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ingrese la contraseña");
                       

                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el Usuario");
                   

                }
            }
            else
            {
               
                MessageBox.Show("Ingrese el Nombre");
            }

        }
        private void insertarUsuarios()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.Nombre = txtnombre.Text;
            parametros.Login = txtusuario.Text;
            parametros.Password = txtcontraseña.Text;
            MemoryStream ms = new MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();
            if(funcion.InsertarUsuarios(parametros)==true)
            {

            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
