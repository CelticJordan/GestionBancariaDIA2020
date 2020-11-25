using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gráficos.Pruebas
/// <summary>
/// Clase de prueba de retirada solo cogemos los datos que nos interesan 
/// </summary>
{
    class Retirada
    {
        public Retirada(double cantidad, DateTime fecha)
        {
            this.Cantidad = cantidad;
            this.Fecha = fecha;
        }

        public double Cantidad
        {
            get;
            private set;
        }
        public DateTime Fecha
        {
            get;
            private set;
        }
    }
}
