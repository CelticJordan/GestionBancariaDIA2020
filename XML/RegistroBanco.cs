using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System;
using System.Globalization;
using DIA_BANCO_V1;

namespace DIA_BANCO_V1 {
    public class RegistroBanco {
        /*
         * Para la realización de esta parte del proyecto (guardado y carga de datos en XML) se presupone la siguiente estructura en 4 archivos:
         *
         *          Cuentas.xml    (raiz del documento, va a contener una coleccion de cuentas)
         *            │
         *            └─── cuenta1 (contiene atributos de cuenta)
         *            │
         *            └─── cuenta2 
         *            └─── ...
         *
         *           Clientes.xml     (contiene una coleccion de clientes)
         *            │
         *            └─── cliente1 (contiene atributos de cliente)
         *            │
         *            └─── cuenta2 
         *            └─── ...
         * 
         *           Transferencias.xml     (contiene una coleccion de transferencias)
         *            │
         *            └─── transferencia1 (contiene atributos de cliente)
         *            │
         *            └─── transferencia2 
         *            └─── ...
         * 
         *           Prestamos.xml     (contiene una coleccion de prestamos)
         *            │
         *            └─── prestamo1 (contiene atributos de cliente)
         *            │
         *            └─── prestamo2 
         *            └─── ...
         *
         * 
         * 
         *
         * En el caso de que finalmente la estructura varíe o exista otra organización de contenedores,
         * la reimplementación será sencilla puesto que los metodos ToXml() están implementados por separado
         * para cada clase funcional del banco.
         *
         * Estos mismos métodos ToXml se definen todos en este archivo (fuera de las clases) y por tanto necesitan
         * recibir como parámetro el elemento de la propia clase que quieren empaquetar/desempaquetar. 
         * 
         */



        /// <summary>
        /// Etiquetas para XML
        /// </summary>
        public static string EtiquetaBancoClientes = "BancoClientes";
        public static string EtiquetaBancoCuentas = "BancoCuentas";
        public static string EtiquetaBancoPrestamos = "BancoPrestamos";
        public static string EtiquetaBancoTransferencias = "BancoTransferencias";

        public static string EtiquetaCliente = "cliente";
        public static string EtiquetaDni = "dni";
        public static string EtiquetaNombre = "nombre";
        public static string EtiquetaTelefono = "telefono";
        public static string EtiquetaEmail = "email";
        public static string EtiquetaDireccion = "direccion";
        public static string EtiquetaCuenta = "cuenta";
        public static string EtiquetaCCC = "ccc";
        public static string EtiquetaTipo = "tipo";
        public static string EtiquetaSaldo = "saldo";
        public static string EtiquetaTitulares = "titulares";
        public static string EtiquetaFechaApertura = "fechaApertura";
        public static string EtiquetaInteresMensual = "interesMensual";
        public static string EtiquetaDepositos = "depositos";
        public static string EtiquetaRetiradas = "retiradas";
        public static string EtiquetaTransferencias = "transferencias";
        public static string EtiquetaTransferencia = "transferencia";
        public static string EtiquetaTipoTransferencia = "tipoTransferencia";
        public static string EtiquetaTipoPrestamo = "tipoPrestamo";
        public static string EtiquetaDeposito = "deposito";
        public static string EtiquetaRetirada = "retirada";
        public static string EtiquetaConcepto = "concepto";
        public static string EtiquetaCantidad = "cantidad";
        public static string EtiquetaDateTime = "dateTime";
        public static string EtiquetaPrestamo = "prestamo";
        public static string EtiquetaId = "id";
        public static string EtiquetaCCCorigen = "cccOrigen";
        public static string EtiquetaCCCdestino = "cccDestino";
        public static string EtiquetaImporte = "importe";
        public static string EtiquetaFecha = "fecha";
        public static string EtiquetaFecha_Siguiente = "fecha_siguiente";
        public static string EtiquetaCuota = "cuota";
        public static string EtiquetaNumeroCuotas = "numeroCuotas";
        public static string EtiquetaTitular = "titular";






        /// <summary>
        /// Metodo ToXml para guardar cuentas
        /// </summary>
        private XElement ToXmlCuenta(Cuenta cuenta) {
            XElement toret = new XElement(EtiquetaCuenta);
            toret.Add(
                //guardado de atributos
                new XAttribute(EtiquetaCCC, cuenta.CCC.ToString()),
                new XAttribute(EtiquetaTipo, cuenta.Tipo.ToString()),
                new XAttribute(EtiquetaSaldo, cuenta.Saldo.ToString()),
                new XAttribute(EtiquetaFechaApertura, cuenta.FechaApertura.ToString()),
                new XAttribute(EtiquetaInteresMensual, cuenta.InteresMensual.ToString())
            );

            //guardado de listas

            //dni clientes:
            XElement clientesx = new XElement(EtiquetaTitulares);
            foreach (Cliente cl in cuenta.Titulares) {
                clientesx.Add(new XElement(EtiquetaTitular, cl.Dni.ToString()));
            }
            toret.Add(clientesx);

            //movimientos:
            //depositos 
            XElement depositosx = new XElement(EtiquetaDepositos);
            if (cuenta.Depositos != null) {
                foreach (Cuenta.Deposito d in cuenta.Depositos) {
                    depositosx.Add(ToXmlDeposito(d));
                }
            }
            toret.Add(depositosx);
            //retiradas 
            XElement retiradasx = new XElement(EtiquetaRetiradas);
            if (cuenta.Retiradas != null) {

                foreach (Cuenta.Retirada r in cuenta.Retiradas) {
                    retiradasx.Add(ToXmlRetirada(r));
                }
            }
            toret.Add(retiradasx);


            //devuelve la cuenta completa
            return toret;
        }


        /// <summary>
        /// Metodo ToXml para guardar clientes
        /// </summary>
        private XElement ToXmlCliente(Cliente cliente) {
            XElement toret = new XElement(EtiquetaCliente);
            toret.Add(
                new XAttribute(EtiquetaDni, cliente.Dni.ToString()),
                new XAttribute(EtiquetaNombre, cliente.Nombre.ToString()),
                new XAttribute(EtiquetaTelefono, cliente.Telefono.ToString()),
                new XAttribute(EtiquetaEmail, cliente.Email.ToString()),
                new XAttribute(EtiquetaDireccion, cliente.DirPostal.ToString())
            );

            return toret;
        }

        /// <summary>
        /// Metodo ToXml para guardar retiradas
        /// </summary>
        private XElement ToXmlRetirada(Cuenta.Retirada retirada) {
            XElement toret = new XElement(EtiquetaRetirada);
            toret.Add(

                new XAttribute(EtiquetaConcepto, retirada.Concepto.ToString()),
                new XAttribute(EtiquetaCantidad, retirada.Cantidad.ToString()),
                new XAttribute(EtiquetaDateTime, retirada.DateTime.ToString())
            );
            return toret;
        }

        /// <summary>
        /// Metodo ToXml para guardar depositos
        /// </summary>
        private XElement ToXmlDeposito(Cuenta.Deposito deposito) {
            XElement toret = new XElement(EtiquetaDeposito);
            toret.Add(
                new XAttribute(EtiquetaConcepto, deposito.Concepto.ToString()),
                new XAttribute(EtiquetaCantidad, deposito.Cantidad.ToString()),
                new XAttribute(EtiquetaDateTime, deposito.DateTime.ToString())
            );
            return toret;
        }




        /// <summary>
        /// Metodo ToXml para guardar prestamos 
        /// </summary>
        private XElement ToXmlPrestamo(Prestamo prestamo) {
            XElement toret = new XElement(EtiquetaPrestamo);
            toret.Add(
                new XAttribute(EtiquetaId, prestamo.IdPrestamo.ToString()),
                new XAttribute(EtiquetaTipoPrestamo, prestamo.Tipo.ToString()),
                new XAttribute(EtiquetaCCC, prestamo.CccOri.ToString()),
                new XAttribute(EtiquetaImporte, prestamo.Importe.ToString()),
                new XAttribute(EtiquetaCuota, prestamo.Cuota.ToString()),
                new XAttribute(EtiquetaNumeroCuotas, prestamo.NumCuotas.ToString()),
                new XAttribute(EtiquetaFecha, prestamo.Fecha.ToString("dd/MM/yyyy"))

            );

            return toret;
        }


        /// <summary>
        /// Metodo ToXml para guardar transferencias
        /// </summary>
        private XElement ToXmlTransferencia(Transferencia transferencia)
        {

            XElement toret;
            if (transferencia is Transferencia_Periodica)
            {
                Transferencia_Periodica t = (Transferencia_Periodica) transferencia;
                
                toret = new XElement(EtiquetaTransferencia);
                toret.Add(
                    new XAttribute(EtiquetaId, t.Id.ToString()),
                    new XAttribute(EtiquetaTipoTransferencia, t.Tipo.ToString()),
                    new XAttribute(EtiquetaCCCorigen, t.CCCOrigen.ToString()),
                    new XAttribute(EtiquetaCCCdestino, t.CCCDestino.ToString()),
                    new XAttribute(EtiquetaImporte, t.Importe.ToString()),
                    new XAttribute(EtiquetaFecha, t.Fecha.ToString()),
                    new XAttribute(EtiquetaFecha_Siguiente, t.Fecha_Siguiente.ToString())
                );
                
            }
            else
            {
                toret = new XElement(EtiquetaTransferencia);
                toret.Add(
                    new XAttribute(EtiquetaId, transferencia.Id.ToString()),
                    new XAttribute(EtiquetaTipoTransferencia, transferencia.Tipo.ToString()),
                    new XAttribute(EtiquetaCCCorigen, transferencia.CCCOrigen.ToString()),
                    new XAttribute(EtiquetaCCCdestino, transferencia.CCCDestino.ToString()),
                    new XAttribute(EtiquetaImporte, transferencia.Importe.ToString()),
                    new XAttribute(EtiquetaFecha, transferencia.Fecha.ToString())
                );
            }

            return toret;
        }







        //--------------------------------------------------------------------------------------------------


        /// <summary>
        /// Metodo que guarda las cuentas del contenedor <see cref="contenedorCuentas"/> en  <see cref="archivo"/>
        /// </summary>
        public void GuardaCuentasXml(List<Cuenta> contenedorCuentas, String archivo) {
            Console.WriteLine("Guardando datos de cuentas, espere...");
            XDocument documento = new XDocument();
            XElement root = new XElement(EtiquetaBancoCuentas);

            foreach (Cuenta cu in contenedorCuentas) {
                root.Add(ToXmlCuenta(cu));
            }

            documento.Add(root);
            documento.Save(archivo);

            Console.WriteLine("Datos guardados correctamente.");

        }


        //--------------------------------------------------------------------------------------------------


        /// <summary>
        /// Metodo que guarda los clientes del contenedor <see cref="contenedorClientes"/> en  <see cref="archivo"/>
        /// </summary>
        public void GuardaClientesXml(List<Cliente> contenedorClientes, String archivo) {
            Console.WriteLine("Guardando datos de clientes, espere...");
            XDocument documento = new XDocument();
            XElement root = new XElement(EtiquetaBancoClientes);

            foreach (Cliente cl in contenedorClientes) {
                root.Add(ToXmlCliente(cl));
            }

            documento.Add(root);
            documento.Save(archivo);

            Console.WriteLine("Datos guardados correctamente.");

        }


        //--------------------------------------------------------------------------------------------------


        /// <summary>
        /// Metodo que guarda los prestamos del contenedor <see cref="contenedorPrestamos"/> en  <see cref="archivo"/>
        /// </summary>
        public void GuardaPrestamosXml(List<Prestamo> contenedorPrestamos, String archivo) {
            Console.WriteLine("Guardando datos de prestamos, espere...");
            XDocument documento = new XDocument();
            XElement root = new XElement(EtiquetaBancoPrestamos);

            foreach (Prestamo pr in contenedorPrestamos) {
                root.Add(ToXmlPrestamo(pr));
            }

            documento.Add(root);
            documento.Save(archivo);

            Console.WriteLine("Datos guardados correctamente.");

        }


        //--------------------------------------------------------------------------------------------------


        /// <summary>
        /// Metodo que guarda las transferencias del contenedor <see cref="contenedorTransferencias"/> en  <see cref="archivo"/>
        /// </summary>
        public void GuardaTransferenciasXml(List<Transferencia> contenedorTransferencias, String archivo) {
            Console.WriteLine("Guardando datos de transferencias, espere...");
            XDocument documento = new XDocument();
            XElement root = new XElement(EtiquetaBancoTransferencias);

            foreach (Transferencia tr in contenedorTransferencias) {
                root.Add(ToXmlTransferencia(tr));
            }

            documento.Add(root);
            documento.Save(archivo);

            Console.WriteLine("Datos guardados correctamente.");
        }




        //---------------------------------------------------------------------------------------------------

        /// <summary>
        /// Metodo que carga las cuentas del archivo  <see cref="archivo"/> en el contenedor <see cref="contenedorCuentas"/>
        /// </summary>
        public List<Cuenta> CargarCuentasXml(String archivo) {
            List<Cuenta> contenedorCuentas = new List<Cuenta>();
            XDocument documento;
            try {
                documento = XDocument.Load(archivo);
                Console.WriteLine("Cargando datos de cuentas...");
            } catch (Exception e) //si no encuentra el archivo creamos uno vacio
              {
                Console.WriteLine(e.Message);
                documento = new XDocument();
                Console.WriteLine("No se han encontrado datos anteriores de cuentas, se ha creado un archivo nuevo \n");
            }

            if (documento.Root != null && documento.Root.Name == EtiquetaBancoCuentas) //en el caso de que encuentre un documento escrito
            {
                var cuentas = documento.Root.Elements(EtiquetaCuenta);
                foreach (var cu in cuentas) {
                    //primero leemos los atributos de cuenta
                    String ccc = (string)cu.Attribute(EtiquetaCCC);
                    String tipo = (string)cu.Attribute(EtiquetaTipo);
                    double saldo = (double)cu.Attribute(EtiquetaSaldo);
                    DateTime fechaApertura = Convert.ToDateTime((string) cu.Attribute(EtiquetaFechaApertura));
                    double interes = Convert.ToDouble((string)cu.Attribute(EtiquetaInteresMensual));


                    //ahora leemos las listas de objetos dentro de cada cuenta
                    //para ello leemos uno a uno cada objeto de la lista, lo creamos y lo añadimos a un contenedor

                    //lista de titulares de la cuenta
                    List<Cliente> titulares = new List<Cliente>();
                    List<Cliente> clientes = CargarClientesXml("clientes.xml");

                    var titularesx = cu.Element(EtiquetaTitulares).Elements(EtiquetaTitular);
                    foreach (var t in titularesx) {
                        string dni = t.Value;
                        foreach (Cliente c in clientes) {
                            if (dni.Equals(c.Dni)) {
                                titulares.Add(c);
                            }
                        }
                    }


                    //lista de depositos
                    List<Cuenta.Deposito> depositos = new List<Cuenta.Deposito>();
                    var depositosx = cu.Element(EtiquetaDepositos).Elements(EtiquetaDeposito);
                    foreach (var m in depositosx) {
                        String concepto = (string)m.Attribute(EtiquetaConcepto);
                        double cantidad = (double)m.Attribute(EtiquetaCantidad);
                        DateTime dateTime = (DateTime)m.Attribute(EtiquetaDateTime);

                        Cuenta.Deposito deposito = new Cuenta.Deposito(concepto, dateTime, cantidad);
                        depositos.Add(deposito);
                    }

                    //lista de retiradas
                    List<Cuenta.Retirada> retiradas = new List<Cuenta.Retirada>();
                    var retiradasx = cu.Element(EtiquetaRetiradas).Elements(EtiquetaRetirada);
                    foreach (var m in retiradasx) {
                        String concepto = (string)m.Attribute(EtiquetaConcepto);
                        double cantidad = (double)m.Attribute(EtiquetaCantidad);
                        DateTime dateTime = (DateTime)m.Attribute(EtiquetaDateTime);

                        Cuenta.Retirada retirada = new Cuenta.Retirada(concepto, dateTime, cantidad);
                        retiradas.Add(retirada);
                    }

                    Cuenta cuenta;

                    //finalmente construye una cuenta con los datos leidos y la guarda en el contenedor de cuentas
                    if (tipo == "Ahorro") {
                        cuenta = new CuentaAhorro(ccc, tipo, saldo, fechaApertura, titulares, depositos, retiradas);

                    } else if (tipo == "Vivienda") {
                        cuenta = new CuentaVivienda(ccc, tipo, saldo, fechaApertura, titulares, depositos, retiradas);

                    } else if (tipo == "Corriente") {
                        cuenta = new CuentaCorriente(ccc, tipo, saldo, fechaApertura, titulares, depositos, retiradas);

                    } else //por si falla reconociendo el tipo, se crea una corriente para al menos conservar los datos
                     {
                        cuenta = new CuentaCorriente(ccc, tipo, saldo, fechaApertura, titulares, depositos, retiradas);
                    }

                    contenedorCuentas.Add(cuenta);
                }
                Console.WriteLine("Datos cargados correctamente. \n");
            }
            return contenedorCuentas;
        }

        //---------------------------------------------------------------------------------------------------
        /// <summary>
        /// Metodo que carga los prestamos del archivo  <see cref="archivo"/> en el contenedor <see cref="contenedorPrestamos"/>
        /// </summary>
        public List<Prestamo> CargarPrestamosXml(String archivo) {
            List<Prestamo> contenedorPrestamos = new List<Prestamo>();

            XDocument documento;
            try {
                documento = XDocument.Load(archivo);
                Console.WriteLine("Cargando datos de prestamos...");
            } catch (Exception e) //si no encuentra el archivo creamos uno vacio
              {
                documento = new XDocument();
                Console.WriteLine("No se han encontrado Prestamos anteriores, se ha creado un archivo nuevo \n" + e.StackTrace);
            }

            if (documento.Root != null && documento.Root.Name == EtiquetaBancoPrestamos) //en el caso de que encuentre un documento escrito
            {
                var prestamos = documento.Root.Elements(EtiquetaPrestamo);
                foreach (var pr in prestamos) {
                    String id = (string)pr.Attribute(EtiquetaId);
                    String tipo = (string)pr.Attribute(EtiquetaTipoPrestamo);
                    String cccOrigen = (string)pr.Attribute(EtiquetaCCC);
                    double importe = Convert.ToDouble((string)pr.Attribute(EtiquetaImporte));
                    double cuota = Convert.ToDouble((string)pr.Attribute(EtiquetaCuota));
                    int numCuotas = (int)pr.Attribute((EtiquetaNumeroCuotas));
                    DateTime fecha = Convert.ToDateTime((string)pr.Attribute(EtiquetaFecha));


                    Prestamo prestamo = new Prestamo(id, tipo, cccOrigen, importe, cuota, numCuotas, fecha);
                    contenedorPrestamos.Add(prestamo);
                }
                Console.WriteLine("Datos cargados correctamente. \n");
            }

            return contenedorPrestamos;
        }

        //---------------------------------------------------------------------------------------------------

        /// <summary>
        /// Metodo que carga los clientes del archivo  <see cref="archivo"/> en el contenedor <see cref="contenedorClientes"/>
        /// </summary>
        public List<Cliente> CargarClientesXml(String archivo) {
            List<Cliente> contenedorClientes = new List<Cliente>();
            XDocument documento;
            try {
                documento = XDocument.Load(archivo);
                Console.WriteLine("Cargando datos de clientes...");
            } catch (Exception e) //si no encuentra el archivo creamos uno vacio
              {
                Console.WriteLine(e.Message);
                documento = new XDocument();
                Console.WriteLine("No se han encontrado Clientes anteriores, se ha creado un archivo nuevo \n");
            }

            if (documento.Root != null && documento.Root.Name == EtiquetaBancoClientes) //en el caso de que encuentre un documento escrito
            {
                var clientes = documento.Root.Elements(EtiquetaCliente);
                foreach (var cl in clientes) {
                    String dni = (string)cl.Attribute(EtiquetaDni);
                    String nombre = (string)cl.Attribute(EtiquetaNombre);
                    String telefono = (string)cl.Attribute(EtiquetaTelefono);
                    String email = (string)cl.Attribute(EtiquetaEmail);
                    String direccion = (string)cl.Attribute(EtiquetaDireccion);

                    Cliente cliente = new Cliente(dni, nombre, telefono, email, direccion);
                    contenedorClientes.Add(cliente);
                }
                Console.WriteLine("Datos cargados correctamente. \n");
            }

            return contenedorClientes;
        }



        //---------------------------------------------------------------------------------------------------

        /// <summary>
        /// Metodo que carga las transferencias del archivo  <see cref="archivo"/> en el contenedor <see cref="contenedorTransferencias"/>
        /// </summary>
        public List<Transferencia> CargarTransferenciasXml(String archivo) {
            List<Transferencia> contenedorTransferencias = new List<Transferencia>();
            XDocument documento;
            try {
                documento = XDocument.Load(archivo);
                Console.WriteLine("Cargando datos de transferencias...");
            } catch (Exception e) //si no encuentra el archivo creamos uno vacio
              {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                documento = new XDocument();
                Console.WriteLine("No se han encontrado Transferencias anteriores, se ha creado un archivo nuevo \n");
            }

            if (documento.Root != null && documento.Root.Name == EtiquetaBancoTransferencias) //en el caso de que encuentre un documento escrito
            {
                var transferencias = documento.Root.Elements(EtiquetaTransferencia);


                foreach (var tr in transferencias) {

                    if ((string) tr.Attribute(EtiquetaTipoTransferencia) == "Puntual")
                    {
                        
                        int id = (int)tr.Attribute(EtiquetaId);
                        String tipoTransferencia = (string)tr.Attribute(EtiquetaTipoTransferencia);
                        String cccOrigen = (string)tr.Attribute(EtiquetaCCCorigen);
                        String cccDestino = (string)tr.Attribute(EtiquetaCCCdestino);
                        double importe = (double)tr.Attribute(EtiquetaImporte);
                        DateTime fecha = Convert.ToDateTime((string)tr.Attribute(EtiquetaFecha));

                        Transferencia transferencia =
                            new Transferencia(id, tipoTransferencia, cccOrigen, cccDestino, importe, fecha);
                        contenedorTransferencias.Add(transferencia);
                        
                    }
                    else
                    {
                        int id = (int)tr.Attribute(EtiquetaId);
                        String tipoTransferencia = (string)tr.Attribute(EtiquetaTipoTransferencia);
                        String cccOrigen = (string)tr.Attribute(EtiquetaCCCorigen);
                        String cccDestino = (string)tr.Attribute(EtiquetaCCCdestino);
                        double importe = (double)tr.Attribute(EtiquetaImporte);
                        DateTime fecha = Convert.ToDateTime((string)tr.Attribute(EtiquetaFecha));
                        DateTime fecha_siguiente = Convert.ToDateTime((string)tr.Attribute(EtiquetaFecha_Siguiente));

                        Transferencia_Periodica transferencia =
                            new Transferencia_Periodica(id, tipoTransferencia, cccOrigen, cccDestino, importe, fecha, fecha_siguiente);
                        contenedorTransferencias.Add(transferencia);
                    }
                    
                }
                Console.WriteLine("Datos de transferencias cargados correctamente. \n");
            }

            return contenedorTransferencias;
        }
    }
}