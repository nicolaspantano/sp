using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public interface ISerializa
    //#.-ISerializa -> Xml() : bool
    //              -> Path{ get; } : string

    {
        bool Xml();
        string Path { get; }
    }
}
