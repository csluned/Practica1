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
    public partial class FormSede : Form
    {
        public FormSede()
        {
            InitializeComponent();
        }


        // Evento guardar Datos de la sede capa de presentacion
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {

                Universidades sede = new Universidades();
                sede.IdSede = Convert.ToInt32(textCodigo.Text);
                sede.Descripcion = textDesp.Text;

                int regla = LogicaSedes.GuardarSedes(sede);

                switch (regla)
                {
                    //Caso 0 cuando todas la regla de negocio se cumple
                    case 0:
                        CuadroDialogo("Sede Registrada", "Registro", MessageBoxIcon.Information);
                        LimpiarFormulario();
                        break;
                    case 1:
                        CuadroDialogo("Campo descripcion vacia", "Validación", MessageBoxIcon.Warning);
                        textDesp.Focus();
                        break;
                    case 2:
                        CuadroDialogo("El codigo "+sede.IdSede+" existe", "Validación", MessageBoxIcon.Warning);
                        break;
                    case 3:
                        CuadroDialogo("No se puede registrar mas sedes", "Advertencia", MessageBoxIcon.Warning);
                        break;
                }


            } catch (Exception ex) {
                CuadroDialogo(ex.Message, "Error de Sistema", MessageBoxIcon.Error);

            }

        }


        private void CuadroDialogo(string mensaje, string titulo,MessageBoxIcon icono)
        {

            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);

        }

        private void LimpiarFormulario() {

            textCodigo.Text = null;
            textDesp.Text = null;
        
        }


    }
}
