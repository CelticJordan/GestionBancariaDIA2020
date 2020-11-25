using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DIA_P2_banco.Cuentas;

namespace DIA_P2_banco
{
    public partial class GestionCuenta : Form
    {
        public List<Cuenta> cuentas;
        public List<Cliente> clientes;

        public GestionCuenta()
        {
            InitializeComponent();
            cuentas = new List<Cuenta>();
            clientes = new List<Cliente>();

            Cliente cli1 = new Cliente("Rubén Solveira", "76735813Q");
            Cliente cli2 = new Cliente("Xoel Molinos", "55555555P");
            Cliente cli3 = new Cliente("Ana Rodriguez", "11111111M");
            Cliente cli4 = new Cliente("Vegeta", "77777777V");
            Cliente cli5 = new Cliente("Ruben titular 2", "81759827P");
            clientes.Add(cli1);
            clientes.Add(cli2);
            clientes.Add(cli3);
            clientes.Add(cli4);
            clientes.Add(cli5);

            Cuenta cue1 = new CuentaAhorro("11111111111111111111", cli1);
            cue1.Saldo = 1000;
            cue1.Titulares.Add(cli5);
            Cuenta cue2 = new CuentaAhorro("22222222222222222222", cli2);
            cue2.Saldo = 12345;
            Cuenta cue3 = new CuentaAhorro("33333333333333333333", cli3);
            cue3.Saldo = 5321;

            cue1.Depositos.Add(new Cuenta.Deposito("nomina diciembre", 1500.23f));
            cue1.Depositos.Add(new Cuenta.Deposito("nomina enero", 3200.23f));
            cue2.Depositos.Add(new Cuenta.Deposito("nomina febrero", 1650.23f));

            cue1.Retiradas.Add(new Cuenta.Retirada("pedido amazon 121", 499.99f));
            cue1.Retiradas.Add(new Cuenta.Retirada("pedido amazon 532", 99.99f));
            cue3.Retiradas.Add(new Cuenta.Retirada("pedido amazon 689", 1499.99f));

            cuentas.Add(cue1);
            cuentas.Add(cue2);
            cuentas.Add(cue3);
        }

        /// <summary>
        /// Pone los datos de <see cref="cuentas"/> en el DataGrid de cuentas
        /// </summary>
        private void RefrescarGridCuentas(List<Cuenta> lsCuenta)
        {
            dataGridCuentas.DataSource = null; //Borrar todos los objetos almacenados en el datagrid
            dataGridCuentas.Rows.Clear();
            int i = 0;

            //Almacenamos en el datagrid cada cuenta que tenemos en nuestra lista.
            foreach (Cuenta cuenta in lsCuenta)
            {
                dataGridCuentas.Rows.Add();
                dataGridCuentas.Rows[i].Cells[0].Value = cuenta.CCC;
                dataGridCuentas.Rows[i].Cells[1].Value = cuenta.Tipo;
                dataGridCuentas.Rows[i].Cells[2].Value = cuenta.Saldo;
                dataGridCuentas.Rows[i].Cells[3].Value = cuenta.FechaApertura.ToString();
                dataGridCuentas.Rows[i].Cells[4].Value = cuenta.InteresMensual;
                dataGridCuentas.Rows[i].Cells[5].Value = cuenta.Titulares.First().dni;
                i++;
            }
        }

        private void RefrescarGridTitulares()
        {
            dataGridTitulares.DataSource = null; //Borrar todos los objetos almacenados en el datagrid titulares
            dataGridTitulares.Rows.Clear();
            int i = 0;

            //Almacenamos en el datagrid cada titular de la cuenta selecionada del datagrid cuentas.
            int indiceActual = dataGridCuentas.CurrentRow.Index;
            Cuenta cuenta = cuentas[indiceActual];
            List<Cliente> titulares = cuenta.Titulares;

            foreach (Cliente cliente in titulares)
            {
                dataGridTitulares.Rows.Add();
                dataGridTitulares.Rows[i].Cells[0].Value = cliente.dni;
                i++;
            }
        }

        private void RefrescarGridDepositos()
        {
            dataGridDepositos.DataSource = null; //Borrar todos los objetos almacenados en el datagrid depositos
            dataGridDepositos.Rows.Clear();
            int i = 0;

            //Almacenamos en el datagrid cada deposito de la cuenta selecionada del datagrid cuentas.
            int indiceActual = dataGridCuentas.CurrentRow.Index;
            Cuenta cuenta = cuentas[indiceActual];
            List<Cuenta.Deposito> depositos = cuenta.Depositos;

            foreach (Cuenta.Deposito dep in depositos)
            {
                dataGridDepositos.Rows.Add();
                dataGridDepositos.Rows[i].Cells[0].Value = dep.DateTime;
                dataGridDepositos.Rows[i].Cells[1].Value = dep.Concepto;
                dataGridDepositos.Rows[i].Cells[2].Value = dep.Cantidad;
                i++;
            }
        }

        private void RefrescarGridRetiradas()
        {
            dataGridRetiradas.DataSource = null; //Borrar todos los objetos almacenados en el datagrid retiradas
            dataGridRetiradas.Rows.Clear();
            int i = 0;

            //Almacenamos en el datagrid cada retirada de la cuenta selecionada del datagrid cuentas.
            int indiceActual = dataGridCuentas.CurrentRow.Index;
            Cuenta cuenta = cuentas[indiceActual];
            List<Cuenta.Retirada> retiradas = cuenta.Retiradas;

            foreach (Cuenta.Retirada ret in retiradas)
            {
                dataGridRetiradas.Rows.Add();
                dataGridRetiradas.Rows[i].Cells[0].Value = ret.DateTime;
                dataGridRetiradas.Rows[i].Cells[1].Value = ret.Concepto;
                dataGridRetiradas.Rows[i].Cells[2].Value = ret.Cantidad;
                i++;
            }
        }

        private void GestionCuenta_Load(object sender, EventArgs e)
        {
            RefrescarGridCuentas(this.cuentas);
            if (dataGridCuentas.Rows.Count >= 1)
            {
                dataGridCuentas.Rows[0].Selected = true;
                RefrescarGridTitulares();
                RefrescarGridDepositos();
                RefrescarGridRetiradas();
            }
        }

        private void dataGridCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Añadir titulares de la cuenta actual selecionada al datagrid titulares
            RefrescarGridTitulares();

            //Añadir depositos de la cuenta actual selecionada al datagrid depositos
            RefrescarGridDepositos();

            //Añadir retiradas de la cuenta actual selecionada al datagrid retiradas
            RefrescarGridRetiradas();
        }

        private void BotonInsertar_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCuentas();
        }

        private void LimpiarFormularioCuentas()
        {
            textCCC.Enabled = true;
            textDNITitular.Enabled = true;
            comboTipo.Enabled = true;
            textCCC.Focus();
            textCCC.Clear();
            textInteres.Clear();
            textSaldo.Clear();
            textDNITitular.Clear();
        }

        private void BotonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridCuentas.Rows.Count == 0)
            {
                MessageBox.Show("No se puede editar nada, ya que no hay cuentas.");
                return;
            }

            //No se puede editar el ccc ni el dni titular
            textCCC.Enabled = false;
            textDNITitular.Enabled = false;
            //Añadir los campos del datagrid a el formulario
            int currentRow = dataGridCuentas.CurrentRow.Index;
            textCCC.Text = dataGridCuentas.Rows[currentRow].Cells[0].Value.ToString();
            comboTipo.ResetText();
            comboTipo.SelectedText = dataGridCuentas.Rows[currentRow].Cells[1].Value.ToString();
            comboTipo.Enabled = false;
            textSaldo.Text = dataGridCuentas.Rows[currentRow].Cells[2].Value.ToString();
            textInteres.Text = dataGridCuentas.Rows[currentRow].Cells[4].Value.ToString();
            textDNITitular.Text = dataGridCuentas.Rows[currentRow].Cells[5].Value.ToString();
        }

        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            //Errores
            if (textCCC.Text.Length != 20)
            {
                MessageBox.Show("El tamaño del CCC debe ser 20 caracteres");
                return;
            }

            Console.WriteLine(comboTipo.Text);
            if (comboTipo.Text != "Ahorro" && comboTipo.Text != "Corriente" &&
                comboTipo.Text != "Vivienda")
            {
                MessageBox.Show("Seleciona un tipo válido del ComboBox 'Tipo'");
                return;
            }

            if (textSaldo.Text.Length == 0 || !float.TryParse(textSaldo.Text, out float ou))
            {
                MessageBox.Show("Debes de indicar un número en el campo 'Saldo'");
                return;
            }

            if (textInteres.Text.Length == 0 || !float.TryParse(textInteres.Text, out float ou2))
            {
                MessageBox.Show("Debes de indicar un número en el campo 'Interes'");
                return;
            }

            if (!existeCliente(textDNITitular.Text))
            {
                MessageBox.Show(
                    "El cliente con el 'DNI Titular' no existe. Debes crearlo primero en el formulario correspondiente");
                return;
            }

            //Ejecución de la función en caso de que pasase correctamente los errores anteriores.

            bool esEditar = existeCCC(textCCC.Text);
            //Cuando se edita, el ccc ya existe, entonces solo editar las demás cosas
            if (esEditar)
            {
                Cuenta cuen = getCuenta(textCCC.Text);
                cuen.Saldo = float.Parse(textSaldo.Text);
                cuen.InteresMensual = float.Parse(textInteres.Text);
                RefrescarGridCuentas(this.cuentas);
                LimpiarFormularioCuentas();
            }
            //Si es nuevo... se crea nueva cuenta y se introduce
            else
            {
                Cuenta cu;
                Cliente cli = getCliente(textDNITitular.Text);

                if (comboTipo.Text.Equals("Ahorro"))
                    cu = new CuentaAhorro(textCCC.Text, cli);
                else if (comboTipo.Text.Equals("Corriente"))
                    cu = new CuentaCorriente(textCCC.Text, cli);
                else if (comboTipo.Text.Equals("Vivienda"))
                    cu = new CuentaVivienda(textCCC.Text, cli);
                else cu = null;

                cli.dni = textDNITitular.Text;
                cu.Saldo = float.Parse(textSaldo.Text);
                cu.InteresMensual = float.Parse(textInteres.Text);
                cuentas.Add(cu);
                MessageBox.Show("Usuario añadido con éxito");
            }

            RefrescarGridCuentas(this.cuentas);
        }

        /// <summary>
        /// Retorna true siel ccc pasado ya existe
        /// </summary>
        /// <param name="ccc"></param>
        /// <returns></returns>
        private bool existeCCC(string ccc)
        {
            foreach (Cuenta c in cuentas)
            {
                if (c.CCC.Equals(ccc)) return true;
            }

            return false;
        }

        private Cuenta getCuenta(string ccc)
        {
            foreach (Cuenta c in cuentas)
            {
                if (c.CCC.Equals(ccc)) return c;
            }

            return null;
        }

        private Cliente getCliente(string dni)
        {
            foreach (Cliente c in this.clientes)
            {
                if (c.dni.Equals(dni))
                    return c;
            }

            return null;
        }

        private bool existeCliente(string dni)
        {
            foreach (Cliente cli in this.clientes)
            {
                if (dni.Equals(cli.dni)) return true;
            }

            return false;
        }

        private void BotonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridCuentas.Rows.Count == 0)
            {
                MessageBox.Show("No hay nada que borrar, ya no quedan cuentas");
                return;
            }

            int currentRow = dataGridCuentas.CurrentRow.Index;
            //Obtiene el ccc de la cuenta selecionada
            string ccccc = dataGridCuentas.Rows[currentRow].Cells[0].Value.ToString();
            Cuenta cuentaBorrar = null;

            foreach (Cuenta cuenta in this.cuentas)
            {
                if (cuenta.CCC.Equals(ccccc))
                {
                    cuentaBorrar = cuenta;
                }
            }

            DialogResult dr = MessageBox.Show("¿De verdad quieres borrar esta cuenta " + ccccc + "?", "¿Borrar?",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cuentas.Remove(cuentaBorrar);
                RefrescarGridCuentas(this.cuentas);
                MessageBox.Show("Borrado con éxito");

                //Selecionar la primera fila, después de borrar
                if (dataGridCuentas.Rows.Count >= 1)
                {
                    dataGridCuentas.Rows[0].Selected = true;
                    RefrescarGridDepositos();
                    RefrescarGridRetiradas();
                    RefrescarGridTitulares();
                }
                else
                {
                    //Si no hay cuentas, limpiar los grid
                    dataGridDepositos.Rows.Clear();
                    dataGridRetiradas.Rows.Clear();
                    dataGridTitulares.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("Borrado cancelado");
            }
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            List<Cuenta> cuentasBuscadas = new List<Cuenta>();

            //Buscar en la lista de las cuentas originales si existe el dni o el ccc indicado
            //y introducirla en 'cuentasBuscadas'

            foreach (Cuenta cuenta in this.cuentas)
            {
                if (cuenta.CCC.Contains(textBuscarCCC.Text) && CuentaContieneTitular(cuenta, textBuscarDni.Text))
                {
                    cuentasBuscadas.Add(cuenta);
                }
            }

            RefrescarGridCuentas(cuentasBuscadas);
        }

        /// <summary>
        /// Devuelve true si la cuenta pasada contiene el cliente pasado
        /// </summary>
        /// <param name="cuenta"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        private bool CuentaContieneTitular(Cuenta cuenta, string dnicliente)
        {
            foreach (Cliente cli in cuenta.Titulares)
            {
                if (cli.dni.Contains(dnicliente))
                {
                    return true;
                }
            }

            return false;
        }

        private void BotonListarTodos_Click(object sender, EventArgs e)
        {
            RefrescarGridCuentas(this.cuentas);
        }

        private void botonInsertarTitulares_Click(object sender, EventArgs e)
        {
            if (dataGridCuentas.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna cuenta selecionada");
                return;
            }
            
            int indiceActual = dataGridCuentas.CurrentRow.Index;
            Cuenta cuenta = cuentas[indiceActual];

            if (existeCliente(textDniTitulares.Text))
            {
                if (!CuentaContieneTitular(cuenta, textDniTitulares.Text))
                {
                    Cliente cli = getCliente(textDniTitulares.Text);
                    cuenta.Titulares.Add(cli);
                    RefrescarGridTitulares();
                    MessageBox.Show("Titular " + textDniTitulares.Text + " insertado con éxito");
                }
                else
                {
                    MessageBox.Show("No se puede insertar, puesto que ya estaba insertado.");
                }
            }
            else
            {
                MessageBox.Show("El cliente no existe, debes crearlo primero en el formulario correspondiente.");
            }
        }

        public Cuenta getCuentaSelecionada()
        {
            int currentRowCuenta = dataGridCuentas.CurrentRow.Index;
            string ccccc = dataGridCuentas.Rows[currentRowCuenta].Cells[0].Value.ToString();
            Cuenta cuentaToret = null;
            cuentaToret = getCuenta(ccccc);
            return cuentaToret;
        }

        private void botonBorrarTitulares_Click(object sender, EventArgs e)
        {
            if (dataGridCuentas.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna cuenta selecionada");
                return;
            }
            
            //Obtiene el dni del titular selecionado
            int currentRowTitulares = dataGridTitulares.CurrentRow.Index;
            string dni = dataGridTitulares.Rows[currentRowTitulares].Cells[0].Value.ToString();
            Cliente clienteBorrar = getCliente(dni);

            //Obtener la cuenta selecionada
            Cuenta cuentaSelecioanda = getCuentaSelecionada();

            //Error, si solo hay un titular, no se deja borrar
            if (cuentaSelecioanda.Titulares.Count == 1)
            {
                MessageBox.Show("No se puede borrar, ya que la cuenta quedaría sin titular.");
                return;
            }

            DialogResult dr = MessageBox.Show("¿De verdad quieres borrar esta titular " + dni + "?", "¿Borrar?",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (cuentaSelecioanda.Titulares.Remove(clienteBorrar))
                {
                    RefrescarGridTitulares();
                    RefrescarGridCuentas(this.cuentas);
                    MessageBox.Show("Borrado con éxito");
                }
            }
            else
            {
                MessageBox.Show("Borrado cancelado");
            }
        }

        private void dataGridTitulares_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowTitulares = dataGridTitulares.CurrentRow.Index;
            textDniTitulares.Text = dataGridTitulares.Rows[currentRowTitulares].Cells[0].Value.ToString();
        }

        // ########################################################################################################
        // ################ Depositos #############################################################################
        // ########################################################################################################
        private void dataGridDepositos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowDepositos = dataGridDepositos.CurrentRow.Index;
            textConceptoDeposito.Text = dataGridDepositos.Rows[currentRowDepositos].Cells[1].Value.ToString();
            textCantidadDeposito.Text = dataGridDepositos.Rows[currentRowDepositos].Cells[2].Value.ToString();
        }

        private void botonInsertarDeposito_Click(object sender, EventArgs e)
        {
            if (dataGridCuentas.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna cuenta selecionada");
                return;
            }
            
            //Errores, si la cantidad no es un numero
            if (!float.TryParse(textCantidadDeposito.Text, out float ou))
            {
                MessageBox.Show("La cantidad debe ser un número");
                return;
            }

            //Insertar deposito
            Cuenta cuentaSelecionada = getCuentaSelecionada();
            cuentaSelecionada.Depositos.Add(new Cuenta.Deposito(textConceptoDeposito.Text,
                float.Parse(textCantidadDeposito.Text)));
            RefrescarGridDepositos();
            MessageBox.Show("Nuevo deposito insertado");
        }


        private void botonBorrarDeposito_Click(object sender, EventArgs e)
        {
            if (dataGridCuentas.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna cuenta selecionada");
                return;
            }
            
            //Error, si no hay depositos
            if (getCuentaSelecionada().Depositos.Count() == 0)
            {
                MessageBox.Show("No hay depositos que borrar.");
                return;
            }


            //Obtiene el deposito de la cuenta selecionada
            int currentRowDeposito = dataGridDepositos.CurrentRow.Index;
            Cuenta.Deposito depSelecionado = getCuentaSelecionada().Depositos[currentRowDeposito];

            //Preguntar y borrar
            DialogResult dr = MessageBox.Show("¿De verdad quieres borrar este deposito " + depSelecionado.Concepto
                + " - " + depSelecionado.Cantidad + "€ ?", "¿Borrar?",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                getCuentaSelecionada().Depositos.Remove(depSelecionado);
                RefrescarGridDepositos();
                MessageBox.Show("Borrado con éxito");
            }
            else
            {
                MessageBox.Show("Borrado cancelado");
            }
        }


        // ########################################################################################################
        // ################ Retiradas #############################################################################
        // ########################################################################################################

        private void dataGridRetiradas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowRetirada = dataGridRetiradas.CurrentRow.Index;
            textConceptoRetirada.Text = dataGridRetiradas.Rows[currentRowRetirada].Cells[1].Value.ToString();
            textCantidadRetirada.Text = dataGridRetiradas.Rows[currentRowRetirada].Cells[2].Value.ToString();
        }

        private void botonInsertarRetirada_Click(object sender, EventArgs e)
        {
            //Errores, si la cantidad no es un numero
            if (!float.TryParse(textCantidadRetirada.Text, out float ou))
            {
                MessageBox.Show("La cantidad debe ser un número");
                return;
            }

            //Insertar retirada
            Cuenta cuentaSelecionada = getCuentaSelecionada();


            cuentaSelecionada.Retiradas.Add(new Cuenta.Retirada(textConceptoRetirada.Text,
                float.Parse(textCantidadRetirada.Text)));
            RefrescarGridRetiradas();
            MessageBox.Show("Nueva retirada insertada");
        }

        private void botonBorrarRetirada_Click(object sender, EventArgs e)
        {
            //Error, si no hay retiradas
            if (getCuentaSelecionada().Retiradas.Count() == 0)
            {
                MessageBox.Show("No hay retiradas que borrar.");
                return;
            }


            //Obtiene el retirada de la cuenta selecionada
            int currentRowRetirada = dataGridRetiradas.CurrentRow.Index;
            Cuenta.Retirada retSelecionada = getCuentaSelecionada().Retiradas[currentRowRetirada];

            //Preguntar y borrar
            DialogResult dr = MessageBox.Show("¿De verdad quieres borrar esta retirada " + retSelecionada.Concepto
                + " - " + retSelecionada.Cantidad + "€ ?", "¿Borrar?",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                getCuentaSelecionada().Retiradas.Remove(retSelecionada);
                RefrescarGridRetiradas();
                MessageBox.Show("Borrado con éxito");
            }
            else
            {
                MessageBox.Show("Borrado cancelado");
            }
        }
    }
}