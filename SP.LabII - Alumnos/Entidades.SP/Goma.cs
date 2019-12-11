using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Goma : Utiles
    {
        //Goma-> soloLapiz:bool(publico); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).

        public bool soloLapiz;

        public Goma(bool soloLapiz,string marca,double precio)
            :base(marca,precio)
        {
            this.soloLapiz = soloLapiz;
        }

        public override bool PreciosCuidados { get { return true; } }

        protected override string UtilesToString()
        {
            StringBuilder sb = new StringBuilder(base.UtilesToString());
            sb.Append("Solo lapiz: ");
            sb.AppendLine(this.soloLapiz.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
