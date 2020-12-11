using System.ComponentModel;

namespace DIA_BANCO_V1
{
    partial class ModalInsertarCuenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textCCC = new System.Windows.Forms.TextBox();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.textSaldo = new System.Windows.Forms.TextBox();
            this.textDNITitular = new System.Windows.Forms.TextBox();
            this.BotonGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textCCC
            // 
            this.textCCC.Location = new System.Drawing.Point(305, 81);
            this.textCCC.Name = "textCCC";
            this.textCCC.Size = new System.Drawing.Size(168, 26);
            this.textCCC.TabIndex = 0;
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {"Ahorro", "Vivienda", "Corriente"});
            this.comboTipo.Location = new System.Drawing.Point(305, 127);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(167, 28);
            this.comboTipo.TabIndex = 1;
            // 
            // textSaldo
            // 
            this.textSaldo.Location = new System.Drawing.Point(305, 173);
            this.textSaldo.Name = "textSaldo";
            this.textSaldo.Size = new System.Drawing.Size(168, 26);
            this.textSaldo.TabIndex = 29;
            // 
            // textDNITitular
            // 
            this.textDNITitular.Location = new System.Drawing.Point(305, 220);
            this.textDNITitular.Name = "textDNITitular";
            this.textDNITitular.Size = new System.Drawing.Size(168, 26);
            this.textDNITitular.TabIndex = 36;
            // 
            // BotonGuardar
            // 
            this.BotonGuardar.Location = new System.Drawing.Point(230, 278);
            this.BotonGuardar.Name = "BotonGuardar";
            this.BotonGuardar.Size = new System.Drawing.Size(345, 60);
            this.BotonGuardar.TabIndex = 39;
            this.BotonGuardar.Text = "Guardar";
            this.BotonGuardar.UseVisualStyleBackColor = true;
            this.BotonGuardar.Click += new System.EventHandler(this.BotonGuardar_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(241, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "CCC";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(241, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(241, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Saldo";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(202, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "DNI Titular";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(337, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "Insertar nueva cuenta";
            // 
            // ModalInsertarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BotonGuardar);
            this.Controls.Add(this.textDNITitular);
            this.Controls.Add(this.textSaldo);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.textCCC);
            this.Name = "ModalInsertarCuenta";
            this.Text = "ModalInsertarCuenta";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button BotonGuardar;
        private System.Windows.Forms.TextBox textDNITitular;
        private System.Windows.Forms.TextBox textSaldo;

        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.TextBox textCCC;

        #endregion
    }
}