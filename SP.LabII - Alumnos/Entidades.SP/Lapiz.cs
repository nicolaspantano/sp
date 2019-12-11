using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Entidades.SP
{
    public class Lapiz : Utiles,ISerializa,IDeserializa
    {
        //Lapiz-> color:ConsoleColor(publico); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; publico); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        


        public ConsoleColor color;
        public ETipoTrazo trazo;

        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio)
            : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public ConsoleColor Color { get { return this.color; } set { this.color = value; } }
        public ETipoTrazo Trazo { get { return this.trazo; } set { this.trazo = value; } }
        public double Precio { get { return base.precio; } set { base.precio = value; } }
        public string Marca { get { return base.marca; } set { base.marca = value; } }
        public override bool PreciosCuidados { get { return true; } }

        public string Path => throw new NotImplementedException();

        protected override string UtilesToString()
        {
            StringBuilder sb = new StringBuilder(base.UtilesToString());
            sb.Append("Color: ");
            sb.AppendLine(this.color.ToString());
            sb.Append("Trazo: ");
            sb.AppendLine(this.trazo.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }

        public bool Xml()
        {
            try
            {
                StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Pantano.Nicolas.Lapiz.xml");
                XmlSerializer ser = new XmlSerializer(typeof(Lapiz));
                ser.Serialize(writer, this);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool IDeserializa.Xml(out Lapiz lapiz)
        {
            try
            {
                StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Pantano.Nicolas.Lapiz.xml");
                XmlSerializer ser = new XmlSerializer(typeof(Lapiz));
                lapiz = (Lapiz)(ser.Deserialize(reader));
                return true;
            }
            catch (Exception)
            {
                lapiz = null;
                return false;
            }
        }
    }
}
