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
            CashalotPRRO.MethodsAPI.Objects(null, null, null);

            //string base64String = "SGVsbG8gd29ybGQh";

            //// Decode Base64 string
            //byte[] bytes = Convert.FromBase64String(base64String);

            //// Convert byte array to string
            //string result = Encoding.UTF8.GetString(bytes);

            //// Output the result
            //MessageBox.Show("Decoded String: " + Convert.ToBase64String(Encoding.UTF8.GetBytes("Hello world!")));
        }
    }
}
