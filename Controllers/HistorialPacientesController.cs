using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OSpital.Models;
using System.Diagnostics;
using System.Data.SqlClient;

namespace OSpital.Controllers
{
    public class HistorialPacientesController : Controller
    {
        private readonly ILogger<HistorialPacientesController> _logger;

        public HistorialPacientesController(ILogger<HistorialPacientesController> logger)
        {
            _logger = logger;
        }

        public IActionResult HistorialPacientes()
        {
            return View(GetData());
        }

        public List<Paciente> GetData()
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            Conexionbd conexion = new Conexionbd();
            conexion.abrir();
            string cadena = "SELECT * FROM Patient WHERE ClienteActivo = 1";
            try
            {
                SqlCommand comando = new SqlCommand(cadena, conexion.conectarbd);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Paciente paciente = new Paciente
                    {
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
                    var fechaUltimaConsultaArrayAnio = paciente.UltimaConsulta.Date; 
                    paciente.UltimaConsulta = fechaUltimaConsultaArrayAnio;
                    listaPacientes.Add(paciente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta");
                Console.WriteLine(ex);
            }

            conexion.cerrar();

            return listaPacientes;
        }
    }
}