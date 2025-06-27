using PryGinoPistoliaLABORATORIOIEFI.BasedeDatos;
using PryGinoPistoliaLABORATORIOIEFI.Formularios;
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

namespace PryGinoPistoliaLABORATORIOIEFI
{
    public partial class FormLogin : Form
    {
        public string connectionString = "Server=localhost\\SQLEXPRESS02;Database=Administracion;Trusted_Connection=True";
        Conexion conexion = new Conexion();
        FormRegistro registro = new FormRegistro();
        public FormLogin()
        {
            InitializeComponent();
            
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            //bool valido = conexion.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            //    string nombreUsuario = txtUsuario.Text.Trim();
            //    string contraseña = txtContraseña.Text;

            //    // Intentar iniciar sesión
            //    Usuario usuarioLogueado = UsuarioDatos.IniciarSesion(nombreUsuario, contraseña);

            //    if (usuarioLogueado != null)
            //    {
            //        // Si el login es exitoso, abrir la ventana principal
            //        FormPrincipal principal = new FormPrincipal(usuarioLogueado);
            //        this.Hide();
            //        principal.Show();
            //    }
            //    else
            //    {
            //        // Usuario o contraseña incorrectos
            //        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Abrir formulario de registro
            FormRegistro registro = new FormRegistro();
            registro.Show();
        }
    }
}
