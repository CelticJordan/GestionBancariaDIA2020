using System.ComponentModel;

namespace DIA_P2_banco
{
    partial class GestionCuenta
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
            this.dataGridCuentas = new System.Windows.Forms.DataGridView();
            this.CCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaApertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNITitular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridTitulares = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridDepositos = new System.Windows.Forms.DataGridView();
            this.Datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConceptoDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridRetiradas = new System.Windows.Forms.DataGridView();
            this.DatetimeRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConceptoRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBuscarCCC = new System.Windows.Forms.TextBox();
            this.textSaldo = new System.Windows.Forms.TextBox();
            this.BuscarCCClabel = new System.Windows.Forms.Label();
            this.Tipolabel = new System.Windows.Forms.Label();
            this.Saldolabel = new System.Windows.Forms.Label();
            this.Intereslabel = new System.Windows.Forms.Label();
            this.Titulareslabel = new System.Windows.Forms.Label();
            this.Depositoslabel = new System.Windows.Forms.Label();
            this.Retiradaslabel = new System.Windows.Forms.Label();
            this.BotonBuscar = new System.Windows.Forms.Button();
            this.BotonInsertar = new System.Windows.Forms.Button();
            this.textInteres = new System.Windows.Forms.TextBox();
            this.Cuentaslabel = new System.Windows.Forms.Label();
            this.BotonBorrar = new System.Windows.Forms.Button();
            this.BotonEditar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BotonListarTodos = new System.Windows.Forms.Button();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.BotonGuardar = new System.Windows.Forms.Button();
            this.DNITitularlabel = new System.Windows.Forms.Label();
            this.textDNITitular = new System.Windows.Forms.TextBox();
            this.CCClabel = new System.Windows.Forms.Label();
            this.textCCC = new System.Windows.Forms.TextBox();
            this.buscarDNITitularlabel = new System.Windows.Forms.Label();
            this.textBuscarDni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textDniTitulares = new System.Windows.Forms.TextBox();
            this.dniTitulareslabel = new System.Windows.Forms.Label();
            this.botonInsertarTitulares = new System.Windows.Forms.Button();
            this.botonBorrarTitulares = new System.Windows.Forms.Button();
            this.textConceptoDeposito = new System.Windows.Forms.TextBox();
            this.labelConceptoDeposito = new System.Windows.Forms.Label();
            this.textCantidadDeposito = new System.Windows.Forms.TextBox();
            this.cantidadDepositoLabel = new System.Windows.Forms.Label();
            this.botonInsertarDeposito = new System.Windows.Forms.Button();
            this.botonBorrarDeposito = new System.Windows.Forms.Button();
            this.botonBorrarRetirada = new System.Windows.Forms.Button();
            this.botonInsertarRetirada = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textCantidadRetirada = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textConceptoRetirada = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridTitulares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridDepositos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridRetiradas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridCuentas
            // 
            this.dataGridCuentas.AllowUserToAddRows = false;
            this.dataGridCuentas.AllowUserToDeleteRows = false;
            this.dataGridCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.CCC, this.Tipo, this.Saldo, this.FechaApertura, this.Interes, this.DNITitular});
            this.dataGridCuentas.Location = new System.Drawing.Point(3, 298);
            this.dataGridCuentas.MultiSelect = false;
            this.dataGridCuentas.Name = "dataGridCuentas";
            this.dataGridCuentas.ReadOnly = true;
            this.dataGridCuentas.RowTemplate.Height = 24;
            this.dataGridCuentas.Size = new System.Drawing.Size(999, 222);
            this.dataGridCuentas.TabIndex = 0;
            this.dataGridCuentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCuentas_CellClick);
            // 
            // CCC
            // 
            this.CCC.HeaderText = "CCC";
            this.CCC.Name = "CCC";
            this.CCC.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Saldo
            // 
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            // 
            // FechaApertura
            // 
            this.FechaApertura.HeaderText = "FechaApertura";
            this.FechaApertura.Name = "FechaApertura";
            this.FechaApertura.ReadOnly = true;
            // 
            // Interes
            // 
            this.Interes.HeaderText = "Interes";
            this.Interes.Name = "Interes";
            this.Interes.ReadOnly = true;
            // 
            // DNITitular
            // 
            this.DNITitular.HeaderText = "DNITitular";
            this.DNITitular.Name = "DNITitular";
            this.DNITitular.ReadOnly = true;
            // 
            // dataGridTitulares
            // 
            this.dataGridTitulares.AllowUserToAddRows = false;
            this.dataGridTitulares.AllowUserToDeleteRows = false;
            this.dataGridTitulares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTitulares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.DNI});
            this.dataGridTitulares.Location = new System.Drawing.Point(1080, 252);
            this.dataGridTitulares.Name = "dataGridTitulares";
            this.dataGridTitulares.ReadOnly = true;
            this.dataGridTitulares.RowTemplate.Height = 24;
            this.dataGridTitulares.Size = new System.Drawing.Size(174, 222);
            this.dataGridTitulares.TabIndex = 1;
            this.dataGridTitulares.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTitulares_CellClick);
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // dataGridDepositos
            // 
            this.dataGridDepositos.AllowUserToAddRows = false;
            this.dataGridDepositos.AllowUserToDeleteRows = false;
            this.dataGridDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDepositos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Datetime, this.ConceptoDeposito, this.CantidadDeposito});
            this.dataGridDepositos.Location = new System.Drawing.Point(3, 781);
            this.dataGridDepositos.Name = "dataGridDepositos";
            this.dataGridDepositos.ReadOnly = true;
            this.dataGridDepositos.RowTemplate.Height = 24;
            this.dataGridDepositos.Size = new System.Drawing.Size(531, 245);
            this.dataGridDepositos.TabIndex = 2;
            this.dataGridDepositos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDepositos_CellClick);
            // 
            // Datetime
            // 
            this.Datetime.HeaderText = "Datetime";
            this.Datetime.Name = "Datetime";
            this.Datetime.ReadOnly = true;
            // 
            // ConceptoDeposito
            // 
            this.ConceptoDeposito.HeaderText = "ConceptoDeposito";
            this.ConceptoDeposito.Name = "ConceptoDeposito";
            this.ConceptoDeposito.ReadOnly = true;
            // 
            // CantidadDeposito
            // 
            this.CantidadDeposito.HeaderText = "CantidadDeposito";
            this.CantidadDeposito.Name = "CantidadDeposito";
            this.CantidadDeposito.ReadOnly = true;
            // 
            // dataGridRetiradas
            // 
            this.dataGridRetiradas.AllowUserToAddRows = false;
            this.dataGridRetiradas.AllowUserToDeleteRows = false;
            this.dataGridRetiradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRetiradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.DatetimeRetirada, this.ConceptoRetirada, this.CantidadRetirada});
            this.dataGridRetiradas.Location = new System.Drawing.Point(588, 781);
            this.dataGridRetiradas.Name = "dataGridRetiradas";
            this.dataGridRetiradas.ReadOnly = true;
            this.dataGridRetiradas.RowTemplate.Height = 24;
            this.dataGridRetiradas.Size = new System.Drawing.Size(518, 245);
            this.dataGridRetiradas.TabIndex = 3;
            this.dataGridRetiradas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRetiradas_CellClick);
            // 
            // DatetimeRetirada
            // 
            this.DatetimeRetirada.HeaderText = "DatetimeRetirada";
            this.DatetimeRetirada.Name = "DatetimeRetirada";
            this.DatetimeRetirada.ReadOnly = true;
            // 
            // ConceptoRetirada
            // 
            this.ConceptoRetirada.HeaderText = "ConceptoRetirada";
            this.ConceptoRetirada.Name = "ConceptoRetirada";
            this.ConceptoRetirada.ReadOnly = true;
            // 
            // CantidadRetirada
            // 
            this.CantidadRetirada.HeaderText = "CantidadRetirada";
            this.CantidadRetirada.Name = "CantidadRetirada";
            this.CantidadRetirada.ReadOnly = true;
            // 
            // textBuscarCCC
            // 
            this.textBuscarCCC.Location = new System.Drawing.Point(12, 114);
            this.textBuscarCCC.Name = "textBuscarCCC";
            this.textBuscarCCC.Size = new System.Drawing.Size(154, 26);
            this.textBuscarCCC.TabIndex = 4;
            // 
            // textSaldo
            // 
            this.textSaldo.Location = new System.Drawing.Point(752, 83);
            this.textSaldo.Name = "textSaldo";
            this.textSaldo.Size = new System.Drawing.Size(206, 26);
            this.textSaldo.TabIndex = 6;
            // 
            // BuscarCCClabel
            // 
            this.BuscarCCClabel.Location = new System.Drawing.Point(16, 69);
            this.BuscarCCClabel.Name = "BuscarCCClabel";
            this.BuscarCCClabel.Size = new System.Drawing.Size(86, 42);
            this.BuscarCCClabel.TabIndex = 8;
            this.BuscarCCClabel.Text = "Buscar CCC";
            // 
            // Tipolabel
            // 
            this.Tipolabel.Location = new System.Drawing.Point(698, 46);
            this.Tipolabel.Name = "Tipolabel";
            this.Tipolabel.Size = new System.Drawing.Size(48, 29);
            this.Tipolabel.TabIndex = 9;
            this.Tipolabel.Text = "Tipo";
            // 
            // Saldolabel
            // 
            this.Saldolabel.Location = new System.Drawing.Point(692, 88);
            this.Saldolabel.Name = "Saldolabel";
            this.Saldolabel.Size = new System.Drawing.Size(57, 29);
            this.Saldolabel.TabIndex = 10;
            this.Saldolabel.Text = "Saldo";
            // 
            // Intereslabel
            // 
            this.Intereslabel.Location = new System.Drawing.Point(688, 163);
            this.Intereslabel.Name = "Intereslabel";
            this.Intereslabel.Size = new System.Drawing.Size(60, 29);
            this.Intereslabel.TabIndex = 11;
            this.Intereslabel.Text = "Interes";
            // 
            // Titulareslabel
            // 
            this.Titulareslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Titulareslabel.Location = new System.Drawing.Point(1080, 40);
            this.Titulareslabel.Name = "Titulareslabel";
            this.Titulareslabel.Size = new System.Drawing.Size(146, 43);
            this.Titulareslabel.TabIndex = 12;
            this.Titulareslabel.Text = "Titulares";
            // 
            // Depositoslabel
            // 
            this.Depositoslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Depositoslabel.Location = new System.Drawing.Point(12, 563);
            this.Depositoslabel.Name = "Depositoslabel";
            this.Depositoslabel.Size = new System.Drawing.Size(178, 52);
            this.Depositoslabel.TabIndex = 13;
            this.Depositoslabel.Text = "Depositos";
            // 
            // Retiradaslabel
            // 
            this.Retiradaslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Retiradaslabel.Location = new System.Drawing.Point(588, 563);
            this.Retiradaslabel.Name = "Retiradaslabel";
            this.Retiradaslabel.Size = new System.Drawing.Size(178, 37);
            this.Retiradaslabel.TabIndex = 14;
            this.Retiradaslabel.Text = "Retiradas";
            // 
            // BotonBuscar
            // 
            this.BotonBuscar.Location = new System.Drawing.Point(318, 115);
            this.BotonBuscar.Name = "BotonBuscar";
            this.BotonBuscar.Size = new System.Drawing.Size(84, 29);
            this.BotonBuscar.TabIndex = 15;
            this.BotonBuscar.Text = "Buscar";
            this.BotonBuscar.UseVisualStyleBackColor = true;
            this.BotonBuscar.Click += new System.EventHandler(this.BotonBuscar_Click);
            // 
            // BotonInsertar
            // 
            this.BotonInsertar.Location = new System.Drawing.Point(549, 75);
            this.BotonInsertar.Name = "BotonInsertar";
            this.BotonInsertar.Size = new System.Drawing.Size(84, 55);
            this.BotonInsertar.TabIndex = 16;
            this.BotonInsertar.Text = "Insertar";
            this.BotonInsertar.UseVisualStyleBackColor = true;
            this.BotonInsertar.Click += new System.EventHandler(this.BotonInsertar_Click);
            // 
            // textInteres
            // 
            this.textInteres.Location = new System.Drawing.Point(752, 158);
            this.textInteres.Name = "textInteres";
            this.textInteres.Size = new System.Drawing.Size(206, 26);
            this.textInteres.TabIndex = 7;
            // 
            // Cuentaslabel
            // 
            this.Cuentaslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Cuentaslabel.Location = new System.Drawing.Point(0, 17);
            this.Cuentaslabel.Name = "Cuentaslabel";
            this.Cuentaslabel.Size = new System.Drawing.Size(178, 52);
            this.Cuentaslabel.TabIndex = 17;
            this.Cuentaslabel.Text = "Cuentas";
            // 
            // BotonBorrar
            // 
            this.BotonBorrar.Location = new System.Drawing.Point(549, 9);
            this.BotonBorrar.Name = "BotonBorrar";
            this.BotonBorrar.Size = new System.Drawing.Size(84, 62);
            this.BotonBorrar.TabIndex = 18;
            this.BotonBorrar.Text = "Borrar";
            this.BotonBorrar.UseVisualStyleBackColor = true;
            this.BotonBorrar.Click += new System.EventHandler(this.BotonBorrar_Click);
            // 
            // BotonEditar
            // 
            this.BotonEditar.Location = new System.Drawing.Point(549, 137);
            this.BotonEditar.Name = "BotonEditar";
            this.BotonEditar.Size = new System.Drawing.Size(84, 65);
            this.BotonEditar.TabIndex = 19;
            this.BotonEditar.Text = "Editar";
            this.BotonEditar.UseVisualStyleBackColor = true;
            this.BotonEditar.Click += new System.EventHandler(this.BotonEditar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.BotonListarTodos);
            this.panel1.Controls.Add(this.comboTipo);
            this.panel1.Controls.Add(this.BotonGuardar);
            this.panel1.Controls.Add(this.DNITitularlabel);
            this.panel1.Controls.Add(this.textDNITitular);
            this.panel1.Controls.Add(this.CCClabel);
            this.panel1.Controls.Add(this.textCCC);
            this.panel1.Controls.Add(this.buscarDNITitularlabel);
            this.panel1.Controls.Add(this.textBuscarDni);
            this.panel1.Controls.Add(this.BotonEditar);
            this.panel1.Controls.Add(this.BotonBorrar);
            this.panel1.Controls.Add(this.Cuentaslabel);
            this.panel1.Controls.Add(this.BotonInsertar);
            this.panel1.Controls.Add(this.BotonBuscar);
            this.panel1.Controls.Add(this.Intereslabel);
            this.panel1.Controls.Add(this.Saldolabel);
            this.panel1.Controls.Add(this.Tipolabel);
            this.panel1.Controls.Add(this.BuscarCCClabel);
            this.panel1.Controls.Add(this.textInteres);
            this.panel1.Controls.Add(this.textSaldo);
            this.panel1.Controls.Add(this.textBuscarCCC);
            this.panel1.Controls.Add(this.dataGridCuentas);
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 537);
            this.panel1.TabIndex = 20;
            // 
            // BotonListarTodos
            // 
            this.BotonListarTodos.Location = new System.Drawing.Point(12, 155);
            this.BotonListarTodos.Name = "BotonListarTodos";
            this.BotonListarTodos.Size = new System.Drawing.Size(390, 29);
            this.BotonListarTodos.TabIndex = 28;
            this.BotonListarTodos.Text = "Limpiar buscador y listar todos";
            this.BotonListarTodos.UseVisualStyleBackColor = true;
            this.BotonListarTodos.Click += new System.EventHandler(this.BotonListarTodos_Click);
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {"Ahorro", "Vivienda", "Corriente"});
            this.comboTipo.Location = new System.Drawing.Point(752, 43);
            this.comboTipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(206, 28);
            this.comboTipo.TabIndex = 27;
            // 
            // BotonGuardar
            // 
            this.BotonGuardar.Location = new System.Drawing.Point(657, 232);
            this.BotonGuardar.Name = "BotonGuardar";
            this.BotonGuardar.Size = new System.Drawing.Size(345, 60);
            this.BotonGuardar.TabIndex = 26;
            this.BotonGuardar.Text = "Guardar";
            this.BotonGuardar.UseVisualStyleBackColor = true;
            this.BotonGuardar.Click += new System.EventHandler(this.BotonGuardar_Click);
            // 
            // DNITitularlabel
            // 
            this.DNITitularlabel.Location = new System.Drawing.Point(657, 195);
            this.DNITitularlabel.Name = "DNITitularlabel";
            this.DNITitularlabel.Size = new System.Drawing.Size(92, 29);
            this.DNITitularlabel.TabIndex = 25;
            this.DNITitularlabel.Text = "DNI Titular";
            // 
            // textDNITitular
            // 
            this.textDNITitular.Location = new System.Drawing.Point(752, 195);
            this.textDNITitular.Name = "textDNITitular";
            this.textDNITitular.Size = new System.Drawing.Size(206, 26);
            this.textDNITitular.TabIndex = 24;
            // 
            // CCClabel
            // 
            this.CCClabel.Location = new System.Drawing.Point(698, 8);
            this.CCClabel.Name = "CCClabel";
            this.CCClabel.Size = new System.Drawing.Size(48, 26);
            this.CCClabel.TabIndex = 23;
            this.CCClabel.Text = "CCC";
            // 
            // textCCC
            // 
            this.textCCC.Location = new System.Drawing.Point(752, 3);
            this.textCCC.Name = "textCCC";
            this.textCCC.Size = new System.Drawing.Size(206, 26);
            this.textCCC.TabIndex = 22;
            // 
            // buscarDNITitularlabel
            // 
            this.buscarDNITitularlabel.Location = new System.Drawing.Point(184, 46);
            this.buscarDNITitularlabel.Name = "buscarDNITitularlabel";
            this.buscarDNITitularlabel.Size = new System.Drawing.Size(84, 66);
            this.buscarDNITitularlabel.TabIndex = 21;
            this.buscarDNITitularlabel.Text = "Buscar DNI Titular";
            // 
            // textBuscarDni
            // 
            this.textBuscarDni.Location = new System.Drawing.Point(178, 114);
            this.textBuscarDni.Name = "textBuscarDni";
            this.textBuscarDni.Size = new System.Drawing.Size(132, 26);
            this.textBuscarDni.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(1080, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "de la cuenta selecionada";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(588, 602);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 26);
            this.label2.TabIndex = 22;
            this.label2.Text = "de la cuenta selecionada";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(14, 602);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 26);
            this.label3.TabIndex = 23;
            this.label3.Text = "de la cuenta selecionada";
            // 
            // textDniTitulares
            // 
            this.textDniTitulares.Location = new System.Drawing.Point(1080, 160);
            this.textDniTitulares.Name = "textDniTitulares";
            this.textDniTitulares.Size = new System.Drawing.Size(174, 26);
            this.textDniTitulares.TabIndex = 29;
            // 
            // dniTitulareslabel
            // 
            this.dniTitulareslabel.Location = new System.Drawing.Point(1080, 127);
            this.dniTitulareslabel.Name = "dniTitulareslabel";
            this.dniTitulareslabel.Size = new System.Drawing.Size(105, 26);
            this.dniTitulareslabel.TabIndex = 29;
            this.dniTitulareslabel.Text = "DNI Titular";
            // 
            // botonInsertarTitulares
            // 
            this.botonInsertarTitulares.Location = new System.Drawing.Point(1080, 192);
            this.botonInsertarTitulares.Name = "botonInsertarTitulares";
            this.botonInsertarTitulares.Size = new System.Drawing.Size(84, 41);
            this.botonInsertarTitulares.TabIndex = 29;
            this.botonInsertarTitulares.Text = "Insertar";
            this.botonInsertarTitulares.UseVisualStyleBackColor = true;
            this.botonInsertarTitulares.Click += new System.EventHandler(this.botonInsertarTitulares_Click);
            // 
            // botonBorrarTitulares
            // 
            this.botonBorrarTitulares.Location = new System.Drawing.Point(1170, 192);
            this.botonBorrarTitulares.Name = "botonBorrarTitulares";
            this.botonBorrarTitulares.Size = new System.Drawing.Size(84, 41);
            this.botonBorrarTitulares.TabIndex = 30;
            this.botonBorrarTitulares.Text = "Borrar";
            this.botonBorrarTitulares.UseVisualStyleBackColor = true;
            this.botonBorrarTitulares.Click += new System.EventHandler(this.botonBorrarTitulares_Click);
            // 
            // textConceptoDeposito
            // 
            this.textConceptoDeposito.Location = new System.Drawing.Point(12, 667);
            this.textConceptoDeposito.Name = "textConceptoDeposito";
            this.textConceptoDeposito.Size = new System.Drawing.Size(206, 26);
            this.textConceptoDeposito.TabIndex = 29;
            // 
            // labelConceptoDeposito
            // 
            this.labelConceptoDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelConceptoDeposito.Location = new System.Drawing.Point(12, 638);
            this.labelConceptoDeposito.Name = "labelConceptoDeposito";
            this.labelConceptoDeposito.Size = new System.Drawing.Size(240, 26);
            this.labelConceptoDeposito.TabIndex = 31;
            this.labelConceptoDeposito.Text = "Concepto deposito";
            // 
            // textCantidadDeposito
            // 
            this.textCantidadDeposito.Location = new System.Drawing.Point(244, 667);
            this.textCantidadDeposito.Name = "textCantidadDeposito";
            this.textCantidadDeposito.Size = new System.Drawing.Size(206, 26);
            this.textCantidadDeposito.TabIndex = 32;
            // 
            // cantidadDepositoLabel
            // 
            this.cantidadDepositoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cantidadDepositoLabel.Location = new System.Drawing.Point(244, 638);
            this.cantidadDepositoLabel.Name = "cantidadDepositoLabel";
            this.cantidadDepositoLabel.Size = new System.Drawing.Size(240, 26);
            this.cantidadDepositoLabel.TabIndex = 33;
            this.cantidadDepositoLabel.Text = "Cantidad deposito";
            // 
            // botonInsertarDeposito
            // 
            this.botonInsertarDeposito.Location = new System.Drawing.Point(14, 699);
            this.botonInsertarDeposito.Name = "botonInsertarDeposito";
            this.botonInsertarDeposito.Size = new System.Drawing.Size(436, 29);
            this.botonInsertarDeposito.TabIndex = 29;
            this.botonInsertarDeposito.Text = "Insertar nuevo deposito";
            this.botonInsertarDeposito.UseVisualStyleBackColor = true;
            this.botonInsertarDeposito.Click += new System.EventHandler(this.botonInsertarDeposito_Click);
            // 
            // botonBorrarDeposito
            // 
            this.botonBorrarDeposito.Location = new System.Drawing.Point(12, 734);
            this.botonBorrarDeposito.Name = "botonBorrarDeposito";
            this.botonBorrarDeposito.Size = new System.Drawing.Size(436, 29);
            this.botonBorrarDeposito.TabIndex = 34;
            this.botonBorrarDeposito.Text = "Borrar deposito selecionado";
            this.botonBorrarDeposito.UseVisualStyleBackColor = true;
            this.botonBorrarDeposito.Click += new System.EventHandler(this.botonBorrarDeposito_Click);
            // 
            // botonBorrarRetirada
            // 
            this.botonBorrarRetirada.Location = new System.Drawing.Point(586, 734);
            this.botonBorrarRetirada.Name = "botonBorrarRetirada";
            this.botonBorrarRetirada.Size = new System.Drawing.Size(436, 29);
            this.botonBorrarRetirada.TabIndex = 40;
            this.botonBorrarRetirada.Text = "Borrar retirada selecionada";
            this.botonBorrarRetirada.UseVisualStyleBackColor = true;
            this.botonBorrarRetirada.Click += new System.EventHandler(this.botonBorrarRetirada_Click);
            // 
            // botonInsertarRetirada
            // 
            this.botonInsertarRetirada.Location = new System.Drawing.Point(588, 699);
            this.botonInsertarRetirada.Name = "botonInsertarRetirada";
            this.botonInsertarRetirada.Size = new System.Drawing.Size(436, 29);
            this.botonInsertarRetirada.TabIndex = 35;
            this.botonInsertarRetirada.Text = "Insertar nueva retirada";
            this.botonInsertarRetirada.UseVisualStyleBackColor = true;
            this.botonInsertarRetirada.Click += new System.EventHandler(this.botonInsertarRetirada_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(818, 638);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 26);
            this.label4.TabIndex = 39;
            this.label4.Text = "Cantidad retirada";
            // 
            // textCantidadRetirada
            // 
            this.textCantidadRetirada.Location = new System.Drawing.Point(818, 667);
            this.textCantidadRetirada.Name = "textCantidadRetirada";
            this.textCantidadRetirada.Size = new System.Drawing.Size(206, 26);
            this.textCantidadRetirada.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.059701F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(586, 638);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 26);
            this.label5.TabIndex = 37;
            this.label5.Text = "Concepto retirada";
            // 
            // textConceptoRetirada
            // 
            this.textConceptoRetirada.Location = new System.Drawing.Point(586, 667);
            this.textConceptoRetirada.Name = "textConceptoRetirada";
            this.textConceptoRetirada.Size = new System.Drawing.Size(206, 26);
            this.textConceptoRetirada.TabIndex = 36;
            // 
            // GestionCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1412, 1038);
            this.Controls.Add(this.botonBorrarRetirada);
            this.Controls.Add(this.botonInsertarRetirada);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textCantidadRetirada);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textConceptoRetirada);
            this.Controls.Add(this.botonBorrarDeposito);
            this.Controls.Add(this.botonInsertarDeposito);
            this.Controls.Add(this.cantidadDepositoLabel);
            this.Controls.Add(this.textCantidadDeposito);
            this.Controls.Add(this.labelConceptoDeposito);
            this.Controls.Add(this.textConceptoDeposito);
            this.Controls.Add(this.botonBorrarTitulares);
            this.Controls.Add(this.botonInsertarTitulares);
            this.Controls.Add(this.dniTitulareslabel);
            this.Controls.Add(this.textDniTitulares);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Retiradaslabel);
            this.Controls.Add(this.Depositoslabel);
            this.Controls.Add(this.Titulareslabel);
            this.Controls.Add(this.dataGridRetiradas);
            this.Controls.Add(this.dataGridDepositos);
            this.Controls.Add(this.dataGridTitulares);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "GestionCuenta";
            this.Load += new System.EventHandler(this.GestionCuenta_Load);
            ((System.ComponentModel.ISupportInitialize) (this.dataGridCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridTitulares)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridDepositos)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridRetiradas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button botonBorrarRetirada;
        private System.Windows.Forms.Button botonInsertarRetirada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textCantidadRetirada;
        private System.Windows.Forms.TextBox textConceptoRetirada;

        private System.Windows.Forms.Button botonBorrarDeposito;
        private System.Windows.Forms.Button botonInsertarDeposito;

        private System.Windows.Forms.Label cantidadDepositoLabel;
        private System.Windows.Forms.TextBox textCantidadDeposito;

        private System.Windows.Forms.Label labelConceptoDeposito;
        private System.Windows.Forms.TextBox textConceptoDeposito;

        private System.Windows.Forms.Button botonBorrarTitulares;
        private System.Windows.Forms.Button botonInsertarTitulares;
        private System.Windows.Forms.Label dniTitulareslabel;
        private System.Windows.Forms.TextBox textDniTitulares;

        private System.Windows.Forms.Button BotonListarTodos;

        private System.Windows.Forms.ComboBox comboTipo;

        private System.Windows.Forms.Button BotonGuardar;
        private System.Windows.Forms.Label buscarDNITitularlabel;
        private System.Windows.Forms.TextBox textBuscarCCC;
        private System.Windows.Forms.TextBox textBuscarDni;

        private System.Windows.Forms.Label CCClabel;
        private System.Windows.Forms.TextBox textDNITitular;

        private System.Windows.Forms.Label BuscarCCClabel;

        private System.Windows.Forms.DataGridView dataGridTitulares;

        private System.Windows.Forms.DataGridView dataGridCuentas;
        private System.Windows.Forms.DataGridView dataGridDepositos;
        private System.Windows.Forms.DataGridView dataGridRetiradas;

        private System.Windows.Forms.Label DNITitularlabel;

        private System.Windows.Forms.DataGridViewTextBoxColumn DNITitular;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button BotonBorrar;
        private System.Windows.Forms.Button BotonEditar;
        private System.Windows.Forms.Label Cuentaslabel;
        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.TextBox textInteres;

        private System.Windows.Forms.TextBox textCCC;
        private System.Windows.Forms.TextBox textSaldo;

        private System.Windows.Forms.Button BotonBuscar;
        private System.Windows.Forms.Button BotonInsertar;

        private System.Windows.Forms.Label Depositoslabel;
        private System.Windows.Forms.Label Retiradaslabel;

        private System.Windows.Forms.Label Intereslabel;
        private System.Windows.Forms.Label Titulareslabel;

        private System.Windows.Forms.Label Saldolabel;
        private System.Windows.Forms.Label Tipolabel;

        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoRetirada;

        private System.Windows.Forms.DataGridViewTextBoxColumn DatetimeRetirada;

        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadDeposito;

        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoDeposito;

        private System.Windows.Forms.DataGridViewTextBoxColumn Datetime;

        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;

        private System.Windows.Forms.DataGridViewTextBoxColumn FechaApertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;

        private System.Windows.Forms.DataGridViewTextBoxColumn CCC;

        #endregion
    }
}