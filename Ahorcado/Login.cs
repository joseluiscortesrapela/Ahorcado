using Ahorcado.Models;
using Ahorcado.Utilidades;
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

        private List<Jugador> jugadores;  // Array de jugadores
        private string nombre;            // Nombre del usuario
        private string contraseña;        // Contraseña del usuario

        public Login()
        {
            InitializeComponent();
        }

        // Autoload de la ventana
        private void Login_Load(object sender, EventArgs e)
        {
            // Obtengo todos los jugadores.
            jugadores = ProcesarFicherosXML.dameListaJugadores();
        }

        // Login usuario
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Obtengo nombre 
            nombre = tbNombre.Text;
            // Obtengo la contraseña
            contraseña = tbContraseña.Text;

            // Si el formulario es valido    
            if (siValidarFormulario())
            {
                // Si usuario existe.
                if (siExistejugador())
                {
                    // Si quien se logia es un jugador
                    if (SesionUsuario.Rol.Equals("Jugador"))
                    {
                        // Muestro la ventana para el jugador
                        MenuJugador menuJugador = new MenuJugador();
                        // Hago visible la ventana
                        menuJugador.Show();
                    } // Si quien se logea es un administrador
                    else
                    {
                        // Muestro la ventana para el administardor
                        MenuAdmin menuAdmin = new MenuAdmin();
                        // Hago visible la ventana.
                        menuAdmin.Show();
                    }

                    // Oculto la ventana de login
                    this.Hide();
                }
                else
                {
                    labelMensajeLogin.Text = "Usuario no encontrado";
                }
            }


        }

        // Creo la sesion para el usuario logeado
        private void crearSesionUsuario(Jugador jugador)
        {   // Inicializo la sesion
            SesionUsuario.Id = jugador.Id;
            SesionUsuario.Usuario = jugador.Nombre;
            SesionUsuario.Contraseña = jugador.Contraseña;
            SesionUsuario.Puntuacion = jugador.Puntuacion;
            SesionUsuario.Rol = jugador.Rol;
        }

        // Comprueba si existe el usuario
        private bool siExistejugador()
        {
            bool encontrado = false;

            // Recorro la lista de jugadores
            foreach (Jugador jugador in jugadores)
            {
                // Si encuentro un jugador con el nombre y contraseña que busco.
                if (jugador.Nombre == nombre && jugador.Contraseña == contraseña)
                {
                    // Usuario encontrado.
                    encontrado = true;
                    // Creo la sesion
                    crearSesionUsuario(jugador);
                }
            }

            return encontrado;
        }


        // Valida el campos formulario login
        private bool siValidarFormulario()
        {

            bool valido = true;

            // Si el nombre de usuario no esta vacio
            if (nombre.Length == 0)
            {
                valido = false;
                error.SetError(tbNombre, "El nombre del usuario no puede estar vacio.");

            }
            else
            {
                error.SetError(tbNombre, "");
            }

            // Si el campo contraseña no esta vacio
            if (contraseña.Length == 0)
            {
                valido = false;
                error.SetError(tbContraseña, "La contraseña no puede estar vacia.");
            }
            else
            {
                error.SetError(tbContraseña, "");
            }


            return valido;


        }


        // Se cierra el programa
        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }


    } // Final clase Login



} // Final nameespace
