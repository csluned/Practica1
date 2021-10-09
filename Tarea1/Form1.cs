using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea1.Ventanas;

namespace Tarea1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void open_fsedes(object sender, EventArgs e)
        {
            FormSede frmsede = new FormSede();
            frmsede.ShowDialog();

        }

        private void openFrmDocente(object sender, EventArgs e)
        {
            FormRegistrarD frD = new FormRegistrarD();
            frD.ShowDialog();

        }
    }
}
