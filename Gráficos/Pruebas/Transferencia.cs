using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gráficos.Pruebas
{
    /// <summary>
    /// Clase de prueba de Transferencia cogemos solo los datos que nos interesan
    /// </summary>
    class Transferencia
    {
        public Transferencia(string id,Cuenta origen,Cuenta destino,double importe,DateTime fecha)
        {
            this.ID = id;
            this.Origen = origen;
            this.Destino = destino;
            this.Importe = importe;
            this.Fecha = fecha;

        }

        public string ID {
            get;
            private set;
        }
        public Cuenta Origen { 
            get;
            private set;
        }
        public Cuenta Destino {
            get;
            private set;

        }
        public double Importe {
            get;
            set;
        }
        public DateTime Fecha {
            get;
            private set;
        }
    }
}
