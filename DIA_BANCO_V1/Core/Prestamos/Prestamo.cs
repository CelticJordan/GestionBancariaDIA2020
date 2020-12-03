using System;
using System.Globalization;
using System.Text;
using DIA_BANCO_V1.Cuentas;

namespace DIA_BANCO_V1.Core
{
    public class Prestamo
    {
        private string idP;
        private string cccOri;
        private string cccDes;
        private double importe;
        private DateTime fecha;
        
        public Prestamo(string id, string cc1, string cc2, double amount, string date)
        {
            var provider = new CultureInfo("es-ES", false);

            IdPrestamo = id;
            CccOri = cc1;
            CccDes = cc2;
            Importe = amount;
            Fecha = DateTime.ParseExact(date, "dd-MM-yyyy",provider);
        }

        public string IdPrestamo
        {
            get => idP;
            set => idP = value;
        }
        
        public string CccOri
        {
            get => cccOri;
            set => cccOri = value;
        }

        public string CccDes
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
            StringBuilder toret = new StringBuilder ();

            toret.AppendLine("\r\tId: " + this.IdPrestamo);
            toret.AppendLine("\r\tCCC Origen:: " + this.CccOri);
            toret.AppendLine("\r\tCCC Destino: " + this.CccDes);
            toret.AppendLine("\r\tImporte: " + this.Importe);
            toret.AppendLine("\r\tFecha: " + this.Fecha.Date);

            return toret.ToString();
        }
    }
}