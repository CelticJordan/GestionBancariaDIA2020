using Clientes.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clientes.Ui
{
    using WForms = System.Windows.Forms;
    class MainWindowCtrl
    {
        string dniglobal;//VARIABLE UTILIZADA PARA PODER MODIFICAR EL DNI AUNQUE SEA CLAVE PRIMARIA
        registroClientes registro = new registroClientes();

        public MainWindowCtrl()
        {
            this.View = new MainWindowView();
            this.buscarView = new BuscarView();
            this.editarView = new EditarView();
            this.eliminarView = new EliminarView();


            this.View.BtAnhade.Click += (sender, args) => this.OnBtAnhadeClick();
            this.View.BtListar.Click += (sender, args) => this.OnBtListarClick();
            this.View.BtBuscar.Click += (sender, args) => this.OnBtBuscarClick();
            this.buscarView.BtBuscar.Click += (sender, args) => this.OnBtBuscar2Click();
            this.View.BtEditar.Click += (sender, args) => this.OnBtEditarClick();
            this.editarView.BtBuscar.Click += (sender, args) => this.OnBtBuscarEditarClick();
            this.editarView.BtEditar.Click += (sender, args) => this.OnBtEditar2Click();
            this.View.BtEliminar.Click += (sender, args) => this.OnBtEliminarClick();
            this.eliminarView.BtBuscar.Click += (sender, args) => this.OnBtBuscarEliminarClick();
            this.eliminarView.BtEliminar.Click += (sender, args) => this.OnBtEliminar2Click();

            //Oculto las cajas de texto de la vista de edit
            this.editarView.titulonombre.Visible = false;
            this.editarView.nombre.Visible = false;
            this.editarView.titulotelefono.Visible = false;
            this.editarView.telefono.Visible = false;
            this.editarView.tituloemail.Visible = false;
            this.editarView.email.Visible = false;
            this.editarView.titulodireccion.Visible = false;
            this.editarView.direccion.Visible = false;
            this.editarView.BtEditar.Visible = false;

            //Oculto las cajas de texto de la vista de delete
            this.eliminarView.titulonombre.Visible = false;
            this.eliminarView.nombre.Visible = false;
            this.eliminarView.titulotelefono.Visible = false;
            this.eliminarView.telefono.Visible = false;
            this.eliminarView.tituloemail.Visible = false;
            this.eliminarView.email.Visible = false;
            this.eliminarView.titulodireccion.Visible = false;
            this.eliminarView.direccion.Visible = false;
            this.eliminarView.BtEliminar.Visible = false;
        }

        void OnBtAnhadeClick()
        {
            string dni;
            string nombre;
            string telefono;
            string email;
            string direccion;
            Boolean existe = false;//variable para ver si el dni está ya asignado

            //Compruebo el formato del dni
            //Compruebo si está vacío
            if (string.IsNullOrEmpty(this.View.dni.Text))
            {
                WForms.MessageBox.Show("El campo del dni está vacío", "ERROR");
                dni = null;
                return; //Salimos
            }

            //Compruebo que ningñun usuario tiene ese dni asignado ya
            foreach (Cliente cli in registro)
            {
                if (this.View.dni.Text.Equals(cli.Dni))
                {
                    existe = true;
                }
            }
            if (existe)//si existe salgo
            {
                WForms.MessageBox.Show("Ya existe un usuario con ese dni", "ERROR");
                return;
            }
            //Compruebo si el formato y la letra so correctos
            if (!string.IsNullOrEmpty(this.View.dni.Text) && !comprobarDni(this.View.dni.Text))
            {
                WForms.MessageBox.Show("Error de formato en el DNI", "ERROR");
                dni = null;
                return;
            }
            //si es correcto meto el valor en la variable
            else
            {
                dni = this.View.dni.Text;
            }




            //Compruebo el formato del nombre
            //Compruebo si está vacío 
            if (string.IsNullOrEmpty(this.View.nombre.Text))
            {
                WForms.MessageBox.Show("El campo del nombre está vacío", "ERROR");
                return; //Salimos
            }
            //Compruebo si solo contiene letras y espacios
            Regex temp = new Regex(@"^[a-zA-Z-ÁÉÍÓÚáéíóúñÑ ]+$");
            if (!temp.IsMatch(this.View.nombre.Text))
            {
                WForms.MessageBox.Show("El campo del nombre solo debe contener letras", "ERROR");
                return; //Salimos
            }
            //Si es correcto lo meto en la variable
            else
            {
                nombre = this.View.nombre.Text;
            }





            //Compruebo el formato del teléfono
            //Compruebo si está vacío
            if (string.IsNullOrEmpty(this.View.telefono.Text))
            {
                WForms.MessageBox.Show("El campo del teléfono está vacío", "ERROR");
                return; //Salimos
            }
            //Compruebo el formato
            Regex temp2 = new Regex(@"^(\+34)?\d{9}$");
            if (!temp2.IsMatch(this.View.telefono.Text))
            {
                WForms.MessageBox.Show("El campo del teléfono no tiene el formato correcto", "ERROR");
                return; //Salimos
            }
            //Si es correcto lo meto en la variable
            else
            {
                telefono = this.View.telefono.Text;
            }






            //Compruebo el formato del email
            //Compruebo que no es vacío
            if (string.IsNullOrEmpty(this.View.email.Text))
            {
                WForms.MessageBox.Show("El campo del email está vacío", "ERROR");
                return; //Salimos
            }
            //Compruebo el formato del email
            Regex temp1 = new Regex(@"^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$");
            if (!temp1.IsMatch(this.View.email.Text))
            {
                WForms.MessageBox.Show("El campo del email no tiene el formato correcto", "ERROR");
                return; //Salimos
            }
            //Si es correcto lo meto en la variable
            else
            {
                email = this.View.email.Text;
            }






            //Compruebo el formato de la dirección
            if (string.IsNullOrEmpty(this.View.direccion.Text))
            {
                WForms.MessageBox.Show("El campo del dirección postal está vacío", "ERROR");
                return; //Salimos
            }
            //Si es correcto lo meto en la variable
            else
            {
                direccion = this.View.direccion.Text;
            }


            Cliente c = new Cliente(dni, nombre, telefono, email, direccion);
            registro.Add(c);

            this.View.dni.Text = null;
            this.View.nombre.Text = null;
            this.View.telefono.Text = null;
            this.View.email.Text = null;
            this.View.direccion.Text = null;


            WForms.MessageBox.Show("Ha sido añadido el cliente: \n" + c.ToString(), "Cliente añadido");
        }

        void OnBtListarClick()
        {
            WForms.MessageBox.Show(this.registro.ToString(), "Listado de clientes");
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
                WForms.MessageBox.Show("El campo del dni está vacío", "ERROR");
                dnibuscar = null;
                return; //Salimos
            }
            //Compruebo si el formato y la letra so correctos
            if (!string.IsNullOrEmpty(this.buscarView.dni.Text) && !comprobarDni(this.buscarView.dni.Text))
            {
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
                    WForms.MessageBox.Show("Este es el usuario que hemos encontrado con ese dni: \n`" + c.ToString(), "Buscar cliente");
                    temp = true;
                }
            }
            if (temp == false)
            {
                WForms.MessageBox.Show("No hemos encontrado ningún cliente con ese dni", "Buscar cliente");
            }
        }


        //SI pulso el botón de buscar en la ventana principal me lleva a la ventana de editar
        void OnBtEditarClick()
        {
            this.editarView.ShowDialog();
            this.editarView.dni.Text = "";
            this.editarView.titulonombre.Visible = false;
            this.editarView.nombre.Visible = false;
            this.editarView.titulotelefono.Visible = false;
            this.editarView.telefono.Visible = false;
            this.editarView.tituloemail.Visible = false;
            this.editarView.email.Visible = false;
            this.editarView.titulodireccion.Visible = false;
            this.editarView.direccion.Visible = false;
            this.editarView.BtEditar.Visible = false;
            this.editarView.BtBuscar.Visible = true;
        }

        void OnBtBuscarEditarClick()
        {

            string dnieditar;
            Boolean temp = false;

            //Compruebo el formato del dni
            //Compruebo si está vacío
            if (string.IsNullOrEmpty(this.editarView.dni.Text))
            {
                WForms.MessageBox.Show("El campo del dni está vacío", "ERROR");
                dnieditar = null;
                return; //Salimos
            }
            //Compruebo si el formato y la letra so correctos
            if (!string.IsNullOrEmpty(this.editarView.dni.Text) && !comprobarDni(this.editarView.dni.Text))
            {
                WForms.MessageBox.Show("Error de formato en el DNI", "ERROR");
                dnieditar = null;
                return;
            }
            //si es correcto meto el valor en la variable
            dnieditar = this.editarView.dni.Text;

            foreach (Cliente c in registro)
            {
                if (dnieditar.Equals(c.Dni))
                {
                    //Pongo las vistas a true para editar el cliente
                    this.editarView.titulonombre.Visible = true;
                    this.editarView.nombre.Visible = true;
                    this.editarView.titulotelefono.Visible = true;
                    this.editarView.telefono.Visible = true;
                    this.editarView.tituloemail.Visible = true;
                    this.editarView.email.Visible = true;
                    this.editarView.titulodireccion.Visible = true;
                    this.editarView.direccion.Visible = true;
                    this.editarView.BtEditar.Visible = true;
                    this.editarView.nombre.Text = c.Nombre;
                    this.editarView.telefono.Text = c.Telefono;
                    this.editarView.email.Text = c.Email;
                    this.editarView.direccion.Text = c.DirPostal;
                    dniglobal = this.editarView.dni.Text;

                    temp = true;
                }
            }
            if (temp == false)
            {
                this.editarView.titulonombre.Visible = false;
                this.editarView.nombre.Visible = false;
                this.editarView.titulotelefono.Visible = false;
                this.editarView.telefono.Visible = false;
                this.editarView.tituloemail.Visible = false;
                this.editarView.email.Visible = false;
                this.editarView.titulodireccion.Visible = false;
                this.editarView.direccion.Visible = false;
                this.editarView.BtEditar.Visible = false;
                WForms.MessageBox.Show("No hemos encontrado ningún cliente con ese dni", "Editar cliente");
            }
            //oculto el botón de buscar
            this.editarView.BtBuscar.Visible = false;
        }

        //Se lanza cuando pulso en el editar de la ventana de editar
        void OnBtEditar2Click() {

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

                    this.editarView.titulonombre.Visible = false;
                    this.editarView.nombre.Visible = false;
                    this.editarView.titulotelefono.Visible = false;
                    this.editarView.telefono.Visible = false;
                    this.editarView.tituloemail.Visible = false;
                    this.editarView.email.Visible = false;
                    this.editarView.titulodireccion.Visible = false;
                    this.editarView.direccion.Visible = false;
                    this.editarView.BtEditar.Visible = false;
                    this.editarView.BtBuscar.Visible = true;
                }
            }
        }

        //Se lanza al pulsar el botón eliminar del menú principal
        void OnBtEliminarClick()
        { 


            this.eliminarView.ShowDialog();
            this.eliminarView.dni.Text = "";
            this.eliminarView.titulonombre.Visible = false;
            this.eliminarView.nombre.Visible = false;
            this.eliminarView.titulotelefono.Visible = false;
            this.eliminarView.telefono.Visible = false;
            this.eliminarView.tituloemail.Visible = false;
            this.eliminarView.email.Visible = false;
            this.eliminarView.titulodireccion.Visible = false;
            this.eliminarView.direccion.Visible = false;
            this.eliminarView.BtEliminar.Visible = false;

            //muestro el botón de buscar
            this.eliminarView.BtBuscar.Visible = true;

            this.eliminarView.dni.ReadOnly = false;
        }

        //Botón para buscar en la ventana de eliminar
        void OnBtBuscarEliminarClick()
        {
            string dnieliminar;
            Boolean temp = false;

            //Compruebo el formato del dni
            //Compruebo si está vacío
            if (string.IsNullOrEmpty(this.eliminarView.dni.Text))
            {
                WForms.MessageBox.Show("El campo del dni está vacío", "ERROR");
                return; //Salimos
            }
            //Compruebo si el formato y la letra so correctos
            if (!string.IsNullOrEmpty(this.eliminarView.dni.Text) && !comprobarDni(this.eliminarView.dni.Text))
            {
                WForms.MessageBox.Show("Error de formato en el DNI", "ERROR");
                return;
            }
            //si es correcto meto el valor en la variable
            dnieliminar = this.eliminarView.dni.Text;

            foreach (Cliente c in registro)
            {
                if (dnieliminar.Equals(c.Dni))
                {
                    //Pongo las vistas a true para editar el cliente
                    this.eliminarView.titulonombre.Visible = true;
                    this.eliminarView.nombre.Visible = true;
                    this.eliminarView.titulotelefono.Visible = true;
                    this.eliminarView.telefono.Visible = true;
                    this.eliminarView.tituloemail.Visible = true;
                    this.eliminarView.email.Visible = true;
                    this.eliminarView.titulodireccion.Visible = true;
                    this.eliminarView.direccion.Visible = true;
                    this.eliminarView.BtEliminar.Visible = true;
                    this.eliminarView.nombre.Text = c.Nombre;
                    this.eliminarView.telefono.Text = c.Telefono;
                    this.eliminarView.email.Text = c.Email;
                    this.eliminarView.direccion.Text = c.DirPostal;

                    //Hago que no se pueda modificar el dni al encontrar el cliente a eliminar
                    this.eliminarView.dni.ReadOnly = true;

                    //Oculto el botón de buscar
                    this.eliminarView.BtBuscar.Visible = false;

                    temp = true;
                }
            }
            if (temp == false)
            {
                this.eliminarView.titulonombre.Visible = false;
                this.eliminarView.nombre.Visible = false;
                this.eliminarView.titulotelefono.Visible = false;
                this.eliminarView.telefono.Visible = false;
                this.eliminarView.tituloemail.Visible = false;
                this.eliminarView.email.Visible = false;
                this.eliminarView.titulodireccion.Visible = false;
                this.eliminarView.direccion.Visible = false;
                this.eliminarView.BtEliminar.Visible = false;

                this.eliminarView.dni.ReadOnly = false;

                //Muestro el botón de buscar para buscar un cliente
                this.eliminarView.BtBuscar.Visible = true;

                WForms.MessageBox.Show("No hemos encontrado ningún cliente con ese dni", "Eliminar cliente");
            }
        }

        //Botón eliminar de la pantalla de eliminar
        void OnBtEliminar2Click () {
            string dnieliminar = this.eliminarView.dni.Text;
            StringBuilder toret = new StringBuilder();

            foreach (Cliente c in registro)
            {
                if (dnieliminar.Equals(c.Dni))
                {
                    //Pongo las vistas a true para editar el cliente
                    this.eliminarView.titulonombre.Visible = true;
                    this.eliminarView.nombre.Visible = true;
                    this.eliminarView.titulotelefono.Visible = true;
                    this.eliminarView.telefono.Visible = true;
                    this.eliminarView.tituloemail.Visible = true;
                    this.eliminarView.email.Visible = true;
                    this.eliminarView.titulodireccion.Visible = true;
                    this.eliminarView.direccion.Visible = true;
                    this.eliminarView.BtEliminar.Visible = true;
                    this.eliminarView.nombre.Text = c.Nombre;
                    this.eliminarView.telefono.Text = c.Telefono;
                    this.eliminarView.email.Text = c.Email;
                    this.eliminarView.direccion.Text = c.DirPostal;


                    toret.Append(c.ToString());
                    registro.Remove(c);
                }
            }

            WForms.MessageBox.Show("Se ha eliminado el cliente con los datos: \n" + toret, "Eliminar cliente");
            this.eliminarView.Close();
        }

        public MainWindowView View { get; }
        public BuscarView buscarView { get; }
        public EditarView editarView { get; }
        public EliminarView eliminarView { get; }


    }
}
