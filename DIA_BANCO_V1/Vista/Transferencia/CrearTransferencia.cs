namespace DIA_BANCO_V1
{
    using Draw=System.Drawing;
    using WForms = System.Windows.Forms;

    public class CrearTransferencia : WForms.Form
    {
        public CrearTransferencia()
        {
            this.Build();
        }

        /// <summary>
        /// Builder de la vista de Crear Transferencia
        /// </summary>
        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill
            };
            
            //Atributos a introducir
            ViewAtributos(pnlMain);

            //Boton crear Transferencia
            this.BCrearTransferencia = new WForms.Button {
                Dock = WForms.DockStyle.Top,
                Text = "Crear Transferencia"
            };
            
            pnlMain.Controls.Add( BCrearTransferencia);
            
            pnlMain.ResumeLayout(false);
            this.Controls.Add(pnlMain);
            this.Text = "Tranferencias";
            
            this.MinimumSize = new Draw.Size( 400, 500 );
        }

        /// <summary>
        /// Muesto la vista de los campos necesarios
        /// </summary>
        /// <param name="pnl"></param>
        public void ViewAtributos(WForms.Panel pnl)
        {
            var lccc = new WForms.Label {
                Dock  = WForms.DockStyle.Top,
                Text = "Introduce tu CCC (Código cuenta cliente):"
            } ;

            this.ecccorigen = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            
            var lid = new WForms.Label {
                Dock  = WForms.DockStyle.Top,
                Text = "Id:"
            };

            this.eid = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            
            var ltp = new WForms.Label {
                Dock  = WForms.DockStyle.Top,
                Text = "Tipo de Transferencia: "
            };

            this.etp = new WForms.ComboBox
            {
                Dock = WForms.DockStyle.Top,
                DropDownStyle = WForms.ComboBoxStyle.DropDownList,
            };

            this.etp.Items.AddRange(new[]
            {
                "Puntual", "Periodica"
            });
            
            this.etp.Text = (string) this.etp.Items[0];
            
            var lcccdest = new WForms.Label {
                Dock  = WForms.DockStyle.Top,
                Text = "Introduce el CCC (Código cuenta cliente) del destinatario:"
            } ;

            this.ecccdest = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            
            var limporte = new WForms.Label {
                Dock  = WForms.DockStyle.Top,
                Text = "Importe:"
            };

            this.eimporte = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            
            var lfecha = new WForms.Label {
                Dock  = WForms.DockStyle.Top,
                Text = "Fecha (ej: 12/12/2020 ):"
            };

            this.efecha = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };


            pnl.Controls.Add( lccc );
            pnl.Controls.Add( this.ecccorigen );
            pnl.Controls.Add( lid );
            pnl.Controls.Add( this.eid );
            pnl.Controls.Add( ltp );
            pnl.Controls.Add( this.etp );
            pnl.Controls.Add( lcccdest );
            pnl.Controls.Add( this.ecccdest );
            pnl.Controls.Add( limporte );
            pnl.Controls.Add( this.eimporte );
            pnl.Controls.Add( lfecha );
            pnl.Controls.Add( this.efecha );
            
            pnl.ResumeLayout(false);
            this.Controls.Add(pnl);

        }

        public WForms.TextBox ecccorigen { get; private set; }
        public WForms.TextBox eid { get; private set; }
        public WForms.ComboBox etp { get; private set; }
        public WForms.TextBox ecccdest { get; private set; }
        public WForms.TextBox eimporte { get; private set; }
        public WForms.TextBox efecha { get; private set; }
        public WForms.Button BCrearTransferencia { get; private set; }

  
    }
}