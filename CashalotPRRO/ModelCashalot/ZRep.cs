using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.Model
{
    public class ZRepContent
    {
        public ZHead ZREPHEAD { get; set; }
        public ZPay ZREPREALIZ { get; set; }
        public ZPay ZREPRETURN { get; set; }
        public ZCash ZREPCASH { get; set; }
        public ZVal ZREPVAL { get; set; }
        public ZFuel ZREPFUEL { get; set; }
        public ZBody ZREPBODY { get; set; }
    }
    public class ZHead
    {
        public string UID { get; set; }
        public string TIN { get; set; }
        public string IPN { get; set; }
        public string ORGNM { get; set; }
        public string POINTNM { get; set; }
        public string POINTADDR { get; set; }
        public string ORDERDATE { get; set; }
        public string ORDERTIME { get; set; }
        public string ORDERNUM { get; set; }
        public string CASHDESKNUM { get; set; }
        public string CASHREGISTERNUM { get; set; }
        public string CASHIER { get; set; }
        public string VER { get; set; }
        public string ORDERTAXNUM { get; set; }
        public bool REVOKED { get; set; }
        public bool TESTING { get; set; }
        public bool OFFLINE { get; set; }
        public string PREVDOCHASH { get; set; }
    }
    public class ZBody
    {
        public decimal SERVICEINPUT { get; set; }
        public decimal SERVICEOUTPUT { get; set; }
        public string VEHICLERN { get; set; }
    }
    public class ZFuelRemainsRow
    {
        public string NAME { get; set; }
        public string TANKNUM { get; set; }
        public string COLUMNNUM { get; set; }
        public string FAUCETNUM { get; set; }
        public decimal REMAINS { get; set; }
    }
    public class ZFuelPayFormsRow
    {
        public int PAYFORMCD { get; set; }
        public string PAYFORMNM { get; set; }
        public decimal SUM { get; set; }
        public decimal AMOUNT { get; set; }
    }
    public class ZFuelDetailsRow
    {
        public string NAME { get; set; }
        public decimal ACCEPTED { get; set; }
        public decimal REALIZVOL { get; set; }
        public decimal REALIZPRK { get; set; }
        public decimal REALIZCOST { get; set; }
        public decimal REMAINS { get; set; }
        public ZFuelPayFormsRow[] PAYFORMS { get; set; }
    }
    public class ZFuel
    {
        public ZFuelDetailsRow[] DETAILS { get; set; }
        public ZFuelRemainsRow[] REMAINS { get; set; }
    }
    public class ZValDetailsRow
    {
        public int VALNUM { get; set; }
        public int VALCD { get; set; }
        public string VALSYMCD { get; set; }
        public string VALNM { get; set; }
        public decimal COURSEBUY { get; set; }
        public decimal COURSESELL { get; set; }
        public decimal COURSEREG { get; set; }
        public decimal BUYVALI { get; set; }
        public decimal SELLVALI { get; set; }
        public decimal BUYVALN { get; set; }
        public decimal SELLVALN { get; set; }
        public decimal STORBUYVALI { get; set; }
        public decimal STORSELLVALI { get; set; }
        public decimal STORBUYVALN { get; set; }
        public decimal STORSELLVALN { get; set; }
        public decimal CINVALI { get; set; }
        public decimal COUTVALI { get; set; }
        public decimal UNUSVALI { get; set; }
        public decimal UNUSVALN { get; set; }
        public decimal COMMISSION { get; set; }
        public decimal INADVANCE { get; set; }
        public decimal INATTACH { get; set; }
        public decimal SURRCOLLECTION { get; set; }
        public decimal STORUNUSVALI { get; set; }
        public decimal STORUNUSVALN { get; set; }
        public decimal STORCINVALI { get; set; }
        public decimal STORCOUTVALI { get; set; }
        public decimal STORCOMMISSION { get; set; }
        public int VALCRCD { get; set; }
        public string CROSSSYMCD { get; set; }
        public decimal CROSSCOURSE { get; set; }
    }
    public class ZVal
    {
        public decimal TOTALINADVANCE { get; set; }
        public decimal TOTALINATTACH { get; set; }
        public decimal TOTALSURRCOLLECTION { get; set; }
        public decimal COMMISSION { get; set; }
        public int CALCDOCSCNT { get; set; }
        public decimal ACCEPTEDN { get; set; }
        public decimal ISSUEDN { get; set; }
        public decimal COMMISSIONN { get; set; }
        public int TRANSFERSCNT { get; set; }
        public ZValDetailsRow[] DETAILS { get; set; }
        public ZTaxRow[] TAXES { get; set; }
    }
    public class ZTaxRow
    {
        public int TYPE { get; set; }
        public string NAME { get; set; }
        public string LETTER { get; set; }
        public decimal PRC { get; set; }
        public bool SIGN { get; set; }
        public decimal TURNOVER { get; set; }
        public decimal TURNOVERDISCOUNT { get; set; }
        public decimal SOURCESUM { get; set; }
        public decimal SUM { get; set; }
    }
    public class ZCash
    {
        public decimal SUM { get; set; }
        public decimal COMMISSION { get; set; }
        public int ORDERSCNT { get; set; }
    }
    public class ZPayFormsRow
    {
        public int PAYFORMCD { get; set; }
        public string PAYFORMNM { get; set; }
        public decimal SUM { get; set; }
    }
    public class ZPay
    {
        public decimal SUM { get; set; }
        public decimal PWNSUMISSUED { get; set; }
        public decimal PWNSUMRECEIVED { get; set; }
        public decimal RNDSUM { get; set; }
        public decimal NORNDSUM { get; set; }
        public int ORDERSCNT { get; set; }
        public int PWNORDERSCNTISSUED { get; set; }
        public int PWNORDERSCNTRECEIVED { get; set; }
        public int TOTALCURRENCYCOST { get; set; }
        public decimal TOTALCURRENCYSUM { get; set; }
        public decimal TOTALCURRENCYCOMMISSION { get; set; }
        public ZPayFormsRow[] PAYFORMS { get; set; }
        public ZTaxRow[] TAXES { get; set; }
    }
}
