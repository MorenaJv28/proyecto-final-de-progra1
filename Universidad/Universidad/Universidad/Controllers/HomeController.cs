using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;

using Universidad.Models;
using System.Collections.Generic;

namespace Universidad.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult elegir_curso_calificacion() 
        {
            return View();        
        }

		public IActionResult curso_Programacion()
		{
			return View();
		}

		public IActionResult curso_Matematicas()
		{
			return View();
		}

		public IActionResult curso_Diseño()
		{
			return View();
		}
        public IActionResult elegir_estudiante()
        {
            return View();
        }

        public IActionResult Info_Estudiante(string id)
        {
            List<Object> listaHtml = new List<object>();
            using (UniversidadContext db = new UniversidadContext())
            {
                try
                {
                    var lista = db.Estudiantes.ToList();

                    foreach (var item in lista)
                    {
                        if (item.Id == Int32.Parse(id))
                        {
                            listaHtml.Add(item.Id);
                            listaHtml.Add(item.Nombre);
                            listaHtml.Add(item.Edad);
                            listaHtml.Add(item.FechaNacimiento);
                            listaHtml.Add(item.CorreoElectronico);
                            listaHtml.Add(item.CodigoPostal);
                            listaHtml.Add(item.NumeroTelefono);
                            
                        }
                    }

                    return View(listaHtml);
                }
                catch (Exception ex)
                {
                    return View("elegir_estudiante");
                }
                
            }
        }

        public IActionResult Calificaciones_progra(int pasarrId)
        {
            
            List <decimal?> listaProgra = new List<decimal?>();
            using (UniversidadContext db = new UniversidadContext())
            {
                var lista1 = db.CalificacionesProgramacions.ToList();
                foreach (var i in lista1)
                {
                    if(i.IdEstudiante == pasarrId)
                    {
                        listaProgra.Add(i.NotaExamen1);
                        listaProgra.Add(i.NotaExamen2);
                        listaProgra.Add(i.NotaExamen3);
                        listaProgra.Add(i.NotaFinal);
                    }
                }
      
            }

            
            return View(listaProgra);
        }

        public IActionResult Calificaciones_mate(int pasarrId)
        {
  
            List<decimal?> listaMate = new List<decimal?>();
            using (UniversidadContext db = new UniversidadContext())
            {
                var lista2 = db.CalificacionesMatematicas.ToList();
                foreach (var i in lista2)
                {
                    if (i.IdEstudiante == pasarrId)
                    {
                        listaMate.Add(i.NotaExamen1);
                        listaMate.Add(i.NotaExamen2);
                        listaMate.Add(i.NotaExamen3);
                        listaMate.Add(i.NotaFinal);
                    }
                }

            }
            
            return View(listaMate);
        }

        public IActionResult Calificaciones_diseño(int pasarrId)
        {
            List<decimal?> listaDiseño = new List<decimal?>();
            using (UniversidadContext db = new UniversidadContext())
            {
                var lista3 = db.CalificacionesDiseños.ToList();
                foreach (var i in lista3)
                {
                    if (i.IdEstudiante ==pasarrId)
                    {

                        listaDiseño.Add(i.NotaExamen1);
                        listaDiseño.Add(i.NotaExamen2);
                        listaDiseño.Add(i.NotaExamen3);
                        listaDiseño.Add(i.NotaFinal);
                    }
                }
                return View(listaDiseño);
            }
        }

        public IActionResult Asignaturas()
        {
            using(UniversidadContext db = new UniversidadContext())
            {
                var Profesores = db.Profesores.ToList();
               
                
                return View(Profesores);
            }
           
        }

        
        [HttpPost]

	
		public IActionResult Registro(string nombre, string edad, string correo,string postal, string telefono, DateTime fecha)
        {
            try
            {
                
                using (UniversidadContext db = new UniversidadContext())
                {
                    var estudiante = new Estudiante();
                    estudiante.Nombre = nombre;
                    estudiante.CorreoElectronico = correo;
                    estudiante.CodigoPostal = Int32.Parse(postal);
                    estudiante.NumeroTelefono = Int32.Parse(telefono);
                    estudiante.Edad = Int32.Parse(edad);
                    estudiante.FechaNacimiento = fecha;
                    db.Estudiantes.Add(estudiante);
                    db.SaveChanges();
                }


                return RedirectToAction("Index"); 
            }
            
            catch (Exception ex)
            {
                return RedirectToAction("Registrar");
            }
            
        }

        public IActionResult agregarNotasProgra( string id_estudiante, string NotaExamen1, string NotaExamen2, string NotaExamen3)
        {
            using (UniversidadContext db = new UniversidadContext())
            {

                try
                {
                    var Calificaciones = new CalificacionesProgramacion();

                    decimal nota1 = decimal.Parse(NotaExamen1);
                    decimal nota2 = decimal.Parse(NotaExamen2);
                    decimal nota3 = decimal.Parse(NotaExamen3);

                    Calificaciones.IdEstudiante = Int32.Parse(id_estudiante);
                    Calificaciones.NotaExamen1 = nota1;
                    Calificaciones.NotaExamen2 = nota2;
                    Calificaciones.NotaExamen3 = nota3;
                    

                    decimal notafinal = (nota1 + nota2 + nota3) / 3;
                    Calificaciones.NotaFinal = notafinal;

                    db.Add(Calificaciones);
                    db.SaveChanges();
                    return RedirectToAction("Index"); // Redirige
                }

                catch (Exception ex)
                {
                    return RedirectToAction("curso_Programacion");
                }

                    
            }
                
        }

        public IActionResult agregarNotasMate(string id_estudiante, string NotaExamen1, string NotaExamen2, string NotaExamen3)
        {
            using (UniversidadContext db = new UniversidadContext())
            {
                try
                {
                    var Calificaciones = new CalificacionesMatematica();

                    decimal nota1 = decimal.Parse(NotaExamen1);
                    decimal nota2 = decimal.Parse(NotaExamen2);
                    decimal nota3 = decimal.Parse(NotaExamen3);
                    Calificaciones.IdEstudiante = Int32.Parse(id_estudiante);
                    Calificaciones.NotaExamen1 = nota1;
                    Calificaciones.NotaExamen2 = nota2;
                    Calificaciones.NotaExamen3 = nota3;

                    decimal notafinal = (nota1 + nota2 + nota3) / 3;
                    Calificaciones.NotaFinal = notafinal;

                    db.Add(Calificaciones);
                    db.SaveChanges();
                    return RedirectToAction("Index"); // Redirige

                }

                catch (Exception ex)
                {
                    return RedirectToAction("curso_Matematicas");
                }

            }

        }

        public IActionResult agregarNotasDiseño(string id_estudiante, string NotaExamen1, string NotaExamen2, string NotaExamen3)
        {
            using (UniversidadContext db = new UniversidadContext())
            {

                try
                {
                    var Calificaciones = new CalificacionesDiseño();

                    decimal nota1 = decimal.Parse(NotaExamen1);
                    decimal nota2 = decimal.Parse(NotaExamen2);
                    decimal nota3 = decimal.Parse(NotaExamen3);


                    Calificaciones.IdEstudiante = Int32.Parse(id_estudiante);
                    Calificaciones.NotaExamen1 = nota1;
                    Calificaciones.NotaExamen2 = nota2;
                    Calificaciones.NotaExamen3 = nota3;

                    decimal notafinal = (nota1 + nota2 + nota3) / 3;
                    Calificaciones.NotaFinal = notafinal;

                    db.Add(Calificaciones);
                    db.SaveChanges();
                    return RedirectToAction("Index"); // Redirige
                }

                catch (Exception ex)
                {
                    return RedirectToAction("curso_Diseño");
                }


            }

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}