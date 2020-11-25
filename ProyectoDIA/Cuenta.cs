using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoDIA
{
    public class Cuenta
    {
        public class Deposito
        {
            public Deposito(string concepto, DateTime fecha, double cantidad)
            {
                this.Concepto = concepto;
                this.Fecha = fecha;
                this.Cantidad = cantidad;
            }

            public string Concepto
            {
                get; set;
            }
            public DateTime Fecha{
                get; set;
            }
            public double Cantidad{
                get; set;
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
        public class Retirada
        {
            public Retirada(string concepto, DateTime fecha, double cantidad)
            {
                this.Concepto = concepto;
                this.Fecha = fecha;
                this.Cantidad = cantidad;
            }

            public string Concepto
            {
                get; set;
            }
            public DateTime Fecha{
                get; set;
            }
            public double Cantidad{
                get; set;
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
        public Cuenta(string ccc, string tipo, double saldo, List<Cliente> titulares, DateTime fechaApertura,double interes,List<Deposito> depositos,List<Retirada> retiradas)
        {
            this.CCC = ccc;
            this.Tipo = tipo;
            this.Saldo = saldo;
            this.Titulares = titulares;
            this.FechaApertura = fechaApertura;
            this.Interes = interes;
            this.Depositos = depositos;
            this.Retiradas = retiradas;
        }

        public string CCC
        {
            get; set;
        }

        public string Tipo
        {
            get; set;
        }

        public double Saldo
        {
            get; set;
        }

        public List<Cliente> Titulares
        {
            get; set;
        }

        public DateTime FechaApertura
        {
            get; set;
        }
        
        public double Interes
        {
            get; set;
        }
        public List<Deposito> Depositos
        {
            get; set;
        }
        public List<Retirada> Retiradas
        {
            get; set;
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