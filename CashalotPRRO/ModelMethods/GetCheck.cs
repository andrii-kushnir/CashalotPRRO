using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class GetCheck
    {
        public string Command { get; set; } = "GetCheck";
        public long RegistrarNumFiscal { get; set; }
        public string NumFiscal { get; set; }
        public string Type { get; set; }
        public bool GetQrCode { get; set; }
    }

    public class GetCheckResult : ErrorBase
    {
        public string Data { get; set; }
        public string Url { get; set; }
        public string VisualCheck 
        { 
            get => Encoding.UTF8.GetString(Convert.FromBase64String(Data));
            set { }
        }

    }
}
