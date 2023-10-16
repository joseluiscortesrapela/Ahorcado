using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado.Models
{
    internal class MenuJugadorModel
    {

        public DataTable getPuntuaciones()
        {
            MySqlConnection conexion = ConexionBaseDatos.getConexion();
            // la abro.
            conexion.Open();
            // Consulta sql
            string sql = "SELECT jugador, puntuacion FROM jugadores ORDER BY puntuacion DESC";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexion);
            DataTable table = new DataTable();

            try
            {
                adapter.Fill(table);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return table;
        }

    }
}
