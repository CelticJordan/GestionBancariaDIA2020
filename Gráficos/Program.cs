using Gráficos.Graficos;
using Gráficos.Pruebas;
using Gráficos.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WForms = System.Windows.Forms;

namespace Gráficos
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
           WForms.Application.EnableVisualStyles();
           WForms.Application.SetCompatibleTextRenderingDefault(false);
            ///REALIZACION DE PRUEBAS, CREACIÓN DE LOS DISTINTOS OBJETOS PARA PASARSELOS A LOS GRÁFICOS
            List<Cliente> clientes = new List<Cliente>();
            List<Cliente> cliente = new List<Cliente>();
            List<Cliente> titulares = new List<Cliente>();
            List<Cuenta> cuentas = new List<Cuenta>();
            List<Deposito> depositos = new List<Deposito>();
            List<Retirada> retiradas = new List<Retirada>();
            Deposito d = new Deposito(200, new DateTime(2000, 08, 27));
            Deposito d2 = new Deposito(500, new DateTime(2001, 08, 27));
            Deposito d3 = new Deposito(120, new DateTime(2001, 08, 27));
            Deposito d4 = new Deposito(250, new DateTime(2004, 08, 27));
            Deposito d5 = new Deposito(1000, new DateTime(2000, 05, 27));
            Deposito d6 = new Deposito(350, new DateTime(2005, 08, 27));
            depositos.Add(d);
            depositos.Add(d2);
            depositos.Add(d3);
            depositos.Add(d4);
            depositos.Add(d5);
            depositos.Add(d6);
            Retirada r= new Retirada(200, new DateTime(2001, 06, 22));
            Retirada r2 = new Retirada(210, new DateTime(2002, 06, 22));
            Retirada r3 = new Retirada(20, new DateTime(2004, 08, 27));
            Retirada r4 = new Retirada(220, new DateTime(2005, 03, 27));
            Retirada r5 = new Retirada(600, new DateTime(2001, 05, 27));
            retiradas.Add(r);
            retiradas.Add(r2);
            retiradas.Add(r3);
            retiradas.Add(r4);
            retiradas.Add(r5);
            List<Transferencia> trasnferencias = new List<Transferencia>();
            Cliente c = new Cliente("44494151F", "Nico");
            Cliente c1 = new Cliente("44494151F", "Pepe");
            Cliente c2 = new Cliente("44494151F", "Antonio");
            Cliente c3 = new Cliente("44494151F", "Cristina");
            Cliente c4 = new Cliente("44494151F", "Pedro");
            Cliente c5 = new Cliente("44494222Y", "Jose");
            clientes.Add(c);
            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);
            clientes.Add(c4);
            titulares.Add(c1);
            titulares.Add(c2);
            cliente.Add(c5);
            Cuenta cc = new Cuenta("2222-4444-3333-4444-5555", 2000, titulares, new DateTime(2000, 08, 27), depositos, retiradas);
            Cuenta cc1 = new Cuenta("2222-4444-3333-4444-5555", 2000, cliente, new DateTime(2001, 08, 27), depositos, retiradas);
            Cuenta cc2 = new Cuenta("2223-4443-3334-4445-5554", 100, clientes, new DateTime(2002, 09, 28), depositos, retiradas);
            Cuenta cc3 = new Cuenta("0000-0000-0000-0000-0000", 2000, titulares, new DateTime(2002, 08, 27), depositos, retiradas);

            cuentas.Add(cc);
            cuentas.Add(cc1);
            cuentas.Add(cc2);
            cuentas.Add(cc3);
            Transferencia t1 = new Transferencia("225d", cc,cc1,1000, new DateTime(2000, 05, 27));
            Transferencia t2 = new Transferencia("444d", cc2,cc3,500, new DateTime(2005, 09, 28));
            Transferencia t3 = new Transferencia("111ad", cc1, cc,200, new DateTime(2002, 10, 2));
            Transferencia t4 = new Transferencia("23sd", cc3, cc2,100, new DateTime(2005, 05, 27));
            trasnferencias.Add(t1);
            trasnferencias.Add(t2);
            trasnferencias.Add(t3);
            trasnferencias.Add(t4);
            GraficoControlView grf = new GraficoControlView();
            grf.Clientes = clientes;
            grf.Cuentas = cuentas;
            grf.Transferencias = trasnferencias;
            grf.Cliente =c5;
            grf.Cuenta = cc;
            Grafico g = new Grafico();
            WForms.Application.Run(grf.PanelGraficoView);
        }
    }
}
