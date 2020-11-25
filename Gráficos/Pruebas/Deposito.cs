using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gráficos.Pruebas
{
    /// <summary>
    /// Clase de prueba de Deposito solo cogemos los datos que nos interesan 
    /// </summary>
    class Deposito
    {
        public Deposito(double cantidad,DateTime fecha)
        {
            this.Cantidad = cantidad;
            this.Fecha = fecha;
        }

        public double Cantidad {
            get;
            set;
        }
        public DateTime Fecha {
            get;
            set;
        }
    }
}
