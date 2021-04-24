using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIA_BANCO_V1
{
    using WForms = System.Windows.Forms;
    public partial class MainWindow: Form
    {
        public const int ColDni = 0;
        public const int ColNombre = 1;
        public const int ColTelefono = 2;
        public const int ColEmail = 3;
        public const int ColDireccion = 4;
        public const int ColGrafico = 5;
        public const int ColGrafico2 = 6;
        string dniglobal;//VARIABLE UTILIZADA PARA PODER MODIFICAR EL DNI AUNQUE SEA CLAVE PRIMARIA
        private List<Cliente> registro;
        private List<Cuenta> cuentas;
        private List<Transferencia> transferencias;

        public MainWindow(List<Cliente> clientes,List<Cuenta> cuentas, List<Transferencia> transferencias)
        {
        this.registro = clientes;
        this.cuentas = cuentas;
        this.transferencias = transferencias;

            this.Build();


            this.anhadirView = new AnhadirView();
            this.buscarView = new BuscarView();
            this.editarView = new EditarView();

            this.buscarView.tituloencontrado.Visible = false;
            this.buscarView.cliente.Visible = false;
            this.buscarView.BtEliminar.Visible = false;
            this.buscarView.BtEditar.Visible = false;

            //Cuando se pulsa en el botón de anhadir salta al método OnBtAnhadeAnhadirClick
            this.anhadirView.BtAnhadir.Click += (sender, args) => this.OnBtAnhadeAnhadirClick();
            this.buscarView.BtBuscar.Click += (sender, args) => this.OnBtBuscar2Click();
            this.buscarView.BtEliminar.Click += (sender, args) => this.OnBtEliminarBuscarClick();
            this.buscarView.BtEditar.Click += (sender, args) => this.OnBtEditarBuscarClick();
            this.editarView.BtEditar.Click += (sender, args) => this.OnBtEditarBuscar2Click();
            
            this.Actualiza();
        }

        //Método para mostrar el gráfico al clickar en la opción de gráfico
        private void OnBtGraficoClick()
        {
            int fila;
            int columna;
            fila = this.grdLista.CurrentRow.Index;
            columna = this.grdLista.CurrentCell.ColumnIndex;
            Cliente cliente = Banco.getCliente(this.grdLista.CurrentRow.Cells[0].Value.ToString(), this.registro);

            if (columna == 5)
            {
                GraficoControlView gcv = new GraficoControlView();
                gcv.Cuentas = this.cuentas;
                gcv.Transferencias = this.transferencias;
                gcv.Cliente = cliente;
                gcv.OnCrearGraficoSaldoCliente();

            }
            if (columna == 6)
            {
                GraficoControlView gcv = new GraficoControlView();
                gcv.Cuentas = this.cuentas;
                gcv.Transferencias = this.transferencias;
                gcv.Cliente = cliente;
                gcv.OnCrearGraficoCliente();

            }

        }

        //Método que actualiza la tabla
        private void Actualiza()
        {
            DateTime ahora = DateTime.Now;

            this.sbStatus.Text = "Número de clientes: " + this.registro.Count.ToString()
                            + " | " + ahora.ToShortDateString()
                            + " | " + ahora.ToShortTimeString();

            this.ActualizaLista(0);
        }


        //Método que actualiza el número de filas de la tabla
        private void ActualizaLista(int numRow)
        {
            int numClientes = this.registro.Count;

            // Crea y actualiza filas
            for (int i = numRow; i < numClientes; ++i)
            {
                if (this.grdLista.Rows.Count <= i)
                {
                    this.grdLista.Rows.Add();
                }

                this.ActualizaFilaDeLista(i);
            }

            // Eliminar filas sobrantes
            int numExtra = this.grdLista.Rows.Count - numClientes;
            for (; numExtra > 0; --numExtra)
            {
                this.grdLista.Rows.RemoveAt(numClientes);
            }

            return;
        }

        //Método que actualiza la lista de clientes
        private void ActualizaFilaDeLista(int rowIndex)
        {
            if (rowIndex < 0
              || rowIndex > this.grdLista.Rows.Count)
            {
                throw new System.ArgumentOutOfRangeException(
                            "fila fuera de rango: " + nameof(rowIndex));
            }

            DataGridViewRow row = this.grdLista.Rows[rowIndex];
            Cliente cliente = registro.ElementAt(rowIndex); ;

            // Assign data
            row.Cells[ColDni].Value = cliente.Dni;
            row.Cells[ColNombre].Value = cliente.Nombre;
            row.Cells[ColTelefono].Value = cliente.Telefono;
            row.Cells[ColEmail].Value = cliente.Email;
            row.Cells[ColDireccion].Value = cliente.DirPostal;
            row.Cells[ColGrafico].Value = "Generar Gráfico Saldo";
            row.Cells[ColGrafico2].Value = "Generar Gráfico Ingresos";

            // Assign tooltip text
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ToolTipText = registro.ToString();
            }

            return;
        }

        

        //Muestro los datos de la fila seleccionada en el panel de detalle
        private void FilaSeleccionada()
        {
            int fila;
            //Comprueba que la tabla no está vacía al meter la fila
            if (this.grdLista.RowCount>0)
            {
                fila = this.grdLista.CurrentRow.Index;
            }
            else
            {
                fila = 0;
            }

                if (this.registro.Count > fila)
                {
                    this.edDetalle.Text = this.registro.ElementAt(fila).ToString();
                    this.edDetalle.SelectionStart = this.edDetalle.Text.Length;
                    this.edDetalle.SelectionLength = 0;
                }
                else
                {
                    this.edDetalle.Clear();
                }

                return;
        }



        //Al pulsar en el menú superior en añadir cliente se salta a la vista de añadir
        private void onBtAnhadeClick()
        {
            this.anhadirView.ShowDialog();
            this.anhadirView.dni.Text = "";
        }

        //Método que añade el cliente cuando se pulsa en añadir cliente en la vista añadir
        void OnBtAnhadeAnhadirClick()
        {
            string dni;
            string nombre;
            string telefono;
            string email;
            string direccion;
            Boolean existe = false;//variable para ver si el dni está ya asignado

            //Compruebo el formato del dni
            //Compruebo si está vacío
            if (string.IsNullOrEmpty(this.anhadirView.dni.Text))
            {
                WForms.MessageBox.Show("El campo del dni está vacío", "ERROR");
                dni = null;
                return; //Salimos
            }

            //Compruebo que ningñun usuario tiene ese dni asignado ya
            if (registro.Count > 0)
            {
                foreach (Cliente cli in registro)
                {
                    if (this.anhadirView.dni.Text.Equals(cli.Dni))
                    {
                        existe = true;
                    }
                }
            }
            if (existe)//si existe salgo
            {
                WForms.MessageBox.Show("Ya existe un usuario con ese dni", "ERROR");
                return;
            }
            //Compruebo si el formato y la letra so correctos
            if (!string.IsNullOrEmpty(this.anhadirView.dni.Text) && !comprobarDni(this.anhadirView.dni.Text))
            {
                WForms.MessageBox.Show("Error de formato en el DNI", "ERROR");
                dni = null;
                return;
            }
            //si es correcto meto el valor en la variable
            else
            {
                dni = this.anhadirView.dni.Text;
            }




            //Compruebo el formato del nombre
            //Compruebo si está vacío 
            if (string.IsNullOrEmpty(this.anhadirView.nombre.Text))
            {
                WForms.MessageBox.Show("El campo del nombre está vacío", "ERROR");
                return; //Salimos
            }
            //Compruebo si solo contiene letras y espacios
            Regex temp = new Regex(@"^[a-zA-Z-ÁÉÍÓÚáéíóúñÑ ]+$");
            if (!temp.IsMatch(this.anhadirView.nombre.Text))
            {
                WForms.MessageBox.Show("El campo del nombre solo debe contener letras", "ERROR");
                return; //Salimos
            }
            //Si es correcto lo meto en la variable
            else
            {
                nombre = this.anhadirView.nombre.Text;
            }





            //Compruebo el formato del teléfono
            //Compruebo si está vacío
            if (string.IsNullOrEmpty(this.anhadirView.telefono.Text))
            {
                WForms.MessageBox.Show("El campo del teléfono está vacío", "ERROR");
                return; //Salimos
            }
            //Compruebo el formato
            Regex temp2 = new Regex(@"^(\+34)?\d{9}$");
            if (!temp2.IsMatch(this.anhadirView.telefono.Text))
            {
                WForms.MessageBox.Show("El campo del teléfono no tiene el formato correcto", "ERROR");
                return; //Salimos
            }
            //Si es correcto lo meto en la variable
            else
            {
                telefono = this.anhadirView.telefono.Text;
            }






            //Compruebo el formato del email
            //Compruebo que no es vacío
            if (string.IsNullOrEmpty(this.anhadirView.email.Text))
            {
                WForms.MessageBox.Show("El campo del email está vacío", "ERROR");
                return; //Salimos
            }
            //Compruebo el formato del email
            Regex temp1 = new Regex(@"^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$");
            if (!temp1.IsMatch(this.anhadirView.email.Text))
            {
                WForms.MessageBox.Show("El campo del email no tiene el formato correcto", "ERROR");
                return; //Salimos
            }
            //Si es correcto lo meto en la variable
            else
            {
                email = this.anhadirView.email.Text;
            }






            //Compruebo el formato de la dirección
            if (string.IsNullOrEmpty(this.anhadirView.direccion.Text))
            {
                WForms.MessageBox.Show("El campo del dirección postal está vacío", "ERROR");
                return; //Salimos
            }
            //Si es correcto lo meto en la variable
            else
            {
                direccion = this.anhadirView.direccion.Text;
            }


            Cliente c = new Cliente(dni, nombre, telefono, email, direccion);
            registro.Add(c);

            this.anhadirView.dni.Text = null;
            this.anhadirView.nombre.Text = null;
            this.anhadirView.telefono.Text = null;
            this.anhadirView.email.Text = null;
            this.anhadirView.direccion.Text = null;


            WForms.MessageBox.Show("Ha sido añadido el cliente: \n" + c.ToString(), "Cliente añadido");
            //Actualizo la tabla
            this.Actualiza();
            this.anhadirView.Close();
        }

        private Boolean comprobarDni(string dni)
        {
            const string correspondencia = "TRWAGMYFPDXBNJZSQVHLCKET";
            string temp = string.Empty;
            string letra = string.Empty;
            int dniNumber;

            if (dni.Length != 9)
            {
                return false;
            }

            Int32.TryParse(dni.Substring(0, 8), out dniNumber);

            // Check NIF format.
            if (!System.Text.RegularExpressions.Regex.IsMatch(dni, @"[0-9]{8,10}[" + correspondencia + "]$"))
            {
                return false;
            }

            temp = string.Empty;
            Int32.TryParse(dni.Substring(0, 8), out dniNumber);
            letra = dni.LastOrDefault().ToString();

            // Check letter.
            if (letra != GetLetraDni(dniNumber))
            {
                return false;
            }

            return true;
        }

        private string GetLetraDni(int numeroDNI)
        {
            const string correspondencia = "TRWAGMYFPDXBNJZSQVHLCKET";
            int index = numeroDNI % 23;
            return correspondencia[index].ToString();
        }



        //SI pulso el botón de buscar en la ventana principal me lleva a la ventana de buscar
        void OnBtBuscarClick()
        {
            this.buscarView.ShowDialog();
            this.buscarView.dni.Text = "";
            this.buscarView.tituloencontrado.Visible = false;
            this.buscarView.cliente.Text = "";
            this.buscarView.cliente.Visible = false;
            this.buscarView.BtEliminar.Visible = false;
            this.buscarView.BtEditar.Visible = false;
        }


        //Método que se lanza al pulsar el botón de buscar dentro del menú de búsqueda
        void OnBtBuscar2Click()
        {
            string dnibuscar;
            Boolean temp = false;

            //Compruebo el formato del dni
            //Compruebo si está vacío
            if (string.IsNullOrEmpty(this.buscarView.dni.Text))
            {
                this.buscarView.tituloencontrado.Visible = false;
                this.buscarView.cliente.Text = "";
                this.buscarView.cliente.Visible = false;
                this.buscarView.BtEliminar.Visible = false;
                this.buscarView.BtEditar.Visible = false;
                WForms.MessageBox.Show("El campo del dni está vacío", "ERROR");
                dnibuscar = null;
                return; //Salimos
            }
            //Compruebo si el formato y la letra so correctos
            if (!string.IsNullOrEmpty(this.buscarView.dni.Text) && !comprobarDni(this.buscarView.dni.Text))
            {
                this.buscarView.tituloencontrado.Visible = false;
                this.buscarView.cliente.Text = "";
                this.buscarView.cliente.Visible = false;
                this.buscarView.BtEliminar.Visible = false;
                this.buscarView.BtEditar.Visible = false;
                WForms.MessageBox.Show("Error de formato en el DNI", "ERROR");
                dnibuscar = null;
                return;
            }
            //si es correcto meto el valor en la variable
            dnibuscar = this.buscarView.dni.Text;

            foreach (Cliente c in registro)
            {
                if (dnibuscar.Equals(c.Dni))
                {
                    this.buscarView.tituloencontrado.Visible = true;
                    this.buscarView.cliente.Text = c.ToString();
                    this.buscarView.cliente.Visible = true;
                    this.buscarView.BtEliminar.Visible = true;
                    this.buscarView.BtEditar.Visible = true;
                    temp = true;
                }
            }
            if (temp == false)
            {
                this.buscarView.tituloencontrado.Visible = false;
                this.buscarView.cliente.Text = "";
                this.buscarView.cliente.Visible = false;
                this.buscarView.BtEliminar.Visible = false;
                this.buscarView.BtEditar.Visible = false;
                WForms.MessageBox.Show("No hemos encontrado ningún cliente con ese dni", "Buscar cliente");
            }
        }

        //Cuando se pulsa para eliminar un cliente desde la pantalla de buscar un cliente
        void OnBtEliminarBuscarClick()
        {
            string dnieliminar = this.buscarView.dni.Text;
            StringBuilder toret = new StringBuilder();
            Cliente temp = null;

            foreach (Cliente c in registro)
            {
                if (dnieliminar.Equals(c.Dni))
                {
                    toret.Append(c.ToString());
                    temp = c;
                }
            }
            registro.Remove(temp);

            this.Actualiza();
            WForms.MessageBox.Show("Se ha eliminado el cliente con los datos: \n" + toret, "Eliminar cliente");
            this.buscarView.Close();
        }

        void OnBtEditarBuscarClick()
        { 
            string dnieditar = this.buscarView.dni.Text;
            foreach (Cliente c in registro)
            {
                if (dnieditar.Equals(c.Dni))
                {
                    this.editarView.dni.Text = c.Dni;
                    this.editarView.nombre.Text =c.Nombre;
                    this.editarView.telefono.Text=c.Telefono;
                    this.editarView.email.Text = c.Email;
                    this.editarView.direccion.Text = c.DirPostal;
                } 
            }
            dniglobal = this.buscarView.dni.Text;
            editarView.ShowDialog();

        }

        void OnBtEditarBuscar2Click()
        {
            //dniglobal = this.buscarView.dni.Text;
            Boolean existe = false;//variable para comprobar si el dni está asignado a un usaurio ya
            foreach (Cliente c in registro)
            {
                if (dniglobal.Equals(c.Dni))
                {

                    //Meto y compruebo los datos de los textbox para el cliente
                    //Compruebo el formato del dni
                    //Compruebo si está vacío
                    if (string.IsNullOrEmpty(this.editarView.dni.Text))
                    {
                        WForms.MessageBox.Show("El campo del dni está vacío", "ERROR");
                        return; //Salimos
                    }
                    //Compruebo que ningñun usuario tiene ese dni asignado ya
                    foreach (Cliente cli in registro)
                    {
                        if (this.editarView.dni.Text.Equals(cli.Dni))
                        {
                            existe = true;
                        }
                        if (this.editarView.dni.Text.Equals(dniglobal))//Si dejo el dni que ya estaba puesto
                        {
                            existe = false;
                        }
                    }
                    if (existe)//si existe salgo
                    {
                        WForms.MessageBox.Show("Ya existe un usuario con ese dni", "ERROR");
                        return;
                    }
                    //Compruebo si el formato y la letra so correctos
                    if (!string.IsNullOrEmpty(this.editarView.dni.Text) && !comprobarDni(this.editarView.dni.Text))
                    {
                        WForms.MessageBox.Show("Error de formato en el DNI", "ERROR");
                        return;
                    }
                    //si es correcto meto el valor en la variable
                    else
                    {
                        c.Dni = this.editarView.dni.Text;
                    }



                    //Compruebo el formato del nombre
                    //Compruebo si está vacío 
                    if (string.IsNullOrEmpty(this.editarView.nombre.Text))
                    {
                        WForms.MessageBox.Show("El campo del nombre está vacío", "ERROR");
                        return; //Salimos
                    }
                    //Compruebo si solo contiene letras y espacios
                    Regex temp = new Regex(@"^[a-zA-Z-ÁÉÍÓÚáéíóúñÑ ]+$");
                    if (!temp.IsMatch(this.editarView.nombre.Text))
                    {
                        WForms.MessageBox.Show("El campo del nombre solo debe contener letras", "ERROR");
                        return; //Salimos
                    }
                    //Si es correcto lo meto en la variable
                    else
                    {
                        c.Nombre = this.editarView.nombre.Text;
                    }



                    //Compruebo el formato del teléfono
                    //Compruebo si está vacío
                    if (string.IsNullOrEmpty(this.editarView.telefono.Text))
                    {
                        WForms.MessageBox.Show("El campo del teléfono está vacío", "ERROR");
                        return; //Salimos
                    }
                    //Compruebo el formato
                    Regex temp2 = new Regex(@"^(\+34)?\d{9}$");
                    if (!temp2.IsMatch(this.editarView.telefono.Text))
                    {
                        WForms.MessageBox.Show("El campo del teléfono no tiene el formato correcto", "ERROR");
                        return; //Salimos
                    }
                    //Si es correcto lo meto en la variable
                    else
                    {
                        c.Telefono = this.editarView.telefono.Text;
                    }


                    //Compruebo el formato del email
                    //Compruebo que no es vacío
                    if (string.IsNullOrEmpty(this.editarView.email.Text))
                    {
                        WForms.MessageBox.Show("El campo del email está vacío", "ERROR");
                        return; //Salimos
                    }
                    //Compruebo el formato del email
                    Regex temp1 = new Regex(@"^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$");
                    if (!temp1.IsMatch(this.editarView.email.Text))
                    {
                        WForms.MessageBox.Show("El campo del email no tiene el formato correcto", "ERROR");
                        return; //Salimos
                    }
                    //Si es correcto lo meto en la variable
                    else
                    {
                        c.Email = this.editarView.email.Text;
                    }


                    //Compruebo el formato de la dirección
                    if (string.IsNullOrEmpty(this.editarView.direccion.Text))
                    {
                        WForms.MessageBox.Show("El campo del dirección postal está vacío", "ERROR");
                        return; //Salimos
                    }
                    //Si es correcto lo meto en la variable
                    else
                    {
                        c.DirPostal = this.editarView.direccion.Text;
                    }

                    WForms.MessageBox.Show("El cliente se ha actualizado correctamente", "Editar cliente");

                    //Vacío la vista de la información modificada
                    this.editarView.dni.Text = "";

                    //Actualizo la vista del panel de detalle
                    this.edDetalle.Text = c.ToString();

                    //Actualizo los datos del cliente en la vista de la búsqueda
                    this.buscarView.cliente.Text = c.ToString();
                }
            }

            this.Actualiza();
            this.editarView.Close();
        }



        //Cuando se pulsa para eliminar un cliente desde el botón eliminar el cliente seleccioinado en la tabla
        void OnBtEliminarMenuClick()
        {
            int fila;
            //Comprueba que la tabla no está vacía para eliminar un cliente
            if (this.grdLista.RowCount > 0)
            {
                fila = this.grdLista.CurrentRow.Index;
            }
            else
            {
                WForms.MessageBox.Show("No hay clientes que eliminar", "Eliminar cliente");
                return;
            }
            string dnieliminar = this.registro.ElementAt(fila).Dni;
            StringBuilder toret = new StringBuilder();

            Cliente temp=null;
            foreach (Cliente c in registro)
            {
                if (dnieliminar.Equals(c.Dni))
                {
                    toret.Append(c.ToString());
                    temp = c;
                }
            }
            registro.Remove(temp);

            this.Actualiza();
            WForms.MessageBox.Show("Se ha eliminado el cliente con los datos: \n" + toret, "Eliminar cliente");
        }

        //Método para cuando se pulsa en el editar cliente del menú
        void OnBtEditarMenuClick()
        {
            int fila;
            //Comprueba que la tabla no está vacía para eliminar un cliente
            if (this.grdLista.RowCount > 0)
            {
                fila = this.grdLista.CurrentRow.Index;
            }
            else
            {
                WForms.MessageBox.Show("No hay clientes que eliminar", "Eliminar cliente");
                return;
            }
            string dnieditar = this.registro.ElementAt(fila).Dni;
            foreach (Cliente c in registro)
            {
                if (dnieditar.Equals(c.Dni))
                {
                    this.editarView.dni.Text = c.Dni;
                    this.editarView.nombre.Text = c.Nombre;
                    this.editarView.telefono.Text = c.Telefono;
                    this.editarView.email.Text = c.Email;
                    this.editarView.direccion.Text = c.DirPostal;
                    dniglobal = c.Dni;
                }
            }
            editarView.ShowDialog();

        }
        public BuscarView buscarView { get; }
        public AnhadirView anhadirView { get; }
        public EditarView editarView { get; }


    }
}




