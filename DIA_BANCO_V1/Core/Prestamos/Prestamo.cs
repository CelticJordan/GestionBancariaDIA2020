using System;
using System.Globalization;
using System.Text;
using DIA_BANCO_V1;

namespace DIA_BANCO_V1
{
    public class Prestamo
    {
        private string idP;
        private string cccOri;
        private double importe;
        private DateTime fecha;
        
<<<<<<< HEAD
        public Prestamo(string id, string type, string cc1, double amount, int nCuotas, DateTime date)  {

          double interes;
            
          IdPrestamo = id;
          Tipo = type;
          CccOri = cc1;

          if (Tipo.Equals("Vivienda"))
          {
              interes = 1.05;
          }
          else interes = 1.08;
            
          Importe = (amount * interes);
          NumCuotas = nCuotas;
          Cuota = (Importe / NumCuotas);
          Fecha = date;
        }

        public Prestamo(string id, string type, string cc1, double amount,double quota, int nCuotas, DateTime date)
        {
=======
      /*  public Prestamo(string id, string cc1, string cc2, double amount, string date)
        {
            date = date.Replace(" 0:00:00", "");
            date = date.Replace("/", "-");
            var provider = new CultureInfo("es-ES", false);

            IdPrestamo = id;
            CccOri = cc1;
            CccDes = cc2;
            Importe = amount;
            Fecha = DateTime.ParseExact(date, "dd/MM/yyyy",provider);
        }*/
        
        public Prestamo(string id, string cc1, string cc2, double amount, DateTime date)  {

>>>>>>> parent of 2226138... Redefinidos y reimplementados Prestamos:
            IdPrestamo = id;
            CccOri = cc1;
            Importe = amount;
            Fecha = date;
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
<<<<<<< HEAD
            toret.AppendLine("\r\tTipo: " + this.Tipo);
            toret.AppendLine("\r\tCCC: " + this.CccOri);
=======
            toret.AppendLine("\r\tCCC Origen:: " + this.CccOri);
            toret.AppendLine("\r\tCCC Destino: " + this.CccDes);
>>>>>>> parent of 2226138... Redefinidos y reimplementados Prestamos:
            toret.AppendLine("\r\tImporte: " + this.Importe);
            toret.AppendLine("\r\tFecha: " + this.Fecha.Date);

            return toret.ToString();
        }
    }
}
