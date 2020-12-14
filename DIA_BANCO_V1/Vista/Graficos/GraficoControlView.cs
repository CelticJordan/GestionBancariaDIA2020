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
    /// Esta clase nos permitirá controlar los gráficos que queremos mostrar y modifcar estos a nuestro gusto
    /// </summary>
    class GraficoControlView
    {
        public static string[] meses = new string[12] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
        public const int CHART_CANVAS_SIZE = 800;
        public GraficoControlView()
        {
            // this.PanelGraficoView= new MainPanelGraficoView();
            // this.PanelGraficoView.Btn_IngresoGeneral.Click += (sender, args) => this.OnCrearGraficoGeneral();
            // this.PanelGraficoView.Btn_GraficoCliente.Click += (sender, args) => this.OnCrearGraficoCliente();
            // this.PanelGraficoView.Btn_GraficoCuenta.Click += (sender, args) => this.OnCrearGraficoCuenta();
            // this.PanelGraficoView.Btn_GraficoSaldoCliente.Click += (sender, args) => this.OnCrearGraficoSaldoCliente();
            //

        }
        /// <summary>
        /// Funcion que se lanzara cada vez que se use el boton de generar grafico por año
        /// </summary>
        private void SeleccionarOperacion()
        {
            try
            {
                var año = Int32.Parse(this.GraficoView.Chart.TextBox.Text.ToString());

                var type = this.GraficoView.Type.ToString();
            switch (type)
            {
                case "General": this.OnCrearGraficoGeneralAño(año);

                    break;
                case "Cliente": this.OnCrearGraficoClienteAño(año);
                        break;
                case "ResumenCuenta": this.OnCrearGraficoCuentaAño(año);
                        break;
                case "ResumenCliente":this.OnCrearGraficoClienteAñoResumen(año);
                        break;
                }

            }
            catch (FormatException E)
            {
                MessageBox.Show("Introduce los años correctamente - "+ E.StackTrace);
            }
        }
        /// <summary>
        /// Funcion que se encarga de crear el Grafico de ingresos general
        /// </summary>
        public void OnCrearGraficoGeneral()
        {
            Grafico grf = new Grafico();
            this.GraficoView = new GraficosView();
            var array_datos = grf.ordenarDatosIngresosGeneral(this.Cuentas, this.Transferencias);
            var array_años = grf.ordenarAñosIngresoGeneral(this.Cuentas, this.Transferencias);
            if (array_años.Length == 0 | array_datos.Length == 1)
            {
                MessageBox.Show("No hay datos que mostrar en el grafico");
            }
            else
            {
                this.GraficoView.Chart.Button.Click += (sender, args) => this.SeleccionarOperacion();
                this.GraficoView.setDataChart("años", "Ingresos", array_datos);
                this.GraficoView.setDataLegend(array_años);
                this.GraficoView.Chart.Draw();
                this.GraficoView.Type = "General";
                this.GraficoView.Show();
            }
        }
        /// <summary>
        /// Funcion que se encarga de crear el Grafico de ingresos general por año
        /// </summary>
        /// <param name="año"></param>
        public void OnCrearGraficoGeneralAño(int año)
        {
            Grafico grf = new Grafico();
            var array_datos = grf.ordenarMesesAñoIngresoGeneral(this.Cuentas, this.Transferencias, año);
            if (array_datos.Length == 1)
            {
                MessageBox.Show("No hay datos que mostrar en el grafico");
            }
            else
            {
               GraficosView GraficoView2 = new GraficosView();
                GraficoView2.Chart.Button.Hide();
                GraficoView2.Chart.Label.Hide();
                GraficoView2.Chart.TextBox.Hide();
                GraficoView2.setDataChart("meses", "Ingresos", array_datos);
                GraficoView2.setDataLegend(meses);
                GraficoView2.Chart.Draw();
                GraficoView2.Type = "General";
                GraficoView2.Chart.Refresh();
                GraficoView2.Show();

            }
        }
        /// <summary>
        /// Funcion que se encarga de crear el Grafico de ingresos generales de un cliente
        /// </summary>
        public void OnCrearGraficoCliente()
        {
            Grafico grf = new Grafico();
            this.GraficoView = new GraficosView();
            var array_datos = grf.ordenarIngresosCliente(this.Cliente,this.Cuentas, this.Transferencias);
            var array_años = grf.ordenarAñosIngresosCliente(this.Cliente,this.Cuentas, this.Transferencias);
            if (array_años.Length == 0 | array_datos.Length == 1)
            {
                MessageBox.Show("No hay datos que mostrar en el grafico");
            }
            else
            {
                this.GraficoView.Chart.Button.Click += (sender, args) => this.SeleccionarOperacion();
                this.GraficoView.setDataChart("años", "Ingresos", array_datos);
                this.GraficoView.setDataLegend(array_años);
                this.GraficoView.Chart.Draw();
                this.GraficoView.Type = "Cliente";
                this.GraficoView.Show();
            }
        }
        /// <summary>
        /// Funcion que se encargar de crear el Grafico de ingresos de un determinado año de un cliente
        /// </summary>
        /// <param name="año"></param>
        public void OnCrearGraficoClienteAño(int año)
        {
            Grafico grf = new Grafico();
            var array_datos = grf.ordenarIngresosClienteAño(this.Cliente, this.Cuentas, this.Transferencias,año);
            if ( array_datos.Length == 1)
            {
                MessageBox.Show("No hay datos que mostrar en el grafico");
            }
            else
            {
                GraficosView GraficoView2 = new GraficosView();
                GraficoView2.Chart.Button.Hide();
                GraficoView2.Chart.Label.Hide();
                GraficoView2.Chart.TextBox.Hide();
                GraficoView2.setDataChart("meses", "Ingresos", array_datos);
                GraficoView2.setDataLegend(meses);
                GraficoView2.Chart.Draw();
                GraficoView2.Type = "Cliente";
                GraficoView2.Chart.Refresh();
                GraficoView2.Show();
            }
        }
        /// <summary>
        /// Funcion que se encarga de crear un grafico con el resumen del saldo de una cuenta
        /// </summary>
        public void OnCrearGraficoCuenta()
        {
            Grafico grf = new Grafico();
            this.GraficoView = new GraficosView();
            var array_datos = grf.ordenarResumenCuenta(this.Cuenta, this.Transferencias);
            var array_años = grf.ordenarAñosResumenCuenta(this.Cuenta, this.Transferencias);
            if (array_años.Length == 0 | array_datos.Length == 1)
            {
                MessageBox.Show("No hay datos que mostrar en el grafico");
            }
            else
            {
                this.GraficoView.Chart.Button.Click += (sender, args) => this.SeleccionarOperacion();
                this.GraficoView.setDataChart("años", "Saldo", array_datos);
                this.GraficoView.setDataLegend(array_años);
                this.GraficoView.Chart.Draw();
                this.GraficoView.Type = "ResumenCuenta";
                this.GraficoView.Show();
            }
        }
        /// <summary>
        /// Funcion que se encarga de crear el grafico con el resumen del saldo de una cuenta en un determinado año
        /// </summary>
        /// <param name="año"></param>
        public void OnCrearGraficoCuentaAño(int año)
        {
            Grafico grf = new Grafico();
            var array_datos = grf.ordenarResumenCuentaAño( this.Cuenta, this.Transferencias, año);
            if (array_datos.Length == 1)
            {
                MessageBox.Show("No hay datos que mostrar en el grafico");
            }
            else
            {
                GraficosView GraficoView2 = new GraficosView();
                GraficoView2.Chart.Button.Hide();
                GraficoView2.Chart.Label.Hide();
                GraficoView2.Chart.TextBox.Hide();
                GraficoView2.setDataChart("meses", "Saldo", array_datos);
                GraficoView2.setDataLegend(meses);
                GraficoView2.Chart.Draw();
                GraficoView2.Type = "ResumenCuenta";
                GraficoView2.Chart.Refresh();
                GraficoView2.Show();
            }
        }
        /// <summary>
        /// Funcion que se encarga de crear el grafico de resumen del saldo de un cliente
        /// </summary>
        public void OnCrearGraficoSaldoCliente()
        {
            Grafico grf = new Grafico();
            this.GraficoView = new GraficosView();
            var array_datos = grf.ordenarResumenSaldoCliente(this.Cliente, this.Cuentas,this.Transferencias);
            var array_años = grf.ordenarAñosResumenCliente(this.Cliente, this.Cuentas,this.Transferencias);
            if (array_años.Length == 0 | array_datos.Length == 1)
            {
                MessageBox.Show("No hay datos que mostrar en el grafico");
            }
            else
            {
                this.GraficoView.Chart.Button.Click += (sender, args) => this.SeleccionarOperacion();
                this.GraficoView.setDataChart("años", "Saldo", array_datos);
                this.GraficoView.setDataLegend(array_años);
                this.GraficoView.Chart.Draw();
                this.GraficoView.Type = "ResumenCliente";
                this.GraficoView.Show();
            }
        }
        /// <summary>
        /// Funcion que se encarga de crear el grafico de resumen del saldo de un cliente en un determinado año
        /// </summary>
        /// <param name="año"></param>
        public void OnCrearGraficoClienteAñoResumen(int año)
        {
            Grafico grf = new Grafico();
            var array_datos = grf.ordenarResumenSaldoClienteAños(this.Cliente,this.Cuentas, this.Transferencias, año);
            if (array_datos.Length == 1)
            {
                MessageBox.Show("No hay datos que mostrar en el grafico");
            }
            else
            {
                GraficosView GraficoView2 = new GraficosView();
                GraficoView2.Chart.Button.Hide();
                GraficoView2.Chart.Label.Hide();
                GraficoView2.Chart.TextBox.Hide();
                GraficoView2.setDataChart("meses", "Saldo", array_datos);
                GraficoView2.setDataLegend(meses);
                GraficoView2.Chart.Draw();
                GraficoView2.Type = "ResumenCliente";
                GraficoView2.Chart.Refresh();
                GraficoView2.Show();
            }
        }

        public GraficosView GraficoView
        {
            get;
           set;
        }
        public MainPanelGraficoView PanelGraficoView
        {
            get;
             set;
        }
        /// <summary>
        /// Ienumerable de clientes para poder realizar las pruebas
        /// </summary>
        public IEnumerable<Cliente> Clientes
        {
            get;
             set;
        }
        /// <summary>
        /// Le pasamos un cliente especifíco para poder realizar las pruebas
        /// </summary>
        public Cliente Cliente
        {
            get;
            set;
        }
        /// <summary>
        /// Le pasamos una cuenta especifíca para poder realizar las pruebas
        /// </summary>
        public Cuenta Cuenta
        {
            get;
            set;
        }
        /// <summary>
        /// Ienumerable de cuentas para poder realizar las pruebas
        /// </summary>
        public IEnumerable<Cuenta> Cuentas
        {
            get;
             set;
        }
        /// <summary>
        /// Ienumerable de transferencias para poder realizar las pruebas
        /// </summary>
        public IEnumerable<Transferencia> Transferencias
        {
            get;
            set;
        }
    }
}
