using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;

namespace DIA_BANCO_V1
{
    using System.Windows.Forms;
    using System.Drawing;
    using System;
    
    public class DlgTransferenciasBanco : Form
    {
        public DlgTransferenciasBanco(IEnumerable<Transferencia> trasnferences)
        {
            this.Transferencias = trasnferences;
            
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

            this.Text = "Gestion de un banco - Buscar Transferencias Banco";

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
                BackColor = Color.FromArgb(60, 80, 120),
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

            var lblAnho = new Label()
            {
                Text = "Anho",
                Left = 200,
                ForeColor = Color.White,
                Width = 150,
                TextAlign = ContentAlignment.TopRight,
            };
            this.cbcAnho = new ComboBox
            {
                Left = -50,
                Width = 250,
                Anchor = AnchorStyles.Bottom,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DropDownWidth = 20,
            };

            string[] op2 = new string[22];
            for (int i = 0; i < op2.Length; i++)
            {
                int valor = 2000 + i;
                
                if(i==21) op2[21] = "";
                else op2[i] = valor.ToString();
            }
            cbcAnho.Items.AddRange(op2);
            
            cbcAnho.SelectedIndexChanged += (sender, e) => this.FilaSeleccionada();
            
            pnlClientes.Controls.Add(cbcAnho);
            pnlClientes.Controls.Add(lblAnho);


            return pnlClientes;
        }


        private void FilaSeleccionada()
        {
            if (cbcAnho.SelectedIndex == -1 || cbcAnho.SelectedIndex==21)
            {
                this.tbDetalle.Clear();
                var listaTransferencias = this.Transferencias.ToList();
                    for (int j = 0; j < this.Transferencias.Count(); j++)
                    {
                        Transferencia transferencia = listaTransferencias[j];
                        this.tbDetalle.Text += "Transferencia " + j + "\r\n";
                        this.tbDetalle.Text += transferencia.ToString();
                    }

                cbcAnho.SelectedIndexChanged += (sender, e) => 
                    this.FilaSeleccionadaAnho(cbcAnho.SelectedIndex);
            }
            else
                FilaSeleccionadaAnho(cbcAnho.SelectedIndex);
        }

        private void FilaSeleccionadaAnho(int anho)
        {
            var anhoComprobacion = 2000 + anho;
            if (anho != 21)
            {
                this.tbDetalle.Clear();
                var listaTransferencias = this.Transferencias.ToList();
                
                for (int j = 0; j < this.Transferencias.Count(); j++)
                {
                    Transferencia transferencia = listaTransferencias[j]; 
                    if (transferencia.Fecha.Year == anhoComprobacion)
                    { 
                        this.tbDetalle.Text += "Transferencia " + j + "\r\n";
                        this.tbDetalle.Text += transferencia.ToString();
                    }
                }

                cbcAnho.SelectedIndexChanged += (sender, e) =>
                    this.FilaSeleccionadaAnho(cbcAnho.SelectedIndex);
            }
            else
                FilaSeleccionada();
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
            
            FilaSeleccionada();
            
            return pnlDetalle;
        }



        private Panel pnlClientes;
        private ComboBox cbcAnho;
        private Panel pnlPrincipal;
        private MainMenu mPpal;
        public MenuItem mArchivo;
        public MenuItem opVolver;
        
        public IEnumerable<Transferencia> Transferencias;
        
        private TextBox tbDetalle;

    }
}