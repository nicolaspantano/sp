using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Entidades.sp
{
    public class Manzana : Fruta,ISerializar,IDeserializar
    {
        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true

        protected string _provinciaOrigen;

        public Manzana()
            :base("roja",0)
        {
            
        }
        public Manzana(string color, double peso, string provincia)
            :base(color,peso)
        {
            this._provinciaOrigen = provincia;
        }

        new public string Color { get { return base._color; } set { base._color = value; } }

        new public double Peso { get { return base._peso; } set { base._peso = value; } }

        public string Nombre { get {return "Manzana"; } }

        public override bool TieneCarozo { get { return true; } }

        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nombre: ");
            sb.AppendLine(this.Nombre);
            sb.Append(base.FrutaToString());
            sb.Append("Provincia Origen: ");
            sb.AppendLine(this._provinciaOrigen);

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }

        public bool Xml(string archivo)
        {
            try
            {
                StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo);
                XmlSerializer ser = new XmlSerializer(typeof(Manzana));
                ser.Serialize(writer, this);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool IDeserializar.Xml(string archivo,out Fruta salida)
        {
            try
            {
                StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo);
                XmlSerializer ser = new XmlSerializer(typeof(Manzana));
                salida=(Fruta)(ser.Deserialize(reader));
                reader.Close();
                return true;
            }
            catch (Exception)
            {
                salida = null;
                return false;
            }
        }
    }
    }

