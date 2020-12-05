﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Clientes.Core;

namespace DIA_BANCO_V1
{
    using WForms = System.Windows.Forms;
    
    static class Program
    {
        static void Main()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            List<Cliente> clientes = new List<Cliente>();
            List<Transferencia> transferencias = new List<Transferencia>();
            List<Prestamo> prestamos = new List<Prestamo>();
            // List<Transferencia> transferencias = new List<Transferencia>();
            // List<Prestamo> prestamos = new List<Prestamo>();

            Cliente cli1 = new Cliente("76735813Q","Rubén Solveira", "987987987","email","direcion");
            Cliente cli2 = new Cliente("55555555P","Xoel Molinos", "654654654","email","direcion");
            Cliente cli3 = new Cliente("11111111M","Ana lopez", "321321321","email","direcion");
            Cliente cli4 = new Cliente("77777777V","Vegeta", "987987987","email","direcion");
            Cliente cli5 = new Cliente("81759827P","Ruben titular 2", "654654654","email","direcion");
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

            cue2.Retiradas.Add(new Cuenta.Retirada("pedido amazon 121", DateTime.Now,499.99f));
            cue2.Retiradas.Add(new Cuenta.Retirada("pedido amazon 532", DateTime.Now,99.99f));
            cue2.Retiradas.Add(new Cuenta.Retirada("pedido amazon 689", DateTime.Now,1499.99f));

            cuentas.Add(cue1);
            cuentas.Add(cue2);
            cuentas.Add(cue3);
            
            Prestamo p1 = new Prestamo( "12", "11111111111111111111", "22222222222222222222", 200d, "22-10-2000");
            Prestamo p2 = new Prestamo( "13", "22222222222222222222", "33333333333333333333", 202d, "22-10-2000");
            Prestamo p3 = new Prestamo( "14", "33333333333333333333", "11111111111111111111", 204d, "22-10-2000");
            
            prestamos.Add(p1);
            prestamos.Add(p2);
            prestamos.Add(p3);

            Transferencia t1 = new Transferencia(123, "Puntual", "11111111111111111111", "22222222222222222222", 350d, DateTime.UtcNow);
            Transferencia t2 = new Transferencia(345, "Periodica", "33333333333333333333", "22222222222222222222", 355d, DateTime.UtcNow);
            Transferencia t3 = new Transferencia(789, "Puntual", "22222222222222222222", "11111111111111111111", 359d, DateTime.UtcNow);

            // RegistroBanco rb = new RegistroBanco();
            // rb.clientes;
            //
            GestionCuentas gc = new GestionCuentas(cuentas, clientes, prestamos, transferencias);
            Application.Run(gc);
        }
    }
}