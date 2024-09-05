using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace CashalotPRRO
{
    public static class Extension
    {
        //public static string CheckOnError(this string json)
        //{
        //    if (json == null) return null;
        //    Response result;
        //    try
        //    {
        //        result = JsonConvert.DeserializeObject<Response>(json);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //    if (result.Success)
        //        return null;
        //    else
        //        return $"Code: {result.Code}; Error: {result.Description}";
        //}

        public static string ToXml<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var xmlserializer = new XmlSerializer(typeof(T));
            var settings = new XmlWriterSettings();
            //settings.Indent = true;
            //settings.OmitXmlDeclaration = true;
            var stringWriter = new StringWriter();
            try
            {
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static T ConvertXml<T>(this string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new StringReader(xml));
        }

        public static T Deserialize<T>(this string json, out string error) where T : class
        {
            error = "";
            if (json == null) return null;
            T result = null;
            try
            {
                result = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
            return result;
        }

        public static string Ekran(this string data)
        {
            var result = Regex.Replace(data, @"'", @"''");
            return result;
        }

        public static string DateToSQL(this DateTime date)
        {
            var dateBegin = new DateTime(1970, 1, 1);
            date = date < dateBegin ? dateBegin : date;
            var result = date.ToString("s");
            return result;
        }

        public static string NullCheck(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "0";
            return value;
        }
    }
}
