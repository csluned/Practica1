using System;
using Entidades;
using Negocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea1.Ventanas
{
    public partial class FormRegistrarD : Form
    {
        // Punto 1
        private Universidades[] arraySede;
        private Profesores docente = new Profesores();
        private int contador = 0;


        public FormRegistrarD()
        {
            InitializeComponent();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Cargar Datos;
        private void CargarDatos(object sender, EventArgs e)
        {
            //cargar los datos de la tabla

            cargarTabla();

            // carga los datos de la lista desplegable
            arraySede = LogicaSedes.getSedes();

            cbxListaSede.DisplayMember = "Descripcion";
            cbxListaSede.ValueMember = "IdSede";

            cbxListaSede.Items.Add(new { Descripcion = "Seleccionar", IdSede = 0 });
         
            // For que recorrer el array sede 
            for (int i = 0; i < arraySede.Count(x=> x!=null); i++)
            {
                cbxListaSede.Items.Add(new { Descripcion = arraySede[i].Descripcion, IdSede = arraySede[i].IdSede});
            }

            cbxListaSede.Refresh();
            cbxListaSede.SelectedIndex = 0;


        }

        private void agregarSedes(object sender, EventArgs e)
        {

            if (cbxListaSede.SelectedIndex != 0)
            {
                // falta validar que docente no aparezca en 2 misma sede

                // Punto 2
                Universidades sede = new Universidades();



                //Punto 3
                sede.IdSede = Convert.ToInt32((cbxListaSede.SelectedItem as dynamic).IdSede);
                sede.Descripcion = (cbxListaSede.SelectedItem as dynamic).Descripcion;

                //Punto 4
                docente.listaSede[contador] = sede;

                listBoxSede.Items.Add((cbxListaSede.SelectedItem as dynamic).Descripcion);

                contador++;
            }
            else {
                MessageBox.Show("Debe seleccionar una Sede", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void AddDocentes(object sender, EventArgs e)
        {
            try
            {

                if (docente.listaSede.Count(x => x != null) == 0)
                {

                    MessageBox.Show("Debe Agregar una Sede", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    // Punto 5
                    docente.IdProfesor = Convert.ToInt32(textCarnet.Text);
                    docente.Nombre = textNombre.Text;
                    docente.Password = textPass.Text;
                    docente.PrimerAp = textApellidos.Text;
                    docente.Sueldo = Convert.ToDouble(textSalario.Text);
                    docente.Usuario = textUsuario.Text;

                    // Punto 6
                    int resultado = LogicaDocentes.GuardarDocente(docente);

                    if (resultado == 0)
                    {
                        MessageBox.Show("Profesor se agrego correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarFormulario();
                        cargarTabla();
                    }

                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        private void limpiarFormulario() {

            // Se incializa el objeto docente
            docente = new Profesores();
            contador = 0;
            cbxListaSede.SelectedIndex = 0;
            textCarnet.Text = string.Empty;
            textNombre.Text = string.Empty;
            textPass.Text = string.Empty;
            textApellidos.Text = string.Empty;
            textSalario.Text = string.Empty;
            textUsuario.Text = string.Empty;
            listBoxSede.Items.Clear();


        }

        private void cargarTabla() {

            Profesores[] tempProfesores = LogicaDocentes.GetProfesores();
            TablaDocente.Rows.Clear();
            TablaDocente.Refresh();

            
            if (tempProfesores.Count(x => x != null) != 0) {

                for (int i = 0; i < tempProfesores.Count(x => x != null); i++) {

                    String sede = "";

                    for (int a = 0; a < tempProfesores[i].listaSede.Count(x => x != null); a++) {

                        sede += tempProfesores[i].listaSede[a].Descripcion + " ";

                    }

                    TablaDocente.Rows.Add(tempProfesores[i].IdProfesor,
                        tempProfesores[i].Nombre, tempProfesores[i].PrimerAp,
                        tempProfesores[i].Sueldo,sede);

                }

            }

        
        }

    }
}
