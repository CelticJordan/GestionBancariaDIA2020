using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;

namespace DIA_BANCO_V1
{
    using System.Windows.Forms;
    using System.Drawing;
    using System;
    
    public class DlgProductosPersona : Form
    {
        public DlgProductosPersona(IEnumerable<Cliente> clients,IEnumerable<Cuenta> accounts,IEnumerable<Transferencia> trasnferences,IEnumerable<Prestamo> loans)
        {
            this.Clientes = clients;
            this.Cuentas = accounts;
            this.Transferencias = trasnferences;
            this.Prestamos = loans;
            
            this.Build();
            this.CenterToScreen();
            
            this.opVolver.Click += (sender, e) => this.DialogResult = DialogResult.Cancel;
        }

        void Build()
        {

            this.BuildMenu();

            this.SuspendLayout();

            this.pnlPrincipal = new TableLayoutPanel
            {
                Size = new Size(450, 100), 
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(50, 70, 80),
            };

            pnlPrincipal.SuspendLayout();
            this.Controls.Add(pnlPrincipal);

            var pnlClientes = this.BuildClientesPanel();
            pnlPrincipal.Controls.Add(pnlClientes);
            
            pnlPrincipal.Controls.Add(PanelDetalle());
            
            var pnlBotones = this.BuildBotonesPanel();
            pnlPrincipal.Controls.Add(pnlBotones);

            pnlPrincipal.ResumeLayout(true);

            this.Text = "Gestion de un banco - Buscar productos por persona";

            Console.WriteLine(pnlClientes.Height);
            
            this.Size = new Size(1200, 900);
            
            this.MaximizeBox = false;
            this.ResumeLayout(false);
        }




        private void BuildMenu()
        {
            this.mPpal = new MainMenu();

            this.mArchivo = new MenuItem("&Archivo");
            this.opVolver = new MenuItem("&Volver");


            this.mArchivo.MenuItems.Add(this.opVolver);


            this.mPpal.MenuItems.Add(this.mArchivo);


            this.Menu = mPpal;


        }



        Panel BuildBotonesPanel()
        {

            var pnlBotones = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1,
                Dock = DockStyle.Right,

            };

            var btGuarda = new Button()
            {
                Text = "&Ok",
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(60,80,120),
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.Silver,

            };

            pnlBotones.Controls.Add(btGuarda);

            this.AcceptButton = btGuarda;

            pnlBotones.Controls.Add(btGuarda);


            return pnlBotones;
        }

        Panel BuildClientesPanel()
        {

            this.pnlClientes = new Panel()
            {
                Dock = DockStyle.Fill,
                MaximumSize = new Size(int.MaxValue, 30),
                Height = 30,

            };

            var lblClientes = new Label()
            {
                Text = "Cliente",
                Left = -50,
                ForeColor = Color.White,
                Width = 150,
                TextAlign = ContentAlignment.TopRight,
            };
            this.cbcCLIENTES = new ComboBox
            {
                Left = -300,
                Width = 250,
                Anchor = AnchorStyles.Bottom,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DropDownWidth = 20,
            };

            var lblAnho = new Label()
            {
                Text = "Anho",
                Left = 500,
                ForeColor = Color.White,
                Width = 150,
                TextAlign = ContentAlignment.TopRight,
            };
            this.cbcAnho = new ComboBox
            {
                Left = 250,
                Width = 250,
                Anchor = AnchorStyles.Bottom,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DropDownWidth = 20,
                Enabled = false
            };
            
            
            var lista = this.Clientes.ToList();
            string[] op = new string[this.Clientes.Count()];
            for (int i = 0; i < op.Length; i++)
            {
                Cliente cliente = lista[i];
                op[i] = cliente.Dni ;
            }
            cbcCLIENTES.Items.AddRange(op);
            
            string[] op2 = new string[22];
            for (int i = 0; i < op2.Length; i++)
            {
                int valor = 2000 + i;
                
                if(i==21) op2[21] = "";
                else op2[i] = valor.ToString();
            }
            cbcAnho.Items.AddRange(op2);
            
            cbcCLIENTES.SelectedIndexChanged += (sender, e) => this.FilaSeleccionada(lista,cbcCLIENTES.SelectedIndex);
            
            pnlClientes.Controls.Add(cbcCLIENTES);
            pnlClientes.Controls.Add(lblClientes);
            pnlClientes.Controls.Add(cbcAnho);
            pnlClientes.Controls.Add(lblAnho);


            return pnlClientes;
        }


        private void FilaSeleccionada(List<Cliente> listaClientes,int ncliente)
        {
            if (cbcAnho.SelectedIndex == -1 || cbcAnho.SelectedIndex==21)
            {
                this.tbDetalle.Clear();
                Cliente cliente = listaClientes[ncliente];

                var listaCuentas = this.Cuentas.ToList();
                var listaTransferencias = this.Transferencias.ToList();
                var listaPrestamos = this.Prestamos.ToList();

                for (int i = 0; i < this.Cuentas.Count(); i++)
                {
                    Cuenta cuenta = listaCuentas[i];
                    for (int z = 0; z < cuenta.Titulares.Count(); z++)
                    {
                        if (cuenta.Titulares[z].Nombre.Equals(cliente.Nombre))
                        {
                            this.tbDetalle.Text += "Nº de Cuenta" + i + "\r\n";
                            this.tbDetalle.Text += "Cuenta " + i + "\r\n";
                            this.tbDetalle.Text += cuenta.ToString();
                            for (int j = 0; j < cuenta.Depositos.Count; j++)
                            {
                                this.tbDetalle.Text += "Deposito " + j + "\r\n";
                                this.tbDetalle.Text += cuenta.Depositos[j].ToString();
                            }

                            for (int j = 0; j < cuenta.Retiradas.Count; j++)
                            {
                                this.tbDetalle.Text += "Retirada " + j + "\r\n";
                                this.tbDetalle.Text += cuenta.Retiradas[j].ToString();
                            }

                            for (int j = 0; j < this.Transferencias.Count(); j++)
                            {
                                Transferencia transferencia = listaTransferencias[j];
                                if (transferencia.CCCOrigen == cuenta.CCC || transferencia.CCCDestino == cuenta.CCC)
                                {
                                    this.tbDetalle.Text += "Transferencia " + j + "\r\n";
                                    this.tbDetalle.Text += transferencia.ToString();
                                }
                            }

                            for (int j = 0; j < this.Prestamos.Count(); j++)
                            {
                                Prestamo prestamo = listaPrestamos[j];
                                if (prestamo.CccOri == cuenta.CCC)
                                {
                                    this.tbDetalle.Text += "Prestamo " + j + "\r\n";
                                    this.tbDetalle.Text += prestamo.ToString();
                                }
                            }
                        }
                    }
                }

                cbcAnho.Enabled = true;
                cbcAnho.SelectedIndexChanged += (sender, e) =>
                    this.FilaSeleccionadaAnho(listaClientes, cbcCLIENTES.SelectedIndex, cbcAnho.SelectedIndex);
            }
            else
                FilaSeleccionadaAnho(listaClientes,cbcCLIENTES.SelectedIndex,cbcAnho.SelectedIndex);
        }

        private void FilaSeleccionadaAnho(List<Cliente> listaClientes, int ncliente,int anho)
        {
            var anhoComprobacion = 2000 + anho;
            if (anho != 21)
            {
                this.tbDetalle.Clear();
                Cliente cliente = listaClientes[ncliente];

                var listaCuentas = this.Cuentas.ToList();
                var listaTransferencias = this.Transferencias.ToList();
                var listaPrestamos = this.Prestamos.ToList();

                for (int i = 0; i < this.Cuentas.Count(); i++)
                {
                    Cuenta cuenta = listaCuentas[i];
                    for (int z = 0; z < cuenta.Titulares.Count(); z++)
                    {
                        if (cuenta.Titulares[z].Nombre.Equals(cliente.Nombre))
                        {
                            this.tbDetalle.Text += "Nº de Cuenta" + i + "\r\n";
                            this.tbDetalle.Text += "Cuenta " + i + "\r\n";
                            this.tbDetalle.Text += cuenta.ToString();
                            for (int j = 0; j < cuenta.Depositos.Count; j++)
                            {
                                if (cuenta.Depositos[j].DateTime.Year == anhoComprobacion)
                                {
                                    this.tbDetalle.Text += "Deposito " + j + "\r\n";
                                    this.tbDetalle.Text += cuenta.Depositos[j].ToString();
                                }
                            }

                            for (int j = 0; j < cuenta.Retiradas.Count; j++)
                            {
                                if (cuenta.Retiradas[j].DateTime.Year == anhoComprobacion)
                                {
                                    this.tbDetalle.Text += "Retirada " + j + "\r\n";
                                    this.tbDetalle.Text += cuenta.Retiradas[j].ToString();
                                }
                            }

                            for (int j = 0; j < this.Transferencias.Count(); j++)
                            {
                                Transferencia transferencia = listaTransferencias[j];
                                if (transferencia.Fecha.Year == anhoComprobacion)
                                {
                                    if (transferencia.CCCOrigen == cuenta.CCC || transferencia.CCCDestino == cuenta.CCC)
                                    {
                                        this.tbDetalle.Text += "Transferencia " + j + "\r\n";
                                        this.tbDetalle.Text += transferencia.ToString();
                                    }
                                }
                            }

                            for (int j = 0; j < this.Prestamos.Count(); j++)
                            {
                                Prestamo prestamo = listaPrestamos[j];
                                if (prestamo.Fecha.Year == anhoComprobacion)
                                {
                                    if (prestamo.CccOri == cuenta.CCC)
                                    {
                                        this.tbDetalle.Text += "Prestamo " + j + "\r\n";
                                        this.tbDetalle.Text += prestamo.ToString();
                                    }
                                }
                            }
                        }
                    }
                }

                cbcAnho.SelectedIndexChanged += (sender, e) =>
                    this.FilaSeleccionadaAnho(listaClientes, cbcCLIENTES.SelectedIndex, cbcAnho.SelectedIndex);
            }
            else
                FilaSeleccionada(listaClientes,cbcCLIENTES.SelectedIndex);
        }

        private Panel PanelDetalle()
        {
            var pnlDetalle = new Panel{Dock = DockStyle.Bottom};
            pnlDetalle.SuspendLayout();

            this.tbDetalle = new TextBox()
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                Font = new Font(FontFamily.GenericMonospace, 12),
                ForeColor = Color.Navy,
                BackColor = Color.LightGray
            };
            
            pnlDetalle.Size = new Size(400, 700);
            pnlDetalle.Controls.Add(this.tbDetalle);
            pnlDetalle.ResumeLayout(false);
            return pnlDetalle;
        }



        private Panel pnlClientes;
        private ComboBox cbcCLIENTES;
        private ComboBox cbcAnho;
        private Panel pnlPrincipal;
        private MainMenu mPpal;
        public MenuItem mArchivo;
        public MenuItem opVolver;


        public IEnumerable<Cliente> Clientes;
        public IEnumerable<Cuenta> Cuentas;
        public IEnumerable<Transferencia> Transferencias;
        public IEnumerable<Prestamo> Prestamos;
        
        private TextBox tbDetalle;

        
    }
}