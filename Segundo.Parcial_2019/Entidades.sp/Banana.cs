using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
{
    public class Banana : Fruta
    {
        //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false

        protected string _paisOrigen;

        public Banana(string color, double peso, string pais)
            :base(color,peso)
        {
            this._paisOrigen = pais;
        }
        public string Nombre { get { return "Banana"; } }
        public override bool TieneCarozo { get { return false; } }

        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nombre: ");
            sb.AppendLine(this.Nombre);
            sb.Append(base.FrutaToString());
            sb.Append("Pais de origen: ");
            sb.AppendLine(this._paisOrigen);
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }
    }
}
