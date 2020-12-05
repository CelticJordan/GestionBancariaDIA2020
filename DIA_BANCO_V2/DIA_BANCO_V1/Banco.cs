using System.Collections.Generic;
using Clientes.Core;

namespace DIA_BANCO_V1
{
    public static class Banco
    {
        public static bool existeCliente(string dni, List<Cliente> clientes)
        {
            foreach (Cliente cli in clientes)
            {
                if (dni.Equals(cli.Dni)) return true;
            }

            return false;
        }
     
        /// <summary>
        /// Retorna true siel ccc pasado ya existe
        /// </summary>
        /// <param name="ccc"></param>
        /// <returns></returns>
        public static bool existeCCC(string ccc, List<Cuenta> cuentas)
        {
            foreach (Cuenta c in cuentas)
            {
                if (c.CCC.Equals(ccc)) return true;
            }

            return false;
        }
        
        public static Cuenta getCuenta(string ccc, List<Cuenta> cuentas)
        {
            foreach (Cuenta c in cuentas)
            {
                if (c.CCC.Equals(ccc)) return c;
            }

            return null;
        }
        
        
        public static Cliente getCliente(string dni, List<Cliente> clientes)
        {
            foreach (Cliente c in clientes)
            {
                if (c.Dni.Equals(dni))
                    return c;
            }

            return null;
        }
        
        /// <summary>
        /// Devuelve true si la cuenta pasada contiene el cliente pasado
        /// </summary>
        /// <param name="cuenta"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static bool CuentaContieneTitular(Cuenta cuenta, string dnicliente)
        {
            foreach (Cliente cli in cuenta.Titulares)
            {
                if (cli.Dni.Contains(dnicliente))
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool borrarDepositoCuenta(Cuenta cuen, Cuenta.Deposito dep)
        {
            CuentaAhorro ch;
            CuentaCorriente cc;
            CuentaVivienda cv;
            
            if (cuen is CuentaAhorro)
            {
                ch = (CuentaAhorro) cuen;
                if(ch.DeleteDeposito(dep)) return true;
            }
            else
            if(cuen is CuentaCorriente){
                cc = (CuentaCorriente) cuen;
                if(cc.DeleteDeposito(dep)) return true;
            }else if (cuen is CuentaVivienda)
            {
                cv = (CuentaVivienda) cuen;
                if(cv.DeleteDeposito(dep)) return true;
            }

            //Confiamos en que devuelva algun true de los de arriba,
            //confiamos.
            return false;
        }
        
        public static void insertarDepositoCuenta(Cuenta cuen, Cuenta.Deposito dep)
        {
            CuentaAhorro ch;
            CuentaCorriente cc;
            CuentaVivienda cv;
            
            if (cuen is CuentaAhorro)
            {
                ch = (CuentaAhorro) cuen;
                ch.AddDeposito(dep);
            }
            else
            if(cuen is CuentaCorriente){
                cc = (CuentaCorriente) cuen;
                cc.AddDeposito(dep);
            }else if (cuen is CuentaVivienda)
            {
                cv = (CuentaVivienda) cuen;
                cv.AddDeposito(dep);
            }
        }
        
        public static bool borrarRetiradaCuenta(Cuenta cuen, Cuenta.Retirada ret)
        {
            CuentaAhorro ch;
            CuentaCorriente cc;
            CuentaVivienda cv;
            
            if(cuen is CuentaCorriente){
                cc = (CuentaCorriente) cuen;
                if(cc.DeleteRetirada(ret)) return true;
            }
            
            return false;
        }
        public static void insertarRetiradaCuenta(Cuenta cuen, Cuenta.Retirada ret)
        {
            CuentaCorriente cc;
            if(cuen is CuentaCorriente){
                cc = (CuentaCorriente) cuen;
                cc.AddRetirada(ret);
            }
        }
    }
}