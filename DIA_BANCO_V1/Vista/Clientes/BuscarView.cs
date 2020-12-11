using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIA_BANCO_V1
{
    using Draw = System.Drawing;
    using WForms = System.Windows.Forms;
    public class BuscarView : WForms.Form
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
            pnlMain.Controls.Add(this.tEncontrado());
            pnlMain.Controls.Add(this.BuildClienteEncontrado());
            pnlMain.Controls.Add(this.BuildBtEliminar());
            pnlMain.Controls.Add(this.BuildBtEditar());

            this.Controls.Add(pnlMain);
            this.Text = "Buscar cliente";
            this.MinimumSize = new Draw.Size(200, 300);
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


        //Creado para mostrar el cliente cuando lo encuentra
        WForms.Label tEncontrado()
        {
            tituloencontrado = new WForms.Label
            {
                Dock = WForms.DockStyle.Top
            };

            tituloencontrado.Text = "Hemos encontrado un cliente con el dni: "+dni.Text.ToString();
            tituloencontrado.MaximumSize = new Draw.Size(800, 20);

            return tituloencontrado;
        }

        //Caja para mostrar los datos del cliente
        WForms.Panel BuildClienteEncontrado()
        {
            var toret = new WForms.Panel
            {
                Dock = WForms.DockStyle.Top
            };

            this.cliente = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                Text = "",
                TextAlign = WForms.HorizontalAlignment.Left
            };

            toret.Controls.Add(this.cliente);
            toret.MaximumSize = new Draw.Size(800, 200);
            this.cliente.ReadOnly = true;
            this.cliente.Multiline = true;

            return toret;
        }


        //Boton para eliminar el cliente encontrado
        WForms.Button BuildBtEliminar()
        {
            this.BtEliminar = new WForms.Button
            {
                Dock = WForms.DockStyle.Bottom,
                Text = "Eliminar cliente"
            };
            this.MaximumSize = new Draw.Size(2000, 20);

            return this.BtEliminar;
        }

        //Boton para editar el cliente encontrado
        WForms.Button BuildBtEditar()
        {
            this.BtEditar = new WForms.Button
            {
                Dock = WForms.DockStyle.Bottom,
                Text = "Editar cliente"
            };
            this.MaximumSize = new Draw.Size(2000, 20);

            return this.BtEditar;
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
        public WForms.Label tituloencontrado
        {
            get; private set;
        }

        public WForms.TextBox cliente
        {
            get; private set;
        }
        public WForms.Button BtEliminar
        {
            get; private set;
        }
        public WForms.Button BtEditar
        {
            get; private set;
        }

    }
}
