using System;
using System.Collections.Generic;

namespace DIA_BANCO_V1
{
    public class CuentaVivienda : Cuenta
    {
        public CuentaVivienda(string ccc, Cliente cliente) : 
            base(ccc, cliente)
        {
            base.Tipo = "Vivienda";
            base.InteresMensual = 0.3;
        }
        
        //Constructor para xml
        public CuentaVivienda(string ccc, string tipo, double saldo,  DateTime fechaApertura, List<Cliente> titulares, List<Deposito> depositos, List<Retirada> retiradas) :
            base(ccc, tipo, saldo, fechaApertura, titulares, depositos, retiradas)
        {
            base.Tipo = "Vivienda";
            base.InteresMensual = 0.3;
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