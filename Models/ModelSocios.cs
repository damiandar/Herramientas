using System;
using System.ComponentModel.DataAnnotations;

namespace ProyClase3.Models
{
    public class Socios
    {
        public int NroSocio {get;set;}
        public string Nombre{get;set;}
        public string Apellido{get;set;}
        public DateTime fecha_pago{get;set;}
        public string estado{get;set;}
        public string Matricula{get;set;}

        public float Pago{get;set;}
        
        public DateTime fecha_nac{get;set;}

    }


    







}
