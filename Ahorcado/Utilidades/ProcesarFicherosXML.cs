using Ahorcado.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Ahorcado.Utilidades
{
    public static class ProcesarFicherosXML
    {


        public static List<Jugador> dameListaJugadores()
        {

            string rutaFichero = "C:\\Users\\jose\\source\\repos\\Ahorcado\\Ahorcado\\Xml\\jugadores.xml";

            List<Jugador> jugadores = new List<Jugador>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(rutaFichero);

                XmlNodeList jugadorNodes = xmlDoc.SelectNodes("/jugadores/jugador");

                foreach (XmlNode jugadorNode in jugadorNodes)
                {
                    int id = int.Parse(jugadorNode.SelectSingleNode("id").InnerText);
                    string nombre = jugadorNode.SelectSingleNode("nombre").InnerText;
                    string contraseña = jugadorNode.SelectSingleNode("contraseña").InnerText;
                    int puntuacion = int.Parse(jugadorNode.SelectSingleNode("puntuacion").InnerText);
                    string rol = jugadorNode.SelectSingleNode("rol").InnerText;


                    // Creo el jugador
                    Jugador jugador = new Jugador(id, nombre, contraseña, puntuacion, rol);

                    // Lo guardo en el array
                    jugadores.Add(jugador);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo XML: " + ex.Message);
            }


            return jugadores;
        }

        public static List<Word> dameListaPalabras()
        {
            string rutaFichero = "C:\\Users\\jose\\source\\repos\\Ahorcado\\Ahorcado\\Xml\\palabras.xml";
            List<Word> palabras = new List<Word>();


            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(rutaFichero);

                XmlNodeList palabraNodes = xmlDoc.SelectNodes("/wordList/word");

                foreach (XmlNode palabraNode in palabraNodes)
                {
                    int id = int.Parse(palabraNode.SelectSingleNode("id").InnerText);
                    string word = palabraNode.SelectSingleNode("palabra").InnerText;
                    string pìsta = palabraNode.SelectSingleNode("pista").InnerText;
                    string categoria = palabraNode.SelectSingleNode("categoria").InnerText;


                    // Instancio e inicializo una nueva palabra
                    Word palabra = new Word(id, word, pìsta, categoria);

                    // Lo guardo en el array
                    palabras.Add(palabra);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo XML: " + ex.Message);
            }


            return palabras;
        }


    }
}
