namespace DIA_BANCO_V1
{
    using Draw=System.Drawing;
    using WForms = System.Windows.Forms;
    
    public class MainWindowView : WForms.Form
    {
        public MainWindowView()
        {
            this.Build();
        }

        /// <summary>
        /// Builder de la vista principal
        /// </summary>
        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill
            };

            this.bCrearTransferencia = new WForms.Button
            {
                Text = "Crear Transferencia",
                Dock = WForms.DockStyle.Top
            };
            
            this.bBorrarTransferencia = new WForms.Button
            {
                Text = "Borrar Transferencia",
                Dock = WForms.DockStyle.Top
            };
            
            this.bConsultarTransferencias = new WForms.Button
            {
                Text = "Consultar Transferencias",
                Dock = WForms.DockStyle.Top
            };
            
            this.bModificarTransferencias = new WForms.Button
            {
                Text = "Modificar Transferencias",
                Dock = WForms.DockStyle.Top
            };


            pnlMain.Controls.Add(bCrearTransferencia);
            pnlMain.Controls.Add(bBorrarTransferencia);
            pnlMain.Controls.Add(bConsultarTransferencias);
            pnlMain.Controls.Add(bModificarTransferencias);
            
            pnlMain.ResumeLayout(false);
            this.Controls.Add(pnlMain);
            this.Text = "Tranferencias";
            
            this.MinimumSize = new Draw.Size( 400, 100 );
            
        }
        
        public WForms.Button bCrearTransferencia { get; private set; }
        public WForms.Button bBorrarTransferencia { get; private set; }
        public WForms.Button bConsultarTransferencias { get; private set; }
        
        public WForms.Button bModificarTransferencias { get; private set; }

    }
}