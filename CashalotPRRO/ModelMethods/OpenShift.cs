using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

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
        [XmlElement("OrderDateTime")]
        public string OrderDateTimeString
        {
            get { return OrderDateTime.ToString("yyyy-MM-ddTHH:mm:ss"); }
            set { OrderDateTime = DateTimeOffset.Parse(value); }
        }
        [XmlIgnore]
        public DateTimeOffset OrderDateTime { get; set; }
        public bool Offline { get; set; }
    }
}
