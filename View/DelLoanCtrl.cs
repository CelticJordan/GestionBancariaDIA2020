using System;
using ProyectoDIAIndep.Core;

namespace ProyectoDIAIndep.View{
    using WForms = System.Windows.Forms;
    public class DelLoanCtrl
    {
        public DelLoanCtrl()
        {
            this.View = new DelLoanView();
            
            this.View.BtEliminar.Click += (sender,  args) => this.onBtEliminaClick();
        }

        public void onBtEliminaClick()
        {
            RegistroPrestamos prestamos = RegistroPrestamos.RecuperaXml();

            try
            {
                prestamos.Remove(this.View.EdIDP.Text);
                prestamos.GuardaXml();
                WForms.MessageBox.Show("Prestamo eliminado");
                this.View.Hide();
                this.View.Close();
            }
            catch (ArgumentException)
            {
                WForms.MessageBox.Show("No existe un Prestamo con ese ID");
            }
        }
        
        public DelLoanView View { get; }
    }
}