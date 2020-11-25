using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace ProyectoDIA
{
    public class VistaPrincipal : Form
    {
        public VistaPrincipal()
        {
            //INICIO DATOS FANTASMA
            List<Cliente> variosClientes = new List<Cliente>();
            List<Cuenta> variasCuentas = new List<Cuenta>();
            List<Transferencia> variasTransferencias = new List<Transferencia>();
            List<Prestamo> variosPrestamos = new List<Prestamo>();
            
            Cliente cla = new Cliente("39479887H","Miguel",610886978,"miguel@gmail.com","Buenaventura");
            Cliente clb = new Cliente("47588871N","Manuel",610886978,"miguel@gmail.com","Buenaventura");
            Cliente clc = new Cliente("33415187L","Jorge",610886978,"miguel@gmail.com","Buenaventura");
            
            List<Cliente> titulares1 = new List<Cliente>();
            titulares1.Add(cla);
            List<Cliente> titulares2 = new List<Cliente>();
            titulares2.Add(clb);
            titulares2.Add(clc);
            
            Cuenta.Deposito da = new Cuenta.Deposito("Deposito A",new DateTime(2005,1,17),50);
            Cuenta.Deposito db = new Cuenta.Deposito("Deposito B",new DateTime(2005,5,10),100);
            Cuenta.Deposito dc = new Cuenta.Deposito("Deposito C",new DateTime(2006,2,5),25);
            List<Cuenta.Deposito> depositos1 = new List<Cuenta.Deposito>();
            depositos1.Add(da);
            List<Cuenta.Deposito> depositos2 = new List<Cuenta.Deposito>();
            depositos2.Add(db);
            depositos2.Add(dc);
            
            Cuenta.Retirada ra = new Cuenta.Retirada("Retirada A",new DateTime(2006,1,17),20);
            Cuenta.Retirada rb = new Cuenta.Retirada("Retirada B",new DateTime(2008,5,10),30);
            Cuenta.Retirada rc = new Cuenta.Retirada("Retirada C",new DateTime(2009,2,5),60);
            List<Cuenta.Retirada> retiradas1 = new List<Cuenta.Retirada>();
            retiradas1.Add(ra);
            List<Cuenta.Retirada> retiradas2 = new List<Cuenta.Retirada>();
            retiradas2.Add(rb);
            retiradas2.Add(rc);

            Cuenta ca = new Cuenta("15975368426951786324", "Corriente", 254.87, titulares1,
                new DateTime(2005, 10, 3), 150.78, depositos1, retiradas1);
            Cuenta cb = new Cuenta("23986368426951786324", "Corriente", 370.87, titulares2,
                new DateTime(2004, 7, 4), 230.78, depositos2, retiradas2);
            
            Transferencia ta = new Transferencia("QWERTY","Puntual","15975368426951786324",
                "23986368426951786324",50,new DateTime(2005, 11, 3));
            Transferencia tb = new Transferencia("ASDFGH","Periódico","23986368426951786324",
                "15975368426951786324",150,new DateTime(2009, 12, 5));
            Transferencia tc = new Transferencia("ZXCVBN","Puntual","23986368426951786324",
                "48975368426951786324",30,new DateTime(2009, 12, 5));
            
            Prestamo pa = new Prestamo("QAZWSX","Vivienda","15975368426951786324",
                "34975368426951786324",1.1,new DateTime(2014, 2, 7));
            Prestamo pb = new Prestamo("EDCRFV","Vivienda","23986368426951786324",
                "15975368426951786324",1.3,new DateTime(2017, 10, 24));
            Prestamo pc = new Prestamo("TGBYHN","Al consumo","23986368426951786324",
                "49975368426951786324",1.2,new DateTime(2019, 5, 14));
            
            variosClientes.Add(cla);
            variosClientes.Add(clb);
            variosClientes.Add(clc);
            
            variasCuentas.Add(ca);
            variasCuentas.Add(cb);

            variasTransferencias.Add(ta);
            variasTransferencias.Add(tb);
            variasTransferencias.Add(tc);
            
            variosPrestamos.Add(pa);
            variosPrestamos.Add(pb);
            variosPrestamos.Add(pc);
            
            this.Clientes = variosClientes;//Listado de todos los clientes
            this.Cuentas = variasCuentas;//Listado de todas las cuentas
            this.Transferencias = variasTransferencias;//Listado de todas las transferencias
            this.Prestamos = variosPrestamos;//Listado de todas las Prestamos
            //FIN DATOS FANTASMA
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

        private Panel pnlPrincipal;
        private StatusBar sbStatus;
        
        public IEnumerable<Cliente> Clientes;
        public IEnumerable<Cuenta> Cuentas;
        public IEnumerable<Transferencia> Transferencias;
        public IEnumerable<Prestamo> Prestamos;
    }
}