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

            Console.WriteLine("Leyendo jugadores.xml");
            string rutaFichero = "C:\\Users\\jose\\source\\repos\\Ahorcado\\Ahorcado\\Xml\\jugadores.xml";

            List<Jugador> jugadores = new List<Jugador>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load( rutaFichero );

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



    }
}
