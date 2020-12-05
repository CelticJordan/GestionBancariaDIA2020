using System;

namespace DIA_BANCO_V1
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

        public void BMoficarTransferencia(string tipo)
        {
            
            TransferenciasXML transferencias = new TransferenciasXML();
            transferencias = transferencias.RecuperarXml();

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

            if (fecha)
            {
                transferencias.Edit(t);
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
    
    
