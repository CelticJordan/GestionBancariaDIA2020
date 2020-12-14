using System;
using System.Text;


namespace DIA_BANCO_V1
{
    public class Transferencia
    {
        
        /// <summary>
        /// Constructor de la clase Transferencia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <param name="CCC_origen"></param>
        /// <param name="CCC_destino"></param>
        /// <param name="importe"></param>
        /// <param name="fecha"></param>
        /// <exception cref="Exception"></exception>
        public Transferencia(int id,string tipo, string CCC_origen, string CCC_destino, double importe, DateTime fecha)
        {
            Id = id;
            // Puntual / Periodica
            Tipo = tipo;
            CCCOrigen = CCC_origen;
            CCCDestino = CCC_destino;
            Importe = importe;
            this.Fecha = fecha;
        }
        

        /// <summary>
        /// Conversor a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder toret = new StringBuilder ();
            
            toret.AppendLine("\r\tId: "+this.Id);
            toret.AppendLine("\r\tTipo: "+this.Tipo);
            toret.AppendLine("\r\tCCC Origen:: " + this.CCCOrigen);
            toret.AppendLine("\r\tCCC Destino: " + this.CCCDestino);
            toret.AppendLine("\r\tImporte: " + this.Importe);
            toret.AppendLine("\r\tFecha: " + this.Fecha);

            return toret.ToString();
        }

        

        public int Id { get ; set; }
        public string Tipo { get ;  set; }
        public string CCCOrigen { get ;  set; }
        public string CCCDestino { get ;set; }
        public double Importe { get ;  set; }
        public DateTime Fecha { get ;  set;}

        
    }

    /// <summary>
    /// Constructor para trasnferencias periodicas
    /// </summary>
    public class Transferencia_Periodica : Transferencia
    {
        //Para transferencias periodicas
        public Transferencia_Periodica(int id,string tipo, string CCC_origen, string CCC_destino, double importe, DateTime fecha,DateTime siguiente_fecha):base(id,tipo,CCC_origen,CCC_destino,importe,fecha)
        {
            Id = id;
            // Puntual / Periodica
            Tipo = tipo;
            CCCOrigen = CCC_origen;
            CCCDestino = CCC_destino;
            Importe = importe;
            this.Fecha = fecha;
            this.Fecha_Siguiente = siguiente_fecha;
        }
        
        public DateTime Fecha_Siguiente {
            get;
            set;
        }
        
        public override string ToString() {
            return "Transferencia:\n" + base.ToString() + "\nFecha_Siguiente: " + Fecha_Siguiente;
        }
        
    }
    
}