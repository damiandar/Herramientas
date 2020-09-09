using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyClase3.Models;

namespace TP2.Controllers
{
    public class SociosController : Controller
    {
        static List<Socios> Lista=new List<Socios>()
        {   
            new Socios(){NroSocio=23,Nombre="Carlos",Apellido="Fernandez",estado="",Matricula="",fecha_pago=new DateTime(2020, 8, 31),fecha_nac=new DateTime(1996, 8, 18)},
            new Socios(){NroSocio=46,Nombre="Juana",Apellido="Viale",estado="",Matricula="",fecha_pago=new DateTime(2020, 1, 31),fecha_nac=new DateTime(1991, 3, 24)},
            new Socios(){NroSocio=55,Nombre="Marcos",Apellido="Peña",estado="",Matricula="",fecha_pago=new DateTime(2020, 8, 31),fecha_nac=new DateTime(1987, 9, 11)},
            new Socios(){NroSocio=48,Nombre="Viviana",Apellido="Saccone",estado="",Matricula="",fecha_pago=new DateTime(2020, 8, 31),fecha_nac=new DateTime(1994, 10, 9)},
            new Socios(){NroSocio=45,Nombre="Pedro",Apellido="Alvarez",estado="",Matricula="",fecha_pago=new DateTime(2020, 7, 01),fecha_nac=new DateTime(1991, 12, 4)}
            
        };
        
        public IActionResult Index()
        {
            ViewBag.MesajeBienvenida="Socios";
            var cant=Lista.Count();
            TimeSpan aux;
            int cant_dias;
                for(int indice=0;indice<cant;indice++)
                {
                var socio=Lista[indice];
                aux=(DateTime.Today-socio.fecha_pago);
                cant_dias=aux.Days;
                        if(cant_dias>30)
                        {
                            if(cant_dias>90)
                            {Lista[indice].Matricula="Vencida";}
                            else
                            {Lista[indice].Matricula="Normal";}
                                Lista[indice].estado="Pago Atrasado";
                        }                        
                        else
                        {
                                Lista[indice].estado="Pago Normal";
                                Lista[indice].Matricula="Normal";
                        }
                }
        Lista=Lista.OrderBy(s=>s.NroSocio).ToList();
        return View(Lista);
        }


public IActionResult Atrasados()
        {
            List<Socios> Lista2=new List<Socios>();            
            var cant=Lista.Count();            
               for(int indice=0;indice<cant;indice++)
               {
               if(Lista[indice].estado=="Pago Atrasado")
                    {
                     Lista2.Add(Lista[indice]);
                    }
                }
                        
            return View(Lista2);
        }

public IActionResult Cumpleanios()
        {
            List<Socios> Lista2=new List<Socios>();            
            var cant=Lista.Count();   
            var mes_actual=DateTime.Now.Month;

               for(int indice=0;indice<cant;indice++)
               {
               if(Lista[indice].fecha_nac.Month==mes_actual)
                    {
                     Lista2.Add(Lista[indice]);
                    }
                }                        
            return View(Lista2);
        }
        
       

        public IActionResult Detalle(int Nro)
        {
            var socio=Lista.Where(s=> s.NroSocio==Nro).FirstOrDefault();
            return View(socio);
        }


         [HttpPost,ActionName("Borrar")]
        public IActionResult Borrar(Socios SocioFormulario){
            var SocioDB= Lista.Where(s=> s.NroSocio==SocioFormulario.NroSocio).FirstOrDefault();
            Lista.Remove(SocioDB);
            return Content("BORRADO");
        }

        public IActionResult Editar(int nro)
        {
            var SocioDB= Lista.Where(s=> s.NroSocio==nro).FirstOrDefault();
            return View(SocioDB);
        }

         [HttpPost]
        public IActionResult Editar(Socios socioFormulario){
            int CantLista=Lista.Count();
                for(int indice=0;indice<CantLista;indice++)
                {
                    if(Lista[indice].NroSocio==socioFormulario.NroSocio)
                    {
                        Lista[indice].Apellido=socioFormulario.Apellido;
                        Lista[indice].Nombre=socioFormulario.Nombre;
                    }
                }           
            return RedirectToAction("Index");
        }


        public IActionResult Pagos(int Nro)
        {
            var socio=Lista.Where(s=> s.NroSocio==Nro).FirstOrDefault();
            return View(socio);
        }

         [HttpPost]
        public IActionResult Pagos(Socios socioFormulario){
             int CantLista=Lista.Count();
                for(int indice=0;indice<CantLista;indice++)
                {
                    if(Lista[indice].NroSocio==socioFormulario.NroSocio)
                    {
                        Lista[indice].Pago=socioFormulario.Pago;  
                        Lista[indice].fecha_pago=DateTime.Now;                    
                    }
                }           
            return RedirectToAction("Index");
        }

          public IActionResult Nuevo()
        {
            return View();
        }

       
        [HttpPost, ActionName("Nuevo")]
        public IActionResult GuardarNuevoAlumno(Socios SocioFormulario){
            Lista.Add(SocioFormulario);
            return RedirectToAction("Index");
        }





    }
}
