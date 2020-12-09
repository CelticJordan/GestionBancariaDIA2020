using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DIA_BANCO_V1 {
    using WForms = System.Windows.Forms;
    public class NewLoanCtrl
    {
        public List<Prestamo> prestamos = new List<Prestamo>();
        public NewLoanCtrl(List<Prestamo> prestamos)
        {
            this.prestamos = prestamos;
            this.View = new NewLoanView();
            
            this.View.BtCrear.Click += (sender,  args) => this.onBtCreaClick();
        }

        public void onBtCreaClick()
        {
            try
            {
                this.prestamos.Add(GetLoan());
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
            var provider = new CultureInfo("es-ES", false);

            string idP = this.View.EdIDP.Text;
            string cccOri = this.View.EdCCCOri.Text;
            string cccDes = this.View.EdCCCDes.Text;
            double amount = Convert.ToDouble(this.View.EdImporte.Text);
            string date = this.View.EdFecha.Text;
            DateTime fDate = DateTime.ParseExact(date, "dd/MM/yyyy",provider);
            
            return new Prestamo(idP,cccOri,cccDes,amount,fDate);
        }
        
        public NewLoanView View { get; }
    }
}
