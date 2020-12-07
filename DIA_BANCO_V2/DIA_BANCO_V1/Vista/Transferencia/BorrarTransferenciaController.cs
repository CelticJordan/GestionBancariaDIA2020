using System.Collections.Generic;

namespace DIA_BANCO_V1
{
    using WForms = System.Windows.Forms;

    public class BorrarTransferenciaController
    {
        private List<Transferencia> transferencias;
        public BorrarTransferenciaController(List<Transferencia> transferencias)
        {
            this.transferencias = transferencias;
            this.View = new BorrarTransferencia();
            
            this.View.Bid.Click += (sender, args) => this.EliminarTransferencia();

        }

        public BorrarTransferencia View { get; }

        /// <summary>
        /// pasandole una id , busco la transferencia asociada (si existe) y la elimino, posteriormente guardo el nuevo contenido en xml
        /// </summary>
        public void EliminarTransferencia()
        {
            int id;
            int.TryParse(this.View.eid.Text, out id);
            bool esta = false;
            Transferencia aEliminar = new Transferencia();
            
            foreach (Transferencia i in transferencias)
            {
                if (i.Id == id)
                {
                    aEliminar = i;
                    esta = true;
                }
            }

            if (esta)
            {
                transferencias.Remove(aEliminar);
                WForms.MessageBox.Show("Se ha borrado correctamente");
                this.View.Hide();
                this.View.Close();
            }
            else
            {
                WForms.MessageBox.Show("No se ha encontrado ninguna transferencia con id: "+ id.ToString());
            }
        }
        
    }
}