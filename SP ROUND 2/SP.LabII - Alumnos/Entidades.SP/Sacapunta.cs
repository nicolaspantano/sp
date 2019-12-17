using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Sacapunta:Utiles
    {
        //Sacapunta-> deMetal:bool(publico); 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        public bool deMetal;

        public Sacapunta(bool deMetal,double precio,string marca)
            : base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        public override bool PreciosCuidados { get { return false; } }

        protected override string UtilesToString()
        {
            StringBuilder sb = new StringBuilder(base.UtilesToString());
            sb.Append("De metal: ");
            sb.AppendLine(this.deMetal.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
