using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class TransactionsRegistrarState : RequestBase
    {
        public string Command { get; set; } = "TransactionsRegistrarState";
        public long NumFiscal { get; set; }
    }

    public class TransactionsRegistrarStateResult : ErrorBase
    {
        public int ShiftState { get; set; }
        public int ShiftId { get; set; }
        public object OpenShiftFiscalNum { get; set; }
        public bool ZRepPresent { get; set; }
        public bool Testing { get; set; }
        public object Name { get; set; }
        public object SubjectKeyId { get; set; }
        public int FirstLocalNum { get; set; }
        public int NextLocalNum { get; set; }
        public object LastFiscalNum { get; set; }
        public bool OfflineSupported { get; set; }
        public bool ChiefCashier { get; set; }
        public object OfflineSessionId { get; set; }
        public object OfflineSeed { get; set; }
        public object OfflineNextLocalNum { get; set; }
        public object OfflineSessionDuration { get; set; }
        public object OfflineSessionsMonthlyDuration { get; set; }
        public bool Closed { get; set; }
        public bool OfflineDocumentsPresent { get; set; }
        public object OfflineDocumentsAutoRegState { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public object TaxObject { get; set; }
    }
}
