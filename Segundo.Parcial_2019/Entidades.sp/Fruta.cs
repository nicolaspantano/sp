using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
{
    public abstract class Fruta
    {
        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)

        protected double _peso;
        protected string _color;

        public double Peso { get; set; }
        public string Color { get; set; }

        public abstract bool TieneCarozo { get;  }

        public Fruta(string color,double peso)
        {
            this._peso = peso;
            this._color = color;
        }

        protected virtual string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Color: ");
            sb.AppendLine(this._color);
            sb.Append("Peso: ");
            sb.AppendLine(this._peso.ToString());
            return sb.ToString();

        }
    }
}
