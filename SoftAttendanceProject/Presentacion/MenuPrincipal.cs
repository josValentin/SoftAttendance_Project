﻿using SoftAttendanceProject.Datos;
using SoftAttendanceProject.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SoftAttendanceProject.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        public int Idusuario;
        public string LoginV;


        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panelbienvenida.Dock = DockStyle.Fill;
            ValidarPermisos();
        }

        private void ValidarPermisos()
        {
            DataTable dt = new DataTable();
            Dpermisos funcion = new Dpermisos();
            Lpermisos parametros = new Lpermisos();
            parametros.IdUsuario = Idusuario;
            funcion.mostrar_Permisos(ref dt, parametros);
            btnConsultas.Enabled = false;
            btnPersonal.Enabled = false;
            btnRegistro.Enabled = false;
            btnUsuarios.Enabled = false;

            btnRestaurar.Enabled = false;
            btnRespaldos.Enabled = false;

            foreach (DataRow rowPermisos in dt.Rows)
            {
                string Modulo = Convert.ToString(rowPermisos["Modulo"]);
                if(Modulo == "PrePlanillas")
                {
                    btnConsultas.Enabled = true;
                }
                if (Modulo == "Usuarios")
                {
                    btnUsuarios.Enabled = true;
                    btnRegistro.Enabled = true;
                }
                if (Modulo == "Personal")
                {
                    btnPersonal.Enabled = true;
                }
                if (Modulo == "Respaldos")
                {
                    btnRespaldos.Enabled = true;
                    btnRestaurar.Enabled = true;
                }

            }
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            PanelPadre.Controls.Clear();
            Preplanilla control = new Preplanilla();
            control.Dock = DockStyle.Fill;
            PanelPadre.Controls.Add(control);
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
           
            PanelPadre.Controls.Clear();
            Personal control = new Personal();
            control.Dock = DockStyle.Fill;
            PanelPadre.Controls.Add(control);
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            PanelPadre.Controls.Clear();
            CtlUsuarios control = new CtlUsuarios();
            control.Dock = DockStyle.Fill;
            PanelPadre.Controls.Add(control);
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Dispose();
            TomarAsistencias frm = new TomarAsistencias();
            frm.ShowDialog();
        }
    }
}
