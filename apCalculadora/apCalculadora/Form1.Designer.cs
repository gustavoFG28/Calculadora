﻿namespace apCalculadora
{
    partial class frmCalculadora
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculadora));
            this.txtVisor = new System.Windows.Forms.TextBox();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btnPonto = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btnPotenciacao = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnDivisao = new System.Windows.Forms.Button();
            this.btnMultiplicacao = new System.Windows.Forms.Button();
            this.btnSubtracao = new System.Windows.Forms.Button();
            this.btnAdicao = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.lbInfixa = new System.Windows.Forms.Label();
            this.btnRadiciacao = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnIgual = new System.Windows.Forms.Button();
            this.btnAbreParenteses = new System.Windows.Forms.Button();
            this.btnFechaParenteses = new System.Windows.Forms.Button();
            this.lbPosfixa = new System.Windows.Forms.Label();
            this.btnApagarCaracter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVisor
            // 
            this.txtVisor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisor.Location = new System.Drawing.Point(21, 9);
            this.txtVisor.Name = "txtVisor";
            this.txtVisor.ReadOnly = true;
            this.txtVisor.Size = new System.Drawing.Size(369, 31);
            this.txtVisor.TabIndex = 0;
            this.txtVisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVisor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(21, 163);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(69, 54);
            this.btn7.TabIndex = 1;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(21, 223);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(69, 54);
            this.btn4.TabIndex = 2;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(21, 283);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(69, 54);
            this.btn1.TabIndex = 3;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(21, 343);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(69, 54);
            this.btn0.TabIndex = 4;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(96, 163);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(69, 54);
            this.btn8.TabIndex = 5;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnPonto
            // 
            this.btnPonto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPonto.Location = new System.Drawing.Point(96, 343);
            this.btnPonto.Name = "btnPonto";
            this.btnPonto.Size = new System.Drawing.Size(69, 54);
            this.btnPonto.TabIndex = 8;
            this.btnPonto.Text = ".";
            this.btnPonto.UseVisualStyleBackColor = true;
            this.btnPonto.Click += new System.EventHandler(this.btnPonto_Click);
            this.btnPonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(96, 283);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(69, 54);
            this.btn2.TabIndex = 7;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(96, 223);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(69, 54);
            this.btn5.TabIndex = 6;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnPotenciacao
            // 
            this.btnPotenciacao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotenciacao.Location = new System.Drawing.Point(246, 283);
            this.btnPotenciacao.Name = "btnPotenciacao";
            this.btnPotenciacao.Size = new System.Drawing.Size(69, 54);
            this.btnPotenciacao.TabIndex = 12;
            this.btnPotenciacao.Text = "^";
            this.btnPotenciacao.UseVisualStyleBackColor = true;
            this.btnPotenciacao.Click += new System.EventHandler(this.btnPotencia_Click);
            this.btnPotenciacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(171, 283);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(69, 54);
            this.btn3.TabIndex = 11;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(171, 223);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(69, 54);
            this.btn6.TabIndex = 10;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(171, 163);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(69, 54);
            this.btn9.TabIndex = 9;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btnNumeros_Click);
            this.btn9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnDivisao
            // 
            this.btnDivisao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDivisao.Location = new System.Drawing.Point(321, 163);
            this.btnDivisao.Name = "btnDivisao";
            this.btnDivisao.Size = new System.Drawing.Size(69, 54);
            this.btnDivisao.TabIndex = 16;
            this.btnDivisao.Text = "/";
            this.btnDivisao.UseVisualStyleBackColor = true;
            this.btnDivisao.Click += new System.EventHandler(this.btnMultiplicacaoDivisao_Click);
            this.btnDivisao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnMultiplicacao
            // 
            this.btnMultiplicacao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplicacao.Location = new System.Drawing.Point(321, 223);
            this.btnMultiplicacao.Name = "btnMultiplicacao";
            this.btnMultiplicacao.Size = new System.Drawing.Size(69, 54);
            this.btnMultiplicacao.TabIndex = 15;
            this.btnMultiplicacao.Text = "*";
            this.btnMultiplicacao.UseVisualStyleBackColor = true;
            this.btnMultiplicacao.Click += new System.EventHandler(this.btnMultiplicacaoDivisao_Click);
            this.btnMultiplicacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnSubtracao
            // 
            this.btnSubtracao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubtracao.Location = new System.Drawing.Point(246, 223);
            this.btnSubtracao.Name = "btnSubtracao";
            this.btnSubtracao.Size = new System.Drawing.Size(69, 54);
            this.btnSubtracao.TabIndex = 14;
            this.btnSubtracao.Text = "-";
            this.btnSubtracao.UseVisualStyleBackColor = true;
            this.btnSubtracao.Click += new System.EventHandler(this.btnAdicaoSubtracao_Click);
            this.btnSubtracao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnAdicao
            // 
            this.btnAdicao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicao.Location = new System.Drawing.Point(246, 163);
            this.btnAdicao.Name = "btnAdicao";
            this.btnAdicao.Size = new System.Drawing.Size(69, 54);
            this.btnAdicao.TabIndex = 13;
            this.btnAdicao.Text = "+";
            this.btnAdicao.UseVisualStyleBackColor = true;
            this.btnAdicao.Click += new System.EventHandler(this.btnAdicaoSubtracao_Click);
            this.btnAdicao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(21, 49);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(369, 33);
            this.txtResultado.TabIndex = 17;
            this.txtResultado.Text = "0";
            this.txtResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtResultado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // lbInfixa
            // 
            this.lbInfixa.AutoSize = true;
            this.lbInfixa.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfixa.Location = new System.Drawing.Point(17, 89);
            this.lbInfixa.Name = "lbInfixa";
            this.lbInfixa.Size = new System.Drawing.Size(60, 21);
            this.lbInfixa.TabIndex = 18;
            this.lbInfixa.Text = "Infixa: ";
            // 
            // btnRadiciacao
            // 
            this.btnRadiciacao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRadiciacao.Location = new System.Drawing.Point(321, 283);
            this.btnRadiciacao.Name = "btnRadiciacao";
            this.btnRadiciacao.Size = new System.Drawing.Size(69, 54);
            this.btnRadiciacao.TabIndex = 19;
            this.btnRadiciacao.Text = "V";
            this.btnRadiciacao.UseVisualStyleBackColor = true;
            this.btnRadiciacao.Click += new System.EventHandler(this.btnRadiciacao_Click);
            this.btnRadiciacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(171, 343);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(69, 54);
            this.btnLimpar.TabIndex = 20;
            this.btnLimpar.Text = "C";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            this.btnLimpar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnIgual
            // 
            this.btnIgual.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgual.Location = new System.Drawing.Point(21, 403);
            this.btnIgual.Name = "btnIgual";
            this.btnIgual.Size = new System.Drawing.Size(219, 54);
            this.btnIgual.TabIndex = 21;
            this.btnIgual.Text = "=";
            this.btnIgual.UseVisualStyleBackColor = true;
            this.btnIgual.Click += new System.EventHandler(this.btnIgual_Click);
            this.btnIgual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnAbreParenteses
            // 
            this.btnAbreParenteses.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbreParenteses.Location = new System.Drawing.Point(246, 343);
            this.btnAbreParenteses.Name = "btnAbreParenteses";
            this.btnAbreParenteses.Size = new System.Drawing.Size(69, 54);
            this.btnAbreParenteses.TabIndex = 22;
            this.btnAbreParenteses.Text = "(";
            this.btnAbreParenteses.UseVisualStyleBackColor = true;
            this.btnAbreParenteses.Click += new System.EventHandler(this.btnAbreParenteses_Click);
            this.btnAbreParenteses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // btnFechaParenteses
            // 
            this.btnFechaParenteses.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechaParenteses.Location = new System.Drawing.Point(321, 343);
            this.btnFechaParenteses.Name = "btnFechaParenteses";
            this.btnFechaParenteses.Size = new System.Drawing.Size(69, 54);
            this.btnFechaParenteses.TabIndex = 23;
            this.btnFechaParenteses.Text = ")";
            this.btnFechaParenteses.UseVisualStyleBackColor = true;
            this.btnFechaParenteses.Click += new System.EventHandler(this.btnFechaParenteses_Click);
            this.btnFechaParenteses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // lbPosfixa
            // 
            this.lbPosfixa.AutoSize = true;
            this.lbPosfixa.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPosfixa.Location = new System.Drawing.Point(17, 121);
            this.lbPosfixa.Name = "lbPosfixa";
            this.lbPosfixa.Size = new System.Drawing.Size(70, 21);
            this.lbPosfixa.TabIndex = 24;
            this.lbPosfixa.Text = "Posfixa: ";
            // 
            // btnApagarCaracter
            // 
            this.btnApagarCaracter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagarCaracter.Location = new System.Drawing.Point(246, 403);
            this.btnApagarCaracter.Name = "btnApagarCaracter";
            this.btnApagarCaracter.Size = new System.Drawing.Size(144, 54);
            this.btnApagarCaracter.TabIndex = 25;
            this.btnApagarCaracter.Text = "CE";
            this.btnApagarCaracter.UseVisualStyleBackColor = true;
            this.btnApagarCaracter.Click += new System.EventHandler(this.btnApagarCaracter_Click);
            this.btnApagarCaracter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            // 
            // frmCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 469);
            this.Controls.Add(this.btnApagarCaracter);
            this.Controls.Add(this.lbPosfixa);
            this.Controls.Add(this.btnFechaParenteses);
            this.Controls.Add(this.btnAbreParenteses);
            this.Controls.Add(this.btnIgual);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnRadiciacao);
            this.Controls.Add(this.lbInfixa);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnDivisao);
            this.Controls.Add(this.btnMultiplicacao);
            this.Controls.Add(this.btnSubtracao);
            this.Controls.Add(this.btnAdicao);
            this.Controls.Add(this.btnPotenciacao);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnPonto);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.txtVisor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCalculadora";
            this.Text = "Calculadora";
            this.Load += new System.EventHandler(this.frmCalculadora_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVisor;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btnPonto;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btnPotenciacao;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnDivisao;
        private System.Windows.Forms.Button btnMultiplicacao;
        private System.Windows.Forms.Button btnSubtracao;
        private System.Windows.Forms.Button btnAdicao;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lbInfixa;
        private System.Windows.Forms.Button btnRadiciacao;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnIgual;
        private System.Windows.Forms.Button btnAbreParenteses;
        private System.Windows.Forms.Button btnFechaParenteses;
        private System.Windows.Forms.Label lbPosfixa;
        private System.Windows.Forms.Button btnApagarCaracter;
    }
}

