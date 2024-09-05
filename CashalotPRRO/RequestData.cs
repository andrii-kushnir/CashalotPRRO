using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CashalotPRRO
{
    public static class RequestData
    {
        public static string SendPost(string url, string json, out string error)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            //request.Timeout = 300000;
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                streamWriter.Write(json);

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (HttpWebResponse errorResponse = (HttpWebResponse)ex.Response)
                    {
                        var errorResult = ParseResponse(errorResponse, out error);
                        return null;
                    }
                }
                else
                {
                    error = ex.Message;
                    return null;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
            var result = ParseResponse(response, out error);
            response.Close();
            return result;
        }

        private static string ParseResponse(HttpWebResponse response, out string error)
        {
            error = "";
            string responseBody = null;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                error += response.StatusCode.ToString();
            }

            try
            {
                using (Stream inputStream = response.GetResponseStream())
                {
                    if (inputStream != null)
                    {
                        responseBody = new StreamReader(inputStream, Encoding.UTF8).ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                error += " " + ex.Message;
                return responseBody;
            }
            return responseBody;
        }
    }
}
