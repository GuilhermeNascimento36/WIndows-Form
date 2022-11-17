using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnCadastrarPaciente_Click(object sender, EventArgs e)
        {
            Cadastro cad = new Cadastro();
            cad.Show();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            Buscar busca = new Buscar();
            busca.Show();
        }
    }
}
