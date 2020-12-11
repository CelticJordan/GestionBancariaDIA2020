using System;
using System.Text;

namespace DIA_BANCO_V1 {
    public class Prestamo {
        private string idP;
        private string tipo;
        private string cccOri;
        private double importe;
        private double cuota;
        private int numCuotas;
        private DateTime fecha;

        public Prestamo(string id, string type, string cc1, double amount, int nCuotas, DateTime date) {

            double interes;

            IdPrestamo = id;
            Tipo = type;
            CccOri = cc1;

            if (Tipo.Equals("Vivienda")) {
                interes = 1.05;
            } else interes = 1.08;

            Importe = (amount * interes);
            NumCuotas = nCuotas;
            Cuota = (Importe / NumCuotas);
            Fecha = date;
        }

        public Prestamo(string id, string type, string cc1, double amount, double quota, int nCuotas, DateTime date) {
            IdPrestamo = id;
            Tipo = type;
            CccOri = cc1;
            Importe = amount;
            Cuota = quota;
            NumCuotas = nCuotas;
            Cuota = (Importe / NumCuotas);
            Fecha = date;
        }

        public string IdPrestamo {
            get => idP;
            set => idP = value;
        }

        public string Tipo {
            get => tipo;
            set => tipo = value;
        }

        public string CccOri {
            get => cccOri;
            set => cccOri = value;
        }

        public double Importe {
            get => importe;
            set => importe = value;
        }

        public double Cuota {
            get => cuota;
            set => cuota = value;
        }

        public int NumCuotas {
            get => numCuotas;
            set => numCuotas = value;
        }

        public DateTime Fecha {
            get => fecha;
            set => fecha = value;
        }

        public override string ToString() {
            StringBuilder toret = new StringBuilder();

            toret.AppendLine("\r\tId: " + this.IdPrestamo);
            toret.AppendLine("\r\tTipo: " + this.Tipo);
            toret.AppendLine("\r\tCCC: " + this.CccOri);
            toret.AppendLine("\r\tImporte: " + this.Importe);
            toret.AppendLine("\r\tCuota: " + this.Cuota);
            toret.AppendLine("\r\tNumCuotas: " + this.NumCuotas);
            toret.AppendLine("\r\tFecha: " + this.Fecha.Date);

            return toret.ToString();
        }
    }
}