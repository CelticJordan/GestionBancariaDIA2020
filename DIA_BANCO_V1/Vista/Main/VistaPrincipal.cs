using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace DIA_BANCO_V1
{
    public class VistaPrincipal : Form
    {
        
        public VistaPrincipal()
        {
            this.Build();
        }

        private void BuildMenu()
        {
            this.mPrincipal = new MainMenu();
            
            this.mBuscar = new MenuItem("&Buscar");
            
            this.opProductosPersona = new MenuItem("&Productos Persona");
            opProductosPersona.Click += (sender, e) => this.ProductosPersona();
            
            this.opMovimientosPersona = new MenuItem("&Movimientos Persona");
            opMovimientosPersona.Click += (sender, e) => this.MovimientosPersona();
            
            this.opTransferenciasPersona = new MenuItem("&Transferencias Persona");
            opTransferenciasPersona.Click += (sender, e) => this.TransferenciasPersona();
            
            this.opTransferenciasBanco = new MenuItem("&Transferencias Banco");
            opTransferenciasBanco.Click += (sender, e) => this.TransferenciasBanco();

            this.mBuscar.MenuItems.Add(opProductosPersona);
            this.mBuscar.MenuItems.Add(opMovimientosPersona);
            this.mBuscar.MenuItems.Add(opTransferenciasPersona);
            this.mBuscar.MenuItems.Add(opTransferenciasBanco);

        
            this.mPrincipal.MenuItems.Add(this.mBuscar);
            
            
            this.Menu = mPrincipal;
            
           
        }

        private void BuildStatus()
        {
            this.sbStatus=new StatusBar{Dock = DockStyle.Bottom};
            this.Controls.Add(sbStatus);
        }

        private void Build()
        {
            this.BuildStatus();
            this.BuildMenu();
            
            this.MinimumSize = new Size(600,400);
            this.Text = "Buscador";
        }

        private void ProductosPersona()
        {
            var dlgProductosPersona = new DlgProductosPersona(this.Clientes,this.Cuentas,this.Transferencias,this.Prestamos);
            dlgProductosPersona.ShowDialog();
        }
        private void MovimientosPersona()
        {
            var dlgMovimientosPersona = new DlgMovimientosPersona(this.Clientes,this.Cuentas,this.Transferencias,this.Prestamos);
            dlgMovimientosPersona.ShowDialog();
        }
        private void TransferenciasPersona()
        {
            var dlgTransferenciasPersona = new DlgTransferenciasPersona(this.Clientes,this.Cuentas,this.Transferencias);
            dlgTransferenciasPersona.ShowDialog();
        }
        private void TransferenciasBanco()
        {
            var dlgTransferenciasBanco = new DlgTransferenciasBanco(this.Transferencias);
            dlgTransferenciasBanco.ShowDialog();
        }

        private MainMenu mPrincipal;
        private MenuItem mBuscar;

        private MenuItem opProductosPersona;
        private MenuItem opMovimientosPersona;
        private MenuItem opTransferenciasPersona;
        private MenuItem opTransferenciasBanco;
        
        private StatusBar sbStatus;
        
        public IEnumerable<Cliente> Clientes;
        public IEnumerable<Cuenta> Cuentas;
        public IEnumerable<Transferencia> Transferencias;
        public IEnumerable<Prestamo> Prestamos;
    }
}