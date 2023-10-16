using Ahorcado.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Login : Form
    {
      
        private String user;
        private String password;

        public Login()
        {
            InitializeComponent();      
        }


        // Login usuario
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Obtengo nombre 
            user = textBoxUser.Text.Trim();
            // Obtengo la contraseña
            password = textBoxPassword.Text.Trim();

            Console.WriteLine("USUARIO: " + user + " CONTRASEÑA: " + password);

            /*
            if (formularioEsValido())
            {
               
                // Si usuario existe.
                if (existe)
                {
                    // Oculto la ventana de login
                    this.Hide();
                    // Obtengo el usuario logeado
                    string tipoUsuario = SesionUsuario.getTipo();

                    // Si quien se logia es un jugador
                    if (tipoUsuario.Equals("Jugador"))
                    {
                        // Intancia
                        MenuJugador menuJugador = new MenuJugador();
                        // Muestro la ventana del jugador
                        menuJugador.Show();
                    } // Si quien se logea es un administrador
                    else if (tipoUsuario.Equals("Administrador"))
                    {
                        // Intancio
                        MenuAdmin menuAdmin = new MenuAdmin();
                        // Muestro la ventana del alministrador
                        menuAdmin.Show();
                    }

                }
                else
                {
                    labelMensajeLogin.Text = "Usuario no encontrado";
                }
            }

            */

        }

        // Valida el formulario de registro y login
        private bool formularioEsValido()
        {
            /*
            bool valor = true;

            // Si el nombre de usuario no esta vacio
            if (user.Length == 0)
            {
                valor = false;
                errorProvider.SetError(textBoxUser, "El nombre del usuario no puede estar vacio.");

            }
            else
            {
                errorProvider.SetError(textBoxUser, "");
            }

            // Si el campo contraseña no esta vacio
            if (password.Length == 0)
            {
                valor = false;
                errorProvider.SetError(textBoxPassword, "El password del usuario no puede estar vacio.");
            }
            else
            {
                errorProvider.SetError(textBoxPassword, "");
            }


            return valor;
            */
            return true;
        }



        // Se cierra el programa
        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }


    } // Final clase Login



} // Final nameespace
