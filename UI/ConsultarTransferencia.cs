
using Transferencias.Core;

namespace Transferencias.UI
{
    using Draw=System.Drawing;
    using WForms = System.Windows.Forms;

    public class ConsultarTransferencia : WForms.Form
    {

        public ConsultarTransferencia()
        {
            
            this.Build();
        }

        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill
            };
            
            TransferenciasXML transferencias = new TransferenciasXML();
            transferencias = transferencias.RecuperarXml();
            
            WForms.Label transferenciasToString = new WForms.Label()
            {
                Dock = WForms.DockStyle.Top,
                Text = transferencias.ToString(),
                AutoSize = true
                
            };
            
            this.Controls.Add(transferenciasToString);
            
            pnlMain.ResumeLayout(false);
            this.Controls.Add(pnlMain);
            this.Text = "Tranferencias";
            
            this.MinimumSize = new Draw.Size( 400, 100 );
        }
        
    }
}