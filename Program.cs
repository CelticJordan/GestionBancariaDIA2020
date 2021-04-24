using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DIA_BANCO_V1
{
    using WForms = System.Windows.Forms;

    static class Program
    {
        static void Main()
        {
            RegistroBanco regbanco = new RegistroBanco();
            GestionCuentas gestion = new GestionCuentas(regbanco);
            Application.Run(gestion);
        }
    }
}