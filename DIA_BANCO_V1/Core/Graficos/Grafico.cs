using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using DIA_BANCO_V1;

namespace DIA_BANCO_V1
{
    class Grafico
    {
        public Grafico()
        {

        }
        /// <summary>
        /// Esta funcion se encarga de ordenar las cantidades de depositos y trasnferencias(ingresos generales) por su fecha,ordena de menor a mayor(todas las trasnferencias que se haya echo a lo largo del tiempo)
        /// </summary>
        /// <param name="cuentas"></param>
        /// <param name="transferencias"></param>
        /// <returns>Devuelve una lista con los ingresos ordenados</returns>
        public int[] ordenarDatosIngresosGeneral(IEnumerable<Cuenta> cuentas, IEnumerable<Transferencia> transferencias)
        {
            //cogemos los depositos
            var depositos_cuentas = from cuenta in cuentas select cuenta.Depositos;
            //juntamos todos los objetos deposito, que en cuenta son IEnumerables
            List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
            foreach (IEnumerable<Cuenta.Deposito> d in depositos_cuentas)
            {
               foreach(Cuenta.Deposito p in d)
                {
                    depositos.Add(p);
                }
            }
          
            //vamos juntar los depositos que tiene la misma fecha
            var dep = from deposito in depositos select (deposito.DateTime, deposito.Cantidad);
            var fechas_transferencias = from transferencia in transferencias select (transferencia.Fecha, transferencia.Importe);
            var lista_dep = dep.ToList();
            var lista_transferencias = fechas_transferencias.ToList();
            lista_dep.AddRange(lista_transferencias);
            var total = lista_dep.OrderBy(fecha => fecha.DateTime.Date);//ordenamos los datos 
            //ahora sumaremos las cantidades de los depositos y trasnferencias que se hicieron en la misma fecha y se eliminaran los elementos comunes
            var lista_total = total.ToList();
            for (int i = 0; i < lista_total.Count(); i++)
            {
                for (int j = i + 1; j < lista_total.Count(); j++)
                {
                    if (lista_total[i].DateTime.ToString() == lista_total[j].DateTime.ToString())
                    {
                        //creamos el item nuevo con la fecha y la suma de las cantidades
                        var cantidad = lista_total[i].Item2 + lista_total[j].Item2;
                        var fecha = lista_total[i].DateTime;
                        var item = (fecha, cantidad);
                        //eliminamos los items antiguos y añadimos uno nuevo actualizado
                        lista_total.RemoveAt(j);
                        lista_total.RemoveAt(i);
                        lista_total.Insert(i, item);

                    }
                }
            }
            var importes_ordenados = from importe in lista_total select importe.Item2;
            List<int> lista_final = new List<int>();
            //aproximamos los importes
            foreach (double importe in importes_ordenados)
            {
                int elem = Convert.ToInt32(importe);
                lista_final.Add(elem);
            }
            lista_final.Insert(0, 0);
            return lista_final.ToArray();
        }
        /// <summary>
        /// Este metodo nos permitira tener el umbral de años de las transferencias y depositos que hubo a lo largo del tiempo
        /// </summary>
        /// <param name="cuentas"></param>
        /// <param name="transferencias"></param>
        /// <returns>Devolvemos el intervalo de años general</returns>
        public String[] ordenarAñosIngresoGeneral(IEnumerable<Cuenta> cuentas, IEnumerable<Transferencia> transferencias)
        {
            //cogemos los depositos
            var depositos_cuentas = from cuenta in cuentas select cuenta.Depositos;
            //juntamos todos los objetos deposito, que en cuenta son IEnumerables
            List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
            foreach (IEnumerable<Cuenta.Deposito> d in depositos_cuentas)
            {
                foreach (Cuenta.Deposito p in d)
                {
                    depositos.Add(p);
                }
            }
            var dep = from deposito in depositos select (deposito.DateTime);
            var fechas_trasnferencias = from transferencia in transferencias select (transferencia.Fecha);
            var total = fechas_trasnferencias.Union(dep);//juntamos los datos de que nos interesan y obtenemos todas las fechas
            total = total.OrderBy(fecha => fecha.Date);//ordenamos los datos
            int ultimo_año = total.Max().Year;
            int primer_año = total.Min().Year;
            HashSet<String> lista_final_años = new HashSet<String>();//creamos un hashset para no introducir años repetidos
            lista_final_años.Add(primer_año.ToString());
            lista_final_años.Add(ultimo_año.ToString());
            
            return lista_final_años.ToArray();//array de años
        }
        /// <summary>
        /// Esta funcion se encarga de ordenar las cantidades de cuentas y transferencias de un año especifico que le pasemos
        /// </summary>
        /// <param name="cuentas"></param>
        /// <param name="transferencias"></param>
        /// <param name="año"></param>
        /// <returns></returns>
        public int[] ordenarMesesAñoIngresoGeneral(IEnumerable<Cuenta> cuentas, IEnumerable<Transferencia> transferencias, int año)
        {
            //cogemos los depositos
            var depositos_cuentas = from cuenta in cuentas select cuenta.Depositos;
            //juntamos todos los objetos deposito, que en cuenta son IEnumerables
            List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
            foreach (IEnumerable<Cuenta.Deposito> d in depositos_cuentas)
            {
                foreach (Cuenta.Deposito p in d)
                {
                    depositos.Add(p);
                }
            }
            var dep = from deposito in depositos where deposito.DateTime.Year == año select (deposito.DateTime, deposito.Cantidad);
            var fechas_trasnferencias = from transferencia in transferencias where transferencia.Fecha.Year == año select (transferencia.Fecha, transferencia.Importe);
            var lista_dep = dep.ToList();
            var lista_transferencias = fechas_trasnferencias.ToList();
            lista_dep.AddRange(lista_transferencias);
            var total = lista_dep.OrderBy(fecha => fecha.DateTime);//ordenamos los datos
            var lista_total = total.ToList();
            for (int i = 0; i < lista_total.Count(); i++)
            {
                for (int j = i + 1; j < lista_total.Count(); j++)
                {
                    if (lista_total[i].DateTime.ToString() == lista_total[j].DateTime.ToString())
                    {
                        //creamos el item nuevo con la fecha y la suma de las cantidades
                        var cantidad = lista_total[i].Item2 + lista_total[j].Item2;
                        var fecha = lista_total[i].DateTime;
                        var item = (fecha, cantidad);
                        //eliminamos los items antiguos y añadimos uno nuevo actualizado
                        lista_total.RemoveAt(j);
                        lista_total.RemoveAt(i);
                        lista_total.Insert(i, item);

                    }
                }
            }
            var importes_ordenados = from importe in lista_total select importe.Item2;
            List<int> lista_final = new List<int>();
            //aproximamos los importes
            foreach (double importe in importes_ordenados)
            {
                int elem = Convert.ToInt32(importe);
                lista_final.Add(elem);
            }
            lista_final.Insert(0, 0);
            return lista_final.ToArray();
        }
        /// <summary>
        /// Esta funcion se encarga de ordenar las transferencias y depositos de un cliente teniendo en cuenta todos los años
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cuentas"></param>
        /// <param name="transferencias"></param>
        /// <returns></returns>
        public int[] ordenarIngresosCliente(Cliente c, IEnumerable<Cuenta> cuentas, IEnumerable<Transferencia> transferencias)
        {
            //cogemos las cuentas que tiene el cliente
            List<Cuenta> cuentas_cliente = new List<Cuenta>();
            foreach (Cuenta c1 in cuentas)
            {
                foreach (Cliente c2 in c1.Titulares)
                {
                    if (c2.Dni.Equals(c.Dni))
                    {
                        cuentas_cliente.Add(c1);
                    }
                }
            }

            //cogemos los depositos y transferencias de todas las cuentas
            var depositos_cliente = from deposito in cuentas_cliente select deposito.Depositos;
            //tratamos la coleccion de Ienumerables de deposito
            List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
            foreach (IEnumerable<Cuenta.Deposito> d in depositos_cliente)
            {
                foreach (Cuenta.Deposito p in d)
                {
                    depositos.Add(p);
                }
            }
            var nombre_cuentas = from cuenta in cuentas_cliente select cuenta.CCC;
            //transferencias que tienen como un titular  de la cuenta de destino el cliente que le pasamos 
            var transferencias_cliente = from transferencia in transferencias where (nombre_cuentas.Contains(transferencia.CCCDestino)) select (transferencia.Fecha, transferencia.Importe);
            var dep = from deposito in depositos select (deposito.DateTime, deposito.Cantidad);
            var fechas_trasnferencias = from transferencia in transferencias_cliente select (transferencia.Fecha, transferencia.Importe);
            var lista_dep = dep.ToList();
            var lista_transferencias = fechas_trasnferencias.ToList();
            lista_dep.AddRange(lista_transferencias);
            var total = lista_dep.OrderBy(fecha => fecha.DateTime);//ordenamos los datos
            var lista_total = total.ToList();
            for (int i = 0; i < lista_total.Count(); i++)
            {
                for (int j = i + 1; j < lista_total.Count(); j++)
                {
                    if (lista_total[i].DateTime.ToString() == lista_total[j].DateTime.ToString())
                    {
                        //creamos el item nuevo con la fecha y la suma de las cantidades
                        var cantidad = lista_total[i].Item2 + lista_total[j].Item2;
                        var fecha = lista_total[i].DateTime;
                        var item = (fecha, cantidad);
                        //eliminamos los items antiguos y añadimos uno nuevo actualizado
                        lista_total.RemoveAt(j);
                        lista_total.RemoveAt(i);
                        lista_total.Insert(i, item);

                    }
                }
            }
            var importes_ordenados = from importe in lista_total select importe.Item2;
            List<int> lista_final = new List<int>();
            //aproximamos los importes
            foreach (double importe in importes_ordenados)
            {
                int elem = Convert.ToInt32(importe);
                lista_final.Add(elem);
            }
            lista_final.Insert(0, 0);
            return lista_final.ToArray();
        }
        /// <summary>
        /// Esta funcion se encarga de ordenar los años en los que se hicieron los depositos y las transferencias
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cuentas"></param>
        /// <param name="transferencias"></param>
        /// <returns></returns>
        public String[] ordenarAñosIngresosCliente(Cliente c, IEnumerable<Cuenta> cuentas, IEnumerable<Transferencia> transferencias)
        {
            //cogemos las cuentas que tiene el cliente
            List<Cuenta> cuentas_cliente = new List<Cuenta>();
            foreach (Cuenta c1 in cuentas)
            {
                foreach (Cliente c2 in c1.Titulares)
                {
                    if (c2.Dni.Equals(c.Dni))
                    {
                        cuentas_cliente.Add(c1);
                    }
                }
            }

            //cogemos los depositos y transferencias de todas las cuentas
            var depositos_cliente = from deposito in cuentas_cliente select deposito.Depositos;
            //tratamos la coleccion de Ienumerables de deposito
            List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
            foreach (IEnumerable<Cuenta.Deposito> d in depositos_cliente)
            {
                foreach (Cuenta.Deposito p in d)
                {
                    depositos.Add(p);
                }
            }
            var nombre_cuentas = from cuenta in cuentas_cliente select cuenta.CCC;
            //transferencias que tienen como un titular  de la cuenta de destino el cliente que le pasamos 
            var transferencias_cliente = from transferencia in transferencias where (nombre_cuentas.Contains(transferencia.CCCDestino)) select (transferencia.Fecha);
            var dep = from deposito in depositos select (deposito.DateTime);
            var fechas_trasnferencias = from transferencia in transferencias select (transferencia.Fecha);
            var total = fechas_trasnferencias.Union(dep);//juntamos los datos de que nos interesan y obtenemos todas las fechas
            total = total.OrderBy(fecha => fecha.Date);//ordenamos los datos
            HashSet<String> lista_final_años = new HashSet<String>();//creamos un hashset para no introducir años repetidos
            if (total.Count() == 0)
            {
                //no se hace nada
                return lista_final_años.ToArray();
            }
            else
            {
                int ultimo_año = total.Max().Year;
                int primer_año = total.Min().Year;

                lista_final_años.Add(primer_año.ToString());
                for (int i = primer_año; i <= ultimo_año; i++)
                {
                    String elem = " ";
                    lista_final_años.Add(elem);
                }
                lista_final_años.Add(ultimo_año.ToString());

                return lista_final_años.ToArray();//array de años
            }
        }
        /// <summary>
        /// A partir de un año y el cliente devolvera todos los depositos y trasnferencias ordenados en el tiempo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cuentas"></param>
        /// <param name="transferencias"></param>
        /// <param name="año"></param>
        /// <returns></returns>
        public int[] ordenarIngresosClienteAño(Cliente c, IEnumerable<Cuenta> cuentas, IEnumerable<Transferencia> transferencias, int año)
        {
            //cogemos las cuentas que tiene el cliente
            List<Cuenta> cuentas_cliente = new List<Cuenta>();
            foreach (Cuenta c1 in cuentas)
            {
                foreach (Cliente c2 in c1.Titulares)
                {
                    if (c2.Dni.Equals(c.Dni))
                    {
                        cuentas_cliente.Add(c1);
                    }
                }
            }

            //cogemos los depositos y transferencias de todas las cuentas
            var depositos_cliente = from deposito in cuentas_cliente select deposito.Depositos;
            //tratamos la coleccion de Ienumerables de deposito
            List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
            foreach (IEnumerable<Cuenta.Deposito> d in depositos_cliente)
            {
                foreach (Cuenta.Deposito p in d)
                {
                    depositos.Add(p);
                }
            }
            var nombre_cuentas = from cuenta in cuentas_cliente select cuenta.CCC;
            var dep = from deposito in depositos where deposito.DateTime.Year == año select (deposito.DateTime, deposito.Cantidad);
            var transferencias_cliente = from transferencia in transferencias where (nombre_cuentas.Contains(transferencia.CCCDestino)) select (transferencia.Fecha, transferencia.Importe);
            var fechas_trasnferencias = from transferencia in transferencias_cliente where transferencia.Fecha.Year == año select (transferencia.Fecha, transferencia.Importe);
            var lista_dep = dep.ToList();
            var lista_transferencias = fechas_trasnferencias.ToList();
            lista_dep.AddRange(lista_transferencias);
            var total = lista_dep.OrderBy(fecha => fecha.DateTime);//ordenamos los datos
            var lista_total = total.ToList();
            for (int i = 0; i < lista_total.Count(); i++)
            {
                for (int j = i + 1; j < lista_total.Count(); j++)
                {
                    if (lista_total[i].DateTime.ToString() == lista_total[j].DateTime.ToString())
                    {
                        //creamos el item nuevo con la fecha y la suma de las cantidades
                        var cantidad = lista_total[i].Item2 + lista_total[j].Item2;
                        var fecha = lista_total[i].DateTime;
                        var item = (fecha, cantidad);
                        //eliminamos los items antiguos y añadimos uno nuevo actualizado
                        lista_total.RemoveAt(j);
                        lista_total.RemoveAt(i);
                        lista_total.Insert(i, item);

                    }
                }
            }
            var importes_ordenados = from importe in lista_total select importe.Item2;
            List<int> lista_final = new List<int>();
            //aproximamos los importes
            foreach (double importe in importes_ordenados)
            {
                int elem = Convert.ToInt32(importe);
                lista_final.Add(elem);
            }
            lista_final.Insert(0, 0);
            return lista_final.ToArray();
        }
        /// <summary>
        /// Mostrara un grafico con un resumen de las transacciones que se han llevo en la cuenta
        /// </summary>
        /// <param name="c"></param>
        /// <param name="transferencias"></param>
        /// <returns>una lista ordenada de la cantidad de salgo que ha tenido la cuenta a lo largo del tiempo</returns>
        public int[] ordenarResumenCuenta(Cuenta c, IEnumerable<Transferencia> transferencias)
        {
            //cogemos las transferencias positivas(que tienen la cuenta como destino) y las negativas(que tienen la cuenta como origen)(el importe de las transferencias lo ponemos como negativo
            var trasnferencias_pos = from transferencia in transferencias where transferencia.CCCDestino.Equals(c.CCC) select (transferencia.Fecha, transferencia.Importe);
            var trasnferencias_neg = from transferencia in transferencias where transferencia.CCCOrigen.Equals(c.CCC) select (transferencia.Fecha, -transferencia.Importe);
            //extraemos los depositos y las retiradas de la cuenta(el importe de las retiradas lo ponemos como negativo
            var depositos_cuenta = from deposito in c.Depositos select (deposito.DateTime, deposito.Cantidad);
            var retiradas_cuenta = from retirada in c.Retiradas select (retirada.DateTime, -retirada.Cantidad);
            //union de saldos negativos y positivos en una lista
            var lista_trasnferencias_pos = trasnferencias_pos.ToList();
            var lista_trasnferencias_neg = trasnferencias_neg.ToList();
            var lista_depositos = depositos_cuenta.ToList();
            var lista_retiradas = retiradas_cuenta.ToList();
            lista_depositos.AddRange(lista_trasnferencias_pos);
            lista_depositos.AddRange(lista_trasnferencias_neg);
            lista_depositos.AddRange(lista_retiradas);
            var total = lista_depositos.OrderBy(fecha => fecha.DateTime);//ordenamos los datos por fecha
            var lista_total = total.ToList();
            for (int i = 0; i < lista_total.Count(); i++)
            {
                for (int j = i + 1; j < lista_total.Count(); j++)
                {
                    if (lista_total[i].DateTime.ToString() == lista_total[j].DateTime.ToString())
                    {
                        //creamos el item nuevo con la fecha y la suma de las cantidades
                        var cantidad = lista_total[i].Item2 + lista_total[j].Item2;
                        var fecha = lista_total[i].DateTime;
                        var item = (fecha, cantidad);
                        //eliminamos los items antiguos y añadimos uno nuevo actualizado
                        lista_total.RemoveAt(j);
                        lista_total.RemoveAt(i);
                        lista_total.Insert(i, item);

                    }
                }
            }
            var importes_ordenados = from importe in lista_total select importe.Item2;
            var saldo = c.Saldo;
            List<int> lista_final = new List<int>();
            //aproximamos los importes y restamos o sumamos al saldo
            foreach (double importe in importes_ordenados)
            {
                saldo = saldo + importe;
                int elem = Convert.ToInt32(saldo);
                lista_final.Add(elem);
            }
            lista_final.Insert(0, Convert.ToInt32(c.Saldo));
            return lista_final.ToArray();
        }
        /// <summary>
        /// funcion que devolvera todos los años(sin repetir estos) en los que la cuenta tuvo movimientos
        /// </summary>
        /// <param name="c"></param>
        /// <param name="transferencias"></param>
        /// <returns>lista de años ordenada</returns>
        public String[] ordenarAñosResumenCuenta(Cuenta c, IEnumerable<Transferencia> transferencias)
        {
            //cogemos las transferencias asociadas a la cuenta tanto como si es de destino u origen
            var transferencias_cuenta = from transferencia in transferencias where (transferencia.CCCOrigen.Equals(c.CCC) | transferencia.CCCDestino.Equals(c.CCC)) select transferencia.Fecha;
            //extraemos los depositos de las cuentas
            var depositos_cuentas = from deposito in c.Depositos select deposito.DateTime;
            var total = transferencias_cuenta.Union(depositos_cuentas);//juntamos los datos de que nos interesan y obtenemos todas las fechas
            total = total.OrderBy(fecha => fecha.Date);//ordenamos los datos
            HashSet<String> lista_final_años = new HashSet<String>();//creamos un hashset para no introducir años repetidos
            String año_cuenta = c.FechaApertura.Year.ToString();
            lista_final_años.Add(año_cuenta);
            if (total.Count() == 0)
            {
                //no se hace nada
                return lista_final_años.ToArray();
            }
            else
            {
                //aproximamos los importes
                int ultimo_año = total.Max().Year;
                int primer_año = total.Min().Year;
                lista_final_años.Add(primer_año.ToString());
                for (int i = primer_año; i <= ultimo_año; i++)
                {
                    String elem = " ";
                    lista_final_años.Add(elem);
                }
                lista_final_años.Add(ultimo_año.ToString());

                return lista_final_años.ToArray();//array de años
            }

        }
        /// <summary>
        /// Devuelve las modificaciones que tuvo el saldo de la cuenta en un año especifico
        /// </summary>
        /// <param name="c"></param>
        /// <param name="transferencias"></param>
        /// <param name="año"></param>
        /// <returns>lista de saldo a lo largo del año indicado</returns>
        public int[] ordenarResumenCuentaAño(Cuenta c, IEnumerable<Transferencia> transferencias, int año)
        {
            //cogemos las transferencias positivas(que tienen la cuenta como destino) y las negativas(que tienen la cuenta como origen)(el importe de las transferencias lo ponemos como negativo
            var trasnferencias_pos = from transferencia in transferencias where (transferencia.CCCDestino.Equals(c.CCC) ) select (transferencia.Fecha, transferencia.Importe);
            var trasnferencias_neg = from transferencia in transferencias where (transferencia.CCCOrigen.Equals(c.CCC)) select (transferencia.Fecha, -transferencia.Importe);
            //extraemos los depositos y las retiradas de la cuenta(el importe de las retiradas lo ponemos como negativo
            var depositos_cuenta = from deposito in c.Depositos select (deposito.DateTime, deposito.Cantidad);
            var retiradas_cuenta = from retirada in c.Retiradas  select (retirada.DateTime, -retirada.Cantidad);
            //union de saldos negativos y positivos en una lista
            var lista_trasnferencias_pos = trasnferencias_pos.ToList();
            var lista_trasnferencias_neg = trasnferencias_neg.ToList();
            var lista_depositos = depositos_cuenta.ToList();
            var lista_retiradas = retiradas_cuenta.ToList();
            lista_depositos.AddRange(lista_trasnferencias_pos);
            lista_depositos.AddRange(lista_trasnferencias_neg);
            lista_depositos.AddRange(lista_retiradas);
            var total = lista_depositos.OrderBy(fecha => fecha.DateTime);//ordenamos los datos por fecha
            var lista_total = total.ToList();
            for (int i = 0; i < lista_total.Count(); i++)
            {
                for (int j = i + 1; j < lista_total.Count(); j++)
                {
                    if (lista_total[i].DateTime.ToString() == lista_total[j].DateTime.ToString())
                    {
                        //creamos el item nuevo con la fecha y la suma de las cantidades
                        var cantidad = lista_total[i].Item2 + lista_total[j].Item2;
                        var fecha = lista_total[i].DateTime;
                        var item = (fecha, cantidad);
                        //eliminamos los items antiguos y añadimos uno nuevo actualizado
                        lista_total.RemoveAt(j);
                        lista_total.RemoveAt(i);
                        lista_total.Insert(i, item);

                    }
                }
            }
            var importes_ordenados = from importe in lista_total select (importe.Item2,importe.DateTime);
            var saldo = c.Saldo;
            List<(int,DateTime)> lista_final = new List<(int,DateTime)>();
            //aproximamos los importes y restamos o sumamos al saldo
            foreach ((double,DateTime) importe in importes_ordenados)
            {
                saldo = saldo + importe.Item1;
                int elem = Convert.ToInt32(saldo);
                var item = (elem, importe.Item2);
                lista_final.Add(item);
            }
            var importes_anteriores = from importe in lista_final where (importe.Item2.Year < año) select importe;
            if (importes_anteriores.Count() == 0)
            {
                var importes_final = from importe in lista_final where (importe.Item2.Year == año) select importe.Item1;
                var l=importes_final.ToList();
                l.Insert(0, Convert.ToInt32(c.Saldo));
                return l.ToArray();
            }
            else
            {
                var anteriores_ordenados = importes_anteriores.OrderByDescending(fecha => fecha.Item2);//ordenamos los datos por fecha de mayor a menor
                var saldo_anterior = anteriores_ordenados.ToArray()[0].Item1;
                var importes_final = from importe in lista_final where (importe.Item2.Year == año) select importe.Item1;
                var l = importes_final.ToList();
                l.Insert(0, saldo_anterior);
                return l.ToArray();
            }
        }
        /// <summary>
        /// Resumen de las transacciones que hizo el cliente tanto positivas como negativas
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cuentas"></param>
        /// <param name="transferencias"></param>
        /// <returns>lista ordenada en el tiempo de la evolucion del saldo del cliente</returns>
        public int[] ordenarResumenSaldoCliente(Cliente c, IEnumerable<Cuenta> cuentas, IEnumerable<Transferencia> transferencias)
        {
            //cogemos las cuentas que tiene el cliente
            List<Cuenta> cuentas_cliente = new List<Cuenta>();
            foreach(Cuenta c1 in cuentas)
            {
                foreach (Cliente c2 in c1.Titulares)
                {
                    if (c2.Dni.Equals(c.Dni))
                    {
                        cuentas_cliente.Add(c1);
                    }
                }
            }

            //cogemos los depositos y transferencias de todas las cuentas
            var depositos_cliente = from deposito in cuentas_cliente select deposito.Depositos;
            var retiradas_cliente = from retirada in cuentas_cliente select retirada.Retiradas;
            //tratamos la coleccion de Ienumerables de deposito
            List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
            foreach (IEnumerable<Cuenta.Deposito> d in depositos_cliente)
            {
                foreach (Cuenta.Deposito p in d)
                {
                    depositos.Add(p);
                }
            }
            List<Cuenta.Retirada> retiradas = new List<Cuenta.Retirada>();
            foreach (IEnumerable<Cuenta.Retirada> d in retiradas_cliente)
            {
                foreach (Cuenta.Retirada p in d)
                {
                    retiradas.Add(p);
                }
            }
            var nombre_cuentas = from cuenta in cuentas_cliente select cuenta.CCC;
            var dep = from deposito in depositos select (deposito.DateTime, deposito.Cantidad);
            var ret = from retirada in retiradas select (retirada.DateTime, -retirada.Cantidad);
            //cogemos las transferencias de retirada y de ingreso en las cuentas del cliente
            var transferencias_pos = from transferencia in transferencias where (nombre_cuentas.Contains(transferencia.CCCDestino)) select (transferencia.Fecha, transferencia.Importe);
            var transferencias_neg = from transferencia in transferencias where (nombre_cuentas.Contains(transferencia.CCCOrigen)) select (transferencia.Fecha, -transferencia.Importe);
            //union de saldos negativos y positivos en una lista
            var lista_trasnferencias_pos = transferencias_pos.ToList();
            var lista_trasnferencias_neg = transferencias_neg.ToList();
            var lista_depositos = dep.ToList();
            var lista_retiradas = ret.ToList();
            lista_depositos.AddRange(lista_trasnferencias_pos);
            lista_depositos.AddRange(lista_trasnferencias_neg);
            lista_depositos.AddRange(lista_retiradas);
            var total = lista_depositos.OrderBy(fecha => fecha.DateTime);//ordenamos los datos por fecha
            var lista_total = total.ToList();

            for (int i = 0; i < lista_total.Count(); i++)
            {
                for (int j = i + 1; j < lista_total.Count(); j++)
                {
                    if (lista_total[i].DateTime.ToString() == lista_total[j].DateTime.ToString())
                    {
                        //creamos el item nuevo con la fecha y la suma de las cantidades
                        var cantidad = lista_total[i].Item2 + lista_total[j].Item2;
                        var fecha = lista_total[i].DateTime;
                        var item = (fecha, cantidad);
                        //eliminamos los items antiguos y añadimos uno nuevo actualizado
                        lista_total.RemoveAt(j);
                        lista_total.RemoveAt(i);
                        lista_total.Insert(i, item);

                    }
                }
            }
            var importes_ordenados = from importe in lista_total select importe.Item2;
            double saldo = 0;
            var saldos_cuentas = from cuenta in cuentas_cliente select cuenta.Saldo;
            foreach (double s in saldos_cuentas)
            {
                saldo += s;
            }
            List<int> lista_final = new List<int>();
            lista_final.Insert(0, Convert.ToInt32(saldo));
            //aproximamos los importes y restamos o sumamos al saldo
            foreach (double importe in importes_ordenados)
            {
                saldo = saldo + importe;
                int elem = Convert.ToInt32(saldo);
                lista_final.Add(elem);
            }
            return lista_final.ToArray();

        }
        /// <summary>
        /// Funcion que calcula los años en los que se hicieron las transacciones
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cuentas"></param>
        /// <param name="transferencias"></param>
        /// <returns>devuelve una lista con los años de las transacciones</returns>
        public String[] ordenarAñosResumenCliente(Cliente c, IEnumerable<Cuenta> cuentas, IEnumerable<Transferencia> transferencias)
        {
            //cogemos las cuentas que tiene el cliente
            List<Cuenta> cuentas_cliente = new List<Cuenta>();
            foreach (Cuenta c1 in cuentas)
            {
                foreach (Cliente c2 in c1.Titulares)
                {
                    if (c2.Dni.Equals(c.Dni))
                    {
                        cuentas_cliente.Add(c1);
                    }
                }
            }

            //cogemos los depositos y transferencias de todas las cuentas
            var depositos_cliente = from deposito in cuentas_cliente select deposito.Depositos;
            var retiradas_cliente = from retirada in cuentas_cliente select retirada.Retiradas;
            //tratamos la coleccion de Ienumerables de deposito
            List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
            foreach (IEnumerable<Cuenta.Deposito> d in depositos_cliente)
            {
                foreach (Cuenta.Deposito p in d)
                {
                    depositos.Add(p);
                }
            }
            List<Cuenta.Retirada> retiradas = new List<Cuenta.Retirada>();
            foreach (IEnumerable<Cuenta.Retirada> d in retiradas_cliente)
            {
                foreach (Cuenta.Retirada p in d)
                {
                    retiradas.Add(p);
                }
            }
            var nombre_cuentas = from cuenta in cuentas_cliente select cuenta.CCC;
            var dep = from deposito in depositos select (deposito.DateTime);
            var ret = from retirada in retiradas select (retirada.DateTime);
            //cogemos las transferencias de retirada y de ingreso en las cuentas del cliente
            var transferencias_pos = from transferencia in transferencias where (nombre_cuentas.Contains(transferencia.CCCDestino)) select (transferencia.Fecha);
            var transferencias_neg = from transferencia in transferencias where (nombre_cuentas.Contains(transferencia.CCCOrigen)) select (transferencia.Fecha);
            var total = dep.Union(ret).Union(transferencias_neg).Union(transferencias_pos);//juntamos los datos de que nos interesan y obtenemos todas las fechas
            total = total.OrderBy(fecha => fecha.Date);//ordenamos los datos
            HashSet<String> lista_final_años = new HashSet<String>();//creamos un hashset para no introducir años repetidos
            if (total.Count() == 0)
            {
                //no se hace nada
                return lista_final_años.ToArray();
            }
            else
            {
                int ultimo_año = total.Max().Year;
                int primer_año = total.Min().Year;

                lista_final_años.Add(primer_año.ToString());
                for (int i = primer_año; i <= ultimo_año; i++)
                {
                    String elem = " ";
                    lista_final_años.Add(elem);
                }
                lista_final_años.Add(ultimo_año.ToString());

                return lista_final_años.ToArray();//array de años
            }
        }
        public int[] ordenarResumenSaldoClienteAños(Cliente c, IEnumerable<Cuenta> cuentas, IEnumerable<Transferencia> transferencias, int año)
        {
            //cogemos las cuentas que tiene el cliente
            List<Cuenta> cuentas_cliente = new List<Cuenta>();
            foreach (Cuenta c1 in cuentas)
            {
                foreach (Cliente c2 in c1.Titulares)
                {
                    if (c2.Dni.Equals(c.Dni))
                    {
                        cuentas_cliente.Add(c1);
                    }
                }
            }

            //cogemos los depositos y transferencias de todas las cuentas
            var depositos_cliente = from deposito in cuentas_cliente select deposito.Depositos;
            var retiradas_cliente = from retirada in cuentas_cliente select retirada.Retiradas;
            //tratamos la coleccion de Ienumerables de deposito
            List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
            foreach (IEnumerable<Cuenta.Deposito> d in depositos_cliente)
            {
                foreach (Cuenta.Deposito p in d)
                {
                    depositos.Add(p);
                }
            }
            List<Cuenta.Retirada> retiradas = new List<Cuenta.Retirada>();
            foreach (IEnumerable<Cuenta.Retirada> d in retiradas_cliente)
            {
                foreach (Cuenta.Retirada p in d)
                {
                    retiradas.Add(p);
                }
            }
            var nombre_cuentas = from cuenta in cuentas_cliente select cuenta.CCC;
            var dep = from deposito in depositos  select (deposito.DateTime, deposito.Cantidad);
            var ret = from retirada in retiradas  select (retirada.DateTime, -retirada.Cantidad);
            //cogemos las transferencias de retirada y de ingreso en las cuentas del cliente
            var transferencias_pos = from transferencia in transferencias where (nombre_cuentas.Contains(transferencia.CCCDestino) ) select (transferencia.Fecha, transferencia.Importe);
            var transferencias_neg = from transferencia in transferencias where (nombre_cuentas.Contains(transferencia.CCCOrigen) ) select (transferencia.Fecha, -transferencia.Importe);
            //union de saldos negativos y positivos en una lista
            var lista_trasnferencias_pos = transferencias_pos.ToList();
            var lista_trasnferencias_neg = transferencias_neg.ToList();
            var lista_depositos = dep.ToList();
            var lista_retiradas = ret.ToList();
            lista_depositos.AddRange(lista_trasnferencias_pos);
            lista_depositos.AddRange(lista_trasnferencias_neg);
            lista_depositos.AddRange(lista_retiradas);
            var total = lista_depositos.OrderBy(fecha => fecha.DateTime);//ordenamos los datos por fecha
            var lista_total = total.ToList();
            for (int i = 0; i < lista_total.Count(); i++)
            {
                for (int j = i + 1; j < lista_total.Count(); j++)
                {
                    if (lista_total[i].DateTime.ToString() == lista_total[j].DateTime.ToString())
                    {
                        //creamos el item nuevo con la fecha y la suma de las cantidades
                        var cantidad = lista_total[i].Item2 + lista_total[j].Item2;
                        var fecha = lista_total[i].DateTime;
                        var item = (fecha, cantidad);
                        //eliminamos los items antiguos y añadimos uno nuevo actualizado
                        lista_total.RemoveAt(j);
                        lista_total.RemoveAt(i);
                        lista_total.Insert(i, item);

                    }
                }
            }
            var importes_ordenados = from importe in lista_total select (importe.Cantidad,importe.DateTime);
            double saldo_inicial = 0;
            var saldos_cuentas = from cuenta in cuentas_cliente select cuenta.Saldo;
            foreach (double s in saldos_cuentas)
            {
                saldo_inicial += s;
            }
            List<(int,DateTime)> lista_final = new List<(int, DateTime)>();
            //aproximamos los importes y restamos o sumamos al saldo
            var saldo = saldo_inicial;
            foreach ((double,DateTime) importe in importes_ordenados)
            {
                saldo = saldo + importe.Item1;
                int elem = Convert.ToInt32(saldo);
                var item = (elem, importe.Item2);
                lista_final.Add(item);
            }
            var saldos_anteriores = from saldos in lista_final where saldos.Item2.Year < año select (saldos.Item1,saldos.Item2);
            if (saldos_anteriores.Count() == 0)
            {
                var l = from cantidad in lista_final where(cantidad.Item2.Year==año) select cantidad.Item1;
                var l2 = l.ToList();
                l2.Insert(0, Convert.ToInt32(saldo_inicial));
                return l2.ToArray();
            }
            else
            {
                var saldos_ordenados = saldos_anteriores.OrderByDescending(fecha => fecha.Item2);
                var saldo_anterior = saldos_ordenados.ToArray()[0].Item1;
                var l = from cantidad in lista_final where (cantidad.Item2.Year == año) select cantidad.Item1;
                var l2 = l.ToList();
                l2.Insert(0, saldo_anterior);
                return l2.ToArray();

            }


        }
    }
}
