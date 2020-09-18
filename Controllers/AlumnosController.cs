using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProyClase3.Models;
using X.PagedList.Mvc.Core;
using X.PagedList;

namespace ProyClase3.Controllers
{
    public class AlumnosController : Controller
    {

        static List<Alumno> Lista= new List<Alumno>()
        {
            new Alumno(){Legajo=100, Nombre="Laura", Apellido="Trabajo",      PaisNombre="Argentina",Sexo="Femenino",Dni=35928121 },
            new Alumno(){Legajo=101, Nombre="Jeronimo", Apellido="Besos", PaisNombre="Bolivia",Sexo="Masculino",Dni=32452958 },
            new Alumno(){Legajo=102, Nombre="Guillermo", Apellido="Puertas", PaisNombre="Argentina",Sexo="Masculino",Dni=39441227 },
            new Alumno(){Legajo=103, Nombre="Julia", Apellido="Coch", PaisNombre="Argentina",Sexo="Femenino",Dni=36888192 },
            new Alumno(){Legajo=104, Nombre="Macarena", Apellido="Besos", PaisNombre="Paraguay",Sexo="Femenino",Dni=36209325 },
            new Alumno(){Legajo=105, Nombre="Walter", Apellido="Way", PaisNombre="Argentina",Sexo="Masculino",Dni=25203952 },
            new Alumno(){Legajo=106, Nombre="Virginia", Apellido="Martinez", PaisNombre="Chile",Sexo="Femenino",Dni=36209325 },
            new Alumno(){Legajo=107, Nombre="Marcos", Apellido="Zucker",     PaisNombre="Argentina",Sexo="Masculino",Dni=33209524 },
            new Alumno(){Legajo=108, Nombre="Guillermina", Apellido="Tanderi", PaisNombre="Bolivia",Sexo="Femenino",Dni=32452958 },
            new Alumno(){Legajo=109, Nombre="Esteban", Apellido="Pelota",    PaisNombre="Argentina",Sexo="Masculino",Dni=37135255 },
            new Alumno(){Legajo=110, Nombre="Eduardo", Apellido="Muscari",     PaisNombre="Argentina",Sexo="Masculino",Dni=41441781 },
            new Alumno(){Legajo=111, Nombre="Jacqueline", Apellido="Marte",     PaisNombre="Argentina",Sexo="Femenino",Dni=39434121 },
            new Alumno(){Legajo=112, Nombre="Edison", Apellido="Oracle",     PaisNombre="Uruguay",Sexo="Masculino",Dni=39563123 },
            new Alumno(){Legajo=113, Nombre="Luis", Apellido="Pagina", PaisNombre="Argentina",Sexo="Masculino",Dni=36280777 },
            new Alumno(){Legajo=114, Nombre="Sergio", Apellido="Brinda", PaisNombre="Argentina",Sexo="Masculino",Dni=37634321 },
            new Alumno(){Legajo=115, Nombre="Miguel", Apellido="Bloom", PaisNombre="Brasil",Sexo="Masculino",Dni=25203952 },
            new Alumno(){Legajo=116, Nombre="Jaime", Apellido="Wallmor", PaisNombre="Argentina",Sexo="Masculino",Dni=36123654 }, 
        };
        public List<Pais> Paises=new List<Pais>(){
            new Pais(){Id=1,Nombre="Argentina"},
            new Pais(){Id=2,Nombre="Bolivia"},
            new Pais(){Id=3,Nombre="Uruguay"},
            new Pais(){Id=4,Nombre="Paraguay"},
            new Pais(){Id=5,Nombre="Chile"},
            new Pais(){Id=6,Nombre="Brasil"},
        };
        public IActionResult Index(string campobusqueda,int? pagina)
        {
            //consulto BD

            var resultadobusqueda=Lista;
            ViewBag.MensajeBienvenida="Estamos probando el viewbag";      
            if (!String.IsNullOrEmpty(campobusqueda))
            {
                
                //resultadobusqueda = Lista.Where(s => s.Nombre.Contains(campobusqueda)
                //|| s.Apellido.Contains(campobusqueda)).ToList<Alumno>();
                resultadobusqueda = Lista.Where(s => s.Nombre.Contains(campobusqueda)
                || s.Apellido.Contains(campobusqueda)).ToList<Alumno>();
                return View(Paginar(resultadobusqueda,pagina));
            } 
            //Lista.Reverse();
            //return View(resultadobusqueda);

            return View(Paginar(resultadobusqueda,pagina));
            
        }

        public IPagedList Paginar(List<Alumno> lista,int? pagina){
            int pageSize = 5;
            int pageNumber = (pagina ?? 1);
            return lista.ToPagedList(pageNumber,pageSize);
        }

        
        public IActionResult Order()
        {
            //consulto BD
            ViewBag.MensajeBienvenida="Estamos probando el viewbag";       
            Lista.Reverse();
            return View("Index",Paginar(Lista,1));
            //return View(Lista);
          
        }


        public IActionResult Editar(int leg){

            ViewBag.Paises=Paises;
            var alumnoDB= Lista.Where(s=> s.Legajo==leg).FirstOrDefault();
            return View(alumnoDB);
        }

        [HttpPost]
        public IActionResult Editar(Alumno alumnoFormulario,IFormCollection formulario){
            if(ModelState.IsValid){
                var alumnoAnterior= Lista.Where(s => s.Legajo == alumnoFormulario.Legajo).FirstOrDefault();
                //var paisSeleccionado=Paises.Where(x => x.Id == int.Parse(alumnoFormulario.PaisNombre) ).FirstOrDefault();
                //alumnoFormulario.PaisNombre=paisSeleccionado.Nombre;
                //alumnoFormulario.Sexo=formulario["genero"];
            
                Lista.Remove(alumnoAnterior);
                Lista.Add(alumnoFormulario);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Edad", "Debe ingresar la edad en el rango indicado.");
            ViewBag.Paises=Paises;
            return View(alumnoFormulario);
            
        }
       

        public IActionResult Crear()
        {

            return View();
        }

        


        /*
        [HttpPost]
        public IActionResult Crear(Alumno alumnoFormulario){
            Lista.Add(alumnoFormulario);
            return RedirectToAction("Index");
        }
        */

        [HttpPost, ActionName("Crear")]
        public IActionResult GuardarNuevoAlumno(Alumno alumnoFormulario){
            //validacion legajo existente
            var alumnoDB= Lista.Where(s=> s.Legajo==alumnoFormulario.Legajo).FirstOrDefault();
            
            if(alumnoDB!=null)
            {return Content("ERROR, LEGAJO EXISTENTE");}
            else
            {Lista.Add(alumnoFormulario);return RedirectToAction("Index"); }
            
        }

        public IActionResult Detalle(int leg){
            var alumnoDB= Lista.Where(s=> s.Legajo==leg).FirstOrDefault();
            
            return View(alumnoDB);
        }

        [HttpPost,ActionName("Borrar")]
        public IActionResult Borrar(Alumno alumnoFormulario){
            var alumnoDB= Lista.Where(s=> s.Legajo==alumnoFormulario.Legajo).FirstOrDefault();
            Lista.Remove(alumnoDB);
            return Content("BORRADO");
        }

    
        
        public IActionResult Borrar(int leg){
            var alumnoDB= Lista.Where(s=> s.Legajo==leg).FirstOrDefault();
            Lista.Remove(alumnoDB);
            return Content("BORRADO");
        }

    }
}
