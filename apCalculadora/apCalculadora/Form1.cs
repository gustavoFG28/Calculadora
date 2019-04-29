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
        Operacao operacao;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            operacao = new Operacao();
            MessageBox.Show("a");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
            lbSequencia.Text = "";
            lbSequencia2.Text = "";
            txtResultado.Text = "0";
            operacao.Resetar();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Button qualBotao = (Button)sender;
            if (!txtVisor.Text.Equals(""))
            {
                if (!operacao.EhOperador(txtVisor.Text[txtVisor.Text.Length - 1] + ""))
                    txtVisor.Text += qualBotao.Text;
            }
            else
                txtVisor.Text += qualBotao.Text;

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "0")
                operacao.Resetar();
            string seqIn = "";
            string seqPos = "";
            txtResultado.Text = operacao.Resultar(txtVisor.Text, ref seqIn, ref seqPos);
            lbSequencia.Text = seqIn + "";
            lbSequencia2.Text = seqPos + "";
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
    }
}
