using Clientes.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientes
{
    using WForms = System.Windows.Forms;
    static class Program
    {
        static void Main()
        {
            WForms.Application.Run(new MainWindowCtrl().View);

        }
    }
}
