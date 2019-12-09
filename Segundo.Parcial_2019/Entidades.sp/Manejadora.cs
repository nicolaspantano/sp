using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades.sp
{
    public class Manejadora<Fruta>
    {
        public void ManejadorEventoPrecio(Cajon<Fruta> cajon)
        {
            StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\"+"CajonLleno.txt");
            writer.Write(DateTime.Now+@"\n" + "Precio total del cajon: "+cajon.PrecioTotal);
            writer.Close();            
        }
    }
}
