using CashalotPRRO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

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
        [XmlElement("OrderDateTime")]
        public string OrderDateTimeString
        {
            get { return OrderDateTime.ToString("yyyy-MM-ddTHH:mm:ss"); }
            set { OrderDateTime = DateTimeOffset.Parse(value); }
        }
        [XmlIgnore]
        public DateTimeOffset OrderDateTime { get; set; }
        public bool Offline { get; set; }
        public decimal Sum { get; set; }  //При введенні/виведенні готівки я це значення заповнюю вручну бо кашалот вертає 0
    }
}
