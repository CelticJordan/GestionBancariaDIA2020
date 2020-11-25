using System;
using System.Text;

namespace ProyectoDIA
{
    public class Transferencia
    {
        public Transferencia(string id, string tipo, string ccco, string cccd, double importe,DateTime fecha)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.CCCO = ccco;
            this.CCCD = cccd;
            this.Importe = importe;
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
        
        public string CCCO
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
                
        public DateTime Fecha
        {
            get; set;
        }
        
        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            toret.AppendLine("\r\tId: " + this.Id);
            toret.AppendLine("\r\tTipo: " + this.Tipo);
            toret.AppendLine("\r\tCCC Origen: " + this.CCCO);
            toret.AppendLine("\r\tCCC Destino: " + this.CCCD);
            toret.AppendLine("\r\tImporte: " + this.Importe);
            toret.AppendLine("\r\tFecha: " + this.Fecha);
            return toret.ToString();
                    
        }
            
    }
}