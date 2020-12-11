using System;
using System.Collections.Generic;
using System.Globalization;
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
            
<<<<<<< HEAD
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
=======
            return new Prestamo(idP,cccOri,cccDes,amount,fDate);
>>>>>>> parent of 2226138... Redefinidos y reimplementados Prestamos:
        }
        
        public NewLoanView View { get; }
    }
}
