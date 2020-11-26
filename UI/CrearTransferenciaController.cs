
using System;
using Transferencias.Core;

namespace Transferencias.UI
{
    using WForms = System.Windows.Forms;
    
    public class CrearTransferenciaController
    {
        public CrearTransferenciaController()
        {
            this.View = new CrearTransferencia();

            string tipo = this.View.etp.Text;
            
            this.View.etp.SelectedIndexChanged += (sender, args) =>
            {
                tipo = this.View.etp.SelectedItem.ToString();
            };
            
            this.View.BCrearTransferencia.Click += (sender, args) => this.BCrearTransferencia(tipo);
        }
        
        /// <summary>
        /// Segun los parametros pasados, se crea una trasnferencia y se guarda (si no existe previamente ninguna transfernecia asociada al id pasado)
        /// </summary>
        /// <param name="tipo"></param>
        public void BCrearTransferencia(string tipo)
        {

          TransferenciasXML transferencias = new TransferenciasXML();
          transferencias = transferencias.RecuperarXml();

            bool esta = false;
            bool fecha = false;
            
            int id;
            int.TryParse(this.View.eid.Text, out id);
            double importe;
            double.TryParse(this.View.eimporte.Text, out importe);
            DateTime data;

            if(DateTime.TryParse(this.View.efecha.Text, out data))
            {
                fecha = true;
            }
            else
            {
                fecha = false;
            }
            

            Transferencia t = new Transferencia( id, tipo, this.View.ecccorigen.Text,
                this.View.ecccdest.Text, importe, data);
            
            
            
            foreach (Transferencia transferencia in transferencias.get())
            {
                if (transferencia.Id == t.Id)
                {
                    esta = true;
                }
            }

            if (!esta && fecha)
            {
                transferencias.Add(t);
                transferencias.GuardarXml();
                WForms.MessageBox.Show("Transferencia creada correctamente");
                this.View.Hide();
                this.View.Close();
            }
            else if (!fecha)
            {
                WForms.MessageBox.Show("Error: Fecha erronea");
            }
            else
            {
                WForms.MessageBox.Show("Error: Ya existe esta transferencia");
            }
            
        }

        
        public CrearTransferencia View {
            get;
        }
    }
}