using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class CloseShift : RequestBase
    {
        public string Command { get; set; } = "CloseShift";
        public long NumFiscal { get; set; }
        public bool ZRepAuto { get; set; } = true;
    }

    public class CloseShiftResult : ErrorBase
    {
        public ZRepAutoInfo ZRepAutoInfo { get; set; }
        public string NumFiscal { get; set; }
        public int NumLocal { get; set; }
        public DateTime OrderDateTime { get; set; }
        public bool Offline { get; set; }
    }

    public class ZRepAutoInfo
    {
#warning доробити цей клас
    }
}
