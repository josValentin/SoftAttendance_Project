using SoftAttendanceProject.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SoftAttendanceProject.Presentacion.AsistenteInstalacion
{
    public partial class ConexionRemota : Form
    {
        public ConexionRemota()
        {
            InitializeComponent();
        }
        string cadena_de_conexion;
        string indicador_de_conexion;
        private AES aes = new AES();
        int id;

        private void btnconectar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIp.Text))
            {
                conectar_manualmente();
            }
            else
            {
                MessageBox.Show("Ingresa la IP", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void conectar_manualmente()
        {
            string IP = txtIp.Text;
            cadena_de_conexion = "Data Source = " + IP + ";Initial Caralog=SOFT_ATTENDANCE;Integrated Security=False;User Id=SA_USER; Password=1234";
            comprobar_conexion();
            if (indicador_de_conexion == "HAY CONEXION")
            {
                SaveToXML(aes.Encrypt(cadena_de_conexion, Desencryptacion.appPwdUnique, int.Parse("256")));
                MessageBox.Show("Conexion Correcta. Vuelve a Abrir el Sistema", "Conexión remota", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SaveToXML(object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writter = new XmlTextWriter("ConnectionString.xml", null);
            writter.Formatting = Formatting.Indented;
            doc.Save(writter);
            writter.Close();
        }

        private void comprobar_conexion()
        {
            try
            {
                SqlConnection conexionManual = new SqlConnection(cadena_de_conexion);
                conexionManual.Open();
                SqlCommand da = new SqlCommand("Select * from Usuarios", conexionManual);
                id = Convert.ToInt32(da.ExecuteScalar());
                indicador_de_conexion = "HAY CONEXION";
            }
            catch (Exception)
            {

                indicador_de_conexion = "NO HAY CONEXION";
            }
        }
    }
}
