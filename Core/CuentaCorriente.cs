using System;

namespace ProyectoDIAIndep.Core
{
    public class CuentaCorriente
    {
        private string idccc;
        public CuentaCorriente(string idCuenta)
        {
            this.IdCcc = idCuenta;
        }

        public string IdCcc
        {
            get => idccc;
            set => idccc = value;
        }

        public override string ToString()
        {
            return String.Format("{0}", IdCcc);
        }
    }
}