namespace DIA_BANCO_V1 {
    using Draw = System.Drawing;
    using WForms = System.Windows.Forms;
    
    public class NewLoanView: WForms.Form
    {
        public NewLoanView()
        {
            this.Build();
        }
        
        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel {
                Dock = WForms.DockStyle.Fill
            };
            
            pnlMain.Controls.Add( this.BuildIDP() );
            pnlMain.Controls.Add( this.BuildCCCOri() );
            pnlMain.Controls.Add( this.BuildCCCDes() );
            pnlMain.Controls.Add( this.BuildImporte() );
            pnlMain.Controls.Add( this.BuildFecha() );
            pnlMain.Controls.Add( this.BuildBtCrear() );
            
            this.Controls.Add( pnlMain );
            this.Text = "Nuevo Prestamo";
            this.MinimumSize = new Draw.Size( 400, 650);
        }
        
        WForms.Panel BuildIDP()
        {
            var toret = new WForms.Panel {
                Dock = WForms.DockStyle.Top
            };
            
            toret.Controls.Add( new WForms.Label {
                Dock  = WForms.DockStyle.Left,
                Text = "ID del Prestamo"
            } );

            this.EdIDP = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                Text = "",
                TextAlign = WForms.HorizontalAlignment.Right
            };

            toret.Controls.Add( this.EdIDP );

            return toret;
        }

        WForms.Panel BuildCCCOri()
        {
            var toret = new WForms.Panel {
                Dock = WForms.DockStyle.Top
            };
            
            toret.Controls.Add( new WForms.Label {
                Dock  = WForms.DockStyle.Left,
                Text = "CC Origen"
            } );

            this.EdCCCOri = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                Text = "",
                TextAlign = WForms.HorizontalAlignment.Right
            };

            toret.Controls.Add( this.EdCCCOri );

            return toret;
        }
        
        WForms.Panel BuildCCCDes()
        {
            var toret = new WForms.Panel {
                Dock = WForms.DockStyle.Top
            };
            
            toret.Controls.Add( new WForms.Label {
                Dock  = WForms.DockStyle.Left,
                Text = "CC Destino"
            } );

            this.EdCCCDes = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                Text = "",
                TextAlign = WForms.HorizontalAlignment.Right
            };

            toret.Controls.Add( this.EdCCCDes );

            return toret;
        }

        WForms.Panel BuildImporte()
        {
            var toret = new WForms.Panel {
                Dock = WForms.DockStyle.Top
            };
            
            toret.Controls.Add( new WForms.Label {
                Dock  = WForms.DockStyle.Left,
                Text = "Importe"
            } );

            this.EdImporte = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                Text = "",
                TextAlign = WForms.HorizontalAlignment.Right
            };

            toret.Controls.Add( this.EdImporte );

            return toret;
        }
         
        WForms.Panel BuildFecha()
        {
            var toret = new WForms.Panel {
                Dock = WForms.DockStyle.Top
            };
            
            toret.Controls.Add( new WForms.Label {
                Dock  = WForms.DockStyle.Left,
                Text = "Fecha (dd-MM-yyyy)"
            } );

            this.EdFecha = new WForms.TextBox {
                Dock = WForms.DockStyle.Fill,
                Text = "",
                TextAlign = WForms.HorizontalAlignment.Right
            };

            toret.Controls.Add( this.EdFecha );

            return toret;
        }
        
        WForms.Button BuildBtCrear()
        {
            this.BtCrear = new WForms.Button {
                Dock = WForms.DockStyle.Top,
                Text = "Crear"
            };

            return this.BtCrear;
        }
        
        public WForms.Button BtCrear { get; private set; }
        
        public WForms.TextBox EdIDP { get; private set; }
        
        public WForms.TextBox EdCCCOri { get; private set; }
        
        public WForms.TextBox EdCCCDes { get; private set; }
        
        public WForms.TextBox EdImporte { get; private set; }
        
        public WForms.TextBox EdFecha { get; private set; }
    }
}