using System.Collections.Generic;

namespace ProyClase3.Models
{
    public class AlumnoVM
    {
        public Alumno Alumno{get;set;}
        public List<Pais> Paises{
            get {
                return new List<Pais>()          
                {
                    new Pais(){Id=1,Nombre="Argentina"},
                    new Pais(){Id=2,Nombre="Bolivia"},
                    new Pais(){Id=3,Nombre="Uruguay"},
                    new Pais(){Id=4,Nombre="Paraguay"},
                    new Pais(){Id=5,Nombre="Chile"},
                    new Pais(){Id=6,Nombre="Brasil"}
                };

            }
        }

    }
}