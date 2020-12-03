using System;
using DIA_BANCO_V1.Core;

namespace DIA_BANCO_V1 {
    using WForms = System.Windows.Forms;
    public class EditLoanCtrl
    {
        public EditLoanCtrl()
        {
            this.View = new EditLoanView();
            
            this.View.BtEditar.Click += (sender,  args) => this.onBtEditaClick();
        }
        
        public void onBtEditaClick()
        {
            RegistroPrestamos prestamos = RegistroPrestamos.RecuperaXml();

            try
            {
                prestamos.Edit(GetLoan());
                prestamos.GuardaXml();
                WForms.MessageBox.Show("Prestamo editado");
                this.View.Hide();
                this.View.Close();
            }
            catch (ArgumentException)
            {
                WForms.MessageBox.Show("No existe un Prestamo con ese ID");
            }
        }
        
        public Prestamo GetLoan()
        {
            string idP = this.View.EdIDP.Text;
            string cccOri = this.View.EdCCCOri.Text;
            string cccDes = this.View.EdCCCDes.Text;
            double amount = Convert.ToDouble(this.View.EdImporte.Text);
            string date = this.View.EdFecha.Text;

            return new Prestamo(idP,cccOri,cccDes,amount,date);
        }
        
        public EditLoanView View { get; }
    }
}