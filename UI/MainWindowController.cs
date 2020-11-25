
using System.Windows.Forms.VisualStyles;

namespace Transferencias.UI
{
    using WForms = System.Windows.Forms;
    
    public class MainWindowController
    {
        public MainWindowController()
        {
            this.View = new MainWindowView();
            
            this.View.bCrearTransferencia.Click += (sender, args) => new CrearTransferenciaController().View.Show();
            this.View.bBorrarTransferencia.Click += (sender, args) => new BorrarTransferenciaController().View.Show();
            this.View.bConsultarTransferencias.Click += (sender, args) => new ConsultarTransferencia().Show();
            this.View.bModificarTransferencias.Click += (sender, args) => new ModificarTransferenciaController().View.Show();
        }

        public MainWindowView View {
            get;
        }
        
    }
}