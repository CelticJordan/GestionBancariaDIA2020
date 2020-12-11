namespace DIA_BANCO_V1
{
    using System.Windows.Forms;
    using System.Drawing;

    public partial class MainWindow
    {

        //Construyo el menú con las opciones de anhadir cliente etc
        private void BuildMenu()
        {
            this.mPpal = new MainMenu();
            this.mEliminar = new MenuItem("&Eliminar");
            this.mEditar = new MenuItem("&Editar");

            this.opAnhadir = new MenuItem("&Añadir cliente")
            {
                Shortcut = Shortcut.CtrlIns
            };
            this.opAnhadir.Click += (sender, e) => this.onBtAnhadeClick();

            this.opBuscar = new MenuItem("&Buscar cliente")
            {
                Shortcut = Shortcut.CtrlIns
            };
            this.opBuscar.Click += (sender, e) => this.OnBtBuscarClick();

            this.opEliminar = new MenuItem("&Eliminar cliente seleccionado")
            {
                Shortcut = Shortcut.CtrlIns
            };
            this.opEliminar.Click += (sender, e) => this.OnBtEliminarMenuClick();

            this.opEditar = new MenuItem("&Editar cliente seleccionado")
            {
                Shortcut = Shortcut.CtrlIns
            };
            this.opEditar.Click += (sender, e) => this.OnBtEditarMenuClick();

            this.mEliminar.MenuItems.Add(this.opEliminar);
            this.mEditar.MenuItems.Add(this.opEditar);


            this.mPpal.MenuItems.Add(this.opAnhadir);
            this.mPpal.MenuItems.Add(this.opBuscar);
            this.mPpal.MenuItems.Add(this.mEliminar);
            this.mPpal.MenuItems.Add(this.mEditar);
            this.Menu = mPpal;
        }


        //Panel de detalle que mostrará la información detallada del cliente que está seleccionado en la tabla
        private Panel BuildPanelDetalle()
        {
            var pnlDetalle = new Panel { Dock = DockStyle.Bottom };
            pnlDetalle.SuspendLayout();

            this.edDetalle = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                Font = new Font(FontFamily.GenericMonospace, 7),
                ForeColor = Color.Navy,
                BackColor = Color.LightGray
            };

            pnlDetalle.Controls.Add(this.edDetalle);
            pnlDetalle.ResumeLayout(false);
            return pnlDetalle;
        }


        //Tabla que mostrará la información de los clientes
        private Panel BuildPanelLista()
        {
            var pnlLista = new Panel();
            pnlLista.SuspendLayout();
            pnlLista.Dock = DockStyle.Fill;

            // Crear gridview
            this.grdLista = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            this.grdLista.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.grdLista.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            var textCellTemplate0 = new DataGridViewTextBoxCell();
            var textCellTemplate1 = new DataGridViewTextBoxCell();
            var textCellTemplate2 = new DataGridViewTextBoxCell();
            var textCellTemplate3 = new DataGridViewTextBoxCell();
            var textCellTemplate4 = new DataGridViewTextBoxCell();
            var textCellTemplate5 = new DataGridViewTextBoxCell();
            var textCellTemplate6 = new DataGridViewTextBoxCell();
            textCellTemplate0.Style.BackColor = Color.LightGray;
            textCellTemplate0.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.BackColor = Color.Wheat;
            textCellTemplate1.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            textCellTemplate2.Style.BackColor = Color.Wheat;
            textCellTemplate2.Style.ForeColor = Color.Black;
            textCellTemplate3.Style.BackColor = Color.Wheat;
            textCellTemplate3.Style.ForeColor = Color.Black;
            textCellTemplate4.Style.BackColor = Color.Wheat;
            textCellTemplate4.Style.ForeColor = Color.Black;
            textCellTemplate5.Style.BackColor = Color.Orange;
            textCellTemplate6.Style.BackColor = Color.DarkOrange;

            var column0 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate0,
                HeaderText = "DNI",
                Width = 50,
                ReadOnly = true
            };

            var column1 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "NOMBRE",
                Width = 50,
                ReadOnly = true
            };

            var column2 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate2,
                HeaderText = "TELÉFONO",
                Width = 50,
                ReadOnly = true
            };

            var column3 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate3,
                HeaderText = "EMAIL",
                Width = 50,
                ReadOnly = true
            };

            var column4 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate4,
                HeaderText = "DIRECCIÓN",
                Width = 50,
                ReadOnly = true
            };
            var column5 = new DataGridViewTextBoxColumn
            {            
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate5,
                HeaderText = "Grafico Saldo",
                Width = 50,
                ReadOnly = true
            };
            var column6 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate6,
                HeaderText = "Grafico Ingreso",
                Width = 50,
                ReadOnly = true
            };

            this.grdLista.Columns.AddRange(new DataGridViewColumn[] {
                column0, column1, column2, column3, column4, column5, column6
            });


            this.grdLista.SelectionChanged +=
                                        (sender, e) => this.FilaSeleccionada();

            this.grdLista.Click +=
                            (sender, e) => this.OnBtGraficoClick();


            pnlLista.Controls.Add(this.grdLista);
            pnlLista.ResumeLayout(false);
            return pnlLista;
        }


        //Texto de la parte inferior de la pantalla que muestra el número de clientes que hay en el banco en la fecha en la que se entró
        private void BuildStatus()
        {
            this.sbStatus = new StatusBar { Dock = DockStyle.Bottom };
            this.Controls.Add(this.sbStatus);
        }

        private void Build()
        {
            //this.BuildIcons();
            this.BuildStatus();
            this.BuildMenu();
            this.BuildPanelLista();

            this.SuspendLayout();
            this.pnlPpal = new Panel()
            {
                Dock = DockStyle.Fill
            };

            this.pnlPpal.SuspendLayout();
            this.Controls.Add(this.pnlPpal);
            this.pnlPpal.Controls.Add(this.BuildPanelLista());
            this.pnlPpal.Controls.Add(this.BuildPanelDetalle());
            this.pnlPpal.ResumeLayout(false);

            this.MinimumSize = new Size(1000, 700);
            this.Resize += (obj, e) => this.ResizeWindow();
            this.Text = "Gestión de clientes del banco";

            this.ResumeLayout(true);
            this.ResizeWindow();
        }

        private void ResizeWindow()
        {
            // Tomar las nuevas medidas
            int width = this.pnlPpal.ClientRectangle.Width;

            // Redimensionar la tabla
            this.grdLista.Width = width;

            this.grdLista.Columns[ColDni].Width =
                                (int)System.Math.Floor(width * .142); // dni
            this.grdLista.Columns[ColNombre].Width =
                                (int)System.Math.Floor(width * .142); // nombre
            this.grdLista.Columns[ColTelefono].Width =
                                (int)System.Math.Floor(width * .142); // telefono
            this.grdLista.Columns[ColEmail].Width =
                                (int)System.Math.Floor(width * .142); // email
            this.grdLista.Columns[ColDireccion].Width =
                                (int)System.Math.Floor(width * .142); // direccion   
            this.grdLista.Columns[ColGrafico].Width =
                (int)System.Math.Floor(width * .142); // grafico  
            this.grdLista.Columns[ColGrafico2].Width =
                (int)System.Math.Floor(width * .142); // grafico  
            
        }

        private MainMenu mPpal;
        private MenuItem opAnhadir;
        private MenuItem mEliminar;
        private MenuItem opBuscar;
        private MenuItem opEliminar;
        private MenuItem mEditar;
        private MenuItem opEditar;

        private StatusBar sbStatus;
        private Panel pnlPpal;
        private TextBox edDetalle;
        private DataGridView grdLista;
    }
}