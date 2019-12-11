using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades.SP
{
    public class Cartuchera<T> where T : Utiles
    {
        public delegate void EventoPrecioDelegate(object sender,EventArgs e);


        protected int capacidad;
        protected List<T> elementos;
        
        public event EventoPrecioDelegate EventoPrecio;

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }

        public Cartuchera(int capacidad)
            :this()
        {
            this.capacidad = capacidad;
        }


        public List<T> Elementos { get {return this.elementos; } }
        public double PrecioTotal
        {
            get
            {
                double precioTotal = 0;

                foreach(T actual in this.Elementos)
                {
                    precioTotal += actual.precio;
                }

                return precioTotal;
            }
        }

       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Tipo de cartuchera: ");
            sb.AppendLine();
            sb.Append("Capacidad: ");
            sb.AppendLine(this.capacidad.ToString());
            sb.Append("Precio total: ");
            sb.AppendLine(this.PrecioTotal.ToString());
            
            foreach(T actual in this.Elementos)
            {
                sb.AppendLine(actual.ToString());
            }

            return sb.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> cartuchera,T elemento)
        {
            if (cartuchera.Elementos.Count < cartuchera.capacidad)
            {
                cartuchera.Elementos.Add(elemento);
                if (cartuchera.PrecioTotal > 85)
                {                    
                    cartuchera.EventoPrecio(cartuchera,new EventArgs());                                        
                }
            }
            return cartuchera;
        }


    }
}
