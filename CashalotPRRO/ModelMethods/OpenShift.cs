using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class OpenShift : RequestBase
    {
        public string Command { get; set; } = "OpenShift";
        public long NumFiscal { get; set; }
    }

    public class OpenShiftResult : ErrorBase
    {
        public string NumFiscal { get; set; }
        public int NumLocal { get; set; }
        public DateTime OrderDateTime { get; set; }
        public bool Offline { get; set; }
    }
}
