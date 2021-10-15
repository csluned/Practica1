using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Profesor hereda de Personas
    public class Profesores:Personas
    {
        public int IdProfesor { get; set; }
        public double Sueldo { get; set; }
        public string Usuario { get; set; }
        //contraseña
        public string Password { get; set; }


        // Universidades hacer referencia a Sedes
        public Universidades[] listaSede { get; set; }

        public Profesores()
        {
            IdProfesor = 0;
            Sueldo =0.0;
            Usuario = string.Empty;
            Password = string.Empty;
            listaSede = new Universidades[5];
        }


    }




}
