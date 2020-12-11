using System;
using System.Globalization;

namespace DIA_BANCO_V1 {
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Collections;
    using System.Xml.Linq;
    using System.Collections.Generic;

    public class RegistroPrestamos : ICollection<Prestamo> {
        private const string ArchivoXml = "prestamos.xml";
        private const string EtqPrestamos = "prestamos";
        private const string EtqPrestamo = "prestamo";
        private const string EtqId = "id";
        private const string EtqTipo = "Tipo";
        private const string EtqCccOri = "CCC";
        private const string EtqImporte = "importe";
        private const string EtqCuota = "cuota";
        private const string EtqNumCuotas = "numCuotas";
        private const string EtqFecha = "fecha";

        public RegistroPrestamos() {
            this.prestamos = new List<Prestamo>();
        }

        public RegistroPrestamos(IEnumerable<Prestamo> prestamos) : this() {
            this.prestamos.AddRange(prestamos);
        }

        public void Add(Prestamo p) {
            var idP = p.IdPrestamo;
            var tipo = p.Tipo;
            var numCuota = p.NumCuotas;

            if (Existe(idP)) {
                throw new ArgumentException("Ya existe un Prestamo con ese identificador");
            }

            this.prestamos.Add(p);
        }

        public bool Remove(string idP) {
            if (!Existe(idP)) {
                throw new ArgumentException("No existe ningun Prestamo con ese identificador");
            }

            foreach (var p in this.prestamos) {
                if (p.IdPrestamo.Equals(idP)) {
                    return this.prestamos.Remove(p);
                }
            }
            return false;
        }

        public bool Remove(Prestamo p) {
            return this.prestamos.Remove(p);
        }

        public void RemoveAt(int i) {
            this.prestamos.RemoveAt(i);
        }

        public bool Existe(string idP) {
            var toret = false;

            foreach (var p in this.prestamos) {
                if (p.IdPrestamo.Equals(idP)) {
                    toret = true;
                }
            }
            return toret;
        }

        public void Edit(Prestamo pEdit) {
            if (!Existe(pEdit.IdPrestamo)) {
                throw new ArgumentException("No existe ningun Prestamo con ese identificador");
            }

            foreach (var p in this.prestamos) {
                if (p.IdPrestamo.Equals(pEdit.IdPrestamo)) {
                    p.Tipo = pEdit.Tipo;
                    p.CccOri = pEdit.CccOri;
                    p.Importe = pEdit.Importe;
                    p.Cuota = pEdit.Cuota;
                    p.NumCuotas = pEdit.NumCuotas;
                    p.Fecha = pEdit.Fecha;

                }
            }
        }

        public void AddRange(IEnumerable<Prestamo> p) {
            this.prestamos.AddRange(p);
        }

        public int Count => this.prestamos.Count;

        public bool IsReadOnly => false;

        public void Clear() {
            this.prestamos.Clear();
        }

        public bool Contains(Prestamo p) {
            return this.prestamos.Contains(p);
        }

        public void CopyTo(Prestamo[] p, int i) {
            this.prestamos.CopyTo(p, i);
        }

        IEnumerator<Prestamo> IEnumerable<Prestamo>.GetEnumerator() {
            foreach (var p in this.prestamos) {
                yield return p;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            foreach (var p in this.prestamos) {
                yield return p;
            }
        }

        public Prestamo this[int i] {
            get => this.prestamos[i];
            set => this.prestamos[i] = value;
        }

        public override string ToString() {
            var toret = new StringBuilder();

            foreach (var p in this.prestamos) {
                toret.AppendLine(p.ToString());
            }

            return toret.ToString();
        }

        public void GuardaXml() {
            this.GuardaXml(ArchivoXml);
        }

        public void GuardaXml(string nf) {
            var doc = new XDocument();
            var root = new XElement(EtqPrestamos);

            foreach (var pres in this.prestamos) {

                root.Add(
                    new XElement(EtqPrestamo,
                        new XAttribute(EtqId, pres.IdPrestamo),
                        new XAttribute(EtqTipo, pres.Tipo),
                        new XAttribute(EtqCccOri, pres.CccOri),
                        new XAttribute(EtqImporte, pres.Importe.ToString("G", CultureInfo.InvariantCulture)),
                        new XAttribute(EtqCuota, pres.Cuota.ToString("G", CultureInfo.InvariantCulture)),
                        new XAttribute(EtqNumCuotas, pres.NumCuotas.ToString("G", CultureInfo.InvariantCulture)),
                        new XAttribute(EtqFecha, pres.Fecha.ToString("dd/MM/yyyy"))));
            }

            doc.Add(root);
            doc.Save(nf);
        }

        public static RegistroPrestamos RecuperaXml(string f) {
            var toret = new RegistroPrestamos();

            try {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                    && doc.Root.Name == EtqPrestamos) {
                    var prestamos = doc.Root.Elements(EtqPrestamo);
                    var provider = new CultureInfo("es-ES", false);
                    foreach (var prestamoXml in prestamos) {

                        toret.Add(new Prestamo(
                            prestamoXml.Attribute(EtqId).Value,
                            prestamoXml.Attribute(EtqTipo).Value,
                            prestamoXml.Attribute(EtqCccOri).Value,
                            Convert.ToDouble(prestamoXml.Attribute(EtqImporte).Value),
                            Convert.ToDouble(prestamoXml.Attribute(EtqCuota).Value),
                            Convert.ToInt32(prestamoXml.Attribute(EtqNumCuotas).Value),
                             DateTime.Parse(prestamoXml.Attribute(EtqFecha).Value, provider)));

                    }
                }
            } catch (XmlException) {
                toret.Clear();
            } catch (IOException) {
                toret.Clear();
            }

            return toret;
        }

        public static RegistroPrestamos RecuperaXml() {
            return RecuperaXml(ArchivoXml);
        }

        private List<Prestamo> prestamos;
    }
}