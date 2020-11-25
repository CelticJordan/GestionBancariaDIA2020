using ProyectoDIAIndep.View;

namespace ProyectoDIAIndep
{
    using WForms = System.Windows.Forms;

    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0
                && args[0] == "--gui")
            {
                var form = new MainWindowCtrl().View;

                try
                {
                    form.Show();
                    WForms.Application.Run(form);
                }
                catch (System.Exception exc)
                {
                    WForms.MessageBox.Show("Unexpected: " + exc.Message, "Demo",
                        WForms.MessageBoxButtons.OK,
                        WForms.MessageBoxIcon.Error);
                }

            }
            else
            {
                View.ConsoleUI.MainLoop(args);
            }

            return;
        }
    }
}