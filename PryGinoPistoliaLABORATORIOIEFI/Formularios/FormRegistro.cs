using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryGinoPistoliaLABORATORIOIEFI.Formularios
{
    public partial class FormRegistro : Form
    {
        public string connectionString = "Server=localhost\\SQLEXPRESS02;Database=Administracion;Trusted_Connection=True";
        Conexion conexion = new Conexion();
        FormLogin formlogin = new FormLogin();
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.cadena))
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Usuario", usuario);

                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("El nombre de usuario ya existe. Por favor elija otro.");
                        return;
                    }

                    string query = "INSERT INTO Usuarios (Usuario, Contraseña) VALUES (@Usuario, @Contraseña)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario creado correctamente.");
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                    FormLogin formlogin = new FormLogin();
                    this.Hide();
                    formlogin.ShowDialog();
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
        }
    }
}
    

