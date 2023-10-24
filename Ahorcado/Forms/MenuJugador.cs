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

        public MenuJugador()
        {
            InitializeComponent();
            // Muestro el nombre del jugador.
            lbNombreUsuario.Text = SesionUsuario.Usuario;
            // Muestro su puntuacion
            lbPuntuacion.Text = SesionUsuario.Puntuacion.ToString();
           
        }
   

        private void labelJugar_Click(object sender, EventArgs e)
        {
             // Oculto el menu
            this.Hide();
            Halloween halloween = new Halloween();
            // Muestro el juego
            halloween.Show();
        }

        // Sales del programa
        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
