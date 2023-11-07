using Ahorcado.Models;
using Ahorcado.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Login : Form
    {

        private List<Jugador> jugadores;  // Array de jugadores


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
            string nombre = tbNombre.Text;
            // Obtengo la contraseña
            string contraseña = tbContraseña.Text;

            // Si el formulario es valido    
            if (siValidarFormularioLogin(nombre, contraseña))
            {
                // Si usuario existe.
                if (siElUsuarioEstaRegistrado(nombre, contraseña))
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
        private bool siElUsuarioEstaRegistrado(string nombre, string contraseña)
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

        // Comprueba si el nombre elegido en el registro esta libre.
        private bool siNombreUsuarioEstaDisponible(string nombre)
        {
            bool encontrado = false;

            // Recorro la lista de jugadores
            foreach (Jugador jugador in jugadores)
            {
                // Si encuentro un jugador con el nombre y contraseña que busco.
                if (jugador.Nombre.ToLower() == nombre.ToLower())
                {
                    // Usuario encontrado.
                    encontrado = true;
                }
            }

            return encontrado;
        }

        // Registra un nuevo jugador
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Obtengo nombre y le quito los espacios en blanco a derecha e izquierda
            string nombre = tbUsuario.Text.Trim();
            // Obtengo la contraseña
            string contraseña = tbPassword.Text;
            // Obtengo un id disponible.
            int id = dameSiguienteId();

            // Si el formulario de registro es valido.
            if (siValidarFormularioRegistro(nombre, contraseña))
            {
                // Comprueba si existe un jugador con el mismo nombre.
                if (!siNombreUsuarioEstaDisponible(nombre))
                {
                    // Si se ha podido añadir un nuevo jugador al fichero xml
                    if (ProcesarFicherosXML.AgregarJugador(id, nombre, contraseña))
                    {
                        // Obtengo la lista actualizada de jugadores
                        jugadores = ProcesarFicherosXML.dameListaJugadores();
                        // Oculto el panel de registro 
                        panelRegistro.Visible = false;
                        // Muestro panel de login
                        panelLogin.Visible = true;
                        // Muestro el jugador
                        tbNombre.Text = nombre;
                        // Muestro la contraseña del jugador
                        tbContraseña.Text = contraseña;
                    }
                    else
                    {
                        lbMensajeRegistro.Text = "No se ha podido registrar";
                    }

                }
                else
                {
                    error.SetError(tbUsuario, "Ya existe un usuario con el mismo nombre");
                }
            }


        }

        // Obtiene el siguiente id jugador que este disponible
        private int dameSiguienteId()
        {
            // Obtengo el ultimo jugador de la lista
            Jugador ultimoJugador = jugadores[jugadores.Count - 1];
            // Obtengo su identificador
            int id = ultimoJugador.Id;
            // Incremento en uno
            id++;

            return id;
        }

        // Valida los campos del formulario de login
        private bool siValidarFormularioLogin(string nombre, string contraseña)
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

        // Valida los campos del formulario de registro
        private bool siValidarFormularioRegistro(string nombre, string contraseña)
        {

            bool valido = true;

            // Si el nombre de usuario no esta vacio
            if (nombre.Length == 0 || string.IsNullOrWhiteSpace(nombre) )
            {
                valido = false;
                error.SetError(tbUsuario, "El nombre del usuario no puede estar vacio.");
            }
            else
            {
                error.SetError(tbUsuario, "");
            }

            // Si el campo contraseña no esta vacio
            if (contraseña.Length == 0)
            {
                valido = false;
                error.SetError(tbPassword, "La contraseña no puede estar vacia.");
            }
            else
            {
                error.SetError(tbPassword, "");
            }


            return valido;


        }

        // Muestro panel para registrar un nuevo usuario
        private void lbMostrarPanelRegistro_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelRegistro.Visible = true;
        }

        // Vuelvo a la vengan de login
        private void lbVolverLogin_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
            panelLogin.Visible = true;
        }

        // Se cierra el programa
        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }


    } // Final clase Login



} // Final nameespace
