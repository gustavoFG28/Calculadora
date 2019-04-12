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
        bool[,] precedencia;
        bool MatrizPrecedencia;
        string sequenciaPosFixa;
        PilhaHerdaLista<double> valores;
        PilhaHerdaLista<char> operadores;
        public frmCalculadora()
        {
            InitializeComponent();
        }
        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            sequenciaPosFixa = "";
            valores = new PilhaHerdaLista<double>();
            operadores = new PilhaHerdaLista<char>();
            precedencia = new bool[100, 100];
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
                QualCharacter(character, ref sequenciaPosFixa);
            }
            
            lbSequencia.Text = sequenciaPosFixa;
        }
        
        void QualCharacter(char c, ref string seq)
        {
            switch(c)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': seq += c; break;

                default: operadores.Empilhar(c); TratarOperador(c); break;
            }
        }

        void TratarOperador(char c)
        {
            while(!operadores.EstaVazia() && TemPrecedencia(operadores.OTopo(), c))
            {

            }
        }

        bool TemPrecedencia(char topo, char qual)
        {
            
            return true;
        }
    }
}
