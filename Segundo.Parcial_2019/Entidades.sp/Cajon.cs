using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Entidades.sp
{
    public class Cajon<T>:ISerializar
    {
        //Crear la clase Cajon<T>
        //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)        
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
        //Constructor
        //Cajon(), Cajon(int), Cajon(double, int); 
        //El por default: es el único que se encargará de inicializar la lista.
        //Métodos
        //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
        //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.

        public delegate void EventoPrecioDelegate(Cajon<T> cajon);
    

        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;
        [XmlIgnore]
        public EventoPrecioDelegate EventoPrecio;

        public List<T> Elementos { get {return this._elementos; } }
        public double PrecioTotal { get { return this._precioUnitario * this.Elementos.Count; } }

        public int Capacidad { get { return this._capacidad; } set { this._capacidad = value; } }

        public Cajon()
        {
            this._elementos = new List<T>();
        }

        public Cajon(int capacidad)
            :this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(double precio, int capacidad)
            :this(capacidad)
        {
            this._precioUnitario = precio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Capacidad: ");
            sb.AppendLine(this._capacidad.ToString());
            sb.Append("Cantidad actual: ");
            sb.AppendLine(this.Elementos.Count.ToString());
            sb.Append("Precio total: ");
            sb.AppendLine(this.PrecioTotal.ToString());
            sb.AppendLine("Elementos: ");
            foreach(T actual in this.Elementos)
            {
                sb.AppendLine(actual.ToString());
            }

            return sb.ToString();

        }

        public bool Xml(string archivo)
        {
            try
            {
                StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo);
                XmlSerializer ser = new XmlSerializer(typeof(Cajon<T>));
                ser.Serialize(writer, this);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            


        }

        public static Cajon<T> operator +(Cajon<T> cajon, T elemento)
        {
            if (cajon.Elementos.Count < cajon._capacidad)
            {
                cajon.Elementos.Add(elemento);
               
            }
            else
            {
                throw new CajonLlenoException();
            }

            return cajon;
        }

        
    }
}
