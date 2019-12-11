using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades.SP
{
    public class Ticketeadora
    {
        public static bool ImprimirTicket(double precio)
        {
            try
            {
                StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\tickets.log");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(DateTime.Now.ToString());
                sb.AppendLine(precio.ToString());
                writer.Write(sb.ToString());
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
