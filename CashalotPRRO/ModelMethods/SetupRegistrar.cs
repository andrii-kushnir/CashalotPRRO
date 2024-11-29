using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class SetupRegistrar
    {
        public string Command { get; set; } = "SetupRegistrar";
        public long NumFiscal { get; set; }
        public string WorkMode { get; set; } = "Normal";
        public bool SendToCabinet { get; set; }
    }

    public class SetupRegistrarResult : ErrorBase
    {
        
    }
}
