using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Ui
{
    using Draw = System.Drawing;
    using WForms = System.Windows.Forms;
    class BuscarView : WForms.Form
    {
        public BuscarView()
        {
            this.Build();
        }

        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill
            };

            pnlMain.Controls.Add(this.tBuscar());
            pnlMain.Controls.Add(this.BuildDni());
            pnlMain.Controls.Add(this.BuildBtBuscar());

            this.Controls.Add(pnlMain);
            this.Text = "Buscar cliente";
            this.MinimumSize = new Draw.Size(200, 200);
        }


        //Creado para solicitar el DNI del cliente a editar
        WForms.Label tBuscar()
        {
            titulobuscar = new WForms.Label
            {
                Dock = WForms.DockStyle.Top
            };

            titulobuscar.Text = "Introduce el dni del cliente";
            titulobuscar.MaximumSize = new Draw.Size(800, 20);

            return titulobuscar;
        }


        //Caja para introducir el dni
        WForms.Panel BuildDni()
        {
            var toret = new WForms.Panel
            {
                Dock = WForms.DockStyle.Top
            };

            this.dni = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                Text = "",
                TextAlign = WForms.HorizontalAlignment.Right
            };

            toret.Controls.Add(this.dni);
            toret.MaximumSize = new Draw.Size(800, 20);

            return toret;
        }


        //Boton para editar un cliente
        WForms.Button BuildBtBuscar()
        {
            this.BtBuscar = new WForms.Button
            {
                Dock = WForms.DockStyle.Bottom,
                Text = "Buscar cliente"
            };
            this.MaximumSize = new Draw.Size(2000, 20);

            return this.BtBuscar;
        }

        public WForms.Label titulobuscar
        {
            get; private set;
        }

        public WForms.TextBox dni
        {
            get; private set;
        }


        public WForms.Button BtBuscar
        {
            get; private set;
        }
    }
}
