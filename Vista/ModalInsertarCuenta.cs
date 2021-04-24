using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DIA_BANCO_V1;

namespace DIA_BANCO_V1
{
    public partial class ModalInsertarCuenta : Form
    {
        private List<Cuenta> cuentas;
        private List<Cliente> clientes;
        
        public ModalInsertarCuenta(List<Cuenta> cuentas, List<Cliente> clientes)
        {
            this.cuentas = cuentas;
            this.clientes = clientes;
            InitializeComponent();
        }
        
        /// <summary>
        /// Comprueba que todos los datos introducidos en el formulario sean correctos
        /// </summary>
        /// <returns></returns>
        private bool ComprobarDatosCorrectos()
        {
            if (textCCC.Text.Length != 20)
            {
                MessageBox.Show("El tamaño del CCC debe ser 20 caracteres");
                return false;
            }
            
            if (Banco.existeCCC(textCCC.Text, this.cuentas))
            {
                MessageBox.Show("El CCC ya existe, no se puede crear otra cuenta con el mismo codigo.");
                return false;
            }

            if (comboTipo.Text != "Ahorro" && comboTipo.Text != "Corriente" &&
                comboTipo.Text != "Vivienda")
            {
                MessageBox.Show("Seleciona un tipo válido del ComboBox 'Tipo'");
                return false;
            }

            if (textSaldo.Text.Length == 0 || !double.TryParse(textSaldo.Text, out double ou))
            {
                MessageBox.Show("Debes de indicar un número en el campo 'Saldo'");
                return false;
            }

            if (!Banco.existeCliente(textDNITitular.Text, this.clientes))
            {
                MessageBox.Show(
                    "El cliente con el 'DNI Titular' no existe. Debes crearlo primero en el formulario correspondiente");
                return false;
            }
            
            
            return true;
        }

        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            bool todoBien = ComprobarDatosCorrectos();
            
            if(todoBien){
                Cuenta cu;
                Cliente cli = Banco.getCliente(textDNITitular.Text, this.clientes);

                if (comboTipo.Text.Equals("Ahorro"))
                    cu = new CuentaAhorro(textCCC.Text, cli);
                else if (comboTipo.Text.Equals("Corriente"))
                    cu = new CuentaCorriente(textCCC.Text, cli);
                else if (comboTipo.Text.Equals("Vivienda"))
                    cu = new CuentaVivienda(textCCC.Text, cli);
                else cu = null;

                cli.Dni = textDNITitular.Text;
                cu.Saldo = double.Parse(textSaldo.Text);
                cuentas.Add(cu);
                MessageBox.Show("Nueva cuenta añadida con éxito");
                Close();
            }
        }
        
    }
}