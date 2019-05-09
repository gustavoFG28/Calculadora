using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 *  Ana Clara Sampaio Pires - 18201
 *  Gustavo Ferreira Gitzel - 18194
*/

namespace apCalculadora
{
    public partial class frmCalculadora : Form
    {
        bool jaTemVirgula;  // Variável para controlar as virgulas digitadas
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)    // iniciamos  a variavel
        {
            jaTemVirgula = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)    // Método que limpa todos os campos
        {                       
            txtVisor.Clear();
            lbInfixa.Text = "Infixa: ";
            lbPosfixa.Text = "Posfixa: ";
            txtResultado.Text = "0";
        }

        private void btnIgual_Click(object sender, EventArgs e) // Método para resolver a expressão
        {
            try
            {
                Operacao operacao = null;       // objeto responsável por resolver a sequencia
                if (!string.IsNullOrEmpty(txtVisor.Text) && TemNumero() && // caso a expressão não esteja vazia, tenha números e o ultimo caracter é válido
                    (txtVisor.Text[txtVisor.Text.Length - 1] == ')' || !Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString()))) 
                {
                    if (EstaBalanceada(txtVisor.Text))  // Verifica se a expressão está balanceada
                    {
                        operacao = new Operacao(txtVisor.Text);     // instanciação do objeto
                        txtResultado.Text = operacao.CalcularExpressao() + "";  // método que retorna o resultado
                        lbInfixa.Text = "Infixa: " + operacao.SequenciaInfixa;  // mostramos as sequencias ao usuário
                        lbPosfixa.Text = "Posfixa: " + operacao.SequenciaPosfixa;
                    }
                    else
                        MessageBox.Show("O número de '(' deve ser igual ao número de ')'", "Expressão não balanceada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (DivideByZeroException)   // Exceção de divisão por 0
            {
                MessageBox.Show("Impossível calcular", "Divisão por 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotFiniteNumberException)    // Exceção de raiz negativa
            {
                MessageBox.Show("Impossível calcular", "Raiz negativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApagarCaracter_Click(object sender, EventArgs e)    // método de apagar o último caracter
        {
            if (!string.IsNullOrEmpty(txtVisor.Text))
            {
                if(txtVisor.Text.Length >= 2 && txtVisor.Text[txtVisor.Text.Length - 1] == '(' && txtVisor.Text[txtVisor.Text.Length - 2] == 'V')
                    txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 2);
                else
                    txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
            }
        }

        private void txtVisor_KeyDown(object sender, KeyEventArgs e)    // método de teclas apertadas
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
                case Keys.V: btnRadiciacao.PerformClick(); break;
                case Keys.None:
                case Keys.OemPeriod: btnPonto.PerformClick(); break;
            }
            txtVisor.Select(txtVisor.Text.Length, 0);
        }
        

        private void btnPonto_Click(object sender, EventArgs e) // Método de quando o . é selecionado
        {
            if (txtVisor.Text != "" && !jaTemVirgula && txtVisor.Text[txtVisor.Text.Length - 1] != '.' && !Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1] + ""))
            {
                txtVisor.Text += ".";
                jaTemVirgula = true;
            }
        }
        private void btnNumeros_Click(object sender, EventArgs e)// Método de quando algum número é selecionado
        {
            if (string.IsNullOrEmpty(txtVisor.Text) || txtVisor.Text[txtVisor.Text.Length - 1] != ')')
                txtVisor.Text += ((Button)sender).Text;
        }

        private void btnAdicaoSubtracao_Click(object sender, EventArgs e)   // Método de quando + ou - é selecionado
        {
            if (string.IsNullOrEmpty(txtVisor.Text) || (txtVisor.Text[txtVisor.Text.Length - 1] == 'V' || txtVisor.Text[txtVisor.Text.Length - 1] == '(' || !Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString()) && txtVisor.Text[txtVisor.Text.Length - 1] != '.'))
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }

        private void btnMultiplicacaoDivisao_Click(object sender, EventArgs e) // Método de quando * ou / é selecionado
        {
            if (!string.IsNullOrEmpty(txtVisor.Text) && txtVisor.Text[txtVisor.Text.Length - 1] != '(' && (!Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString()) || txtVisor.Text[txtVisor.Text.Length - 1] == ')') && txtVisor.Text[txtVisor.Text.Length - 1] != '.')
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }

        private void btnPotencia_Click(object sender, EventArgs e)  // Método de quando ^ é selecionado
        {
            if (!string.IsNullOrEmpty(txtVisor.Text) && txtVisor.Text[txtVisor.Text.Length - 1] != '.' && (txtVisor.Text[txtVisor.Text.Length - 1] == ')' || !Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString())))
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }

        private void btnRadiciacao_Click(object sender, EventArgs e)    // Método de quando a raiz quadrada é selecionada
        {
            if (string.IsNullOrEmpty(txtVisor.Text) || (Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString()) && txtVisor.Text[txtVisor.Text.Length - 1] != ')'))
            {
                txtVisor.Text += ((Button)sender).Text + "(";
                jaTemVirgula = false;
            }
        }

        private void btnAbreParenteses_Click(object sender, EventArgs e)    // Método de quando o ( é selecionado
        {
            if (string.IsNullOrEmpty(txtVisor.Text) || (txtVisor.Text[txtVisor.Text.Length - 1] != ')' && Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1].ToString()) && txtVisor.Text[txtVisor.Text.Length - 1] != '.'))
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }

        private void btnFechaParenteses_Click(object sender, EventArgs e)   // Método de quando o ) é selecionado
        {
            if (!string.IsNullOrEmpty(txtVisor.Text) && txtVisor.Text[txtVisor.Text.Length - 1] != '.' && (txtVisor.Text[txtVisor.Text.Length - 1] == ')' || !Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1] + "")))
            {
                txtVisor.Text += ((Button)sender).Text;
                jaTemVirgula = false;
            }
        }
        public static bool EstaBalanceada(String entrada)   // Método que verifica se a expressão está balanceada
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
                if (simbolo == '(')
                {
                    p.Empilhar(simbolo); // chamada causa overhead
                }
                else
                if (simbolo == ')')
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

        public static bool Combinam(char fecha, char abre)//verifica se os caracteres informados combinam
        {
            return fecha == ')' && abre == '(';
        }

        private bool TemNumero()    //verifica se há número na expressão
        {
            foreach (char possivelNumero in txtVisor.Text)
                if (!Operacao.EhOperador(possivelNumero + ""))
                    return true;
            return false;
        }
    }
}
