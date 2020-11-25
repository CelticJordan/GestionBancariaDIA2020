namespace ProyectoDIAIndep.View
{
    using Draw = System.Drawing;
    using WForms = System.Windows.Forms;

    public class DelLoanView: WForms.Form
    {
        public DelLoanView()
        {
            this.Build();
        }

        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill
            };

            pnlMain.Controls.Add(this.BuildIDP());
            pnlMain.Controls.Add(this.BuildBtEliminar());

            this.Controls.Add(pnlMain);
            this.Text = "Eliminar Prestamo";
            this.MinimumSize = new Draw.Size(300, 200);
        }

        WForms.Panel BuildIDP()
        {
            var toret = new WForms.Panel
            {
                Dock = WForms.DockStyle.Top
            };

            toret.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Left,
                Text = "ID del Prestamo"
            });

            this.EdIDP = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                Text = "",
                TextAlign = WForms.HorizontalAlignment.Right
            };

            toret.Controls.Add(this.EdIDP);

            return toret;
        }
        
        WForms.Button BuildBtEliminar()
        {
            this.BtEliminar = new WForms.Button {
                Dock = WForms.DockStyle.Top,
                Text = "Eliminar"
            };

            return this.BtEliminar;
        }
        
        public WForms.Button BtEliminar { get; private set; }

        public WForms.TextBox EdIDP { get; private set; }
    }
}