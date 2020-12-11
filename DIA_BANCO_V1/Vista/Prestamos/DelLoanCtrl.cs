using System;

namespace DIA_BANCO_V1 {
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