using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class CertificateInfo
    {
        public string Command { get; set; } = "CertificateInfo";
        public string Certificate { get; set; }
    }
    public class CertificateInfoResult : ErrorBase
    {
        public DateTime DtBeg { get; set; }
        public DateTime DtEnd { get; set; }
        public String Edrpou { get; set; }
        public String Drfo { get; set; }
        public String Name { get; set; }
        public bool Stamp { get; set; }
    }
}
