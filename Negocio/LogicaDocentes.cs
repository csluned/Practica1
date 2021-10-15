using System;
using Entidades;
using AccesoDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaDocentes
    {

        public static int GuardarDocente(Profesores docente)
        {

            ConexionDatos.GuardarDocente(docente);

            return 0; // Hace referencia a la regla que los datos estan correctos

        }


        public static Profesores[] GetProfesores() {
            return ConexionDatos.getProfesores();
        }

    }
}
