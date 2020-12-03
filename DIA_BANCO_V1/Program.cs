using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Clientes.Core;
using DIA_BANCO_V1.Core;
using DIA_BANCO_V1.Cuentas;

namespace DIA_BANCO_V1
{
    using WForms = System.Windows.Forms;
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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
            
            // RegistroBanco rb = new RegistroBanco();
            // rb.clientes;
            //
            // GestionCuentas gc = new GestionCuentas(cuentas, clientes);
            // Application.Run(gc);
            
            // GraficoControlView mpgv = new GraficoControlView();
            // mpgv.Clientes = clientes;
            // mpgv.Cuentas = cuentas;
            // WForms.Application.Run(mpgv.PanelGraficoView);
            //
            VistaPrincipal vp = new VistaPrincipal();
            Application.Run(vp);
        }
    }
}