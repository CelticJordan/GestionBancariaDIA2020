using DIA_BANCO_V1;
using DIA_BANCO_V1.Core;

namespace DIA_BANCO_V1 {
    using Draw = System.Drawing;
    using WForms = System.Windows.Forms;
    
    public class ListLoanView: WForms.Form
    {
        public ListLoanView()
        {
            this.Build();
        }

        public void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel()
            {
                Dock = WForms.DockStyle.Fill
            };
            
            var prestamosXML = RegistroPrestamos.RecuperaXml();
            
            WForms.Label prestamosToString = new WForms.Label()
            {
                Dock = WForms.DockStyle.Top,
                Text = prestamosXML.ToString(),
                AutoSize = true
            };
            
            this.Controls.Add(prestamosToString);
            
            pnlMain.ResumeLayout(false);
            this.Controls.Add(pnlMain);
            this.MinimumSize = new Draw.Size(640,320);
            this.Text = "Lista de Prestamos";

        }
    }
}