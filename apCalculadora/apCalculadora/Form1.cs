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
        bool jaTemVirgula;
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            jaTemVirgula = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
            lbInfixa.Text = "Infixa: ";
            lbPosfixa.Text = "Posfixa: ";
            txtResultado.Text = "0";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                Operacao operacao = null;
                if (!string.IsNullOrEmpty(txtVisor.Text) && TemNumero())
                {
                    if (EstaBalanceada(txtVisor.Text))
                    {
                        operacao = new Operacao(txtVisor.Text);
                        txtResultado.Text = operacao.CalcularExpressao() + "";
                        lbInfixa.Text = "Infixa: " + operacao.SequenciaInfixa;
                        lbPosfixa.Text = "Posfixa: " + operacao.SequenciaPosfixa;
                    }
                    else
                        MessageBox.Show("A expressão está incorreta");
                }
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Impossível calcular", "Divisão por 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotFiniteNumberException)
            {
                MessageBox.Show("Impossível calcular", "Raiz negativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApagarCaracter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVisor.Text))
            {
                if(txtVisor.Text.Length >= 2 && txtVisor.Text[txtVisor.Text.Length - 1] == '(' && txtVisor.Text[txtVisor.Text.Length - 2] == 'V')
                    txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 2);
                else
                    txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
            }
        }

        private void txtVisor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0: btn0.PerformClick(); break;
                case Keys.D1:
                case Keys.NumPad1: btn1.PerformClick(); break;
                case Keys.D2:
                case Keys.NumPad2: btn2.PerformClick(); break;
                case Keys.D3:
                case Keys.NumPad3: btn3.PerformClick(); break;
                case Keys.D4:
                case Keys.NumPad4: btn4.PerformClick(); break;
                case Keys.D5:
                case Keys.NumPad5: btn5.PerformClick(); break;
                case Keys.D6:
                case Keys.NumPad6: btn6.PerformClick(); break;
                case Keys.D7:
                case Keys.NumPad7: btn7.PerformClick(); break;
                case Keys.D8:
                case Keys.NumPad8: btn8.PerformClick(); break;
                case Keys.D9:
                case Keys.NumPad9: btn9.PerformClick(); break;
                case Keys.Back:
                    if (!txtVisor.Text.Equals(""))
                        btnApagarCaracter.PerformClick(); break;

                case Keys.Delete: btnLimpar.PerformClick(); break;
                case Keys.Add: btnAdicao.PerformClick(); break;
                case Keys.Subtract: btnSubtracao.PerformClick(); break;
                case Keys.Enter: btnIgual.PerformClick(); break;
                case Keys.Divide: btnDivisao.PerformClick(); break;
                case Keys.Multiply: btnMultiplicacao.PerformClick(); break;
                case Keys.Oemtilde: btnPotenciacao.PerformClick(); break;
                case Keys.V: btnRadiciacao.PerformClick(); break;
                case Keys.OemPeriod: btnPonto.PerformClick(); break;
                case Keys.OemOpenBrackets: btnAbreParenteses.PerformClick(); break;
                case Keys.OemCloseBrackets: btnFechaParenteses.PerformClick(); break;
            }
            txtVisor.Select(txtVisor.Text.Length, 0);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text.Length == 0 || txtVisor.Text[txtVisor.Text.Length - 1] != ')')
                txtVisor.Text += ((Button)sender).Text;
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text != "" && !jaTemVirgula && txtVisor.Text[txtVisor.Text.Length - 1] != '.' && !Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1] + ""))
            {
                txtVisor.Text += ".";
                jaTemVirgula = true;
            }
        }
        private void btnNumeros_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVisor.Text) || txtVisor.Text[txtVisor.Text.Length - 1] != ')')
                txtVisor.Text += ((Button)sender).Text;
        }

        private void btnAdicaoSubtracao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVisor.Text) || (txtVisor.Text[txtVisor.Text.Length - 1] == 'V' || txtVisor.Text[txtVisor.Text.Length - 1] == '(' || !Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString()) && txtVisor.Text[txtVisor.Text.Length - 1] != '.'))
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }

        private void btnMultiplicacaoDivisao_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVisor.Text) && txtVisor.Text[txtVisor.Text.Length - 1] != '(' && (!Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString()) || txtVisor.Text[txtVisor.Text.Length - 1] == ')') && txtVisor.Text[txtVisor.Text.Length - 1] != '.')
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }

        private void btnPotencia_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVisor.Text) && txtVisor.Text[txtVisor.Text.Length - 1] != '.' && (txtVisor.Text[txtVisor.Text.Length - 1] == ')' || !Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString())))
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }

        private void btnRadiciacao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVisor.Text) || (Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString()) && txtVisor.Text[txtVisor.Text.Length - 1] != ')'))
            {
                txtVisor.Text += ((Button)sender).Text + "(";
                jaTemVirgula = false;
            }
        }

        private void btnAbreParenteses_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVisor.Text) || (txtVisor.Text[txtVisor.Text.Length - 1] != ')' && Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString()) && txtVisor.Text[txtVisor.Text.Length - 1] != '.'))
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }

        private void btnFechaParenteses_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVisor.Text) && txtVisor.Text[txtVisor.Text.Length - 1] != '.' && (txtVisor.Text[txtVisor.Text.Length - 1] == ')' || !Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1] + "")))
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }
        public static bool EstaBalanceada(String entrada)
        {
            // construtor com tamanho default; topo valerá -1
            PilhaHerdaLista<char> p = new PilhaHerdaLista<char>();
            bool balanceada = true;
            int indice = 0;
            char simbolo;
            char caracterAbertura;
            for (indice = 0; balanceada && indice < entrada.Length; indice++)
            {
                simbolo = entrada[indice];
                if (simbolo == '{' || simbolo == '[' || simbolo == '(')
                {
                    p.Empilhar(simbolo); // chamada causa overhead
                }
                else
                if (simbolo == '}' || simbolo == ']' || simbolo == ')')
                    if (p.EstaVazia())
                        balanceada = false; // pois a pilha já esvaziou
                    else
                    {
                        caracterAbertura = p.Desempilhar();
                        if (!Combinam(simbolo, caracterAbertura))
                            balanceada = false;
                    }
            }
            if (!p.EstaVazia())
                balanceada = false;
            return balanceada;
        }

        public static bool Combinam(char fecha, char abre)
        {
            return ((fecha == ']' && abre == '[') ||
                    (fecha == ')' && abre == '(') ||
                    (fecha == '}' && abre == '{'));
        }

        private bool TemNumero()
        {
            foreach (char possivelNumero in txtVisor.Text)
                if (!Operacao.EhOperador(possivelNumero + ""))
                    return true;
            return false;
        }
    }
}
