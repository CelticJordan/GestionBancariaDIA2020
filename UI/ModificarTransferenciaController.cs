using System;
using Transferencias.Core;

namespace Transferencias.UI
{
    using WForms = System.Windows.Forms;
    public class ModificarTransferenciaController
    {

        public ModificarTransferenciaController()
        {

            this.View = new ModificarTransferencia();
            
            string tipo = this.View.etp.Text;
            
            this.View.etp.SelectedIndexChanged += (sender, args) =>
            {
                tipo = this.View.etp.SelectedItem.ToString();
            };
            
            this.View.BMoficarTransferencia.Click += (sender, args) => this.BMoficarTransferencia(tipo);
            
        }
        
        public Transferencia GetTransferencia(string tipo)
        {
            int id;
            int.TryParse(this.View.eid.Text, out id);
            double importe;
            double.TryParse(this.View.eimporte.Text, out importe);
            
            
            return new Transferencia( id, tipo, this.View.ecccorigen.Text,
                this.View.ecccdest.Text, importe, this.View.efecha.Text);
        }

        public void BMoficarTransferencia(string tipo)
        {
            
            TransferenciasXML transferencias = new TransferenciasXML();
            transferencias = transferencias.RecuperarXml();

            bool fecha = false;
            

            try
            {
                DateTime.Parse(this.View.efecha.Text);
                fecha = true;
            }
            catch (FormatException)
            {
                fecha = false;
                
            }
            
            if ( fecha)
            {
                transferencias.Edit(GetTransferencia(tipo));
                transferencias.GuardarXml();
                WForms.MessageBox.Show("Transferencia Modificada correctamente");
                this.View.Hide();
                this.View.Close();
            }
            else 
            {
                WForms.MessageBox.Show("Error: Fecha erronea");
            }


        }

        public ModificarTransferencia View { get; }
        
    }    
}
    
    
