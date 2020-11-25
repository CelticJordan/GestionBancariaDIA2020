using System;
using System.Text;

namespace ProyectoDIA
{
    public class Cliente
    {
        public Cliente(string dni, string nombre, long telefono, string email, string direccionPostal)
        {
            this.DNI = dni;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
            this.DireccionPostal = direccionPostal;
        }

        public string DNI
        {
            get; private set;
        }

        public string Nombre
        {
            get; private set;
        }

        public long Telefono
        {
            get; private set;
        }

        public string Email
        {
            get; private set;
        }

        public string DireccionPostal
        {
            get; private set;
        }
        
        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            toret.AppendLine("DNI: " + this.DNI);
            toret.AppendLine("Nombre: " + this.Nombre);
            toret.AppendLine("Telefono: " + this.Telefono);
            toret.AppendLine("Email: " + this.Email);
            toret.AppendLine("Dirección postal: " + this.DireccionPostal);
            return toret.ToString();
        }
    }
}