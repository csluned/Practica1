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

        

            arraySede = LogicaSedes.getSedes();

            cbxListaSede.DisplayMember = "Descripcion";
            cbxListaSede.ValueMember = "IdSede";

            cbxListaSede.Items.Add(new { Descripcion = "Seleccionar", IdSede = 0 });
         

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


                Universidades sede = new Universidades();




                sede.IdSede = Convert.ToInt32((cbxListaSede.SelectedItem as dynamic).IdSede);
                sede.Descripcion = (cbxListaSede.SelectedItem as dynamic).Descripcion;


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

            if (docente.listaSede.Count(x => x != null) == 0)
            {

                MessageBox.Show("Debe Agregar una Sede", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else {


                docente.IdProfesor = Convert.ToInt32(textCarnet.Text);
                docente.Nombre = textNombre.Text;
                docente.Password = textPass.Text;
                docente.PrimerAp = textApellidos.Text;
                docente.Sueldo = Convert.ToDouble(textSalario.Text);
                docente.Usuario = textUsuario.Text;

                LogicaDocentes.GuardarDocente(docente);

            
            }


        }
    }
}
