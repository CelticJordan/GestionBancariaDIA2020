namespace DIA_P2_banco.Cuentas
{
    public class CuentaAhorro : Cuenta
    {
        public CuentaAhorro(string ccc, Cliente cliente) : 
            base(ccc, cliente)
        {
            base.Tipo = "Ahorro";
            //base.InteresMensual = 0.1f;
        }
        
        public void AddDeposito(Deposito deposito)
        {
            this.Depositos.Add(deposito);
        }
    }
}