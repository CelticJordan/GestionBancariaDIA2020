using System;
using System.Collections.Generic;
using System.Windows.Forms;
 using DIA_BANCO_V1;

namespace DIA_BANCO_V1
{
    public partial class ModalInsertarTitular : Form
    {
        //La cuenta selecionada para introducir mas titulares
        private Cuenta cuenta;
        //La lista de todos los clientes del banco
        private List<Cliente> clientes;
        //Se inserta aquí los clientes que ya no están metidos en la cuenta, si no se repeterian
        private List<Cliente> clientesBuscados; 

        public ModalInsertarTitular(Cuenta c, List<Cliente> clientes)
        {
            clientesBuscados = new List<Cliente>();
            this.cuenta = c;
            this.clientes = clientes;
            InitializeComponent();
        }

        private void ModalInsertarTitular_Load(object sender, EventArgs e)
        {
            ObtenerClientesPermitidos();
            RefrescarGridTitulares(clientesBuscados);
        }

        /// <summary>
        /// Obtener solo los clientes que ya no están en esta actual cuenta.
        /// </summary>
        private void ObtenerClientesPermitidos()
        {
            foreach (Cliente cTodos in this.clientes)
            {
                bool esta = false;
                foreach(Cliente cYaEnCuenta in this.cuenta.Titulares)
                    if (cTodos.Dni.Equals(cYaEnCuenta.Dni))
                    {
                        esta = true;
                    }
                if(esta == false) this.clientesBuscados.Add(cTodos);
            }
        }

        private void RefrescarGridTitulares(List<Cliente> clies)
        {
            //Limpiar el datagrid para evitar concatenar los registros
            dataGridView1.DataSource = null; //Borrar todos los objetos almacenados en el datagrid
            dataGridView1.Rows.Clear();
            
            int i = 0;
            foreach (Cliente cliente in clies)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = cliente.Dni;
                dataGridView1.Rows[i].Cells[1].Value = cliente.Nombre;
                dataGridView1.Rows[i].Cells[2].Value = "Insertar titular";
                i++;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se clica en la columna 2, que es la de 'insertar', entonces se inserta ese cliente en la cuenta
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                int currentRow = dataGridView1.CurrentRow.Index;
                //Obtiene el dni de la cuenta selecionada
                string dni = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();
                Cliente cliente = Banco.getCliente(dni, this.clientes);

                DialogResult dr = MessageBox.Show("¿De verdad quieres meter como titular a" +
                                                  "" + dni + " en la cuenta " + cuenta.CCC + "?", "Introducir?",
                    MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.cuenta.Titulares.Add(cliente);
                    MessageBox.Show("Titular introducido con éxito");
                    Close();
                }
                else
                {
                    MessageBox.Show("Insertado cancelado");
                }
            }
        }

        //Buscar solo los clientes que coincidan con el dni buscado
        private void textDNIbuscarTitular_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> clientesCoinciden = new List<Cliente>();
            
            //Buscar en la lista de las clientes originales si existe el dni o el nombre indicado
            //y introducirla en 'clientesBuscados'
            foreach (Cliente cli in this.clientesBuscados)
            {
                if (cli.Dni.Contains(textDNIbuscarTitular.Text) && cli.Nombre.ToLower().Contains(textNombreBuscarTitular.Text.ToLower()))
                {
                    clientesCoinciden.Add(cli);
                }
            }

            RefrescarGridTitulares(clientesCoinciden);
        }

        /// <summary>
        /// Buscar los clientes que coincidan con el nombre buscado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textNombreBuscarTitular_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> clientesCoinciden = new List<Cliente>();
            
            //Buscar en la lista de las clientes originales si existe el dni o el nombre indicado
            //y introducirla en 'clientesBuscados'
            foreach (Cliente cli in this.clientesBuscados)
            {
                if (cli.Dni.Contains(textDNIbuscarTitular.Text) && cli.Nombre.ToLower().Contains(textNombreBuscarTitular.Text.ToLower()))
                {
                    clientesCoinciden.Add(cli);
                }
            }

            RefrescarGridTitulares(clientesCoinciden);
        }
    }
}