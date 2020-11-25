
namespace Transferencias.UI
{
    using Draw=System.Drawing;
    using WForms = System.Windows.Forms;

    public class BorrarTransferencia : WForms.Form
    {
        public BorrarTransferencia()
        {
            this.Build();
        }

        /// <summary>
        /// Builder de la vista de Borrar Transferencias
        /// </summary>
        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill
            };
            
            var lid = new WForms.Label {
                Dock  = WForms.DockStyle.Top,
                Text = "Introduce la Id de la transferencia:"
            };

            this.eid = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Center
            };
            
            this.Bid = new WForms.Button {
                Dock = WForms.DockStyle.Top,
                Text = "Eliminar"
            };
            
            pnlMain.Controls.Add(lid);
            pnlMain.Controls.Add(this.eid);
            pnlMain.Controls.Add(this.Bid);
            
            
            pnlMain.ResumeLayout(false);
            this.Controls.Add(pnlMain);
            this.Text = "Tranferencias";
            
            this.MinimumSize = new Draw.Size( 400, 100 );
        }
        
        public WForms.TextBox eid { get; private set; }
        public WForms.Button Bid { get; private set; }
        
    }
}