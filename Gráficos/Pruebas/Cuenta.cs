using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gráficos.Pruebas
{/// <summary>
/// Clase de prueba de Cuenta solo cogemos los datos que nos interesan de cuenta
/// </summary>
    class Cuenta
    {
        public Cuenta(String ccc,double saldo,IEnumerable<Cliente> titulares,DateTime fecha,IEnumerable<Deposito> depositos, IEnumerable<Retirada> retiradas)
        {
            this.CCC = ccc;
            this.Saldo = saldo;
            this.Titulares = titulares;
            this.Fecha = fecha;
            this.Depositos = depositos;
            this.Retiradas = retiradas;
        }

        public string CCC {
            get; 
            private set; 
        }
        public double Saldo {
            get;
            private set;
        }
        public IEnumerable<Cliente> Titulares {
            get;
            private set;
        }
        public DateTime Fecha {
            get;
            private set;
        }
        public IEnumerable<Deposito> Depositos {
            get;
            private set;
        }
        public IEnumerable<Retirada> Retiradas {
            get;
            private set;
        }
    }
}
