using System;
using System.Collections.Generic;
using Clientes.Core;

namespace DIA_BANCO_V1
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
            public override string ToString()
            {
                StringBuilder toret = new StringBuilder();
                toret.AppendLine("\r\tConcepto: " + this.Concepto);
                toret.AppendLine("\r\tFecha: " + this.Fecha);
                toret.AppendLine("\r\tCantidad: " + this.Cantidad);
                return toret.ToString();
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
            public override string ToString()
            {
                StringBuilder toret = new StringBuilder();
                toret.AppendLine("\r\tConcepto: " + this.Concepto);
                toret.AppendLine("\r\tFecha: " + this.Fecha);
                toret.AppendLine("\r\tCantidad: " + this.Cantidad);
                return toret.ToString();
            }
        }
        public string CCC { get; set; }
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
        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            toret.AppendLine("\r\tCCC: " + this.CCC);
            toret.AppendLine("\r\tTipo: " + this.Tipo);
            toret.AppendLine("\r\tSaldo: " + this.Saldo);
            for (int i = 0; i < this.Titulares.Count; i++)
            {
                toret.AppendLine("\r\tTitulares: " + this.Titulares[i].Nombre.ToString()); 
            }
            toret.AppendLine("\r\tFecha Apertural: " + this.FechaApertura);
            toret.AppendLine("\r\tInteres: " + this.Interes);
            return toret.ToString();
        }
    }
}