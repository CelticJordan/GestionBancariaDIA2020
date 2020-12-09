using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections;
using System.Xml.Linq;
using System.Collections.Generic;

namespace DIA_BANCO_V1
{
    class registroClientes:ICollection<Cliente>
    {

        public List<Cliente> registro;//lista donde se almacenan los clientes

        //Constructor vacío
        public registroClientes(List<Cliente> clientes)
        {
            this.registro = clientes;
        }

        public void Add( Cliente c)//método para añadir un cliente
        {
            this.registro.Add(c);
        }

        public bool Remove(Cliente c)//método para borrar un cliente
        {
            return this.registro.Remove(c);
        }

        public void RemoveAt(int i)//borrar en una posición
        {
            this.registro.RemoveAt(i);
        }


        public void Clear()//borrar todo
        {
            this.registro.Clear();
        }

        public bool Contains(Cliente c)//Comprobar si la lista contiene un cliente 
        {
            return this.registro.Contains(c);
        }

        public void CopyTo(Cliente[] c, int i)//copia los clientes a partir de la posición i
        {
            this.registro.CopyTo(c, i);
        }

        public int Count//total de clientes
        {
            get { return registro.Count; }
        }


        public bool IsReadOnly//Especifica que no es de solo lectura
        {
            get { return false; }
        }

        //Enumerador aplicado a cliente
        IEnumerator<Cliente> IEnumerable<Cliente>.GetEnumerator()
        {
            for (int i = 0; i < registro.Count; i++)
            {
                Cliente c = this.registro[i];
                yield return c;
            }
        }

        //Enumerador sin tipo
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var c in this.registro)
            {
                yield return c;
            }
        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Cliente c in this.registro)
            {
                toret.AppendLine(c.ToString());
            }

            return toret.ToString();
        }
    }
}
