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
            //if(!operacao.EhOperador(qualBotao.Text[0].ToString()))
            //{
                txtVisor.Text += qualBotao.Text;
           // }
           /* else
            {
                char ultimoCaracter = ' ';
                if (txtVisor.Text.Length > 0)
                {
                    ultimoCaracter = txtVisor.Text[txtVisor.Text.Length - 1];

                    if (!operacao.EhOperador(ultimoCaracter.ToString()))
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


            }*/
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "0")
                operacao.Resetar();
            string seqIn = "";
            string seqPos = "";
            txtResultado.Text = operacao.Resultar(txtVisor.Text, ref seqIn,ref seqPos);
            lbSequencia.Text = seqIn + "";
            lbSequencia2.Text = seqPos + "";
        }

        private void btnApagarCaracter_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
        }
    }
}
