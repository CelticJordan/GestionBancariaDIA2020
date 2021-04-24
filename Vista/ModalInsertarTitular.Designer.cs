using System.ComponentModel;
using System.Drawing;

namespace DIA_BANCO_V1
{
    partial class ModalInsertarTitular
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textDNIbuscarTitular = new System.Windows.Forms.TextBox();
            this.textNombreBuscarTitular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Insertar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textDNIbuscarTitular
            // 
            this.textDNIbuscarTitular.Location = new System.Drawing.Point(41, 109);
            this.textDNIbuscarTitular.Name = "textDNIbuscarTitular";
            this.textDNIbuscarTitular.Size = new System.Drawing.Size(196, 26);
            this.textDNIbuscarTitular.TabIndex = 1;
            this.textDNIbuscarTitular.TextChanged += new System.EventHandler(this.textDNIbuscarTitular_TextChanged);
            // 
            // textNombreBuscarTitular
            // 
            this.textNombreBuscarTitular.Location = new System.Drawing.Point(243, 109);
            this.textNombreBuscarTitular.Name = "textNombreBuscarTitular";
            this.textNombreBuscarTitular.Size = new System.Drawing.Size(196, 26);
            this.textNombreBuscarTitular.TabIndex = 2;
            this.textNombreBuscarTitular.TextChanged += new System.EventHandler(this.textNombreBuscarTitular_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(52, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar por DNI";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(265, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buscar por nombre";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Dni, this.Nombre, this.Insertar});
            this.dataGridView1.Location = new System.Drawing.Point(43, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(611, 220);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Dni
            // 
            this.Dni.HeaderText = "Dni";
            this.Dni.Name = "Dni";
            this.Dni.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Insertar
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LawnGreen;
            this.Insertar.DefaultCellStyle = dataGridViewCellStyle1;
            this.Insertar.HeaderText = "Insertar";
            this.Insertar.Name = "Insertar";
            this.Insertar.ReadOnly = true;
            // 
            // ModalInsertarTitular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNombreBuscarTitular);
            this.Controls.Add(this.textDNIbuscarTitular);
            this.Name = "ModalInsertarTitular";
            this.Text = "ModalInsertarTitular";
            this.Load += new System.EventHandler(this.ModalInsertarTitular_Load);
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn Dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Insertar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDNIbuscarTitular;
        private System.Windows.Forms.TextBox textNombreBuscarTitular;

        #endregion
    }
}