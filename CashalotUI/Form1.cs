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
            //var ddd = CashalotPRRO.MethodsAPI.ServerState();
            //var fff = CashalotPRRO.MethodsAPI.Objects(null, null, null);
            //var ggg = CashalotPRRO.MethodsAPI.TransactionsRegistrarState(null, null, null, 4001004105);
            //var hhh = CashalotPRRO.MethodsAPI.OpenShift(null, null, null, 4001004105);
            //var jjj = CashalotPRRO.MethodsAPI.RegisterCheck(null, null, null, 4001004105, new Guid("076724AF-559A-4A40-A8A8-2A7552207F55"), 0);
            //var kkk =  CashalotPRRO.MethodsAPI.LastShiftTotals(null, null, null, 4001004105);
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
    }
}
