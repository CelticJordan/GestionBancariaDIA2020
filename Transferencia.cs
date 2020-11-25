namespace DIA_P2_banco.Cuentas
{
    public class Transferencia
    {
        public string Id;
        public float Importe;

        public Transferencia(string id, float importe)
        {
            this.Id = id;
            this.Importe = importe;
        }
    }
}