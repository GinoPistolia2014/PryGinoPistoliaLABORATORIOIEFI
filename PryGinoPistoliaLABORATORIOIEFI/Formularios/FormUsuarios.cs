using PryGinoPistoliaLABORATORIOIEFI.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryGinoPistoliaLABORATORIOIEFI.Formularios
{
    public partial class FormUsuarios : Form
    {
        public string connectionString = "Server=localhost\\SQLEXPRESS02;Database=Administracion;Trusted_Connection=True";
        Conexion conexion = new Conexion();
        Usuarios usuarios = new Usuarios();
        public class Conexion
        {
        }

        public FormUsuarios()
        {
            InitializeComponent();
            

        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            conexion.Conectar(dgvUsuarios);
            


            cmbTarea.Items.Clear();
            cmbTarea.Items.Add("Gestion de Personal");
            cmbTarea.Items.Add("Encargado de los clientes");
            cmbTarea.Items.Add("Control de insumos");
            cmbTarea.SelectedIndex = 0;


            txtId.Text = "";
            txtNombre.Text = "";
            txtPuesto.Text = "";

            string Id = txtId.Text;
            string Nombre = txtNombre.Text;
            string Puesto = txtPuesto.Text;

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Usuarios (Id,Nombre, Puesto, Tarea) VALUES (@id, @Nombre, @Puesto, @Tarea)";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                int Id = Convert.ToInt32(txtId.Text);
                cmd.Parameters.AddWithValue("@Codigo", txtId.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Titulo", txtPuesto.Text);
                cmd.Parameters.AddWithValue("@Tarea", cmbTarea.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario guardado exitosamente.");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Id, Titulo, Nombre, Puesto, Tarea FROM Usuarios WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtId.Text = reader["Id"].ToString();
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtPuesto.Text = reader["Puesto"].ToString();
                        cmbTarea.Text = reader["Tarea"].ToString();

                        MessageBox.Show("Consulta realizada exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string updateQuery = "UPDATE Usuarios SET Id = @Titulo, Nombre = @Nombre, Puesto = @Puesto, Tarea = @Tarea WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Puesto", txtPuesto.Text);
                cmd.Parameters.AddWithValue("@Tarea", cmbTarea.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario modificado exitosamente.");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Usuarios WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("El usuario eliminado exitosamente.");

            }
        }
        public static List<Usuarios> ObtenerTodos()
        {
            List<Usuarios> lista = new List<Usuarios>();

            using (SqlConnection conn = new Conexion().ObtenerConexion())
            {
                string query = "SELECT * FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // crea un objeto fila por fila
                    Usuarios usuarios = new Usuarios
                    {
                        // reader.GetOrdinal() <-- Obtiene el indice de la columna y despues lee el valor
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Puesto = reader.GetString(reader.GetOrdinal("Puesto")),
                        Tarea = reader.GetString(reader.GetOrdinal("Tarea")),
                    };

                    lista.Add(usuarios);
                }
            }
            // devuelve la lista completa
            return lista;
        }
        //public bool ValidarUsuario(string NombreUsuario, string Contraseña)
        //{
        //    try
        //    {
        //        foreach (DataRow fila in DataSet.DataTable["Usuarios"].Rows)
        //        {
        //            if (fila["Usuario"].ToString() == NombreUsuario && fila["Contraseña"].ToString() == Contraseña)
        //            {
        //                return true; // Usuario válido
        //            }
        //        }
        //        return false; // No se encontró coincidencia
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al validar usuario: " + ex.Message);
        //        return false;
        //    }
        //}
    }

}
