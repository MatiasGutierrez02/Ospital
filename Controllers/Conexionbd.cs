using System.Data.SqlClient;

namespace OSpital.Controllers
{
    public class Conexionbd
    {
        string cadena = "Data Source=DESKTOP-AL8NGAE\\SQLEXPRESS;Initial Catalog=TP_Final_PNT1_Bossio_Gonzalez_Gutierrez; Integrated Security=True";

        public SqlConnection conectarbd = new SqlConnection();

        public void conexionbd()
        {
            conectarbd.ConnectionString = cadena;
        }

        public void abrir()
        {
            try
            {
                conectarbd.ConnectionString = cadena;
                conectarbd.Open();
                Console.WriteLine("Conexion ok");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al conectar la BD " + ex.Message );
            }
        }

        public void cerrar()
        {
            conectarbd.Close();
        }
    }
}