namespace DIA_P2_banco.Cuentas
{
    public class CuentaVivienda : Cuenta
    {
        public CuentaVivienda(string ccc, Cliente cliente) : 
            base(ccc, cliente)
        {
            base.Tipo = "Vivienda";
            base.InteresMensual = 0.3f;
        }
        
        public void AddDeposito(Deposito deposito)
        {
            this.Depositos.Add(deposito);
        }
    }
}