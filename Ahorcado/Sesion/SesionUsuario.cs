using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    internal class SesionUsuario
    {

        private static int id;
        private static String usuario;
        private static String contraseña;
        private static int puntuacion;
        private static String tipo;



        public SesionUsuario()
        {
        }

        public static int getId()
        {
            return id;
        }

        public static void setId(int id)
        {
            SesionUsuario.id = id;
        }

        public static String getUsuario()
        {
            return usuario;
        }

        public static void setUsuario(String usuario)
        {
            SesionUsuario.usuario = usuario;
        }

        public static String getContraseña()
        {
            return contraseña;
        }

        public static void setContraseña(String contraseña)
        {
            SesionUsuario.contraseña = contraseña;
        }

        public static int getPuntuacion()
        {
            return puntuacion;
        }

        public static void setPuntuacion(int puntuacion)
        {
            SesionUsuario.puntuacion = puntuacion;
        }


        public static String getTipo()
        {
            return tipo;
        }

        public static void setTipo(String tipo)
        {
            SesionUsuario.tipo = tipo;
        }

    }
}
