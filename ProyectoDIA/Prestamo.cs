using System;
using System.Text;

namespace ProyectoDIA
{
    public class Prestamo
    {
        public Prestamo(string id, string tipo, string ccc, string cccd, double importe, DateTime fecha)//double cuota,int numCuotas,
        {
            this.Id = id;
            this.Tipo = tipo;
            this.CCC = ccc;
            this.CCCD = cccd;
            this.Importe = importe;
            /*this.Cuota = cuota;
            this.NumCuotas = numCuotas;*/
            this.Fecha = fecha;
        }

        public string Id
        {
            get; set;
        }

        public string Tipo
        {
            get; set;
        }

        public string CCC
        {
            get; set;
        }

        public string CCCD
        {
            get; set;
        }
        public double Importe
        {
            get; set;
        }

        /*public double Cuota
        {
            get; set;
        }
        
        public int NumCuotas
        {
            get; set;
        }*/
        public DateTime Fecha
        {
            get; set;
        }
        
        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            toret.AppendLine("\r\tId: " + this.Id);
            toret.AppendLine("\r\tTipo: " + this.Tipo);
            toret.AppendLine("\r\tCCC: " + this.CCC);
            toret.AppendLine("\r\tCCC: " + this.CCCD);
            toret.AppendLine("\r\tImporte: " + this.Importe);
            /*toret.AppendLine("\r\tCuota: " + this.Cuota);
            toret.AppendLine("\r\tNumCuotas: " + this.NumCuotas);*/
            toret.AppendLine("\r\tFecha: " + this.Fecha);
            return toret.ToString();
        }
    }
}