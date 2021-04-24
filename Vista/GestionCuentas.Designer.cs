using System.Drawing;

namespace DIA_BANCO_V1
{
    partial class GestionCuentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnInsertarTransferencia = new System.Windows.Forms.Button();
            this.dataGridTransferencias = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCCOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCCDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrarTransferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textConceptoRetirada = new System.Windows.Forms.TextBox();
            this.textCantidadRetirada = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textCantidadDeposito = new System.Windows.Forms.TextBox();
            this.textConceptoDeposito = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BotonInsertarCuenta = new System.Windows.Forms.Button();
            this.BotonListarTodos = new System.Windows.Forms.Button();
            this.textBuscarDni = new System.Windows.Forms.TextBox();
            this.textBuscarCCC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridCuentas = new System.Windows.Forms.DataGridView();
            this.CCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaApertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intereses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNITitular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrarCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraficoSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonInsertarTitulares = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Titulareslabel = new System.Windows.Forms.Label();
            this.dataGridTitulares = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrarTitular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonInsertarRetirada = new System.Windows.Forms.Button();
            this.dataGridRetiradas = new System.Windows.Forms.DataGridView();
            this.DatetimeRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConceptoRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrarRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.Retiradaslabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Depositoslabel = new System.Windows.Forms.Label();
            this.botonInsertarDeposito = new System.Windows.Forms.Button();
            this.dataGridDepositos = new System.Windows.Forms.DataGridView();
            this.Datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConceptoDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorarDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientosPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciasPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciasBancoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficoGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarXMLYSalirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnInsertarPrestamo = new System.Windows.Forms.Button();
            this.dataGridPrestamos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridTransferencias)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridTitulares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridRetiradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridDepositos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.dataGridPrestamos);
            this.panel1.Controls.Add(this.btnInsertarPrestamo);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnInsertarTransferencia);
            this.panel1.Controls.Add(this.dataGridTransferencias);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textConceptoRetirada);
            this.panel1.Controls.Add(this.textCantidadRetirada);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textCantidadDeposito);
            this.panel1.Controls.Add(this.textConceptoDeposito);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.botonInsertarTitulares);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Titulareslabel);
            this.panel1.Controls.Add(this.dataGridTitulares);
            this.panel1.Controls.Add(this.botonInsertarRetirada);
            this.panel1.Controls.Add(this.dataGridRetiradas);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Retiradaslabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Depositoslabel);
            this.panel1.Controls.Add(this.botonInsertarDeposito);
            this.panel1.Controls.Add(this.dataGridDepositos);
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2279, 966);
            this.panel1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label11.Location = new System.Drawing.Point(1199, 625);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(240, 26);
            this.label11.TabIndex = 53;
            this.label11.Text = "de la cuenta selecionada";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label12.Location = new System.Drawing.Point(1199, 582);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(240, 43);
            this.label12.TabIndex = 52;
            this.label12.Text = "Transferencias";
            // 
            // btnInsertarTransferencia
            // 
            this.btnInsertarTransferencia.BackColor = System.Drawing.Color.SpringGreen;
            this.btnInsertarTransferencia.Location = new System.Drawing.Point(1199, 656);
            this.btnInsertarTransferencia.Name = "btnInsertarTransferencia";
            this.btnInsertarTransferencia.Size = new System.Drawing.Size(693, 29);
            this.btnInsertarTransferencia.TabIndex = 51;
            this.btnInsertarTransferencia.Text = "Insertar nueva transferencia";
            this.btnInsertarTransferencia.UseVisualStyleBackColor = false;
            this.btnInsertarTransferencia.Click += new System.EventHandler(this.btnInsertarTransferencia_Click);
            // 
            // dataGridTransferencias
            // 
            this.dataGridTransferencias.AllowUserToAddRows = false;
            this.dataGridTransferencias.AllowUserToDeleteRows = false;
            this.dataGridTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTransferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.ID, this.TipoTrans, this.CCCOrig, this.CCCDest, this.Importe, this.Fecha, this.BorrarTransferencia});
            this.dataGridTransferencias.Location = new System.Drawing.Point(1199, 691);
            this.dataGridTransferencias.Name = "dataGridTransferencias";
            this.dataGridTransferencias.ReadOnly = true;
            this.dataGridTransferencias.RowTemplate.Height = 28;
            this.dataGridTransferencias.Size = new System.Drawing.Size(755, 249);
            this.dataGridTransferencias.TabIndex = 50;
            this.dataGridTransferencias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTransferencias_CellClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 51;
            // 
            // TipoTrans
            // 
            this.TipoTrans.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TipoTrans.HeaderText = "TipoTrans";
            this.TipoTrans.Name = "TipoTrans";
            this.TipoTrans.ReadOnly = true;
            this.TipoTrans.Width = 104;
            // 
            // CCCOrig
            // 
            this.CCCOrig.HeaderText = "CCCOrig";
            this.CCCOrig.Name = "CCCOrig";
            this.CCCOrig.ReadOnly = true;
            // 
            // CCCDest
            // 
            this.CCCDest.HeaderText = "CCCDest";
            this.CCCDest.Name = "CCCDest";
            this.CCCDest.ReadOnly = true;
            // 
            // Importe
            // 
            this.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 89;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 79;
            // 
            // BorrarTransferencia
            // 
            this.BorrarTransferencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Red;
            this.BorrarTransferencia.DefaultCellStyle = dataGridViewCellStyle2;
            this.BorrarTransferencia.HeaderText = "BorrarTransferencia";
            this.BorrarTransferencia.Name = "BorrarTransferencia";
            this.BorrarTransferencia.ReadOnly = true;
            this.BorrarTransferencia.Width = 175;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label10.Location = new System.Drawing.Point(1714, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 26);
            this.label10.TabIndex = 49;
            this.label10.Text = "Concepto";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label9.Location = new System.Drawing.Point(2141, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 26);
            this.label9.TabIndex = 48;
            this.label9.Text = "Cantidad";
            // 
            // textConceptoRetirada
            // 
            this.textConceptoRetirada.Location = new System.Drawing.Point(1714, 145);
            this.textConceptoRetirada.Name = "textConceptoRetirada";
            this.textConceptoRetirada.Size = new System.Drawing.Size(449, 26);
            this.textConceptoRetirada.TabIndex = 47;
            // 
            // textCantidadRetirada
            // 
            this.textCantidadRetirada.Location = new System.Drawing.Point(2141, 116);
            this.textCantidadRetirada.Name = "textCantidadRetirada";
            this.textCantidadRetirada.Size = new System.Drawing.Size(144, 26);
            this.textCantidadRetirada.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label8.Location = new System.Drawing.Point(1553, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 29);
            this.label8.TabIndex = 45;
            this.label8.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label7.Location = new System.Drawing.Point(1067, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 29);
            this.label7.TabIndex = 44;
            this.label7.Text = "Concepto";
            // 
            // textCantidadDeposito
            // 
            this.textCantidadDeposito.Location = new System.Drawing.Point(1553, 145);
            this.textCantidadDeposito.Name = "textCantidadDeposito";
            this.textCantidadDeposito.Size = new System.Drawing.Size(142, 26);
            this.textCantidadDeposito.TabIndex = 43;
            // 
            // textConceptoDeposito
            // 
            this.textConceptoDeposito.Location = new System.Drawing.Point(1067, 145);
            this.textConceptoDeposito.Name = "textConceptoDeposito";
            this.textConceptoDeposito.Size = new System.Drawing.Size(480, 26);
            this.textConceptoDeposito.TabIndex = 42;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.BotonInsertarCuenta);
            this.panel2.Controls.Add(this.BotonListarTodos);
            this.panel2.Controls.Add(this.textBuscarDni);
            this.panel2.Controls.Add(this.textBuscarCCC);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dataGridCuentas);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 489);
            this.panel2.TabIndex = 41;
            // 
            // BotonInsertarCuenta
            // 
            this.BotonInsertarCuenta.Location = new System.Drawing.Point(802, 47);
            this.BotonInsertarCuenta.Name = "BotonInsertarCuenta";
            this.BotonInsertarCuenta.Size = new System.Drawing.Size(170, 69);
            this.BotonInsertarCuenta.TabIndex = 6;
            this.BotonInsertarCuenta.Text = "Insertar cuenta";
            this.BotonInsertarCuenta.UseVisualStyleBackColor = true;
            this.BotonInsertarCuenta.Click += new System.EventHandler(this.BotonInsertarCuenta_Click);
            // 
            // BotonListarTodos
            // 
            this.BotonListarTodos.Location = new System.Drawing.Point(4, 122);
            this.BotonListarTodos.Name = "BotonListarTodos";
            this.BotonListarTodos.Size = new System.Drawing.Size(252, 40);
            this.BotonListarTodos.TabIndex = 5;
            this.BotonListarTodos.Text = "Limpiar buscador y listar todos";
            this.BotonListarTodos.UseVisualStyleBackColor = true;
            this.BotonListarTodos.Click += new System.EventHandler(this.BotonListarTodos_Click);
            // 
            // textBuscarDni
            // 
            this.textBuscarDni.Location = new System.Drawing.Point(155, 90);
            this.textBuscarDni.Name = "textBuscarDni";
            this.textBuscarDni.Size = new System.Drawing.Size(100, 26);
            this.textBuscarDni.TabIndex = 4;
            this.textBuscarDni.TextChanged += new System.EventHandler(this.textBuscarDni_TextChanged);
            // 
            // textBuscarCCC
            // 
            this.textBuscarCCC.Location = new System.Drawing.Point(4, 90);
            this.textBuscarCCC.Name = "textBuscarCCC";
            this.textBuscarCCC.Size = new System.Drawing.Size(145, 26);
            this.textBuscarCCC.TabIndex = 3;
            this.textBuscarCCC.TextChanged += new System.EventHandler(this.textBuscarCCC_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(155, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buscar DNI titular";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar CCC";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de cuentas";
            // 
            // dataGridCuentas
            // 
            this.dataGridCuentas.AllowUserToAddRows = false;
            this.dataGridCuentas.AllowUserToDeleteRows = false;
            this.dataGridCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.CCC, this.Tipo, this.Saldo, this.FechaApertura, this.Intereses, this.DNITitular, this.BorrarCuenta, this.GraficoSaldo});
            this.dataGridCuentas.Location = new System.Drawing.Point(4, 168);
            this.dataGridCuentas.MultiSelect = false;
            this.dataGridCuentas.Name = "dataGridCuentas";
            this.dataGridCuentas.ReadOnly = true;
            this.dataGridCuentas.RowTemplate.Height = 28;
            this.dataGridCuentas.Size = new System.Drawing.Size(1023, 288);
            this.dataGridCuentas.TabIndex = 7;
            this.dataGridCuentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCuentas_CellClick);
            // 
            // CCC
            // 
            this.CCC.HeaderText = "CCC";
            this.CCC.Name = "CCC";
            this.CCC.ReadOnly = true;
            this.CCC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CCC.Width = 48;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 64;
            // 
            // Saldo
            // 
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Saldo.Width = 56;
            // 
            // FechaApertura
            // 
            this.FechaApertura.HeaderText = "FechaApertura";
            this.FechaApertura.Name = "FechaApertura";
            this.FechaApertura.ReadOnly = true;
            this.FechaApertura.Width = 141;
            // 
            // Intereses
            // 
            this.Intereses.HeaderText = "Intereses";
            this.Intereses.Name = "Intereses";
            this.Intereses.ReadOnly = true;
            this.Intereses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Intereses.Width = 82;
            // 
            // DNITitular
            // 
            this.DNITitular.HeaderText = "DNITitular";
            this.DNITitular.Name = "DNITitular";
            this.DNITitular.ReadOnly = true;
            this.DNITitular.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DNITitular.Width = 86;
            // 
            // BorrarCuenta
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            this.BorrarCuenta.DefaultCellStyle = dataGridViewCellStyle3;
            this.BorrarCuenta.HeaderText = "BorrarCuenta";
            this.BorrarCuenta.Name = "BorrarCuenta";
            this.BorrarCuenta.ReadOnly = true;
            this.BorrarCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BorrarCuenta.Width = 111;
            // 
            // GraficoSaldo
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Orange;
            this.GraficoSaldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.GraficoSaldo.HeaderText = "GraficoCuenta";
            this.GraficoSaldo.Name = "GraficoSaldo";
            this.GraficoSaldo.ReadOnly = true;
            this.GraficoSaldo.Width = 138;
            // 
            // botonInsertarTitulares
            // 
            this.botonInsertarTitulares.BackColor = System.Drawing.Color.SpringGreen;
            this.botonInsertarTitulares.Location = new System.Drawing.Point(12, 656);
            this.botonInsertarTitulares.Name = "botonInsertarTitulares";
            this.botonInsertarTitulares.Size = new System.Drawing.Size(438, 29);
            this.botonInsertarTitulares.TabIndex = 40;
            this.botonInsertarTitulares.Text = "Insertar";
            this.botonInsertarTitulares.UseVisualStyleBackColor = false;
            this.botonInsertarTitulares.Click += new System.EventHandler(this.botonInsertarTitulares_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(12, 625);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 26);
            this.label6.TabIndex = 39;
            this.label6.Text = "de la cuenta selecionada";
            // 
            // Titulareslabel
            // 
            this.Titulareslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Titulareslabel.Location = new System.Drawing.Point(12, 582);
            this.Titulareslabel.Name = "Titulareslabel";
            this.Titulareslabel.Size = new System.Drawing.Size(146, 43);
            this.Titulareslabel.TabIndex = 38;
            this.Titulareslabel.Text = "Titulares";
            // 
            // dataGridTitulares
            // 
            this.dataGridTitulares.AllowUserToAddRows = false;
            this.dataGridTitulares.AllowUserToDeleteRows = false;
            this.dataGridTitulares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridTitulares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTitulares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.DNI, this.Nombre, this.BorrarTitular});
            this.dataGridTitulares.Location = new System.Drawing.Point(12, 699);
            this.dataGridTitulares.Name = "dataGridTitulares";
            this.dataGridTitulares.ReadOnly = true;
            this.dataGridTitulares.RowTemplate.Height = 24;
            this.dataGridTitulares.Size = new System.Drawing.Size(438, 264);
            this.dataGridTitulares.TabIndex = 37;
            this.dataGridTitulares.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTitulares_CellClick);
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Width = 62;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 90;
            // 
            // BorrarTitular
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Red;
            this.BorrarTitular.DefaultCellStyle = dataGridViewCellStyle5;
            this.BorrarTitular.HeaderText = "Borrar Ti.";
            this.BorrarTitular.Name = "BorrarTitular";
            this.BorrarTitular.ReadOnly = true;
            this.BorrarTitular.Width = 98;
            // 
            // botonInsertarRetirada
            // 
            this.botonInsertarRetirada.BackColor = System.Drawing.Color.LightGreen;
            this.botonInsertarRetirada.Location = new System.Drawing.Point(1714, 179);
            this.botonInsertarRetirada.Name = "botonInsertarRetirada";
            this.botonInsertarRetirada.Size = new System.Drawing.Size(599, 29);
            this.botonInsertarRetirada.TabIndex = 36;
            this.botonInsertarRetirada.Text = "Insertar nueva retirada";
            this.botonInsertarRetirada.UseVisualStyleBackColor = false;
            this.botonInsertarRetirada.Click += new System.EventHandler(this.botonInsertarRetirada_Click);
            // 
            // dataGridRetiradas
            // 
            this.dataGridRetiradas.AllowUserToAddRows = false;
            this.dataGridRetiradas.AllowUserToDeleteRows = false;
            this.dataGridRetiradas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridRetiradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRetiradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.DatetimeRetirada, this.ConceptoRetirada, this.CantidadRetirada, this.BorrarRetirada});
            this.dataGridRetiradas.Location = new System.Drawing.Point(1714, 222);
            this.dataGridRetiradas.Name = "dataGridRetiradas";
            this.dataGridRetiradas.ReadOnly = true;
            this.dataGridRetiradas.RowTemplate.Height = 24;
            this.dataGridRetiradas.Size = new System.Drawing.Size(599, 270);
            this.dataGridRetiradas.TabIndex = 35;
            this.dataGridRetiradas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRetiradas_CellClick);
            // 
            // DatetimeRetirada
            // 
            this.DatetimeRetirada.HeaderText = "DateTime R.";
            this.DatetimeRetirada.Name = "DatetimeRetirada";
            this.DatetimeRetirada.ReadOnly = true;
            this.DatetimeRetirada.Width = 123;
            // 
            // ConceptoRetirada
            // 
            this.ConceptoRetirada.HeaderText = "Concepto R.";
            this.ConceptoRetirada.Name = "ConceptoRetirada";
            this.ConceptoRetirada.ReadOnly = true;
            this.ConceptoRetirada.Width = 123;
            // 
            // CantidadRetirada
            // 
            this.CantidadRetirada.HeaderText = "Cantidad R.";
            this.CantidadRetirada.Name = "CantidadRetirada";
            this.CantidadRetirada.ReadOnly = true;
            this.CantidadRetirada.Width = 118;
            // 
            // BorrarRetirada
            // 
            this.BorrarRetirada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Red;
            this.BorrarRetirada.DefaultCellStyle = dataGridViewCellStyle6;
            this.BorrarRetirada.HeaderText = "Borrar R.";
            this.BorrarRetirada.Name = "BorrarRetirada";
            this.BorrarRetirada.ReadOnly = true;
            this.BorrarRetirada.Width = 98;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(1714, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 26);
            this.label5.TabIndex = 34;
            this.label5.Text = "de la cuenta selecionada";
            // 
            // Retiradaslabel
            // 
            this.Retiradaslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Retiradaslabel.Location = new System.Drawing.Point(1714, 39);
            this.Retiradaslabel.Name = "Retiradaslabel";
            this.Retiradaslabel.Size = new System.Drawing.Size(178, 37);
            this.Retiradaslabel.TabIndex = 33;
            this.Retiradaslabel.Text = "Retiradas";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(1076, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 26);
            this.label4.TabIndex = 32;
            this.label4.Text = "de la cuenta selecionada";
            // 
            // Depositoslabel
            // 
            this.Depositoslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Depositoslabel.Location = new System.Drawing.Point(1076, 24);
            this.Depositoslabel.Name = "Depositoslabel";
            this.Depositoslabel.Size = new System.Drawing.Size(178, 52);
            this.Depositoslabel.TabIndex = 31;
            this.Depositoslabel.Text = "Depositos";
            // 
            // botonInsertarDeposito
            // 
            this.botonInsertarDeposito.BackColor = System.Drawing.Color.LightGreen;
            this.botonInsertarDeposito.Location = new System.Drawing.Point(1067, 179);
            this.botonInsertarDeposito.Name = "botonInsertarDeposito";
            this.botonInsertarDeposito.Size = new System.Drawing.Size(628, 32);
            this.botonInsertarDeposito.TabIndex = 30;
            this.botonInsertarDeposito.Text = "Insertar nuevo deposito";
            this.botonInsertarDeposito.UseVisualStyleBackColor = false;
            this.botonInsertarDeposito.Click += new System.EventHandler(this.botonInsertarDeposito_Click);
            // 
            // dataGridDepositos
            // 
            this.dataGridDepositos.AllowUserToAddRows = false;
            this.dataGridDepositos.AllowUserToDeleteRows = false;
            this.dataGridDepositos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDepositos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Datetime, this.ConceptoDeposito, this.CantidadDeposito, this.BorarDeposito});
            this.dataGridDepositos.Location = new System.Drawing.Point(1063, 225);
            this.dataGridDepositos.Name = "dataGridDepositos";
            this.dataGridDepositos.ReadOnly = true;
            this.dataGridDepositos.RowTemplate.Height = 24;
            this.dataGridDepositos.Size = new System.Drawing.Size(632, 267);
            this.dataGridDepositos.TabIndex = 8;
            this.dataGridDepositos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDepositos_CellClick);
            // 
            // Datetime
            // 
            this.Datetime.HeaderText = "DateTime R.";
            this.Datetime.Name = "Datetime";
            this.Datetime.ReadOnly = true;
            this.Datetime.Width = 123;
            // 
            // ConceptoDeposito
            // 
            this.ConceptoDeposito.HeaderText = "Concepto D.";
            this.ConceptoDeposito.Name = "ConceptoDeposito";
            this.ConceptoDeposito.ReadOnly = true;
            this.ConceptoDeposito.Width = 123;
            // 
            // CantidadDeposito
            // 
            this.CantidadDeposito.HeaderText = "Cantidad D.";
            this.CantidadDeposito.Name = "CantidadDeposito";
            this.CantidadDeposito.ReadOnly = true;
            this.CantidadDeposito.Width = 118;
            // 
            // BorarDeposito
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Red;
            this.BorarDeposito.DefaultCellStyle = dataGridViewCellStyle7;
            this.BorarDeposito.HeaderText = "Borrar D.";
            this.BorarDeposito.Name = "BorarDeposito";
            this.BorarDeposito.ReadOnly = true;
            this.BorarDeposito.Width = 98;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.vistaToolStripMenuItem, this.buscadorToolStripMenuItem, this.graficoGeneralToolStripMenuItem, this.guardarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2279, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vistaToolStripMenuItem
            // 
            this.vistaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.clientesToolStripMenuItem});
            this.vistaToolStripMenuItem.Name = "vistaToolStripMenuItem";
            this.vistaToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.vistaToolStripMenuItem.Text = "Vista";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // buscadorToolStripMenuItem
            // 
            this.buscadorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.productosPersonaToolStripMenuItem, this.movimientosPersonaToolStripMenuItem, this.transferenciasPersonaToolStripMenuItem, this.transferenciasBancoToolStripMenuItem});
            this.buscadorToolStripMenuItem.Name = "buscadorToolStripMenuItem";
            this.buscadorToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.buscadorToolStripMenuItem.Text = "Buscador";
            // 
            // productosPersonaToolStripMenuItem
            // 
            this.productosPersonaToolStripMenuItem.Name = "productosPersonaToolStripMenuItem";
            this.productosPersonaToolStripMenuItem.Size = new System.Drawing.Size(262, 30);
            this.productosPersonaToolStripMenuItem.Text = "Productos persona";
            this.productosPersonaToolStripMenuItem.Click += new System.EventHandler(this.productosPersonaToolStripMenuItem_Click);
            // 
            // movimientosPersonaToolStripMenuItem
            // 
            this.movimientosPersonaToolStripMenuItem.Name = "movimientosPersonaToolStripMenuItem";
            this.movimientosPersonaToolStripMenuItem.Size = new System.Drawing.Size(262, 30);
            this.movimientosPersonaToolStripMenuItem.Text = "Movimientos persona";
            this.movimientosPersonaToolStripMenuItem.Click += new System.EventHandler(this.movimientosPersonaToolStripMenuItem_Click);
            // 
            // transferenciasPersonaToolStripMenuItem
            // 
            this.transferenciasPersonaToolStripMenuItem.Name = "transferenciasPersonaToolStripMenuItem";
            this.transferenciasPersonaToolStripMenuItem.Size = new System.Drawing.Size(262, 30);
            this.transferenciasPersonaToolStripMenuItem.Text = "Transferencias persona";
            this.transferenciasPersonaToolStripMenuItem.Click += new System.EventHandler(this.transferenciasPersonaToolStripMenuItem_Click);
            // 
            // transferenciasBancoToolStripMenuItem
            // 
            this.transferenciasBancoToolStripMenuItem.Name = "transferenciasBancoToolStripMenuItem";
            this.transferenciasBancoToolStripMenuItem.Size = new System.Drawing.Size(262, 30);
            this.transferenciasBancoToolStripMenuItem.Text = "Transferencias banco";
            this.transferenciasBancoToolStripMenuItem.Click += new System.EventHandler(this.transferenciasBancoToolStripMenuItem_Click);
            // 
            // graficoGeneralToolStripMenuItem
            // 
            this.graficoGeneralToolStripMenuItem.Name = "graficoGeneralToolStripMenuItem";
            this.graficoGeneralToolStripMenuItem.Size = new System.Drawing.Size(143, 29);
            this.graficoGeneralToolStripMenuItem.Text = "Grafico general";
            this.graficoGeneralToolStripMenuItem.Click += new System.EventHandler(this.graficoGeneralToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.guardarXMLToolStripMenuItem, this.guardarXMLYSalirToolStripMenuItem});
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(87, 29);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // guardarXMLToolStripMenuItem
            // 
            this.guardarXMLToolStripMenuItem.Name = "guardarXMLToolStripMenuItem";
            this.guardarXMLToolStripMenuItem.Size = new System.Drawing.Size(237, 30);
            this.guardarXMLToolStripMenuItem.Text = "Guardar XML";
            this.guardarXMLToolStripMenuItem.Click += new System.EventHandler(this.guardarXMLToolStripMenuItem_Click);
            // 
            // guardarXMLYSalirToolStripMenuItem
            // 
            this.guardarXMLYSalirToolStripMenuItem.Name = "guardarXMLYSalirToolStripMenuItem";
            this.guardarXMLYSalirToolStripMenuItem.Size = new System.Drawing.Size(237, 30);
            this.guardarXMLYSalirToolStripMenuItem.Text = "Guardar XML y salir";
            this.guardarXMLYSalirToolStripMenuItem.Click += new System.EventHandler(this.guardarXMLySalirToolStripMenuItem_Click);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label13.Location = new System.Drawing.Point(471, 572);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(240, 43);
            this.label13.TabIndex = 54;
            this.label13.Text = "Préstamos";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label14.Location = new System.Drawing.Point(481, 615);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(240, 26);
            this.label14.TabIndex = 55;
            this.label14.Text = "de la cuenta selecionada";
            // 
            // btnInsertarPrestamo
            // 
            this.btnInsertarPrestamo.BackColor = System.Drawing.Color.SpringGreen;
            this.btnInsertarPrestamo.Location = new System.Drawing.Point(481, 654);
            this.btnInsertarPrestamo.Name = "btnInsertarPrestamo";
            this.btnInsertarPrestamo.Size = new System.Drawing.Size(693, 29);
            this.btnInsertarPrestamo.TabIndex = 56;
            this.btnInsertarPrestamo.Text = "Insertar nuevo préstamo";
            this.btnInsertarPrestamo.UseVisualStyleBackColor = false;
            this.btnInsertarPrestamo.Click += new System.EventHandler(this.btnInsertarPrestamo_Click);

            // 
            // dataGridPrestamos
            // 
            this.dataGridPrestamos.AllowUserToAddRows = false;
            this.dataGridPrestamos.AllowUserToDeleteRows = false;
            this.dataGridPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPrestamos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.dataGridViewTextBoxColumn7});
            this.dataGridPrestamos.Location = new System.Drawing.Point(481, 694);
            this.dataGridPrestamos.Name = "dataGridPrestamos";
            this.dataGridPrestamos.ReadOnly = true;
            this.dataGridPrestamos.RowTemplate.Height = 28;
            this.dataGridPrestamos.Size = new System.Drawing.Size(693, 249);
            this.dataGridPrestamos.TabIndex = 57;
            this.dataGridPrestamos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPrestamos_CellClick);

            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "CCC";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn7.HeaderText = "Borrar Pres.";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 118;
            // 
            // GestionCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 1005);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1918, 1018);
            this.Name = "GestionCuentas";
            this.Text = "Gestion Cuentas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GestionCuentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridTransferencias)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridTitulares)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridRetiradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridDepositos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridPrestamos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnInsertarPrestamo;
        private System.Windows.Forms.DataGridView dataGridPrestamos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;

        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarXMLYSalirToolStripMenuItem;

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;

        private System.Windows.Forms.DataGridView dataGridTransferencias;

        private System.Windows.Forms.DataGridViewTextBoxColumn BorrarTransferencia;

        private System.Windows.Forms.Button btnInsertarTransferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCCDest;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCCOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoTrans;

        private System.Windows.Forms.DataGridViewTextBoxColumn ID;

        private System.Windows.Forms.ToolStripMenuItem graficoGeneralToolStripMenuItem;

        private System.Windows.Forms.DataGridViewTextBoxColumn GraficoSaldo;

        private System.Windows.Forms.ToolStripMenuItem movimientosPersonaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferenciasBancoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferenciasPersonaToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem productosPersonaToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem buscadorToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vistaToolStripMenuItem;

        private System.Windows.Forms.DataGridViewTextBoxColumn BorrarRetirada;

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textCantidadRetirada;
        private System.Windows.Forms.TextBox textConceptoRetirada;

        private System.Windows.Forms.DataGridViewTextBoxColumn BorarDeposito;

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textCantidadDeposito;
        private System.Windows.Forms.TextBox textConceptoDeposito;

        private System.Windows.Forms.DataGridViewTextBoxColumn BorrarTitular;

        private System.Windows.Forms.DataGridViewTextBoxColumn BorrarCuenta;

        private System.Windows.Forms.Button BotonInsertarCuenta;

        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Button botonInsertarTitulares;
        private System.Windows.Forms.DataGridView dataGridTitulares;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Titulareslabel;

        private System.Windows.Forms.Button botonInsertarDeposito;
        private System.Windows.Forms.Button botonInsertarRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadDeposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoDeposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoRetirada;
        private System.Windows.Forms.DataGridView dataGridDepositos;
        private System.Windows.Forms.DataGridView dataGridRetiradas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatetimeRetirada;
        private System.Windows.Forms.Label Depositoslabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Retiradaslabel;

        private System.Windows.Forms.DataGridView dataGridCuentas;

        private System.Windows.Forms.DataGridViewTextBoxColumn CCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNITitular;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaApertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intereses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;

        private System.Windows.Forms.Button BotonListarTodos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBuscarCCC;
        private System.Windows.Forms.TextBox textBuscarDni;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}