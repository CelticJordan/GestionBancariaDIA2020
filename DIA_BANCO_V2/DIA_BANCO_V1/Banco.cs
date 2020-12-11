using System;
using System.Collections.Generic;

namespace DIA_BANCO_V1
{
    public static class Banco
    {
        
        /// <summary>
        /// comprueba que el cliente con el dni pasado existe
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="clientes"></param>
        /// <returns></returns>
        public static bool existeCliente(string dni, List<Cliente> clientes)
        {
            if (clientes != null)
            {
                foreach (Cliente cli in clientes)
                {
                    if (dni.Equals(cli.Dni)) return true;
                }
            }

            return false;
        }
     
        /// <summary>
        /// Retorna true si el ccc pasado ya existe
        /// </summary>
        /// <param name="ccc"></param>
        /// <returns></returns>
        public static bool existeCCC(string ccc, List<Cuenta> cuentas)
        {
            if (cuentas != null)
            {
                foreach (Cuenta c in cuentas)
                {
                    if (c.CCC.Equals(ccc)) return true;
                }
            }

            return false;
        }
        
        //Devuelve la cuenta que coincida con el ccc pasado
        public static Cuenta getCuenta(string ccc, List<Cuenta> cuentas)
        {
            if (cuentas != null)
            {
                foreach (Cuenta c in cuentas)
                {
                    if (c.CCC.Equals(ccc)) return c;
                }
            }

            return null;
        }
        
        //Devuelve el cliente que coincida con el dni pasado
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
        
        /// <summary>
        /// Borra el deposito de una cuenta
        /// </summary>
        /// <param name="cuen"></param>
        /// <param name="dep"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Inserta un deposito en la cuenta
        /// </summary>
        /// <param name="cuen"></param>
        /// <param name="dep"></param>
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
            CuentaCorriente cc;
            
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

        public static List<Transferencia> getTransferenciasCuenta(string ccc, List<Transferencia> todasTransferencias)
        {
            if (todasTransferencias != null)
            {
                List<Transferencia> transferenciasCuenta = new List<Transferencia>();
                foreach (Transferencia t in todasTransferencias)
                {
                    if (ccc.Equals(t.CCCOrigen))
                    {
                        transferenciasCuenta.Add(t);
                    }
                }
                return transferenciasCuenta;
            }
            else
            {
                return null;
            }
        }
        
        public static List<Prestamo> getPrestamosCuenta(string ccc, List<Prestamo> todosPrestamos)
        {
            if (todosPrestamos != null)
            {
                List<Prestamo> prestamosCuenta = new List<Prestamo>();
                foreach (Prestamo p in todosPrestamos)
                {
                    if (ccc.Equals(p.CccOri))
                    {
                        prestamosCuenta.Add(p);
                    }
                }
                return prestamosCuenta;
            }
            else
            {
                return null;
            }
        }
        
        public static bool borrarTransferencia(int id, List<Transferencia> transferencias)
        {
            foreach (Transferencia t in transferencias)
            {
                if (id.Equals(t.Id))
                {
                    transferencias.Remove(t);
                    return true;
                }
            }

            return false;
        }
        
        public static bool borrarPrestamo(string id, List<Prestamo> prestamos)
        {
            foreach (Prestamo p in prestamos)
            {
                if (id.Equals(p.IdPrestamo))
                {
                    prestamos.Remove(p);
                    return true;
                }
            }

            return false;
        }

        public static bool BorrarDniDeCuenta(string dni, Cuenta cuenta)
        {
            List<Cliente> titulares = cuenta.Titulares;
            foreach (Cliente c in titulares)
            {
                if (dni.Equals(c.Dni))
                {
                    cuenta.Titulares.Remove(c);
                    return true;
                }
            }

            return false;
        }

        public static bool transferencia_sum_rest(Cuenta origen, Cuenta destino, double importe)
        {
            if (origen.Saldo > importe)
            {
                origen.Saldo = origen.Saldo - importe;
                destino.Saldo = destino.Saldo + importe;
                return true;
            }
            else
            {
                return false;
            }
            
            
        }
    }
}