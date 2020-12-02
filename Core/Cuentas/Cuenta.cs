using System;
using System.Collections.Generic;

namespace DIA_P2_banco.Cuentas
{
    public abstract class Cuenta {
        public class Deposito {
            public string Concepto;
            public DateTime DateTime;
            public double Cantidad;

            public Deposito(string concepto, DateTime dt, double cantidad){
                this.Concepto = concepto;
                this.Cantidad = cantidad;
                this.DateTime = dt;
            }
        }
        public class Retirada {
            public string Concepto;
            public DateTime DateTime;
            public double Cantidad;

            public Retirada(string concepto, DateTime dt, double cantidad) {
                this.Concepto = concepto;
                this.Cantidad = cantidad;
                this.DateTime = dt;
            }
        }
        public string CCC { get; private set; }
        public string Tipo { get; protected set; }
        public double Saldo { get; set; }
        public List<Cliente> Titulares;
        public DateTime FechaApertura { get; private set; }
        public double InteresMensual { get; set; }
        public List<Deposito> Depositos { get; private set; }
        public List<Retirada> Retiradas { get; private set; }



        protected Cuenta(string ccc, Cliente cliente)
        {
            this.CCC = ccc;
            this.Titulares = new List<Cliente>();
            this.Titulares.Add(cliente);
            this.FechaApertura = DateTime.UtcNow;
            this.Depositos = new List<Deposito>();
            this.Retiradas = new List<Retirada>();
        }
    }
}