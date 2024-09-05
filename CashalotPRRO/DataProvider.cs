using CashalotPRRO.Model;
using CashalotPRRO.ModelMethods;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CashalotPRRO
{
    public static class DataProvider
    {
#warning змінити в релізній версії!!!
        //private const string connectionSql100 = "Context Connection = true;";
        private const string connectionSql100 = @"Server=192.168.4.100; Database=InetClient; uid=КушнірА; pwd=зщшфтв;";

        public static List<Tuple<int, string>> PayType = new List<Tuple<int, string>>();

        public static void SaveErrorToSQL(SqlConnection connection, string error)
        {
            if (!String.IsNullOrWhiteSpace(error))
            {
                var methodName = new StackTrace(1).GetFrame(0).GetMethod().Name;
                var isConnection = (connection != null);
                if (isConnection)
                    connection.Close();
                using (SqlConnection connectionNew = new SqlConnection(connectionSql100))
                {
                    connectionNew.Open();
                    var sql = $@"INSERT INTO [InetClient].[dbo].[CashalotPRROErrorLog] (method, error) VALUES ('{methodName}', '{error.Ekran()}')";
                    using (var query = new SqlCommand(sql, connectionNew))
                        query.ExecuteNonQuery();
                    connectionNew.Close();
                }
                if (isConnection)
                    connection.Open();
            }
        }
        
        public static void SaveErrorToSQL(SqlConnection connection, ErrorBase objectBase)
        {
            if (objectBase != null && !String.IsNullOrWhiteSpace(objectBase.ErrorCode))
            {
                var methodName = new StackTrace(1).GetFrame(0).GetMethod().Name;
                var isConnection = (connection != null);
                if (isConnection)
                    connection.Close();
                using (SqlConnection connectionNew = new SqlConnection(connectionSql100))
                {
                    connectionNew.Open();
                    var sql = $@"INSERT INTO [InetClient].[dbo].[CashalotPRROErrorLog] (method, error) VALUES ('{methodName}', 'ErrorCode: {objectBase.ErrorCode}; ErrorMessage: {objectBase.ErrorMessage.Ekran()}')";
                    using (var query = new SqlCommand(sql, connectionNew))
                        query.ExecuteNonQuery();
                    connectionNew.Close();
                }
                if (isConnection)
                    connection.Open();
            }
        }

        public static List<CBodyRow> GetDataForCheck(Guid nakladnaGuid)
        {
            var result = new List<CBodyRow>();

            using (var connection = new SqlConnection(connectionSql100))
            {
                var query = $"EXECUTE [us_CashalotPRRO_DataForCheck] '{nakladnaGuid}'";
                var command = new SqlCommand(query, connection);
                connection.Open();
                var isErrorOv = false;
                SqlDataReader reader = null;
                try
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["ovid"] == System.DBNull.Value || reader["ovCashalot"] == System.DBNull.Value)
                            isErrorOv = true;
                        var bodyRow = new CBodyRow()
                        {
                            CODE = Convert.ToInt32(reader["codetv"]).ToString(),
                            NAME = new string(Convert.ToString(reader["nametv"]).Where(c => !char.IsControl(c)).ToArray()),
                            UNITCD = reader["ovid"] == System.DBNull.Value ? 2009 : Convert.ToInt32(reader["ovid"]),
                            UNITNM = reader["ovCashalot"] == System.DBNull.Value ? "шт" : Convert.ToString(reader["ovCashalot"]),
                            BARCODE = Convert.ToString(reader["barcode"]),
                            AMOUNT = Convert.ToDecimal(reader["kol"]),
                            PRICE = Convert.ToDecimal(reader["cena_r"]),
                            LETTERS = "Н"
                        };
                        bodyRow.COST = bodyRow.AMOUNT * bodyRow.PRICE;
                        result.Add(bodyRow);
                    }
                    reader.NextResult();
                    while (reader.Read())
                    {
                        var paytype = Convert.ToInt32(reader["paytype"]);
                        var payname = Convert.ToString(reader["payname"]);
                        PayType.Add(Tuple.Create(paytype, payname));
                    }
                }
                catch (Exception ex)
                {
                    SaveErrorToSQL(connection, ex.Message);
                }
                finally
                {
                    reader?.Close();
                }
                if (isErrorOv)
                    SaveErrorToSQL(connection, $"Невірна одиниця виміру в накладій: {nakladnaGuid}");

            }
            return result;
        }


    }
}
