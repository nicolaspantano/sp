using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public abstract class Utiles
    {
        //Utiles-> marca:string y precio:double (publicos); PreciosCuidados:bool (prop.s/l, abstracta);
        //constructor con 2 parametros y UtilesToString():string (protegido y virtual, retorna los valores del útil)
        //ToString():string (polimorfismo; reutilizar código)

        public string marca;
        public double precio;

        public abstract bool PreciosCuidados { get;}

        public Utiles(string marca, double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }

        protected virtual string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Marca: ");
            sb.AppendLine(this.marca);
            sb.Append("Precio: ");
            sb.AppendLine(this.precio.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }


    }
}
