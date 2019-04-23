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
        string sequenciaPosFixa;
        string[] vet;
        PilhaHerdaLista<double> valores;
        PilhaHerdaLista<char> operadores;
        double resultado;
        int cont = 0;
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
            sequenciaPosFixa = "";
            vet = new string[100];
            valores = new PilhaHerdaLista<double>();
            operadores = new PilhaHerdaLista<char>();
            cont = 0;
            resultado = 0;
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
            vet = new string['Z'];
            string sequenciaInfixa = txtVisor.Text;
            for (int i = 0; i < sequenciaInfixa.Length; i++)
            {
                string elemento = "";

                if (EhOperando(sequenciaInfixa[i]))
                {
                    elemento = "";
                    int inicial = i;
                    while (inicial + elemento.Length < sequenciaInfixa.Length && (EhOperando(sequenciaInfixa[inicial + elemento.Length]) || sequenciaInfixa[inicial + elemento.Length] == '.'))
                        elemento += sequenciaInfixa[inicial + elemento.Length];
                    i = inicial + elemento.Length - 1;
                }
                else
                    elemento = sequenciaInfixa[i] + "";

                vet[cont++] = elemento;
                TratarElemento(elemento, ref sequenciaPosFixa);
               
            }
            EscreverInfixa();

            TratarPilhaOperadores();

            Calcular();

            //lbSequencia.Text = sequenciaPosFixa;
            txtResultado.Text = resultado + "";
        }

        private void EscreverInfixa()
        {
            char pos = 'A';
            for(int i = 0; i < cont; i++)
            {
                if (EhOperador(vet[i]))
                    lbSequencia.Text += vet[i];
                else
                    lbSequencia.Text += pos++;
                
            }
        }

        private void TratarElemento(string c, ref string seq)
        {

            if (!EhOperador(c))
            {
                seq += c;
            }
            else
            {
                char operador = c[0];
                if (operadores.EstaVazia())
                {
                    operadores.Empilhar(operador);
                }
                else
                {
                    do
                    {
                        if (TemPrecedencia(operadores.OTopo(), operador))
                        {
                            char op = operadores.Desempilhar();
                            if (op != '(' && op != ')')
                            {
                                seq += op;
                            }

                            if (operadores.EstaVazia())
                            {
                                operadores.Empilhar(operador);
                                break;
                            }
                        }
                        else
                        {
                            operadores.Empilhar(operador);
                            break;
                        }
                    }
                    while (!operadores.EstaVazia());
                }
            }
        }

        private void TratarPilhaOperadores()
        {
            while(!operadores.EstaVazia())
            {
                char op = operadores.Desempilhar();
                if (op != '(' && op != ')')
                {
                    sequenciaPosFixa += op;
                }
            }
        }

        private bool TemPrecedencia(char a, char b)
        {
            if (a == ')')
                return false;

            return precedencia[a, b];
        }
        

        private bool EhOperador(string qual)
        {
            switch(qual)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "^":
                case "V":
                case "(":
                case ")": return true;

                default: return false;
            }
        }

        private bool EhOperando(char qual)
        {
            return qual >= '0' && qual <= '9';
        }

        private void IniciarMatrizPrecedencia()
        {
            precedencia['+', '+'] = true;
            precedencia['+', '-'] = true;
            precedencia['+', '*'] = false;
            precedencia['+', '/'] = false;
            precedencia['+', '^'] = false;
            precedencia['+', 'V'] = false;
            precedencia['+', '('] = false;
            precedencia['+', ')'] = true;
            precedencia['-', '+'] = true;
            precedencia['-', '-'] = true;
            precedencia['-', '*'] = false;
            precedencia['-', '/'] = false;
            precedencia['-', '^'] = false;
            precedencia['-', 'V'] = false;
            precedencia['-', '('] = false;
            precedencia['-', ')'] = true;
            precedencia['*', '+'] = true;
            precedencia['*', '-'] = true;
            precedencia['*', '*'] = true;
            precedencia['*', '/'] = true;
            precedencia['*', '^'] = false;
            precedencia['*', 'V'] = false;
            precedencia['*', '('] = false;
            precedencia['*', ')'] = true;
            precedencia['/', '+'] = true;
            precedencia['/', '-'] = true;
            precedencia['/', '*'] = true;
            precedencia['/', '/'] = true;
            precedencia['/', '^'] = false;
            precedencia['/', 'V'] = false;
            precedencia['/', '('] = false;
            precedencia['/', ')'] = true;
            precedencia['^', '+'] = true;
            precedencia['^', '-'] = true;
            precedencia['^', '*'] = true;
            precedencia['^', '/'] = true;
            precedencia['^', '^'] = true;
            precedencia['^', 'V'] = true;
            precedencia['^', '('] = false;
            precedencia['^', ')'] = true;
            precedencia['V', '+'] = true;
            precedencia['V', '-'] = true;
            precedencia['V', '*'] = true;
            precedencia['V', '/'] = true;
            precedencia['V', '^'] = true;
            precedencia['V', 'V'] = true;
            precedencia['V', '('] = false;
            precedencia['V', ')'] = true;
            precedencia['(', '+'] = false;
            precedencia['(', '-'] = false;
            precedencia['(', '*'] = false;
            precedencia['(', '/'] = false;
            precedencia['(', '^'] = false;
            precedencia['(', 'V'] = false;
            precedencia['(', '('] = false;
            precedencia['(', ')'] = true;

           
        }

        private void Calcular()
        {
            double v1 = 0, v2 = 0, result = 0;
            for (int c = 0; c < cont; c++)
            {
                if (EhOperando(sequenciaPosFixa[c]))
                {
                    valores.Empilhar(double.Parse(sequenciaPosFixa[c].ToString().Replace('.', ',')));
                }
                else
                {
                    v1 = valores.Desempilhar();
                    v2 = valores.Desempilhar();
                    switch (sequenciaPosFixa[c].ToString())
                    {
                        case "+": result = v2 + v1; break;
                        case "-": result = v2 - v1; break;
                        case "*": result = v2 * v1; break;
                        case "/": result = v2 / v1; break;
                        case "^": result = Math.Pow(v2, v1); break;
                        case "V": result = Math.Pow(v2, 1 / v1); break;
                    }
                    valores.Empilhar(result);
                }
            }

            this.resultado = valores.Desempilhar();
        }

        private void btn7_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void frmCalculadora_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtVisor_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
