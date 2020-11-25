using System;
using System.Globalization;

namespace ProyectoDIAIndep.Core
{
    public class Prestamo
    {
        private string idP;
        private CuentaCorriente cccOri;
        private CuentaCorriente cccDes;
        private double importe;
        private DateTime fecha;
        
        public Prestamo(string id, string cc1, string cc2, double amount, string date)
        {
            var provider = new CultureInfo("es-ES", false);

            IdPrestamo = id;
            CccOri = new CuentaCorriente(cc1);
            CccDes = new CuentaCorriente(cc2);
            Importe = amount;
            Fecha = DateTime.ParseExact(date, "dd-MM-yyyy",provider);
        }

        public string IdPrestamo
        {
            get => idP;
            set => idP = value;
        }
        
        public CuentaCorriente CccOri
        {
            get => cccOri;
            set => cccOri = value;
        }

        public CuentaCorriente CccDes
        {
            get => cccDes;
            set => cccDes = value;
        }

        public double Importe
        {
            get => importe;
            set => importe = value;
        }

        public DateTime Fecha
        {
            get => fecha;
            set => fecha = value;
        }

        public override string ToString()
        {
            return String.Format("Préstamo desde CC: {0} a CC: {1} con importe de {2} Euros, realizado el dia {3}.", CccOri, CccDes, Importe, Fecha.Date);
        }
    }
}