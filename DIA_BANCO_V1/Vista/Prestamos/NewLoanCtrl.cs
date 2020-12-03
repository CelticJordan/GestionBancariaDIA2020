using System;
using DIA_BANCO_V1.Core;

namespace DIA_BANCO_V1 {
    using WForms = System.Windows.Forms;
    public class NewLoanCtrl
    {
        public NewLoanCtrl()
        {
            this.View = new NewLoanView();
            
            this.View.BtCrear.Click += (sender,  args) => this.onBtCreaClick();
        }

        public void onBtCreaClick()
        {
            RegistroPrestamos prestamos = RegistroPrestamos.RecuperaXml();

            try
            {
                prestamos.Add(GetLoan());
                prestamos.GuardaXml();
                WForms.MessageBox.Show("Prestamo creado");
                this.View.Hide();
                this.View.Close();
            }
            catch (ArgumentException)
            {
                WForms.MessageBox.Show("Ya existe un Prestamo con ese ID");
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
        
        public NewLoanView View { get; }
    }
}