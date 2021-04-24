
using System;
using System.Collections.Generic;

namespace DIA_BANCO_V1
{
    public class CuentaAhorro : Cuenta
    {
        public CuentaAhorro(string ccc, Cliente cliente) : 
            base(ccc, cliente)
        {
            base.Tipo = "Ahorro";
            base.InteresMensual = 0.1d;
        }
        
        //Constructor para xml
        public CuentaAhorro(string ccc, string tipo, double saldo,  DateTime fechaApertura, List<Cliente> titulares, List<Deposito> depositos, List<Retirada> retiradas) :
            base(ccc, tipo, saldo, fechaApertura, titulares, depositos, retiradas)
        {
            base.Tipo = "Ahorro";
            base.InteresMensual = 0.1d;
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
    }
}