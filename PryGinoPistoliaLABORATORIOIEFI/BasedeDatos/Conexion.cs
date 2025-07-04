﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PryGinoPistoliaLABORATORIOIEFI.BasedeDatos
{
    public class Conexion
    {
        public void Conectar(DataGridView dgv)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS02;Database=Administracion;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    dgv.Rows.Clear();
                    connection.Open();
                    MessageBox.Show("Datos guardados correctamente");
                    string query = "SELECT * FROM Usuarios";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv.DataSource = table;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Los datos presentan error" + ex.Message);
                }
            }
        }
    }
}
