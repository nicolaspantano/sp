using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Cartuchera<T> where T : Utiles
    {
        //Crear la clase Cartuchera<T> -> restringir para que solo lo pueda usar Utiles o clases que deriven de Utiles
        //atributos: capacidad:int y elementos:List<T> (todos protegidos)        
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total de la cartuchera (la suma de los precios de sus elementos).
        //Constructor
        //Cartuchera(), Cartuchera(int); 
        //El constructor por default es el único que se encargará de inicializar la lista.
        //Métodos
        //ToString: Mostrará en formato de tipo string: 
        //el tipo de cartuchera, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        //de todos los elementos contenidos en la misma. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos a la cartuchera siempre y cuando no supere la capacidad máxima de la misma.

        public delegate void EventoPrecioDelegate(Cartuchera<T> car,EventArgs e);


        protected int capacidad;
        protected List<T> elementos;
        public event EventoPrecioDelegate EventoPrecio;

        public List<T> Elementos { get { return this.elementos; } }
        public double PrecioTotal
        {
            get
            {
                double acumulador = 0;
                foreach (T actual in this.Elementos)
                {
                    acumulador += actual.precio;
                }
                return acumulador;
            }
        }

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }

        public Cartuchera(int capacidad)
            : this()
        {
            this.capacidad = capacidad;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Capacidad: ");
            sb.AppendLine(this.capacidad.ToString());
            sb.Append("Cantidad actual de elementos: ");
            sb.AppendLine(this.Elementos.Count.ToString());
            sb.Append("Precio total: ");
            sb.AppendLine(this.PrecioTotal.ToString());
            sb.AppendLine("Elementos: ");
            foreach (T actual in this.Elementos)
            {
                sb.AppendLine(actual.ToString());
            }
            return sb.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> car, T elemento)
        {
            if (car.Elementos.Count < car.capacidad)
            {
                
                car.Elementos.Add(elemento);
                if (car is Cartuchera<Goma>)
                {
                    if (car.PrecioTotal > 85)
                    {
                        car.EventoPrecio(car, new EventArgs());
                    }
                }
            }
            else
            {
                throw new CartucheraLlenaException();
            }
            return car;
        }

    }
}
