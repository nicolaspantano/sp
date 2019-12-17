using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public static class ClaseExtendedora
    {
        //Agregar, para la clase CartucheraLlenaException, un método de extensión (InformarNovedad():string)
        //que retorne el mensaje de error

        public static string InformarNovedad(this CartucheraLlenaException e)
        {
            return e.Message;
        }
    }
}
