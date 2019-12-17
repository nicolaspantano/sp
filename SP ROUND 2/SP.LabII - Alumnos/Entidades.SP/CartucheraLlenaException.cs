using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class CartucheraLlenaException : Exception
    {
        public CartucheraLlenaException():base("No se pudo agregar el elemento. La cartuchera ya esta llena") { }
    }
}
