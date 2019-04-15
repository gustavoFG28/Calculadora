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
        double resultado;

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
            IniciarMatrizPrecedencia();
            resultado = 0.0;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
            lbSequencia.Text = "";
            txtResultado.Clear();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Button qualBotao = (Button)sender;
            if(EhOperando(qualBotao.Text[0]))
            {
                txtVisor.Text += qualBotao.Text;
            }
            else
            {
                char ultimoCaracter = ' ';
                if (txtVisor.Text.Length > 0)
                {
                    ultimoCaracter = txtVisor.Text[txtVisor.Text.Length - 1];

                    if (EhOperando(ultimoCaracter))
                    {
                            txtVisor.Text += qualBotao.Text;
                    }
                    else
                    {
                        if (qualBotao.Text == "(")
                            txtVisor.Text += qualBotao.Text;

                        if(ultimoCaracter == ')')
                        {
                            if(qualBotao.Text!= "(")
                                txtVisor.Text += qualBotao.Text;
                        }
                    }
                }
                else
                    if (qualBotao.Text == "(")
                    txtVisor.Text += qualBotao.Text;


            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            string sequenciaInfixa = txtVisor.Text;
            foreach (char character in sequenciaInfixa)
            {
                    TratarCaracter(character, ref sequenciaPosFixa);    
                
            }

            TratarPilhaOperadores();

            Calcular();

            lbSequencia.Text = sequenciaPosFixa;
            txtResultado.Text = resultado + "";
        }
        
        private void TratarCaracter(char c, ref string seq)
        {
           
            if (EhOperando(c))
                seq += c;
            else
            {
                if (operadores.EstaVazia())
                        operadores.Empilhar(c);
                    else
                        if(TemPrecedencia(c,operadores.OTopo()))
                        {
                            operadores.Empilhar(c);
                        }
                        else
                        {
                            seq += operadores.Desempilhar();
                           TratarCaracter(c, ref seq);
                        }
                        
                    
            }
        }

        private void TratarPilhaOperadores()
        {
            if(!operadores.EstaVazia())
            {
                sequenciaPosFixa += operadores.Desempilhar();
            }
        }

        private bool TemPrecedencia(char a, char b)
        {
            return precedencia[a, b];
        }
        

        private bool EhOperando(char qual)
        {
            switch(qual)
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
                case '9': return true; break;
            }
            return false;
        }

        private void IniciarMatrizPrecedencia()
        {
            precedencia['+', '+'] = true;
            precedencia['+', '-'] = true;
            precedencia['-', '+'] = true;
            precedencia['-', '-'] = true;
            precedencia['+', '*'] = false;
            precedencia['*', '+'] = true;

        }

        private void Calcular()
        {
            PilhaHerdaLista<double> resultado = new PilhaHerdaLista<double>();
            double v1 = 0, v2 = 0;
        }
        

    }
}
