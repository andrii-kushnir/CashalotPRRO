using CashalotPRRO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class RegisterCheck : RequestBase
    {
        public string Command { get; set; } = "RegisterCheck";
        public long NumFiscal { get; set; }
        public CheckContent Check { get; set; }
    }

    public class RegisterCheckResult : ErrorBase
    {
        public string QrCode { get; set; }
        public string Url { get; set; }
        public string NumFiscal { get; set; }
        public int NumLocal { get; set; }
        public DateTime OrderDateTime { get; set; }
        public bool Offline { get; set; }
    }
}
