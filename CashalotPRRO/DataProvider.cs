using CashalotPRRO.Model;
using CashalotPRRO.ModelMethods;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CashalotPRRO
{
    public static class DataProvider
    {
#warning змінити в релізній версії!!!
        private const string connectionSql100In = "Context Connection = true;";
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
                    var sql = $@"INSERT INTO [InetClient].[dbo].[CashalotPRROErrorLog] (method, error) VALUES ('{methodName}', '{error.Ekran().Substring(0, Math.Min(2000, error.Ekran().Length))}')";
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
            if (objectBase != null && !String.IsNullOrWhiteSpace(objectBase.ErrorCode) && objectBase.ErrorCode != "Ok" && objectBase.ErrorMessage != null)
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

        public static void SaveInfoSQL(long numFiscal, ObjectsResult objects, TransactionsRegistrarStateResult transactions)
        {
            var prro = objects.TaxObjects.FirstOrDefault(o => o.TransactionsRegistrars.Any(t => t.NumFiscal == numFiscal));
            var ipn = prro.Ipn == null ? "NULL" : $"'{prro.Ipn}'";
            using (var connection = new SqlConnection(connectionSql100In))
            {
                connection.Open();
                var sql = $"IF EXISTS(SELECT * FROM [InetClient].[dbo].[CashalotPRROUsers] WHERE NumFiscal = {numFiscal}) UPDATE [InetClient].[dbo].[CashalotPRROUsers] SET NumFiscal = {numFiscal}, OrgName = '{prro.OrgName}', Name = '{prro.Name}', Address = '{prro.Address}', Tin = '{prro.Tin}', KasaName = '{transactions.Name}', Ipn = {ipn} WHERE NumFiscal = {numFiscal} ELSE INSERT INTO [InetClient].[dbo].[CashalotPRROUsers] (NumFiscal, OrgName, Name, Address, Tin, KasaName, Ipn) values ({numFiscal}, '{prro.OrgName}', '{prro.Name}', '{prro.Address}', '{prro.Tin}', '{transactions.Name}', {ipn})";
                using (var query = new SqlCommand(sql, connection))
                    query.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static List<CBodyRow> GetDataForCheck(Guid nakladnaGuid, int isPDV, out int coden)
        {
            var result = new List<CBodyRow>();
            coden = 0;

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
                        coden = Convert.ToInt32(reader["coden"]);
                        if (reader["ovid"] == System.DBNull.Value || reader["ovCashalot"] == System.DBNull.Value)
                            isErrorOv = true;
                        var bodyRow = new CBodyRow()
                        {
                            CODE = Convert.ToInt32(reader["codetv"]).ToString(),
                            NAME = new string(Convert.ToString(reader["nametv"]).Where(c => !char.IsControl(c)).ToArray()),
                            UNITCD = reader["ovid"] == System.DBNull.Value ? 2009 : Convert.ToInt32(reader["ovid"]),
                            UNITNM = reader["ovCashalot"] == System.DBNull.Value ? "шт" : Convert.ToString(reader["ovCashalot"]),
                            BARCODE = Convert.ToString(reader["barcode"]),
                            AMOUNT = Convert.ToDecimal(reader["kol"], CultureInfo.InvariantCulture),
                            PRICE = Convert.ToDecimal(reader["cena_r"], CultureInfo.InvariantCulture),
                            LETTERS = isPDV == 1 ? "А" : "Н"
                        };
                        bodyRow.COST = Math.Round(bodyRow.AMOUNT * bodyRow.PRICE, 2, MidpointRounding.AwayFromZero);
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

        public static void UpdateCheckDiscount(Guid nakladnaGuid, List<CBodyRow> listTovar)
        {
            using (var connection = new SqlConnection(connectionSql100))
            {
                connection.Open();
                string sql = "";
                foreach (var tovar in listTovar)
                {
                    if (tovar.DISCOUNTSUM == 0)
                        continue;
                    sql = $"UPDATE [InetClient].[dbo].[CashalotNRozhD] SET discount = {tovar.DISCOUNTSUM} WHERE id = '{nakladnaGuid}' AND codetv = {tovar.CODE}";
                    using (var query = new SqlCommand(sql, connection))
                        query.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
