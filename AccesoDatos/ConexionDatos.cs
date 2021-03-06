using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ConexionDatos
    {
        // Primeros Niveles 
        private static Universidades[] dataSedes = new Universidades[20];
        private static Profesores[] dataDocentes = new Profesores[20];

        private static int index1 = 0;

        public static bool GuardarSede(Universidades sede) {

            dataSedes[index1] = sede;
            index1++;

            return true;
        }

        // Metodo que valida si un codigo esta repetido
        public static bool SiexisteSede(int IdSede) {

            if (index1 > 0) { 
            
               
                for( int i = 0; i < index1; i++)
                {
                    if(dataSedes[i].IdSede == IdSede)
                    {
                        return true;
                    }
                }

                /*
                foreach(Universidades item in dataSedes)
                {
                    if (item.Descripcion != null) {
                        if (item.IdSede == IdSede)
                        {

                            return true;
                        }

                    }  

                }*/

            }


            return false;
        
        }

         public static int cantidad()
        {
            return index1 + 1;
        }

        // Retorna los datos a la capa de Negocio y posterior a la presentacion 
        public static Universidades[] getSede() {

            return dataSedes;
        }

        public static bool GuardarDocente(Profesores docente)
        {
            dataDocentes[dataDocentes.Count(x => x != null)] = docente;
            return true;
        }

        public static Profesores[] getProfesores() {

            return dataDocentes;


        }



    }
}
