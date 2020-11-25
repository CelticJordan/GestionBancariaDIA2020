using System.Collections.Generic;
using Transferencias.Core;
using Transferencias.UI;

namespace Transferencias
{
  using WForms = System.Windows.Forms;
  
  internal class Program
  {
    public static void Main(string[] args)
    {
      /*
      List<Transferencia> t = new List<Transferencia>();
      Transferencia x = new Transferencia( 1, "Puntual","20770024003102575766", "95843047289532681258", 20, "12/12/2020");
      Transferencia z = new Transferencia( 2, "Periodica", "95843047289532681258","20770024003102575766", 12, "10/12/2020");
      t.Add(x);
      t.Add(z);
      TransferenciasXML v = new TransferenciasXML(t);
      v.GuardarXml();*/
      
      WForms.Application.Run( new MainWindowController().View );

    }
  }
}