using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
{
    public class Durazno : Fruta
    {
        //Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true

        protected int _cantPelusa;

        public Durazno(string color, double peso, int pelusa)
            :base(color,peso)
        {
            this._cantPelusa = pelusa;
        }

        public string Nombre { get { return "Durazno"; } }
        public override bool TieneCarozo { get { return true; } }

        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nombre: ");
            sb.AppendLine(this.Nombre);
            sb.Append(base.FrutaToString());
            sb.Append("Cantidad de pelusa: ");
            sb.AppendLine(this._cantPelusa.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }
    }
}
