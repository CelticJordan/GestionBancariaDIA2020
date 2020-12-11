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
            catch (PrestamoException)
            {
                WForms.MessageBox.Show("Numero de Cuotas no valido");
            }
        }
        
        public Prestamo GetLoan()
        {
            var provider = new CultureInfo("es-ES", false);
            
            string idP = this.View.EdIDP.Text;
            string type = this.View.EdTipo.Text;
            string cccOri = this.View.EdCCCOri.Text;
            double amount = Convert.ToDouble(this.View.EdImporte.Text);
            int numCuotas = Convert.ToInt32(this.View.EdNumCuotas.Text);
            
            if(type.Equals("Consumo") && (numCuotas<12 || 120<numCuotas))
            {
                throw new PrestamoException("Num Cuotas no valido");
            }
            else if (type.Equals("Vivienda") && (numCuotas < 12 || 360 < numCuotas))
            {
                throw new PrestamoException("Num Cuotas no valido");
            }
            
            string date = this.View.EdFecha.Text;
            DateTime fDate = DateTime.ParseExact(date, "dd/MM/yyyy",provider);

            return new Prestamo(idP,type,cccOri,amount,numCuotas,fDate.Date);
        }
        
        public EditLoanView View { get; }
    }
}
