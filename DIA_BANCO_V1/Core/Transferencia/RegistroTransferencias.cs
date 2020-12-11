using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DIA_BANCO_V1
{
    class TransferenciasXML
    {
        public const string NombreArchivoXml = "transferencias.xml";
        public const string TagTransferencias = "Transferencias";
        public const string TagTransferencia = "Transferencia";

        private List<Transferencia> transferencias;


        public TransferenciasXML()
        {
            this.transferencias = new List<Transferencia>();
        }
        
        public TransferenciasXML(IEnumerable<Transferencia> reparaciones) :this()
        {
          this.transferencias.AddRange(reparaciones);
        }

        public List<Transferencia> get()
        {
            return this.transferencias;
        }
        
        public void Add(Transferencia transferencia)
        {
            this.transferencias.Add(transferencia);
        }
        
        public bool Remove(Transferencia t)
        {
            return this.transferencias.Remove(t);
        }
        
        public bool Contains(Transferencia t)
        {
            return this.transferencias.Contains(t);
        }
        
        public void Clear()
        {
            this.transferencias.Clear();
        }

        
        public void Edit(Transferencia tEdit)
        {
            foreach (Transferencia t in this.transferencias)
            {
                if (t.Id.Equals(tEdit.Id))
                {
                    t.Tipo = tEdit.Tipo;
                    t.CCCOrigen = tEdit.CCCOrigen;
                    t.CCCDestino = tEdit.CCCDestino;
                    t.Importe = tEdit.Importe;
                    t.Fecha = tEdit.Fecha;

                }
            }
        }
        
        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Transferencia i in transferencias)
            {
                toret.AppendLine(i.ToString());
            }

            return toret.ToString();
        }
        
        public void GuardarXml()
    {
      this.GuardarXml(NombreArchivoXml);
    }
    /// <summary>
    /// guarda los datos en un archivo xml
    /// </summary>
    /// <param name="archivo"></param>
    public void GuardarXml(string archivo)
    {
      var doc = new XDocument();
      var root = new XElement(TagTransferencias);

      foreach (Transferencia transferencia in this.transferencias)
      {
        try {
            root.Add(
              new XElement(TagTransferencia,
                new XAttribute("Id", transferencia.Id),
                new XAttribute("Tipo", transferencia.Tipo),
                new XAttribute("CCC_origen", transferencia.CCCOrigen),
                new XAttribute("CCC_destino", transferencia.CCCDestino),
                new XAttribute("Importe", transferencia.Importe),
                new XAttribute("Fecha", transferencia.Fecha)));
        }
        catch(System.IndexOutOfRangeException e)
        {
          System.Console.WriteLine("ERROR" + e);
        }
      }

      doc.Add(root);
      doc.Save(archivo);
    }

    public TransferenciasXML RecuperarXml()
    {
      return RecuperarXml(NombreArchivoXml);
    }
    /// <summary>
    /// recupera los datos del xml
    /// </summary>
    /// <param name="archivo"></param>
    /// <returns></returns>
    public static TransferenciasXML RecuperarXml(string archivo)
    {

      //Creo un nuevo objecto al que volcaré los datos cargados de reparaciones.xml
      var toret = new TransferenciasXML();

      try
      {
          //Cargo transferencias.xml
          var doc = XDocument.Load(archivo);

          //Si hay contenido y la raiz se llama transferencias
          if (doc.Root != null && doc.Root.Name == TagTransferencias)
          {
              //Almaceno en la variable data las reparaciones
              var data = doc.Root.Elements(TagTransferencia);

              //Para cada conjunto de elementos (reparacion)
              foreach (XElement transferenciaxml in data)
              {
                  toret.Add(new Transferencia((int) transferenciaxml.Attribute("Id"),
                      (string) transferenciaxml.Attribute("Tipo"), (string) transferenciaxml.Attribute("CCC_origen"),
                      (string) transferenciaxml.Attribute("CCC_destino"),
                      (double) transferenciaxml.Attribute("Importe"), (DateTime) transferenciaxml.Attribute("Fecha")));
              }
          }
      }
      catch (XmlException)
      {
          toret.Clear();
      }
      catch (IOException)
      {
          toret.Clear();
      }

      return toret;
      }
    }
}