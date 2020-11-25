using System;

namespace Gráficos.Pruebas
{/// <summary>
/// Clase de prueba de Cliente solo cogemos algun datos relevante
/// </summary>
    class Cliente
    {
        public Cliente(String dni, String nombre)
        {
            this.DNI = dni;
            this.Nombre = nombre;
        }

        public String DNI
        {
            get;
            set;
        }

        public String Nombre
        {
            get;
            set;
        }

    }
}
