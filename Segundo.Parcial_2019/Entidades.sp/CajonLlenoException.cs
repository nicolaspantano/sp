using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
{
    class CajonLlenoException:Exception
    {
        public CajonLlenoException():base("El cajon esta lleno") { }
    }
}
