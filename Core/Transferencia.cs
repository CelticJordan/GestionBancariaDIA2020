using System;


namespace Transferencias.Core
{
    public class Transferencia
    {

        public Transferencia()
        {
            
        }
        
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
        public Transferencia(int id,string tipo, string CCC_origen, string CCC_destino, double importe, string fecha)
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
            return "Id: " + this.Id + "\n" + "Tipo: " + this.Tipo +
                   "\n" + "CCC Origen: " + this.CCCOrigen + "\n" + "CCC Destino: " + this.CCCDestino + "\n" +
                   "Importe: " + this.Importe + "\n" + "Fecha: " + this.Fecha + "\n";
        }

        

        public int Id { get ; set; }
        public string Tipo { get ;  set; }
        public string CCCOrigen { get ;  set; }
        public string CCCDestino { get ;set; }
        public double Importe { get ;  set; }
        public string Fecha { get ;  set;}
        

    }
}