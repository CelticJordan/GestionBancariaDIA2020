using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clientes.Core;
using DIA_BANCO_V1;

namespace DIA_BANCO_V1
{
    public partial class GestionCuentas : Form
    {
        public List<Cuenta> cuentas;
        public List<Cliente> clientes;
        public List<Prestamo> prestamos;
        public List<Transferencia> transferencias;

        public GestionCuentas(List<Cuenta> cuentas, List<Cliente> clientes, List<Prestamo> prestamos, List<Transferencia> transferencias)
        {
            this.cuentas = cuentas;
            this.clientes = clientes;
            this.prestamos = prestamos;
            this.transferencias = transferencias;
            InitializeComponent();
        }

        private void GestionCuentas_Load(object sender, EventArgs e)
        {
            RefrescarGridCuentas(this.cuentas);
            if (dataGridCuentas.Rows.Count >= 1)
            {
                dataGridCuentas.Rows[0].Cells[0].Selected = true;
                RefrescarGridTitulares(getCuentaSelecionadaGridCuentas().Titulares);
                RefrescarGridDepositos(getCuentaSelecionadaGridCuentas().Depositos);
                RefrescarGridRetiradas(getCuentaSelecionadaGridCuentas().Retiradas);
            }
            ComprobarTipoCuentaParaMostrarDepositosORetiradas(getCuentaSelecionadaGridCuentas());
        }

        /// <summary>
        /// Pone los datos de <see cref="cuentas"/> en el DataGrid de cuentas
        /// </summary>
        private void RefrescarGridCuentas(List<Cuenta> cuentas)
        {
            int filaActualSelecionada = 0;
            //Guardar el puntero de la fila actual selecionada
            if (dataGridCuentas.Rows.Count > 0)
            {
                filaActualSelecionada = dataGridCuentas.CurrentRow.Index;
            }

            dataGridCuentas.DataSource = null; //Borrar todos los objetos almacenados en el datagrid
            dataGridCuentas.Rows.Clear();

            if (cuentas != null)
            {
                int i = 0;

                //Almacenamos en el datagrid cada cuenta que tenemos en nuestra lista.
                foreach (Cuenta cuenta in cuentas)
                {
                    dataGridCuentas.Rows.Add();
                    dataGridCuentas.Rows[i].Cells[0].Value = cuenta.CCC;
                    dataGridCuentas.Rows[i].Cells[1].Value = cuenta.Tipo;
                    dataGridCuentas.Rows[i].Cells[2].Value = cuenta.Saldo;
                    dataGridCuentas.Rows[i].Cells[3].Value = cuenta.FechaApertura.ToString();
                    dataGridCuentas.Rows[i].Cells[4].Value = cuenta.InteresMensual;
                    dataGridCuentas.Rows[i].Cells[5].Value = cuenta.Titulares.First().Dni;
                    dataGridCuentas.Rows[i].Cells[6].Value = "Borrar Cuenta";
                    i++;
                }

                //Volver a poner el puntero de la fila actual selecionada
                if (dataGridCuentas.Rows.Count > 0 && dataGridCuentas.Rows.Count > filaActualSelecionada)
                {
                    dataGridCuentas.Rows[filaActualSelecionada].Cells[0].Selected = true;
                }
            }

            RefrescarGridTitulares(getTitularesCuentaSelecionadaGridCuentas());
            RefrescarGridDepositos(GetDepositosCuentaSelecionadaGridCuentas());
            RefrescarGridRetiradas(getRetiradasCuentaSelecionadaGridCuentas());
        }

        private void RefrescarGridTitulares(List<Cliente> titulares)
        {
            dataGridTitulares.DataSource = null; //Borrar todos los objetos almacenados en el datagrid titulares
            dataGridTitulares.Rows.Clear(); //Para evitar concatenaciones. Se elimina y se refresca
            if (titulares != null)
            {
                int i = 0;

                //Almacenamos en el datagrid cada titular de la cuenta selecionada del datagrid cuentas.

                foreach (Cliente cliente in titulares)
                {
                    dataGridTitulares.Rows.Add();
                    dataGridTitulares.Rows[i].Cells[0].Value = cliente.Dni;
                    dataGridTitulares.Rows[i].Cells[1].Value = cliente.Nombre;
                    dataGridTitulares.Rows[i].Cells[2].Value = "Borrar titular";
                    i++;
                }
            }
        }


        private void RefrescarGridDepositos(List<Cuenta.Deposito> depositos)
        {
            dataGridDepositos.DataSource = null; //Borrar todos los objetos almacenados en el datagrid depositos
            dataGridDepositos.Rows.Clear();
            if (depositos != null)
            {
                int i = 0;

                //Almacenamos en el datagrid cada deposito de la cuenta selecionada del datagrid cuentas.

                foreach (Cuenta.Deposito dep in depositos)
                {
                    dataGridDepositos.Rows.Add();
                    dataGridDepositos.Rows[i].Cells[0].Value = dep.DateTime;
                    dataGridDepositos.Rows[i].Cells[1].Value = dep.Concepto;
                    dataGridDepositos.Rows[i].Cells[2].Value = dep.Cantidad;
                    dataGridDepositos.Rows[i].Cells[3].Value = "Borrar depósito";
                    i++;
                }
            }
        }

        private void RefrescarGridRetiradas(List<Cuenta.Retirada> retiradas)
        {
            dataGridRetiradas.DataSource = null; //Borrar todos los objetos almacenados en el datagrid retiradas
            dataGridRetiradas.Rows.Clear();

            if (retiradas != null)
            {
                int i = 0;

                //Almacenamos en el datagrid cada retirada de la cuenta selecionada del datagrid cuentas.
                int indiceActual = dataGridCuentas.CurrentRow.Index;

                foreach (Cuenta.Retirada ret in retiradas)
                {
                    dataGridRetiradas.Rows.Add();
                    dataGridRetiradas.Rows[i].Cells[0].Value = ret.DateTime;
                    dataGridRetiradas.Rows[i].Cells[1].Value = ret.Concepto;
                    dataGridRetiradas.Rows[i].Cells[2].Value = ret.Cantidad;
                    dataGridRetiradas.Rows[i].Cells[3].Value = "Borrar depósito";

                    i++;
                }
            }
        }

        public Cuenta getCuentaSelecionadaGridCuentas()
        {
            if (dataGridCuentas.RowCount >= 0 && dataGridCuentas.CurrentRow != null)
            {
                int currentRowCuenta = dataGridCuentas.CurrentRow.Index;
                string ccccc = dataGridCuentas.Rows[currentRowCuenta].Cells[0].Value.ToString();
                Cuenta cuentaToret = null;
                cuentaToret = Banco.getCuenta(ccccc, this.cuentas);
                return cuentaToret;
            }
            else return null;
        }

        public List<Cliente> getTitularesCuentaSelecionadaGridCuentas()
        {
            Cuenta c = getCuentaSelecionadaGridCuentas();
            if (c != null)
            {
                return c.Titulares;
            }
            else
            {
                return null;
            }
        }
        
        public List<Cuenta.Retirada> getRetiradasCuentaSelecionadaGridCuentas()
        {
            Cuenta c = getCuentaSelecionadaGridCuentas();
            if (c != null)
            {
                return c.Retiradas;
            }
            else
            {
                return null;
            }
        }
        
        public List<Cuenta.Deposito> GetDepositosCuentaSelecionadaGridCuentas()
        {
            Cuenta c = getCuentaSelecionadaGridCuentas();
            if (c != null)
            {
                return c.Depositos;
            }
            else
            {
                return null;
            }
        }
        
        private void ComprobarTipoCuentaParaMostrarDepositosORetiradas(Cuenta cue)
        {
            //Visualizar o no los depositos o las retiradas en función del tipo de cuenta
            if (cue is CuentaAhorro || cue is CuentaVivienda)
            {
                dataGridDepositos.Visible = true;
                dataGridRetiradas.Visible = false;
                textCantidadRetirada.Visible = false;
                textConceptoRetirada.Visible = false;
                botonInsertarRetirada.Visible = false;
            }
            else if(cue is CuentaCorriente)
            {
                dataGridDepositos.Visible = true;
                dataGridRetiradas.Visible = true;
                textCantidadRetirada.Visible = true;
                textConceptoRetirada.Visible = true;
                botonInsertarRetirada.Visible = true;
            }
        }        

        /***************************************************************************/
        /* GESTION DE CUENTAS ******************************************************/
        /***************************************************************************/
        private void dataGridCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Añadir titulares de la cuenta actual selecionada al datagrid titulares
            RefrescarGridTitulares(getTitularesCuentaSelecionadaGridCuentas());

            //Añadir depositos de la cuenta actual selecionada al datagrid depositos
            RefrescarGridDepositos(GetDepositosCuentaSelecionadaGridCuentas());

            //Añadir retiradas de la cuenta actual selecionada al datagrid retiradas
            RefrescarGridRetiradas(getRetiradasCuentaSelecionadaGridCuentas());

            //Si se clica en la columna 6, entonces se borra ese registro!
            if (dataGridCuentas.CurrentCell.ColumnIndex == 6)
            {
                BorrarCuentaSeleccionadaDelGrid();
            }
            
            ComprobarTipoCuentaParaMostrarDepositosORetiradas(getCuentaSelecionadaGridCuentas());
        }

        private void BorrarCuentaSeleccionadaDelGrid()
        {
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
                    RefrescarGridDepositos(GetDepositosCuentaSelecionadaGridCuentas());
                    RefrescarGridRetiradas(getRetiradasCuentaSelecionadaGridCuentas());
                    RefrescarGridTitulares(getTitularesCuentaSelecionadaGridCuentas());
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

        private void BotonInsertarCuenta_Click(object sender, EventArgs e)
        {
            ModalInsertarCuenta nuevaCuenta = new ModalInsertarCuenta(this.cuentas, this.clientes);
            nuevaCuenta.ShowDialog();
            RefrescarGridCuentas(this.cuentas);
        }

        /// <summary>
        /// Listar solo las cuentas que coincidan con el CCC a buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBuscarCCC_TextChanged(object sender, EventArgs e)
        {
            List<Cuenta> cuentasBuscadas = new List<Cuenta>();

            //Buscar en la lista de las cuentas originales si existe el dni o el ccc indicado
            //y introducirla en 'cuentasBuscadas'
            foreach (Cuenta cuenta in this.cuentas)
            {
                if (cuenta.CCC.Contains(textBuscarCCC.Text) && Banco.CuentaContieneTitular(cuenta, textBuscarDni.Text))
                {
                    cuentasBuscadas.Add(cuenta);
                }
            }

            RefrescarGridCuentas(cuentasBuscadas);
        }

        /// <summary>
        /// Listar solo las cuentas que coincidan con el dni a buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBuscarDni_TextChanged(object sender, EventArgs e)
        {
            List<Cuenta> cuentasBuscadas = new List<Cuenta>();

            //Buscar en la lista de las cuentas originales si existe el dni o el ccc indicado
            //y introducirla en 'cuentasBuscadas'
            foreach (Cuenta cuenta in this.cuentas)
            {
                if (cuenta.CCC.Contains(textBuscarCCC.Text) && Banco.CuentaContieneTitular(cuenta, textBuscarDni.Text))
                {
                    cuentasBuscadas.Add(cuenta);
                }
            }

            RefrescarGridCuentas(cuentasBuscadas);
        }

        /// <summary>
        /// Limpiar el formulario de busqueda y listar todas las cuentas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonListarTodos_Click(object sender, EventArgs e)
        {
            textBuscarCCC.Text = "";
            textBuscarDni.Text = "";
            RefrescarGridCuentas(this.cuentas);
        }
        /***************************************************************************/
        /* GESTION DE TITULARES ****************************************************/
        /***************************************************************************/

        private void botonInsertarTitulares_Click(object sender, EventArgs e)
        {
            if (getCuentaSelecionadaGridCuentas() != null)
            {
                ModalInsertarTitular mit = new ModalInsertarTitular(getCuentaSelecionadaGridCuentas(), this.clientes);
                mit.ShowDialog();
                RefrescarGridTitulares(getTitularesCuentaSelecionadaGridCuentas());
            }
        }

        private void dataGridTitulares_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se clica en la columna 2, entonces se borra ese registro!
            if (dataGridTitulares.CurrentCell.ColumnIndex == 2)
            {
                if (dataGridCuentas.CurrentRow == null)
                {
                    MessageBox.Show("No hay ninguna cuenta selecionada");
                    return;
                }

                //Obtiene el dni del titular selecionado
                int currentRowTitulares = dataGridTitulares.CurrentRow.Index;
                string dni = dataGridTitulares.Rows[currentRowTitulares].Cells[0].Value.ToString();
                Cliente clienteBorrar = Banco.getCliente(dni, this.clientes);

                //Obtener la cuenta selecionada
                Cuenta cuentaSelecioanda = getCuentaSelecionadaGridCuentas();

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
                        RefrescarGridTitulares(getTitularesCuentaSelecionadaGridCuentas());
                        RefrescarGridCuentas(this.cuentas);
                        MessageBox.Show("Borrado con éxito");
                    }
                }
                else
                {
                    MessageBox.Show("Borrado cancelado");
                }
            }
        }

        /***************************************************************************/
        /* GESTION DE DEPOSITOS ****************************************************/
        /***************************************************************************/
        private void dataGridDepositos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se clica en la columna 3, entonces se borra ese deposito!
            if (dataGridDepositos.CurrentCell.ColumnIndex == 3)
            {
                int currentRowDeposito = dataGridDepositos.CurrentRow.Index;
                Cuenta cuentaSelecionada = getCuentaSelecionadaGridCuentas();
                Cuenta.Deposito depSelecionado = getCuentaSelecionadaGridCuentas().Depositos[currentRowDeposito];

                //Preguntar y borrar
                DialogResult dr = MessageBox.Show("¿De verdad quieres borrar este deposito " + depSelecionado.Concepto
                    + " - " + depSelecionado.Cantidad + "€ ?", "¿Borrar?",
                    MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (Banco.borrarDepositoCuenta(cuentaSelecionada, depSelecionado))
                    {
                        MessageBox.Show("Deposito borrado con éxito");
                    }
                    else
                    {
                        MessageBox.Show("Algo malo ha pasado, no se ha borrado el depósito");
                    }
                    RefrescarGridDepositos(GetDepositosCuentaSelecionadaGridCuentas());
                    RefrescarGridCuentas(this.cuentas);
                }
                else
                {
                    MessageBox.Show("Borrado cancelado");
                }
            }
        }

        private void botonInsertarDeposito_Click(object sender, EventArgs e)
        {
            if (dataGridCuentas.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna cuenta selecionada");
                return;
            }

            //Errores, si la cantidad no es un numero
            if (!double.TryParse(textCantidadDeposito.Text, out double ou))
            {
                MessageBox.Show("La cantidad debe ser un número");
                return;
            }

            //Insertar deposito
            Cuenta cuentaSelecionada = getCuentaSelecionadaGridCuentas();
            Banco.insertarDepositoCuenta(cuentaSelecionada,
                new Cuenta.Deposito(textConceptoDeposito.Text, DateTime.Now, double.Parse(textCantidadDeposito.Text)));
            RefrescarGridDepositos(GetDepositosCuentaSelecionadaGridCuentas());
            RefrescarGridCuentas(this.cuentas);
            MessageBox.Show("Nuevo deposito insertado");
        }
        
        /***************************************************************************/
        /* GESTION DE Retiradas ****************************************************/
        /***************************************************************************/

        private void botonInsertarRetirada_Click(object sender, EventArgs e)
        {
            if (dataGridCuentas.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna cuenta selecionada");
                return;
            }

            //Errores, si la cantidad no es un numero
            if (!double.TryParse(textCantidadRetirada.Text, out double ou))
            {
                MessageBox.Show("La cantidad debe ser un número");
                return;
            }

            //Insertar retirada
            Cuenta cuentaSelecionada = getCuentaSelecionadaGridCuentas();
            Banco.insertarRetiradaCuenta(cuentaSelecionada,
                new Cuenta.Retirada(textConceptoRetirada.Text, DateTime.Now, double.Parse(textCantidadRetirada.Text)));
            RefrescarGridRetiradas(getRetiradasCuentaSelecionadaGridCuentas());
            RefrescarGridCuentas(this.cuentas);
            MessageBox.Show("Nueva retirada insertada");
        }


        private void dataGridRetiradas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se clica en la columna 3, entonces se borra esa retirada
            if (dataGridRetiradas.CurrentCell.ColumnIndex == 3)
            {
                int currentRowRetirada = dataGridDepositos.CurrentRow.Index;
                Cuenta cuentaSelecionada = getCuentaSelecionadaGridCuentas();
                Cuenta.Retirada retSelecionado = getCuentaSelecionadaGridCuentas().Retiradas[currentRowRetirada];

                //Preguntar y borrar
                DialogResult dr = MessageBox.Show("¿De verdad quieres borrar esta retirada " + retSelecionado.Concepto
                    + " - " + retSelecionado.Cantidad + "€ ?", "¿Borrar?",
                    MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (Banco.borrarRetiradaCuenta(cuentaSelecionada, retSelecionado))
                    {
                        MessageBox.Show("Retirada borrada con éxito");
                    }
                    else
                    {
                        MessageBox.Show("Algo malo ha pasado, no se ha borrado la retirada");
                    }
                    RefrescarGridRetiradas(getRetiradasCuentaSelecionadaGridCuentas());
                    RefrescarGridCuentas(this.cuentas);
                }
                else
                {
                    MessageBox.Show("Borrado cancelado");
                }
            }
        }
    }
}