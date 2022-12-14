using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OSpital.Models;
using System.Diagnostics;
using System.Data.SqlClient;

namespace OSpital.Controllers
{
    public class PacientesActivosController : Controller
    {
        private readonly ILogger<PacientesActivosController> _logger;

        public PacientesActivosController(ILogger<PacientesActivosController> logger)
        {
            _logger = logger;
        }

        public IActionResult PacientesActivos()
        {
            return View(GetData());
        }

        public List<Paciente> GetData()
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            Conexionbd conexion = new Conexionbd();
            conexion.abrir();
            string cadena = "SELECT * FROM Patient WHERE ClienteActivo = 0 order by ID_Paciente + 0 ";
            try
            {
                SqlCommand comando = new SqlCommand(cadena, conexion.conectarbd);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Paciente paciente = new Paciente
                    {
                        Id = lector.GetValue(0).ToString(),
                        Dni = lector.GetValue(1).ToString(),
                        Nombre = lector.GetValue(2).ToString(),
                        Apellido = lector.GetValue(3).ToString(),
                        Sexo = lector.GetValue(4).ToString(),
                        Mail = lector.GetValue(5).ToString(),
                        CodigoTelefono = lector.GetValue(6).ToString(),
                        Telefono = lector.GetValue(7).ToString(),
                        FechaRegistro = (DateTime)lector.GetValue(8),
                        UltimaConsulta = (DateTime)lector.GetValue(9),
                        ObraSocial = lector.GetValue(10).ToString(),
                        NumeroAfiliadoOS = lector.GetValue(11).ToString(),
                        Direccion = lector.GetValue(12).ToString(),
                        Localidad = lector.GetValue(13).ToString(),
                        ClienteActivo = lector.GetValue(14).ToString()
                    };
                    listaPacientes.Add(paciente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta");
            }

            conexion.cerrar();

            return listaPacientes;
        }


        //POST: BuscarPaciente
        [HttpPost]
        public void EliminarPacienteBD(string ID_Paciente)
        {
            System.Console.WriteLine("entro 222");
            
        }

    }
}