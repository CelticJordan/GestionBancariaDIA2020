using System;
using System.Collections.Generic;

namespace DIA_BANCO_V1
{
    public class CuentaCorriente : Cuenta
    {
        public CuentaCorriente(string ccc, Cliente cliente) : 
            base(ccc, cliente)
        {
            base.Tipo = "Corriente";
            base.InteresMensual = 0.0;
        }
        
        //Constructor para xml
        public CuentaCorriente(string ccc, string tipo, double saldo,  DateTime fechaApertura, List<Cliente> titulares, List<Deposito> depositos, List<Retirada> retiradas) :
            base(ccc, tipo, saldo, fechaApertura, titulares, depositos, retiradas)
        {
            base.Tipo = "Corriente";
            base.InteresMensual = 0.0;
        }

        public void AddDeposito(Deposito deposito)
        {
            base.Saldo += deposito.Cantidad;
            this.Depositos.Add(deposito);
        }
        
        public bool DeleteDeposito(Deposito deposito)
        {
            base.Saldo -= deposito.Cantidad;
            if (this.Depositos.Remove(deposito)) return true;
            else return false;
        }

        public void AddRetirada(Retirada retirada)
        {
            base.Saldo -= retirada.Cantidad;
            this.Retiradas.Add(retirada);
        }

        public bool DeleteRetirada(Retirada retirada)
        {
            base.Saldo += retirada.Cantidad;
            if (this.Retiradas.Remove(retirada)) return true;
            else return false;
        }
    }
}