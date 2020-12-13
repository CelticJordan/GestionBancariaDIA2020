using System;
using System.Collections.Generic;
using System.Globalization;

namespace DIA_BANCO_V1 {
    using WForms = System.Windows.Forms;

    public class NewLoanCtrl {
        public List<Cuenta> cuentas;
        
        public List<Prestamo> prestamos = new List<Prestamo>();
        public NewLoanCtrl(List<Prestamo> prestamos, List<Cuenta> cuentas) {
            this.prestamos = prestamos;
            this.cuentas = cuentas;
            this.View = new NewLoanView();

            this.View.BtCrear.Click += (sender, args) => this.onBtCreaClick();
        }

        public void onBtCreaClick() {
            try
            {
                Prestamo p = GetLoan();
                if (Banco.prestamo_sum(p, this.cuentas))
                {
                    this.prestamos.Add(p);
                    WForms.MessageBox.Show("Prestamo creado");
                    this.View.Hide();
                    this.View.Close();
                }
                    
            } catch (ArgumentException) {
                WForms.MessageBox.Show("Ya existe un Prestamo con ese ID");
            } catch (PrestamoException) {
                WForms.MessageBox.Show("Numero de Cuotas no valido");
            }
        }

        public Prestamo GetLoan() {
            var provider = new CultureInfo("es-ES", false);

            string idP = this.View.EdIDP.Text;
            string type = this.View.EdTipo.Text;
            string cccOri = this.View.EdCCCOri.Text;
            double amount = Convert.ToDouble(this.View.EdImporte.Text);
            int numCuotas = Convert.ToInt32(this.View.EdNumCuotas.Text);

            if (type.Equals("Consumo") && (numCuotas < 12 || 120 < numCuotas)) {
                throw new PrestamoException("Num Cuotas no valido");
            } else if (type.Equals("Vivienda") && (numCuotas < 12 || 360 < numCuotas)) {
                throw new PrestamoException("Num Cuotas no valido");
            }

            string date = this.View.EdFecha.Text;
            DateTime fDate = DateTime.ParseExact(date, "dd/MM/yyyy", provider);

            return new Prestamo(idP, type, cccOri, amount, numCuotas, fDate.Date);
        }

        public NewLoanView View { get; }
    }
}
