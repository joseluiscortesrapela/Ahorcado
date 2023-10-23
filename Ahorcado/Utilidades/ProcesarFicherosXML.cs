using Ahorcado.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Ahorcado.Utilidades
{
    public static class ProcesarFicherosXML
    {

        // Devuelve la lista de jugadores tras extraer los datos de jugadores.xml
        public static List<Jugador> dameListaJugadores()
        {


            // Donde tengo el fichero xml
            string archivoXML = "Xml\\jugadores.xml";
           // string archivoXML = @"Xml\jugadores.xml"; tabmien funciona de esta forma

            if (File.Exists(archivoXML))
            {              
                Console.WriteLine("Existe fichero jugadores.xml ");
            }


          
            // Creo un array que guardara objetos del tipo Jugador
            List<Jugador> jugadores = new List<Jugador>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(archivoXML);

                XmlNodeList jugadorNodes = xmlDoc.SelectNodes("/Jugadores/Jugador");

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

        // Lee palabras.xml y devuelve un array de palabras.
        public static List<Word> dameListaPalabras()
        {
            string rutaFichero = "Xml\\palabras.xml";
            List<Word> palabras = new List<Word>();


            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(rutaFichero);

                XmlNodeList palabraNodes = xmlDoc.SelectNodes("/WordList/Word");

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
     
        public static void crearJugadoresXML(DataGridView dgvJugadores )
        {
            string archivoXML = @"..\..\Xml\jugadores.xml";
            //string archivoXML = "Xml\\jugadores.xml";

            try
            {
                // Verifica si el archivo XML existe y lo elimina si es necesario.
                if (File.Exists(archivoXML))
                {
                     File.Delete(archivoXML);
                    Console.WriteLine("fichero jugadores exite lo eliminio");
                }

                // Crea un nuevo documento XML.
                XmlDocument xmlDoc = new XmlDocument();



                // Trato de añadir la etiquetas al princpio fichero xml

                // Agrega la declaración XML manualmente.
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.AppendChild(xmlDeclaration);







                // Crea el elemento raíz del documento.
                XmlElement rootElement = xmlDoc.CreateElement("Jugadores");
                xmlDoc.AppendChild(rootElement);

                // Recorre las filas del DataGridView y agrega cada jugador como un elemento al documento XML.
                foreach (DataGridViewRow fila in dgvJugadores.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        XmlElement jugadorElement = xmlDoc.CreateElement("Jugador");

                        // Crea elementos para cada columna y agrega sus valores.
                        XmlElement idElement = xmlDoc.CreateElement("id");
                        idElement.InnerText = fila.Cells[0].Value.ToString();
                        jugadorElement.AppendChild(idElement);

                        XmlElement nombreElement = xmlDoc.CreateElement("nombre");
                        nombreElement.InnerText = fila.Cells["nombre"].Value.ToString();
                        jugadorElement.AppendChild(nombreElement);

                        XmlElement contraseñaElement = xmlDoc.CreateElement("contraseña");
                        contraseñaElement.InnerText = fila.Cells["contraseña"].Value.ToString();
                        jugadorElement.AppendChild(contraseñaElement);

                        XmlElement puntuacionElement = xmlDoc.CreateElement("puntuacion");
                        puntuacionElement.InnerText = fila.Cells["puntuacion"].Value.ToString();
                        jugadorElement.AppendChild(puntuacionElement);

                        XmlElement rolElement = xmlDoc.CreateElement("rol");
                        rolElement.InnerText = fila.Cells["rol"].Value.ToString();
                        jugadorElement.AppendChild(rolElement);

                        rootElement.AppendChild(jugadorElement);
                    }
                }

                // Guarda el documento XML en el archivo.
                xmlDoc.Save(archivoXML);

                Console.WriteLine("Datos guardados en " + archivoXML);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar los datos en el archivo XML: " + ex.Message);
            }
        }


    }
}
