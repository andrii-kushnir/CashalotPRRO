using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class ServerState
    {
        public string Command { get; set; } = "ServerState";
    }

    public class ServerStateResult : ErrorBase
    {
        public bool Available { get; set; }
        public string Version { get; set; }
    }
}
