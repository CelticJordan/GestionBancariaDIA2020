using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
        /// <summary>
        /// Selecciona una retirada y la elimina de la cuenta que se le pase
        /// </summary>
        /// <param name="cuen"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        public static bool borrarRetiradaCuenta(Cuenta cuen, Cuenta.Retirada ret)
        {
            CuentaCorriente cc;
            
            if(cuen is CuentaCorriente){
                cc = (CuentaCorriente) cuen;
                if(cc.DeleteRetirada(ret)) return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Selecciona yna retirada y la añade en la cuenta que se le pase
        /// </summary>
        /// <param name="cuen"></param>
        /// <param name="ret"></param>
        public static void insertarRetiradaCuenta(Cuenta cuen, Cuenta.Retirada ret)
        {
            CuentaCorriente cc;
            if(cuen is CuentaCorriente){
                cc = (CuentaCorriente) cuen;
                cc.AddRetirada(ret);
            }
        }

        /// <summary>
        /// Devuelve una lista de transferenicas de una cuenta a raiz del ccc
        /// </summary>
        /// <param name="ccc"></param>
        /// <param name="todasTransferencias"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Devuelve una lista de prestamos de una cuenta a raiz del ccc
        /// </summary>
        /// <param name="ccc"></param>
        /// <param name="todosPrestamos"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Se borra y se añade o retira el dinero de esa transferencia de las respectivas cuentas
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transferencias"></param>
        /// <param name="cuentas"></param>
        /// <returns></returns>
        public static bool borrarTransferencia(int id, List<Transferencia> transferencias , List<Cuenta> cuentas)
        {
            foreach (Transferencia t in transferencias)
            {
                if (id.Equals(t.Id))
                {
                    //Devuelvo el dinero
                    Cuenta a = getCuenta(t.CCCOrigen, cuentas);
                    Cuenta b = getCuenta(t.CCCDestino, cuentas);
                    a.Saldo = a.Saldo + t.Importe;
                    b.Saldo = b.Saldo - t.Importe;
                    //Borro la cuenta
                    transferencias.Remove(t);
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Se borra y se añade o retira el dinero de ese prestamo de las respectivas cuentas
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prestamos"></param>
        /// <param name="cuentas"></param>
        /// <returns></returns>
        public static bool borrarPrestamo(string id, List<Prestamo> prestamos ,List<Cuenta> cuentas)
        {
            foreach (Prestamo p in prestamos)
            {
                if (id.Equals(p.IdPrestamo))
                {
                    Cuenta a = getCuenta(p.CccOri, cuentas);
                    
                    if (p.Tipo.Equals("Consumo"))
                    {
                        a.Saldo = a.Saldo -  p.Importe/1.08;
                    }
            
                    if (p.Tipo.Equals("Vivienda"))
                    {
                        a.Saldo = a.Saldo -  p.Importe/1.05;
                    }

                    prestamos.Remove(p);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Borrar un dni de una cuenta
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="cuenta"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Añade el importe de la transferencia a la cuenta destino y retira el dinero de la cuenta de origen
        /// </summary>
        /// <param name="t"></param>
        /// <param name="cuentas"></param>
        /// <returns></returns>
        public static bool transferencia_sum_rest(Transferencia t,List<Cuenta> cuentas)
        {
            Cuenta origen = Banco.getCuenta(t.CCCOrigen, cuentas);
            Cuenta destino =  Banco.getCuenta(t.CCCDestino, cuentas);

            if (origen.Saldo > t.Importe)
            {
                origen.Saldo = origen.Saldo -  t.Importe;
                destino.Saldo = destino.Saldo +  t.Importe;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Añade el importe del prestamo a la cuenta
        /// </summary>
        /// <param name="p"></param>
        /// <param name="cuentas"></param>
        /// <returns></returns>
        public static bool prestamo_sum(Prestamo p,List<Cuenta> cuentas)
        {
            Cuenta origen = Banco.getCuenta(p.CccOri, cuentas);

            if (p.Tipo.Equals("Consumo"))
            {
                origen.Saldo = origen.Saldo +  p.Importe/1.08;
                return true;
            }
            
            if (p.Tipo.Equals("Vivienda"))
            {
                origen.Saldo = origen.Saldo +  p.Importe/1.05;
                return true;
            }
            return false;
        }
        
    }
}