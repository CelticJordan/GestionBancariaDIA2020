namespace DIA_BANCO_V1{
    using Draw = System.Drawing;
    using WForms = System.Windows.Forms;
    
    public class MainWindowView2: WForms.Form
    {
        public MainWindowView2()
        {
            this.Build();
        }

        private void BuildMenu()
        {
            this.Menu = new WForms.MainMenu();

            this.OpQuit = new WForms.MenuItem("&Quit") {
                Shortcut = WForms.Shortcut.CtrlQ
            };
            
            this.OpListLoan = new WForms.MenuItem("&Listar Prestamos") {
                Shortcut = WForms.Shortcut.CtrlL
            };
            
            this.OpNewLoan = new WForms.MenuItem("&Nuevo Prestamo") {
                Shortcut = WForms.Shortcut.CtrlN
            };
            
            this.OpEditLoan = new WForms.MenuItem("&Editar Prestamo") {
                Shortcut = WForms.Shortcut.CtrlE
            };
            
            this.OpDelLoan = new WForms.MenuItem("&Eliminar Prestamo") {
                Shortcut = WForms.Shortcut.CtrlD
            };
            
            var mFile = new WForms.MenuItem("&File");
            var mLoans = new WForms.MenuItem("&Prestamos");

            mFile.MenuItems.Add(this.OpQuit);

            mLoans.MenuItems.Add(this.OpListLoan);
            mLoans.MenuItems.Add(this.OpNewLoan);
            mLoans.MenuItems.Add(this.OpEditLoan);
            mLoans.MenuItems.Add(this.OpDelLoan);

            this.Menu.MenuItems.Add(mFile);
            this.Menu.MenuItems.Add(mLoans);
        }

        private void Build()
        {
            var pnlTable = new WForms.TableLayoutPanel();
            
            pnlTable.SuspendLayout();
            pnlTable.Dock = WForms.DockStyle.Fill;

            this.BtListLoan = new WForms.Button {
                Text = "Listar Prestamos",
                Dock = WForms.DockStyle.Top
            };
            
            this.BtNewLoan = new WForms.Button {
                Text = "Nuevo Prestamo",
                Dock = WForms.DockStyle.Top
            };

            this.BtEditLoan = new WForms.Button {
                Text = "Editar Prestamo",
                Dock = WForms.DockStyle.Top
            };

            this.BtDelLoan = new WForms.Button {
                Text = "Eliminar Prestamo",
                Dock = WForms.DockStyle.Top
            };
            
            pnlTable.Controls.Add(BtListLoan);
            pnlTable.Controls.Add(BtNewLoan);
            pnlTable.Controls.Add(BtEditLoan);
            pnlTable.Controls.Add(BtDelLoan);
            
            pnlTable.ResumeLayout(false);
            this.Controls.Add(pnlTable);
            
            this.BuildMenu();
            this.MinimumSize = new Draw.Size(320,240);
            this.Text = "Gestion de Prestamos";
        }

        public WForms.Button BtListLoan { get; private set; }
        
        public WForms.Button BtNewLoan { get; private set; }
        
        public WForms.Button BtEditLoan { get; private set; }
        
        public WForms.Button BtDelLoan { get; private set; }

        public WForms.MenuItem OpQuit { get; private set; }
        
        public WForms.MenuItem OpListLoan { get; private set; }
        
        public WForms.MenuItem OpNewLoan { get; private set; }
        
        public WForms.MenuItem OpEditLoan { get; private set; }
        
        public WForms.MenuItem OpDelLoan { get; private set; }
    }
}