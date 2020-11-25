using System.Windows.Forms;
using DIA_P2_banco.Cuentas;

namespace DIA_P2_banco
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Cliente cli = new Cliente("ruben", "76735813Q");
            Cuenta c = new CuentaCorriente("2fwofiejfowiejdkslañ", cli);
            GestionCuenta gc = new GestionCuenta();
            Application.Run(gc);
        }
    }
}