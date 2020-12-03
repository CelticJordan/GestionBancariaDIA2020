using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Clientes.Core;
using DIA_BANCO_V1.Core;
using DIA_BANCO_V1.Cuentas;
using Transferencias.Core;

namespace DIA_BANCO_V1
{
    public class VistaPrincipal : Form
    {
        
        public VistaPrincipal()
        {
            
            List<Cuenta> cuentas = new List<Cuenta>();
            List<Cliente> clientes = new List<Cliente>();
            // List<Transferencia> transferencias = new List<Transferencia>();
            // List<Prestamo> prestamos = new List<Prestamo>();

            Cliente cli1 = new Cliente("Rubén Solveira", "76735813Q","123","email","direcion");
            Cliente cli2 = new Cliente("Xoel Molinos", "55555555P","123","email","direcion");
            Cliente cli3 = new Cliente("Ana lopez", "11111111M","123","email","direcion");
            Cliente cli4 = new Cliente("Vegeta", "77777777V","123","email","direcion");
            Cliente cli5 = new Cliente("Ruben titular 2", "81759827P","123","email","direcion");
            clientes.Add(cli1);
            clientes.Add(cli2);
            clientes.Add(cli3);
            clientes.Add(cli4);
            clientes.Add(cli5);

            Cuenta cue1 = new CuentaVivienda("11111111111111111111", cli1);
            cue1.Titulares.Add(cli5);
            Cuenta cue2 = new CuentaCorriente("22222222222222222222", cli2);
            cue2.Saldo = 12345;
            Cuenta cue3 = new CuentaAhorro("33333333333333333333", cli3);
            cue3.Saldo = 5321;

            cue1.Depositos.Add(new Cuenta.Deposito("nomina diciembre", DateTime.Now,  1500.23f));
            cue1.Depositos.Add(new Cuenta.Deposito("nomina enero", DateTime.Now,3200.23f));
            cue2.Depositos.Add(new Cuenta.Deposito("nomina febrero", DateTime.Now,1650.23f));

            cue1.Retiradas.Add(new Cuenta.Retirada("pedido amazon 121", DateTime.Now,499.99f));
            cue1.Retiradas.Add(new Cuenta.Retirada("pedido amazon 532", DateTime.Now,99.99f));
            cue3.Retiradas.Add(new Cuenta.Retirada("pedido amazon 689", DateTime.Now,1499.99f));

            cuentas.Add(cue1);
            cuentas.Add(cue2);
            cuentas.Add(cue3);
            
     
            this.Controls.Add(new GestionCuentas(cuentas,clientes ));
           
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

        private Panel pnlPrincipal;
        private StatusBar sbStatus;
        
        public IEnumerable<Cliente> Clientes;
        public IEnumerable<Cuenta> Cuentas;
        public IEnumerable<Transferencia> Transferencias;
        public IEnumerable<Prestamo> Prestamos;
    }
}