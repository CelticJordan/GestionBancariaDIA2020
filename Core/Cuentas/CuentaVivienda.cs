namespace DIA_P2_banco.Cuentas
{
    public class CuentaVivienda : Cuenta
    {
        public CuentaVivienda(string ccc, Cliente cliente) : 
            base(ccc, cliente)
        {
            base.Tipo = "Vivienda";
            base.InteresMensual = 0.3d;
        }
        
        public void AddDeposito(Deposito deposito)
        {
            base.Saldo += deposito.Cantidad;
            this.Depositos.Add(deposito);
        }
        
        public bool DeleteDeposito(Deposito deposito)
        {
            base.Saldo -= deposito.Cantidad;
            if (this.Depositos.Remove(deposito)) return true;
            else return false;
        }
    }
}