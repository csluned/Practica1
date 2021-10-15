using System;
using AccesoDatos;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaSedes
    {

        public static int GuardarSedes(Universidades sedes) {


            // Primera regla la descripcion no debe estar vacia
            if (String.IsNullOrEmpty(sedes.Descripcion))
            {
                return 1;
            }


            // Segunda regla el codigo no se debe repetir dentro del Array
            if (ConexionDatos.SiexisteSede(sedes.IdSede)) {

                return 2;
            }

            // Tercera que permite validar la cantida Espacio en el Array

            if (ConexionDatos.cantidad() > 20) {

                return 3; // tercera regla
            
            }

            ConexionDatos.GuardarSede(sedes);

            return 0; // Hace referencia a la regla que los datos estan correctos
        
        }

        public static bool ComprobarSede() {

            Universidades[] tempSede = ConexionDatos.getSede();

            if (tempSede.Count(x => x != null) == 0) {
                return true;
            }

            return false;

        }


        public static Universidades[] getSedes() {
            return ConexionDatos.getSede();
        }





    }
}
