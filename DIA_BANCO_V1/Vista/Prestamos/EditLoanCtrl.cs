using System;
using System.Globalization;

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
            var provider = new CultureInfo("es-ES", false);
            
            string idP = this.View.EdIDP.Text;
            string cccOri = this.View.EdCCCOri.Text;
            double amount = Convert.ToDouble(this.View.EdImporte.Text);
            string date = this.View.EdFecha.Text;
            DateTime fDate = DateTime.ParseExact(date, "dd/MM/yyyy",provider);

<<<<<<< HEAD
            return new Prestamo(idP,type,cccOri,amount,numCuotas,fDate.Date);
=======
            return new Prestamo(idP,cccOri,cccDes,amount,fDate);
>>>>>>> parent of 2226138... Redefinidos y reimplementados Prestamos:
        }
        
        public EditLoanView View { get; }
    }
}
