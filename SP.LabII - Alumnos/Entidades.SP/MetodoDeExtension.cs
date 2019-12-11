using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public static class MetodoDeExtension
    {
        public static string InformarNovedad(this CartucheraLlenaException e)
        {
            return e.Message;
        } 
    }
}
