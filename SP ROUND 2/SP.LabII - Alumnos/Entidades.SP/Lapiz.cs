using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    public class Lapiz: Utiles,ISerializa,IDeserializa
    {
        //Lapiz-> color:ConsoleColor(publico); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; publico); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        public enum ETipoTrazo
        {
            Fino,Grueso,Medio
        }


        public ConsoleColor color;
        public ETipoTrazo trazo;

        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio)
            : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public Lapiz()
            :base("SinMarca",0)
        {

        }

        public ConsoleColor Color { get { return this.color; } set { this.color = value; } }
        public ETipoTrazo Trazo { get { return this.trazo; } set { this.trazo = value; } }

        public string Marca { get { return base.marca; } set { base.marca = value; } }
        public double Precio { get { return base.precio; } set { base.precio = value; } }


        public override bool PreciosCuidados { get { return true; } }

        public string Path { get { return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Pantano.Nicolas.lapiz.xml"; } }

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
                StreamWriter writer = new StreamWriter(this.Path);
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
                StreamReader reader = new StreamReader(this.Path);
                XmlSerializer ser = new XmlSerializer(typeof(Lapiz));
                lapiz=(Lapiz)(ser.Deserialize(reader));
                reader.Close();
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
