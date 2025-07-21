using CashalotPRRO;
using CashalotPRRO.ModelMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashalotUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var result = "{\"Totals\":{\"ZREPHEAD\":{\"REVOKED\":false,\"TESTING\":false,\"OFFLINE\":false},\"ZREPREALIZ\":{\"SUM\":15861.78,\"PWNSUMISSUED\":0.0,\"PWNSUMRECEIVED\":0.0,\"RNDSUM\":-0.13,\"NORNDSUM\":15861.65,\"ORDERSCNT\":31,\"PWNORDERSCNTISSUED\":0,\"PWNORDERSCNTRECEIVED\":0,\"TOTALCURRENCYCOST\":0,\"TOTALCURRENCYSUM\":0.0,\"TOTALCURRENCYCOMMISSION\":0.0,\"PAYFORMS\":[{\"PAYFORMCD\":0,\"PAYFORMNM\":\"ГОТІВКА\",\"SUM\":14942.70},{\"PAYFORMCD\":1,\"PAYFORMNM\":\"КАРТКА\",\"SUM\":919.08}],\"TAXES\":[{\"TYPE\":0,\"NAME\":\"ПДВ\",\"LETTER\":\"Н\",\"PRC\":0.00,\"SIGN\":false,\"TURNOVER\":15861.65,\"TURNOVERDISCOUNT\":0.0,\"SOURCESUM\":15861.65,\"SUM\":0.00}]},\"ZREPRETURN\":{\"SUM\":1000.00,\"PWNSUMISSUED\":0.0,\"PWNSUMRECEIVED\":0.0,\"RNDSUM\":-0.01,\"NORNDSUM\":999.99,\"ORDERSCNT\":1,\"PWNORDERSCNTISSUED\":0,\"PWNORDERSCNTRECEIVED\":0,\"TOTALCURRENCYCOST\":0,\"TOTALCURRENCYSUM\":0.0,\"TOTALCURRENCYCOMMISSION\":0.0,\"PAYFORMS\":[{\"PAYFORMCD\":0,\"PAYFORMNM\":\"ГОТІВКА\",\"SUM\":1000.00}],\"TAXES\":[{\"TYPE\":0,\"NAME\":\"ПДВ\",\"LETTER\":\"Н\",\"PRC\":0.00,\"SIGN\":false,\"TURNOVER\":999.99,\"TURNOVERDISCOUNT\":0.0,\"SOURCESUM\":999.99,\"SUM\":0.00}]},\"ZREPBODY\":{\"SERVICEINPUT\":27769.76,\"SERVICEOUTPUT\":0.0}},\"ShiftOpened\":\"2025-06-11T09:01:55.1059734+03:00\",\"Visualization\":null,\"ErrorCode\":\"Ok\",\"ErrorMessage\":null}";
            //var resultObj = result.Deserialize<LastShiftTotalsResult>(out var error);

            //var sum = new XRepResult { Sum = 0 };
            //if (resultObj.Totals?.ZREPREALIZ?.PAYFORMS?.FirstOrDefault(x => x.PAYFORMNM == "ГОТІВКА")?.SUM != null)
            //    sum.Sum += resultObj.Totals.ZREPREALIZ.PAYFORMS.FirstOrDefault(x => x.PAYFORMNM == "ГОТІВКА").SUM;
            //if (resultObj.Totals?.ZREPRETURN?.PAYFORMS?.FirstOrDefault(x => x.PAYFORMNM == "ГОТІВКА")?.SUM != null)
            //    sum.Sum -= resultObj.Totals.ZREPRETURN.PAYFORMS.FirstOrDefault(x => x.PAYFORMNM == "ГОТІВКА").SUM;
            //if (resultObj.Totals?.ZREPBODY?.SERVICEINPUT != null)
            //    sum.Sum += resultObj.Totals.ZREPBODY.SERVICEINPUT;
            //if (resultObj.Totals?.ZREPBODY?.SERVICEOUTPUT != null)
            //    sum.Sum -= resultObj.Totals.ZREPBODY.SERVICEOUTPUT;



            //RegisterCheckResult ddd = new RegisterCheckResult() { OrderDateTime = DateTimeOffset.Now };
            //var str = ddd.ToXml<RegisterCheckResult>();

            //var ddd = CashalotPRRO.MethodsAPI.ServerState();
            //var fff = CashalotPRRO.MethodsAPI.Objects(null, null, null);
            //var ggg = CashalotPRRO.MethodsAPI.TransactionsRegistrarState(null, null, null, 4001004105);
            //var hhh = CashalotPRRO.MethodsAPI.OpenShift(null, null, null, 4001004105);
            var jjj = CashalotPRRO.MethodsAPI.RegisterCheck(new byte[0], new byte[0], null, 4001073193, new Guid("A5EC882C-2752-4599-9E45-B57FD08AE5D7"), 1, 0, 0, 36, 1, "", "", "", "", DateTime.Now, "", "","");
            //var kkk = CashalotPRRO.MethodsAPI.LastShiftTotals(null, null, null, 4001004105);
            //var lll = CashalotPRRO.MethodsAPI.RegisterZRep(null, null, null, 4001004105);
            //var mmm = CashalotPRRO.MethodsAPI.CloseShift(null, null, null, 4001004105);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CashalotPRRO.MethodsAPI.SetupRegistrar(Convert.ToInt64(_tbNumFiscal.Text));
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var check = CashalotPRRO.MethodsAPI.GetCheck(Convert.ToInt64(_tbNumFiscal.Text), _tbNumCheck.Text);
            var ddd = check.VisualCheck;

            //CashalotPRRO.MethodsAPI.GetCheckXml(Convert.ToInt64(_tbNumFiscal.Text), _tbNumCheck.Text, out string result);

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var zvit = CashalotPRRO.MethodsAPI.GetCheck(Convert.ToInt64(_tbNumFiscal.Text), _tbNumCheck.Text);
        }
    }
}
