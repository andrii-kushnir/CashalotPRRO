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
        //private const string baseUrl = "https://fsapi.cashalot.org.ua/";
        private const string baseUrl = "";
        private const string _cert = "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";
        private const string _key = "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";
        private const string _password = "Slava20022024";

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

        public static CloseShiftResult CloseShift(byte[] cert, byte[] key, string password, long numFiscal)
        {
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

        public static RegisterCheckResult RegisterCheck(byte[] cert, byte[] key, string password, long numFiscal, Guid id, int payType)
        {
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
                    DOCTYPE = CheckDocumentType.SaleGoods,
                    DOCSUBTYPE = CheckDocumentSubType.CheckGoods,
                },
                //CHECKTOTAL = null,
                //CHECKPAY = null,
                ////new List<CPayRow>() 
                ////{
                ////    new CPayRow()
                ////    {
                ////        PAYFORMCD = 1,  /*0*/  /*201*/
                ////        PAYFORMNM = "КАРТКА",  /*"ГОТІВКА"*/  /*"ПІСЛЯПЛАТА"*/
                ////        PAYSYS = new List<CPaySysRow>()
                ////        {
                ////            new CPaySysRow()
                ////            {
                ////                NAME = "VISA", /*IssuerName*/ /*Платіжна система*/
                ////                ACQUIRENM = "Приватбанк", /*AcquireName*/ /*Еквайр*/
                ////                ACQUIRETRANSID = "086577310200", /*RRN*/
                ////                POSTRANSDATE = DateTime.Now.ToString("ddMMyyyyHHmmss"), /*TransactionDate*/
                ////                DEVICEID = "X1111RJ2", /*TerminalID*/ /*Термінал*/
                ////                EPZDETAILS = "4149 43 ** 8717", /*PAN*/ /*ЕПЗ*/
                ////                AUTHCD = "923557", /*ApprovalCode*/ /*Код авторизації*/
                ////                SUM = 100, /*SumPayByCard*/ /*СУМА*/
                ////            }
                ////        }
                ////    }
                ////},
                //CHECKTAX = null,
                //CHECKPTKS = null,
                //CHECKBODY = null,
            };

            request.Check.CHECKBODY = DataProvider.GetDataForCheck(id); 
            var sum = request.Check.CHECKBODY.Sum(ch => ch.COST);
            request.Check.CHECKTOTAL = new CTotal() { SUM = sum };
            request.Check.CHECKPAY[0].SUM = sum;

            var opl = DataProvider.PayType.FirstOrDefault(o => o.Item1 == payType);
#warning оплата не та або картка - це доробити
            if (opl == null || opl.Item1 == 1)
            {
                DataProvider.SaveErrorToSQL(null, "Тип оплати не знайдено або це картка(не реалізовано)");
                return null;
            }
            CPayRow cPayRow = new CPayRow()
            {
                PAYFORMCD = opl.Item1,
                PAYFORMNM = opl.Item2,
            };
            request.Check.CHECKPAY = new List<CPayRow>() { cPayRow };

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var result = RequestData.SendPost(baseUrl, json, out string error);
            DataProvider.SaveErrorToSQL(null, error);
            var resultObj = result.Deserialize<RegisterCheckResult>(out error);
            DataProvider.SaveErrorToSQL(null, error);
            DataProvider.SaveErrorToSQL(null, resultObj);
            return resultObj;
        }

        public static void RegisterCheckXml(byte[] cert, byte[] key, string password, long numFiscal, Guid id, int typeOpl, out string result)
        {
            result = RegisterCheck(cert, key, password, numFiscal, id, typeOpl).ToXml<RegisterCheckResult>();
        }

    }
}
