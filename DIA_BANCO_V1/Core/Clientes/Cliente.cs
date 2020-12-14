using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIA_BANCO_V1
{
    public class Cliente
    {

        public Cliente(string dni, string nombre, string telefono, string email, string dirPostal)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
            this.DirPostal = dirPostal;
        }

        public string Dni
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public string Telefono
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string DirPostal
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder toret = new StringBuilder ();

            toret.Append("\nDATOS DEL CLIENTE");
            toret.Append("\r\nDNI: "+this.Dni);
            toret.Append("\r\nNombre: " + this.Nombre);
            toret.Append("\r\nTelefono: " + this.Telefono);
            toret.Append("\r\nEmail: " + this.Email);
            toret.Append("\r\nDirección postal: " + this.DirPostal);

            return toret.ToString();
        }

    }
}
