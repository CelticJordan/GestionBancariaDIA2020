namespace DIA_P2_banco.Cuentas
{
    public class CuentaCorriente : Cuenta
    {
        public CuentaCorriente(string ccc, Cliente cliente) : 
            base(ccc, cliente)
        {
            base.Tipo = "Corriente";
            base.InteresMensual = 0.0f;
        }

        public void AddDeposito(Deposito deposito)
        {
            this.Depositos.Add(deposito);
        }

        public void AddRetirada(Retirada retirada)
        {
            this.Retiradas.Add(retirada);
        }
    }
}