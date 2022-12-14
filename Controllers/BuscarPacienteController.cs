using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OSpital.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Net;

namespace OSpital.Controllers
{
    public class BuscarPacienteController : Controller
    {
        private readonly ILogger<BuscarPacienteController> _logger;

        public BuscarPacienteController(ILogger<BuscarPacienteController> logger)
        {
            _logger = logger;
        }

        public IActionResult BuscarPaciente()
        {
            return View();
        }

        public IActionResult VolverAlHome()
        {
            
            return RedirectToAction("Index", "Home");
        }

        public List<Paciente> GetData()
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            Conexionbd conexion = new Conexionbd();
            conexion.abrir();
            string cadena = "SELECT * FROM Patient";
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
                    listaPacientes.Add(paciente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta");
            }
            return listaPacientes;
        }

        //POST: BuscarPaciente
        [HttpPost]
        public Paciente BuscarPacienteBD(string Dni)
        {
            List<Paciente> listaPacientes = GetData();
            Paciente pacienteEncontrado = null;

            var i = 0;
                                                                         
            while (pacienteEncontrado == null && listaPacientes.Count() > i)
            {
                if (listaPacientes[i].Dni == Dni)
                {
                    pacienteEncontrado = listaPacientes[i];
                }
                else
                {
                    i++;
                }
            }
            return pacienteEncontrado;
        }

        private int CalcularTamanioLista(){
            List<Paciente> listaPacientes = GetData();

            return listaPacientes.Count();
        }

        public void AgregarPacienteAConsulta(string Dni, string Nombre, string Apellido, string Sexo, string Mail, string CodigoTelefono, string Telefono, string FechaRegistro, string UltimaConsulta, string ObraSocial, string NumeroAfiliadoOS, string Direccion, string Localidad) 
        {
            Conexionbd conexion = new Conexionbd();
            conexion.abrir();
            int tamanioLista = CalcularTamanioLista()+1;
            int clienteActivado = 0;


            string cadena = $"INSERT INTO Patient Values({tamanioLista},{Dni},'{Nombre}','{Apellido}','{Sexo}','{Mail}',{CodigoTelefono},{Telefono},'{FechaRegistro}','{UltimaConsulta}','{ObraSocial}',{NumeroAfiliadoOS},'{Direccion}','{Localidad}',{clienteActivado})";
            
            try
            {
                SqlCommand comando = new SqlCommand(cadena, conexion.conectarbd);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta");
                Console.WriteLine(ex);
            }
        }

        
    }
    
}