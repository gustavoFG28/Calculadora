using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apCalculadora
{
    public partial class frmCalculadora : Form
    {
         bool MatrizPrecedencia;
        string sequenciaPosFixa;
        PilhaHerdaLista<double> valores;
        public frmCalculadora()
        {
            InitializeComponent();
        }
        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            sequenciaPosFixa = "";
            valores = new PilhaHerdaLista<double>();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Button qualBotao = (Button)sender;
            txtVisor.Text += qualBotao.Text;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            string sequenciaInfixa = txtVisor.Text;
            foreach(char character in sequenciaInfixa)
            {
                
            }
        }
    }
}
