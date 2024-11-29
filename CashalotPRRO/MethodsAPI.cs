using CashalotPRRO.Model;
using CashalotPRRO.ModelMethods;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CashalotPRRO
{
    public class MethodsAPI
    {
        private const string baseUrl = "https://fsapi.cashalot.org.ua/";
        //private const string baseUrl = "";
        private const string _cert = "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";
        private const string _key = "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";
        private const string _password = "To141086";

        public static ServerStateResult ServerState()
        {
            var request = new ServerState();
            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<ServerStateResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void ServerStateXml(out string result)
        {
            result = ServerState().ToXml<ServerStateResult>();
        }

        public static GetCheckResult GetCheck(long registrarNumFiscal, string numFiscal)
        {
            var request = new GetCheck()
            {
                RegistrarNumFiscal = registrarNumFiscal,
                NumFiscal = numFiscal,
                Type = "Visualization",
                GetQrCode = false
            };

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<GetCheckResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void GetCheckXml(long registrarNumFiscal, string numFiscal, out string result)
        {
            result = GetCheck(registrarNumFiscal, numFiscal).ToXml<GetCheckResult>();
        }

        public static ObjectsResult Objects(byte[] cert, byte[] key, string password)
        {
            //var request = new Objects()
            //{
            //    UID = Guid.NewGuid(),
            //    Certificate = _cert,
            //    PrivateKey = _key,
            //    Password = _password
            //};

            var request = new Objects()
            {
                UID = Guid.NewGuid(),
                Certificate = Convert.ToBase64String(cert),
                PrivateKey = Convert.ToBase64String(key),
                Password = password
            };

            //string path = @"D:\test.txt";
            //if (request.Certificate != _cert)
            //{
            //    File.AppendAllText(path, "---");
            //    File.AppendAllText(path, request.Certificate);
            //}
            //if (request.PrivateKey != _key)
            //{
            //    File.AppendAllText(path, "---");
            //    File.AppendAllText(path, request.PrivateKey);
            //}
            //if (request.Password != _password)
            //{
            //    File.AppendAllText(path, "---");
            //    File.AppendAllText(path, request.Password);
            //}

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<ObjectsResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void ObjectsXml(byte[] cert, byte[] key, string password, out string result)
        {
            result = Objects(cert, key, password).ToXml<ObjectsResult>();
        }

        public static CertificateInfoResult CertificateInfo(byte[] cert)
        {
            var request = new CertificateInfo()
            {
                Certificate = Convert.ToBase64String(cert)
            };
            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<CertificateInfoResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void CertificateInfoXml(byte[] cert, out string result)
        {
            result = CertificateInfo(cert).ToXml<CertificateInfoResult>();
        }

        public static TransactionsRegistrarStateResult TransactionsRegistrarState(byte[] cert, byte[] key, string password, long numFiscal)
        {
            //var request = new TransactionsRegistrarState()
            //{
            //    UID = Guid.NewGuid(),
            //    Certificate = _cert,
            //    PrivateKey = _key,
            //    Password = _password,
            //    NumFiscal = numFiscal
            //};

            var request = new TransactionsRegistrarState()
            {
                UID = Guid.NewGuid(),
                Certificate = Convert.ToBase64String(cert),
                PrivateKey = Convert.ToBase64String(key),
                Password = password,
                NumFiscal = numFiscal
            };

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<TransactionsRegistrarStateResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void TransactionsRegistrarStateXml(byte[] cert, byte[] key, string password, long numFiscal, out string result)
        {
            result = TransactionsRegistrarState(cert, key, password, numFiscal).ToXml<TransactionsRegistrarStateResult>();
        }

        public static SetupRegistrarResult SetupRegistrar(long numFiscal)
        {
            var request = new SetupRegistrar()
            {
                NumFiscal = numFiscal,
                SendToCabinet = true
            };

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<SetupRegistrarResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void SetupRegistrarXml(long numFiscal, out string result)
        {
            result = SetupRegistrar(numFiscal).ToXml<SetupRegistrarResult>();
        }

        public static OpenShiftResult OpenShift(byte[] cert, byte[] key, string password, long numFiscal)
        {
            var request = new OpenShift()
            {
                UID = Guid.NewGuid(),
                Certificate = Convert.ToBase64String(cert),
                PrivateKey = Convert.ToBase64String(key),
                Password = password,
                NumFiscal = numFiscal
            };

            //var request = new OpenShift()
            //{
            //    UID = Guid.NewGuid(),
            //    Certificate = _cert,
            //    PrivateKey = _key,
            //    Password = _password,
            //    NumFiscal = numFiscal
            //};

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<OpenShiftResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void OpenShiftXml(byte[] cert, byte[] key, string password, long numFiscal, out string result)
        {
            result = OpenShift(cert, key, password, numFiscal).ToXml<OpenShiftResult>();
        }

        public static LastShiftTotalsResult LastShiftTotals(byte[] cert, byte[] key, string password, long numFiscal)
        {
            var request = new LastShiftTotals()
            {
                UID = Guid.NewGuid(),
                Certificate = Convert.ToBase64String(cert),
                PrivateKey = Convert.ToBase64String(key),
                Password = password,
                NumFiscal = numFiscal
            };

            //var request = new LastShiftTotals()
            //{
            //    UID = Guid.NewGuid(),
            //    Certificate = _cert,
            //    PrivateKey = _key,
            //    Password = _password,
            //    NumFiscal = numFiscal
            //};

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<LastShiftTotalsResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void LastShiftTotalsXml(byte[] cert, byte[] key, string password, long numFiscal, out string result)
        {
            result = LastShiftTotals(cert, key, password, numFiscal).ToXml<LastShiftTotalsResult>();
        }

        public static RegisterZRepResult RegisterZRep(byte[] cert, byte[] key, string password, long numFiscal)
        {
            var request = new LastShiftTotals()
            {
                UID = Guid.NewGuid(),
                Certificate = Convert.ToBase64String(cert),
                PrivateKey = Convert.ToBase64String(key),
                Password = password,
                NumFiscal = numFiscal
            };

            //var request = new RegisterZRep()
            //{
            //    UID = Guid.NewGuid(),
            //    Certificate = _cert,
            //    PrivateKey = _key,
            //    Password = _password,
            //    NumFiscal = numFiscal
            //};

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<RegisterZRepResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void RegisterZRepXml(byte[] cert, byte[] key, string password, long numFiscal, out string result)
        {
            result = RegisterZRep(cert, key, password, numFiscal).ToXml<RegisterZRepResult>();
        }

        public static CloseShiftResult CloseShift(byte[] cert, byte[] key, string password, long numFiscal)
        {
            //var request = new CloseShift()
            //{
            //    UID = Guid.NewGuid(),
            //    Certificate = _cert,
            //    PrivateKey = _key,
            //    Password = _password,
            //    NumFiscal = numFiscal
            //};

            var request = new CloseShift()
            {
                UID = Guid.NewGuid(),
                Certificate = Convert.ToBase64String(cert),
                PrivateKey = Convert.ToBase64String(key),
                Password = password,
                NumFiscal = numFiscal
            };

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<CloseShiftResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void CloseShiftXml(byte[] cert, byte[] key, string password, long numFiscal, out string result)
        {
            result = CloseShift(cert, key, password, numFiscal).ToXml<CloseShiftResult>();
        }

        public static RegisterCheckResult RegisterCheck(byte[] cert, byte[] key, string password, long numFiscal, int checkSubType, Guid nakladnaGuid, int payType)
        {
            //var request = new RegisterCheck()
            //{
            //    UID = Guid.NewGuid(),
            //    Certificate = _cert,
            //    PrivateKey = _key,
            //    Password = _password,
            //    NumFiscal = numFiscal
            //};

            var request = new RegisterCheck()
            {
                UID = Guid.NewGuid(),
                Certificate = Convert.ToBase64String(cert),
                PrivateKey = Convert.ToBase64String(key),
                Password = password,
                NumFiscal = numFiscal
            };

            request.Check = new CheckContent()
            {
                CHECKHEAD = new CHead() 
                { 
                    DOCTYPE = CheckDocumentType.SaleGoods
                },

                //new List<CPayRow>() 
                //{
                //    new CPayRow()
                //    {
                //        PAYFORMCD = 1,  /*0*/  /*201*/
                //        PAYFORMNM = "КАРТКА",  /*"ГОТІВКА"*/  /*"ПІСЛЯПЛАТА"*/
                //        PAYSYS = new List<CPaySysRow>()
                //        {
                //            new CPaySysRow()
                //            {
                //                NAME = "VISA", /*IssuerName*/ /*Платіжна система*/
                //                ACQUIRENM = "Приватбанк", /*AcquireName*/ /*Еквайр*/
                //                ACQUIRETRANSID = "086577310200", /*RRN*/
                //                POSTRANSDATE = DateTime.Now.ToString("ddMMyyyyHHmmss"), /*TransactionDate*/
                //                DEVICEID = "X1111RJ2", /*TerminalID*/ /*Термінал*/
                //                EPZDETAILS = "4149 43 ** 8717", /*PAN*/ /*ЕПЗ*/
                //                AUTHCD = "923557", /*ApprovalCode*/ /*Код авторизації*/
                //                SUM = 100, /*SumPayByCard*/ /*СУМА*/
                //            }
                //        }
                //    }
                //},
                CHECKPTKS = null,
            };
            switch (checkSubType)
            {
                case 0:
                    request.Check.CHECKHEAD.DOCSUBTYPE = CheckDocumentSubType.CheckGoods;
                    break;
                case 1:
                    request.Check.CHECKHEAD.DOCSUBTYPE = CheckDocumentSubType.CheckReturn;
                    break;
                default:
                    DataProvider.SaveErrorToSQL(null, "Тип чеку окрім оплати і повернення не реалізовано");
                    return null;
            }

            request.Check.CHECKBODY = DataProvider.GetDataForCheck(nakladnaGuid); 
            var sum = request.Check.CHECKBODY.Sum(ch => ch.COST);
            request.Check.CHECKTOTAL = new CTotal() { SUM = sum };

            request.Check.CHECKTAX = new List<CTaxRow>() { new CTaxRow() {
                TYPE = 6,
                NAME = "Неоподатк.",
                LETTER = "Н",
                PRC = 0,
                TURNOVER = sum,
                SOURCESUM = sum,
                SUM = 0
            } };

            var opl = DataProvider.PayType.FirstOrDefault(o => o.Item1 == payType);
#warning оплата не та або картка - це доробити
            if (opl == null || opl.Item1 == 1)
            {
                DataProvider.SaveErrorToSQL(null, "Тип оплати не знайдено або це картка(не реалізовано)");
                return null;
            }
            request.Check.CHECKPAY = new List<CPayRow>() { new CPayRow() {
                PAYFORMCD = opl.Item1,
                PAYFORMNM = opl.Item2,
                SUM = sum,
                PROVIDED = sum,
                REMAINS = 0
            } };

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<RegisterCheckResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void RegisterCheckXml(byte[] cert, byte[] key, string password, long numFiscal, int checkSubType, Guid id, int typeOpl, out string result)
        {
            result = RegisterCheck(cert, key, password, numFiscal, checkSubType, id, typeOpl).ToXml<RegisterCheckResult>();
        }


    }
}
