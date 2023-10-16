using Ahorcado.Models;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;


namespace Ahorcado
{
    public partial class Juego : Form
    {
       
        private juegoModel jugadorModel;
        // Lista de plabras de la categoria que aun no han sido jugadas.
        private List<String> palabras = new List<String>();
        // La palabra que esta en juego.
        private String palabra;
        // La categoria que juega
        private String categoria;
        // La pista de la palabra
        private String pista;
        // La palabra que esta en juego convertida en un array de caracteres
        private char[] charsPalabra;
        // Los espacios de la palabra que se esta jugando convertida en un array con guiones.
        private char[] charsGionesPalabra;
        // Lista letras jugadas
        private List<Char> letras = new List<Char>();
        // Numero de aciertos
        private int numeroAciertos;
        // Numero de fallos
        private int numeroFallos;
        // Puntuación jugador.
        private int puntuacion;
    


        public Juego()
        {
            InitializeComponent();
            // Cargo el modelo
            jugadorModel = new juegoModel();
            // Carga inicial del juego.
            inicializarJuego();
        }


        private void inicializarJuego()
        {
            cargarPalabras();
        }

        // Obtengo la categoria 
        private void comboBoxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtengo el nombre
            categoria = comboBoxCategorias.GetItemText(comboBoxCategorias.Text);
            // Muestro al jugador la categoria.
            labelCategoria.Text = categoria;
            // Obtengo la lista de palabras que pertenecen a la categoria.
            palabras = dameListaPalabras(categoria);
            // Preparo la partida
            prepararPartida();
        }


        // Incia el juego.
        private void prepararPartida()
        {
            // La palabra a jugar.
            palabra = damePalabra();
            // La pista de la palara a jugar
            pista = damePista(palabra);
            // Asigno valor al label que mostrar la pista
            labelPista.Text = pista;
            // Convierto la palabra a un array de caractres.
            charsPalabra = palabra.ToCharArray();
            // Reseteo a cero el mensaje final partida 
            labelFinalPartida.Text = "";
            // Muestro los la palabra con los guiones.
            convertirPalabraEnGuiones(palabra);
            // Muestro al jugador la palabra que tiene que adivinar.
            mostrarPalabraPorAdivinar();
            // Limpio la lista de letras jugadas de una partida anterior.
            limpiarListaLetrasJugadas();
            // Reseteo los valores de las puntuaciones.
            resetearPuntuacionesJugador();
            // Oculto panel game over
            panelGameOver.Hide();
            // Muestro el panel con las letras/botones
            panelLetras.Show();
            // Muestro el el pandel con las puntuaciones.
            panelScore.Show();
            // Muestro el panel con la palabra adivinar
            panelPalabra.Show();
            // Muestro el panel de la vida.
            panelBarraProgreso.Show();
            // Muestro el boton para resolver
            pbBrain.Show();
            // Muestro titulo brain
            labelResolver.Show();
            // Oculto select categorias
            comboBoxCategorias.Hide();
            // Muestro las letras
            buttonA.Show();
            buttonB.Show();
            buttonC.Show();
            buttonD.Show();
            buttonE.Show();
            buttonF.Show();
            buttonG.Show();
            buttonH.Show();
            buttonI.Show();
            buttonJ.Show();
            buttonK.Show();
            buttonL.Show();
            buttonM.Show();
            buttonN.Show();
            buttonÑ.Show();
            buttonO.Show();
            buttonP.Show();
            buttonQ.Show();
            buttonR.Show();
            buttonS.Show();
            buttonT.Show();
            buttonU.Show();
            buttonV.Show();
            buttonW.Show();
            buttonX.Show();
            buttonY.Show();
            buttonZ.Show();

        }

        // Obtengo la palabra que se jugara.
        private String damePalabra()
        {
            // Obtengo un numero aleatorio entre cero y el numero de palabras.
            int indice = generarNumeroAleatorio();
            // Palabra disponible
            String palabra = palabras[indice];
            // Paso a minusculas 
            palabra = palabra.ToLower();
            // Retorno la palabra
            return palabra;
        }

        // Obtengo las palabras de una categoria.
        private List<String> dameListaPalabras(String categoria)
        {
            // Lista de palabras que no han sido repetidas
            List<String> palabras = new List<String>();

            // Recorro el array
            foreach (DataGridViewRow palabra in dgvTablaPalabras.Rows)
            {
                // Si la palabra pertenece a la categoria 
                if (palabra.Cells[3].Value.Equals(categoria))
                {
                    // Añado la palabra a la lista.
                    palabras.Add(palabra.Cells[1].Value.ToString());
                }

            }
            // Retorno la lista de palabras
            return palabras;
        }

        // Muestra los giones o esapcios que conforman la palabra por adivinar.
        private void convertirPalabraEnGuiones(String palabra)
        {

            // Creo un array de caractres con los espacios que tiene la palabra
            charsGionesPalabra = palabra.ToCharArray();
            // Convierto la palabra en un array de caracteres.
            char[] giones = palabra.ToCharArray();
            // Recorro cada uno de los caracteres de la palabra.
            for (int i = 0; i < palabra.Length; i++)
            {
                // Si en la posicion i tengo un caracter escribo - sino espacio en blanco.
                charsGionesPalabra[i] = (Char.IsLetter(charsPalabra[i])) ? '-' : ' ';
            }


        }

        // Actualiza la plabra en guiones con las letras que se hayan podido acertar.
        private void mostrarPalabraPorAdivinar()
        {   // Convierto el array de caracteres con los guiones y letras completadas a String.
            String adivinar = new string(charsGionesPalabra);
            // Muestro la palabra por adivinar con giones y letras acertadas.
            labelPalabraGuiones.Text = adivinar;
        }

        // Genera un numero aleatorio
        private int generarNumeroAleatorio()
        {
            Random random = new Random();
            int numero = random.Next(palabras.Count);
            return numero;
        }

        // Carga las catgorias
        private void cargarCategorias()
        {
            // Lista de categorias repetidas.
            List<String> lista = new List<string>();

            // Recorro por la columna categorias.
            foreach (DataGridViewRow categoria in dgvTablaPalabras.Rows)
            {

                // Si la palabra NO EXISTE
                if (!lista.Contains(categoria.Cells[3].Value))
                {
                    // Añado una nueva categoria al select
                    comboBoxCategorias.Items.Add(categoria.Cells[3].Value);
                    // Guardo en la lista la catetoria para no repetirla
                    lista.Add(categoria.Cells[3].Value.ToString());
                }

            }

        }

        private String damePista(String palabra)
        {
            String pista = "";

            // Recorro todas las palabras
            foreach (DataGridViewRow row in dgvTablaPalabras.Rows)
            {
                // Si encuentras la palabra
                if (row.Cells[1].Value.ToString().ToLower() == palabra)
                {   // Guardo su pista
                    pista = row.Cells[2].Value.ToString();
                }

            }
            // Devuelvo valor
            return pista;
        }

        // Carga inicial de las palabras al cargar el juego.
        private void cargarPalabras()
        {
            // Obtengo las palabras de la tabla palabras de la base de datos
            dgvTablaPalabras.DataSource = jugadorModel.getPalabras();
            // Si no esta vacio
            if (dgvTablaPalabras != null)
            {
                cargarCategorias(); // Cargo las categorias
            }
            else
            {
                MessageBox.Show("No se han ecnontrado palabras en la base de datos, tabla vacia.");
            }
        }

        // Permite al jugador resolver
        private void buttonRespuestaRapida_Click(object sender, EventArgs e)
        {
            // Obtengo la respuesta del jugador, le quito los espacios y la convierto a minusculas.
            String respuesta = tbRespuesta.Text.Trim().ToLower();

            // Si la respuesta del jugador es igual a la palabra por adivinar
            if (respuesta.Equals(palabra))
            {
                // Incremento en diez puntos la puntuación.
                puntuacion += 10;
                finDelJuego("Has acertado la palabra");
            }
            else
            {
                // Resto 5 puntos por respuesta fallida.
                puntuacion -= 5;
                finDelJuego("No has acertado la palabra");
            }
            // Muestro las puntuaciones
            mostrarPuntuacionesJugador();

        }

        // Elimina las leras almacenadas en la lista de letras jugadas.
        private void limpiarListaLetrasJugadas()
        {
            letras.Clear();
        }

        // Comprubar si con el siguiente acierto, se ha completado la palabra, el jugador ha ganado, fin de la partida.
        private bool siHaCompletadoPalabra()
        {

            // Convierto array de caracteres a string
            String palabraEnJuego = new String(charsGionesPalabra);
            // Si la palabra con guiones es igual a la palabra secreta
            bool resultado = (palabraEnJuego.Equals(palabra)) ? true : false;

            return resultado;
        }

        // Muestra las imagenes del ahorcado
        private void dibujarParteAhorcdo(int parte)
        {

            switch (parte)
            {
                case 1: pictureBoxAhorcado.Image = Properties.Resources._1; break;
                case 2: pictureBoxAhorcado.Image = Properties.Resources._2; break;
                case 3: pictureBoxAhorcado.Image = Properties.Resources._3; break;
                case 4: pictureBoxAhorcado.Image = Properties.Resources._4; break;
                case 5: pictureBoxAhorcado.Image = Properties.Resources._5; break;
                case 6: pictureBoxAhorcado.Image = Properties.Resources._6; break;

            }


        }

        // Comprueba si la letra se encuentra en la palabra.
        private void comprobarLetra(char letra)
        {

            // Por defecto toma este valor.
            bool acierto = false;

            // Recorro cada letra de la plabra que hay que adivinar.
            for (int i = 0; i < charsPalabra.Length; i++)
            {   // Si se encuentra la letra
                if (charsPalabra[i] == letra)
                {
                    // He acertado la letra/s
                    acierto = true;
                    // Inserto la letra.
                    charsGionesPalabra[i] = letra;
                    // Muestro la palabra por adivinar con las letra acertadas.
                    mostrarPalabraPorAdivinar();
                }
            }


            // Si ha acertado la letra
            if (acierto)
            {   // Incremento 2 puntos
                puntuacion += 2;
                // Incremento el numero de aciertos.
                numeroAciertos += 1;
                // Muestro las puntuaciones
                mostrarPuntuacionesJugador();
            }
            else // Sino ha acertado la letra.
            {
                // Por cada letra fallida un punto menos.
                numeroFallos += 1;
                // Dibujo una parte del ahorcado
                dibujarParteAhorcdo(numeroFallos);

                // si el jugados ha llegado a los 6 fallos
                if (numeroFallos == 6)
                {
                    puntuacion -= 5; // Por cada palabra fallada cinco puntos menos.
                    // El juego ha finalizado
                    finDelJuego("Has perdido, fin del juego");
                }
                else
                {
                    // Si ha fallado, le resto uno, sino no hago nada, no quiero un score con resultados negativos.
                    puntuacion -= (puntuacion > 0) ? 1 : puntuacion;
                    // Nivel de vida baja
                    progressBarVida.Value -= 1;
                    // Muestro las puntuaciones
                    mostrarPuntuacionesJugador();
                }

            }

            // Si has adivinado la palabra
            if (siHaCompletadoPalabra())
            {
                // Incremento el score
                puntuacion += 10;
                // el juego ha finalizado
                finDelJuego("Has ganado!");
            }

            mostrarPuntuacionesJugador();

        }

        // Obtengo la letra que acaba de pulsar el jugador.
        private void buttonLetter_Click(object sender, EventArgs e)
        {
            // Obtengo el texto del boton que ha sido pulsado y lo convierto a tipo char.
            char letra = char.Parse(((Button)sender).Text.ToLower());
            // Obtengo el boton pulsado
            Button button = (Button)sender;
            // Desactivo el evento del boton
            button.Hide();
            // Comprobar si la letra existe en la palabra.
            comprobarLetra(letra);
        }

        // Muestra las puntuaciones
        private void mostrarPuntuacionesJugador()
        {
            // Muestro numero de aciertos.
            labelNumeroAciertos.Text = numeroAciertos.ToString();
            // Muestro numero de fallos
            labelNumeroFallos.Text = numeroFallos.ToString();
            // Muestro el score
            labelPuntuacion.Text = puntuacion.ToString();

        }

        // Resetea a cero las puntuaciones
        private void resetearPuntuacionesJugador()
        {
            // Pongo la variable puntuaciones a cero.
            this.numeroAciertos = 0;
            // Muestro numero de fallos
            this.numeroFallos = 0;
            // Pongo el score.
            this.puntuacion = 0;
            // Barra de vida al 100 %
            progressBarVida.Value = 6;
            // Label n acierto a cero
            labelNumeroAciertos.Text = "0";
            // Numero fallos label
            labelNumeroFallos.Text = "0";
            // Reseteo label score
            labelPuntuacion.Text = "0";
        }


        // Muestro el panel de respuesta rapida
        private void btnShowPanelResolver_Click(object sender, EventArgs e)
        {
            panelResolver.Show();
        }

        // Fin de la partida
        private void finDelJuego(String mensaje)
        {

            // Muestro al jugador la palabra secreta.
            labelPalabraGuiones.Text = palabra;
            // Muestro al jugador el siguiente mensaje
            labelFinalPartida.Text = mensaje;
            // Oculto el panel de botones/letras
            panelLetras.Hide();
            // Oculto el paner respuesta rapida.
            panelResolver.Hide();
            // Oculto pista 
            labelPista.Hide();
            // Oculto boton resolver
            pbBrain.Hide();
            // Oculto su titulo
            labelResolver.Hide();
            //Muestro panel game over
            panelGameOver.Show();
            // Guardo la ultima puntuacion
            int totalPuntuacion = SesionUsuario.getPuntuacion() + puntuacion;
            // Actualizo la puntuacion para la sesion del jugador
            SesionUsuario.setPuntuacion(totalPuntuacion);
            // Actualizo la puntuacion del jugador
            jugadorModel.updatePuntuacion( SesionUsuario.getId(), totalPuntuacion );

        }


        // Jugar otra partida
        private void buttonJugarOtraPartida_Click(object sender, EventArgs e)
        {
            // Hago visible el combobox para elegir categoria
            comboBoxCategorias.Show();
            // Reseteo el mensaje
            labelFinalPartida.Text = "";
            // Oculto el panel de botones/letras
            panelLetras.Hide();
            // Oculto el paner respuesta rapida.
            panelResolver.Hide();
            // Oculto el panel game over
            panelGameOver.Hide();
            // Oculto el panel scores
            panelScore.Hide();
            // Quito la imagen del ahorcado
            pictureBoxAhorcado.Image = null;
            // Oculto panel vida
            panelBarraProgreso.Hide();
            // Oculto mensaje al fnalizar partda
            labelFinalPartida.Text = "";
            // Oculto el label categoria
            labelCategoria.Text = "";
            // Oculto los guiones palabra
            labelPalabraGuiones.Text = "";
            // Quito la pista anterior.
            labelPista.Text = "";
            // Muestro la pista
            labelPista.Show();

        }

        private void buttonNoJugarOtra_Click(object sender, EventArgs e)
        {
            // Oculto la ventana de login
            this.Hide();
            // Intancia
            MenuJugador menuJugador = new MenuJugador();
            // Muestro la ventana del jugador
            menuJugador.Show();

        }

        // Se cierra el juego
        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
