using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.Model
{
    public class CheckContent
    {
        public CHead CHECKHEAD { get; set; }
        public CTotal CHECKTOTAL { get; set; }
        public CPayRow[] CHECKPAY { get; set; }
        public CTaxRow[] CHECKTAX { get; set; }
        public CPtks CHECKPTKS { get; set; }
        public CBodyRow[] CHECKBODY { get; set; }
    }
    public class CHead
    {
        public CheckDocumentType DOCTYPE { get; set; }
        public CheckDocumentSubType DOCSUBTYPE { get; set; }
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
        public string ORDERRETNUM { get; set; }
        public string ORDERSTORNUM { get; set; }
        public string OPERTYPENM { get; set; }
        public string VEHICLERN { get; set; }
        public bool REVOKELASTONLINEDOC { get; set; }
        public string CASHIER { get; set; }
        public string LOGOURL { get; set; }
        public string COMMENT { get; set; }
        public string VER { get; set; }
        public string ORDERTAXNUM { get; set; }
        public bool REVOKED { get; set; }
        public bool STORNED { get; set; }
        public bool TESTING { get; set; }
        public bool OFFLINE { get; set; }
        public string PREVDOCHASH { get; set; }
    }
    public class CExciseLabelsRow
    {
        public string EXCISELABEL { get; set; }
    }
    public class CBodyRow
    {
        public string CODE { get; set; }
        public string BARCODE { get; set; }
        public string UKTZED { get; set; }
        public string DKPP { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public int UNITCD { get; set; }
        public string UNITNM { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal PRICE { get; set; }
        public string LETTERS { get; set; }
        public decimal COST { get; set; }
        public string RECIPIENTNM { get; set; }
        public string RECIPIENTIPN { get; set; }
        public string BANKCD { get; set; }
        public string BANKNM { get; set; }
        public string BANKRS { get; set; }
        public string PAYDETAILS { get; set; }
        public string PAYPURPOSE { get; set; }
        public string PAYERNM { get; set; }
        public string PAYERIPN { get; set; }
        public string PAYERPACTNUM { get; set; }
        public string PAYDETAILSP { get; set; }
        public string BASISPAY { get; set; }
        public string PAYOUTTYPE { get; set; }
        public string FUELORDERNUM { get; set; }
        public string FUELUNITNM { get; set; }
        public string FUELTANKNUM { get; set; }
        public string FUELCOLUMNNUM { get; set; }
        public string FUELFAUCETNUM { get; set; }
        public bool FUELSALESIGN { get; set; }
        public int VALCD { get; set; }
        public string VALSYMCD { get; set; }
        public string VALNM { get; set; }
        public int? VALOPERTYPE { get; set; }
        public string VALOUTCD { get; set; }
        public string VALOUTSYMCD { get; set; }
        public string VALOUTNM { get; set; }
        public decimal VALCOURSE { get; set; }
        public string VALCOURSEDATE { get; set; }
        public decimal VALFOREIGNSUM { get; set; }
        public decimal VALNATIONALSUM { get; set; }
        public decimal VALCOMMISSION { get; set; }
        public int VALOPERCNT { get; set; }
        public bool VALREFUSESELL { get; set; }
        public bool PWNDIR { get; set; }
        public int? USAGETYPE { get; set; }
        public int? DISCOUNTTYPE { get; set; }
        public decimal SUBTOTAL { get; set; }
        public int? DISCOUNTNUM { get; set; }
        public string DISCOUNTTAX { get; set; }
        public decimal DISCOUNTPERCENT { get; set; }
        public decimal DISCOUNTSUM { get; set; }
        public decimal PARTPAYSUM { get; set; }
        public string COMMENT { get; set; }
        public CExciseLabelsRow[] EXCISELABELS { get; set; }
    }
    public class CPtks
    {
        public string PTKSPN { get; set; }
        public string PTKSNM { get; set; }
        public string PAYSYSTEMPN { get; set; }
        public string PAYSYSTEMNM { get; set; }
        public string ACQUIREPN { get; set; }
        public string ACQUIRENM { get; set; }
        public string ACQUIRETRANSID { get; set; }
        public string POSTRANSDATE { get; set; }
        public string POSTRANSNUM { get; set; }
        public string DEVICEID { get; set; }
        public string EPZDETAILS { get; set; }
        public string AUTHCD { get; set; }
        public string TERMINALNUM { get; set; }
        public string TERMINALADDR { get; set; }
        public string OPERNUM { get; set; }
        public string OPERSYSNUM { get; set; }
        public string BANKCD { get; set; }
        public string BANKNM { get; set; }
    }
    public class CTaxRow
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
    public class CPaySysRow
    {
        public string TAXNUM { get; set; }
        public string NAME { get; set; }
        public string ACQUIREPN { get; set; }
        public string ACQUIRENM { get; set; }
        public string ACQUIRETRANSID { get; set; }
        public string POSTRANSDATE { get; set; }
        public string POSTRANSNUM { get; set; }
        public string DEVICEID { get; set; }
        public string EPZDETAILS { get; set; }
        public string AUTHCD { get; set; }
        public decimal SUM { get; set; }
        public decimal COMMISSION { get; set; }
    }
    public class CPayRow
    {
        public int PAYFORMCD { get; set; }
        public string PAYFORMNM { get; set; }
        public decimal SUM { get; set; }
        public decimal PROVIDED { get; set; }
        public decimal REMAINS { get; set; }
        public CPaySysRow[] PAYSYS { get; set; }
    }
    public class CTotal
    {
        public decimal SUM { get; set; }
        public decimal PWNSUMISSUED { get; set; }
        public decimal PWNSUMRECEIVED { get; set; }
        public decimal RNDSUM { get; set; }
        public decimal NORNDSUM { get; set; }
        public decimal NOTAXSUM { get; set; }
        public decimal COMMISSION { get; set; }
        public int? USAGETYPE { get; set; }
        public decimal SUBCHECK { get; set; }
        public int? DISCOUNTTYPE { get; set; }
        public decimal DISCOUNTPERCENT { get; set; }
        public decimal DISCOUNTSUM { get; set; }
        public PartialPaymentType? PARTPAYTYPE { get; set; }
        public decimal PARTPAYPERCENT { get; set; }
        public decimal PARTPAYSUM { get; set; }
        public string PARTPAYORDPREPAYNUM { get; set; }
    }
}
