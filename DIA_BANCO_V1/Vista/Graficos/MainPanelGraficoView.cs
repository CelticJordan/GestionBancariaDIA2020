using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIA_BANCO_V1
{
    /// <summary>
    /// Se encargará de mostrar los botones para acceder a los distintos tipos de graficos
    /// </summary>
    class MainPanelGraficoView:Form
    {

        public MainPanelGraficoView()
        {
            this.Build();
        }
        public void Build()
        {
            this.Text = "Listado de  Gáficos";
            this.Height = 450;
            this.Width = 400;
            this.Padding = new Padding(25);
            this.AutoSize = true;
            this.BuildPanelGráfico();
            this.Controls.Add(this.PanelGrafico);
            this.Show();

        }
        public void BuildPanelGráfico()
        {
            this.PanelGrafico = new TableLayoutPanel() {
                Dock = DockStyle.Fill
            };
            this.Btn_IngresoGeneral = new Button
            {
                Dock = DockStyle.Top,
                Margin = new Padding(5),
                Text = "Calcular Grafico de ingresos General",
            };
            this.PanelGrafico.Controls.Add(Btn_IngresoGeneral);
            this.Btn_GraficoCliente = new Button
            {
                Dock = DockStyle.Top,
                Margin = new Padding(5),
                Text = "Calcular Grafico de ingresos del Cliente"
            };
            this.PanelGrafico.Controls.Add(Btn_GraficoCliente);
            this.Btn_GraficoCuenta = new Button
            {
                Dock = DockStyle.Top,
                Margin = new Padding(5),
                Text = "Calcular Grafico resumen cuenta "
            };
            this.PanelGrafico.Controls.Add(Btn_GraficoCuenta);
            this.Btn_GraficoSaldoCliente = new Button
            {
                Dock = DockStyle.Top,
                Margin = new Padding(5),
                Text = "Calcular Gráfico saldo cliente"
            };
            this.PanelGrafico.Controls.Add(Btn_GraficoSaldoCliente);
        }
        

        public TableLayoutPanel PanelGrafico {
            get;
            set;
        } //Panel grafico
        public Button Btn_IngresoGeneral
        {
            get; private set;
        }
        public Button Btn_GraficoCliente
        {
            get; private set;
        }
        public Button Btn_GraficoCuenta
        {
            get; private set;
        }
        public Button Btn_GraficoSaldoCliente
        {
            get; private set;
        }
    }

}
