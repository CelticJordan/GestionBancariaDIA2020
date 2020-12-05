using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gráficos.UI;

namespace DIA_BANCO_V1
{
    /// <summary>
    /// Esta clase se encarga de generar los gráficos
    /// </summary>
    class GraficosView:Form
    {
        public const int CHART_CANVAS_SIZE = 800;
        public GraficosView()
        {
            this.Build();
        }
        public void Build()
        {
            this.Text = "Gráfico";
            this.Height = CHART_CANVAS_SIZE + 50;
            this.Width = CHART_CANVAS_SIZE;
            this.Padding = new Padding(25);
            this.AutoSize = true;
            this.BuildPanelGraficoGeneral();
            this.Controls.Add(this.panelGraficoGeneral);

        }
        public void BuildPanelGraficoGeneral()
        {
            panelGraficoGeneral = new Panel();
            panelGraficoGeneral.SuspendLayout();
            panelGraficoGeneral.Dock = DockStyle.Fill;

            this.Chart = new Chart(width: CHART_CANVAS_SIZE,
                                    height: CHART_CANVAS_SIZE)
            {
                Dock = DockStyle.Fill,
            };

            //Comprobar si es antes o después del ResumenLayout
            // this.MinimumSize = new Size(CHART_CANVAS_SIZE, CHART_CANVAS_SIZE);
            panelGraficoGeneral.Controls.Add(this.Chart); //Aquí añadir el gráfico a introducir
            panelGraficoGeneral.ResumeLayout(false);

        }

        public void setDataChart(string x, string y, int[] values)
        {
            this.Chart.LegendY = y;
            this.Chart.LegendX = x;
            this.Chart.Values = values;
        }
        public void setDataLegend(string[] a)
        {
            this.Chart.ValuesDraw = a;
        }
        public Chart Chart
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public Panel panelGraficoGeneral
        {
            get;
            set;
        }
    }
}
