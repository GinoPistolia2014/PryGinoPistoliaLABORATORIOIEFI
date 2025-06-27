using PryGinoPistoliaLABORATORIOIEFI.BasedeDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PryGinoPistoliaLABORATORIOIEFI.Formularios
{
    public partial class FormPrincipal : Form
    {
        public string connectionString = "Server=localhost\\SQLEXPRESS02;Database=master;Trusted_Connection=True";
        Conexion conexion = new Conexion();
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.Show();
        }

        private void auditoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAuditorias formAuditorias= new FormAuditorias();
            formAuditorias.Show();
        }
    }
}
