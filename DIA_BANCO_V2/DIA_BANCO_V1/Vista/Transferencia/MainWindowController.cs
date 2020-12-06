
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace DIA_BANCO_V1
{
    using WForms = System.Windows.Forms;
    
    public class MainWindowController
    {
        public MainWindowController(List<Transferencia> transferencias)
        {
            this.View = new MainWindowView();
            
            this.View.bCrearTransferencia.Click += (sender, args) => new CrearTransferenciaController(transferencias).View.Show();
            this.View.bBorrarTransferencia.Click += (sender, args) => new BorrarTransferenciaController().View.Show();
            this.View.bConsultarTransferencias.Click += (sender, args) => new ConsultarTransferencia().Show();
            this.View.bModificarTransferencias.Click += (sender, args) => new ModificarTransferenciaController().View.Show();
        }

        public MainWindowView View {
            get;
        }
        
    }
}