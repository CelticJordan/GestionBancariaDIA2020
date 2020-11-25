using System;
using System.Collections.Generic;

namespace DIA_P2_banco.Cuentas
{
    public abstract class Cuenta {
        public class Deposito {
            public string Concepto;
            public DateTime DateTime;
            public float Cantidad;

            public Deposito(string concepto, float cantidad){
                this.Concepto = concepto;
                this.Cantidad = cantidad;
                this.DateTime = DateTime.UtcNow;
            }
        }
        public class Retirada {
            public string Concepto;
            public DateTime DateTime;
            public float Cantidad;

            public Retirada(string concepto, float cantidad) {
                this.Concepto = concepto;
                this.Cantidad = cantidad;
                this.DateTime = DateTime.UtcNow;
            }
        }
        public string CCC { get; private set; }
        public string Tipo { get; protected set; }
        public float Saldo { get; set; }
        public List<Cliente> Titulares;
        public DateTime FechaApertura { get; private set; }
        public float InteresMensual { get; set; }
        public List<Deposito> Depositos;
        public List<Retirada> Retiradas;
        public List<Transferencia> transferencias;

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