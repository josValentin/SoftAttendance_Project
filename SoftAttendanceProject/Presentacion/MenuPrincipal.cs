﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//23654

namespace SoftAttendanceProject.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panelbienvenida.Dock = DockStyle.Fill;
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            //PRUEBA
            PanelPadre.Controls.Clear();
            Personal control = new Personal();
            control.Dock = DockStyle.Fill;
            PanelPadre.Controls.Add(control);
        }
    }
}
