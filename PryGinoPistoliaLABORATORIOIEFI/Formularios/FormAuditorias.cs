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
    public partial class FormAuditorias : Form
    {
        public string connectionString = "Server=localhost\\SQLEXPRESS02;Database=Administracion;Trusted_Connection=True";
        public Conexion conexion = new Conexion( );


        public FormAuditorias()
        {
            InitializeComponent();
            CargarAuditoria();
        }
        private void CargarAuditoria()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string consulta = "SELECT Id, Nombre, Puesto, Tarea, Estado FROM Auditoria";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvAuditorias.DataSource = tabla;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la auditoría: " + ex.Message);
            }
        }
    }
}
