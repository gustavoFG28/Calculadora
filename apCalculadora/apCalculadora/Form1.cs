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
        int ponto = 0;
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
            lbInfixa.Text = "Infixa: ";
            lbPosfixa.Text = "Posfixa: ";
            txtResultado.Text = "0";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Button qualBotao = (Button)sender;
            if (!txtVisor.Text.Equals(""))
            {
                //if (qualBotao.Text  == ")")
                //{
                //    int abre = 0, fecha = 0;
                //    while (txtVisor.Text.IndexOf("(") != -1)
                //        abre++;
                //    while (txtVisor.Text.IndexOf(")") != -1)
                //        fecha++;
                //    txtVisor.Text += qualBotao.Text;
                //}

                if (!Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1] + ""))
                {
                    txtVisor.Text += qualBotao.Text;
                    ponto = 0;
                }
                else
                {

                    if (txtVisor.Text[txtVisor.Text.Length - 1] + "" == "*" ||
                        txtVisor.Text[txtVisor.Text.Length - 1] + "" == "/" ||
                        txtVisor.Text[txtVisor.Text.Length - 1] + "" == "^" ||
                        txtVisor.Text[txtVisor.Text.Length - 1] + "" == "V")
                    {
                        if (qualBotao.Text == "(")
                            txtVisor.Text += qualBotao.Text;
                    }
                   
                       

                }
                

            }
            else
                txtVisor.Text += qualBotao.Text;

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            Operacao operacao = null;
            if (txtVisor.Text != null)
            {
                operacao = new Operacao(txtVisor.Text);
                txtResultado.Text = operacao.CalcularExpressao() + "";
                lbInfixa.Text = "Infixa: " + operacao.SequenciaInfixa;
                lbPosfixa.Text = "Posfixa: " + operacao.SequenciaPosfixa;
            }
        }

        private void btnApagarCaracter_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
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
                    if(!txtVisor.Text.Equals(""))
                    btnApagarCaracter.PerformClick(); break;

                case Keys.Delete: btnLimpar.PerformClick(); break;
                case Keys.Add: btnAdicao.PerformClick(); break;
                case Keys.Subtract: btnSubtracao.PerformClick(); break;


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
            if (txtVisor.Text.Length != 0 && 
                (!Operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1] + "")&& 
                txtVisor.Text[txtVisor.Text.Length - 1] != '.'))
            {
                if (ponto == 0)
                {
                    txtVisor.Text += ".";
                    ponto++;
                }
            }

        }
    }
}
