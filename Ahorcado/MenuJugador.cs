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
    public partial class MenuJugador : Form
    {

        private MenuJugadorModel model_jugador;

        public MenuJugador()
        {
            InitializeComponent();
            // Instancio el modelo de datos
            model_jugador = new MenuJugadorModel();
            // Muestro el nombre del jugador.
            labelNombreUsuario.Text = SesionUsuario.getUsuario();
           
        }

        private void labelBotonJugar_Click(object sender, EventArgs e)
        {
            // Oculto el menu
            this.Hide();
            // Instancio el juego
            Juego juego = new Juego();
            // Muestro el juego.
            juego.Show();
        }

        // Sales del programa
        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelMostrarPuntuaciones_Click(object sender, EventArgs e)
        {
       

        }
    }
}
