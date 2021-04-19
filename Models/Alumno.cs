using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace ProyClase3.Models
{
    public class Alumno
    {
        [Required]
        public int Legajo {get;set;}
        
        [Required]
        public string Nombre {get;set;}
        [Required]
        [MaxLength(15)]
        public string Apellido {get;set;}
    
        public int Dni{get;set;}
        public string PaisNombre {get;set;}
        public string Sexo {get;set;}
        [Range(18,150,ErrorMessage="Debe poner")]
        public int Edad{get;set;}

        public Pais Pais{get;set;}


        public string FotoRuta {get;set;}
        [NotMapped()]
        public IFormFile Foto {get;set;}
    }
}