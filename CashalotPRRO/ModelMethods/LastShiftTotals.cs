using CashalotPRRO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class LastShiftTotals : RequestBase
    {
        public string Command { get; set; } = "LastShiftTotals";
        public long NumFiscal { get; set; }
    }

    public class LastShiftTotalsResult : ErrorBase
    {
        public ZRepContent Totals { get; set; }
    }
}
