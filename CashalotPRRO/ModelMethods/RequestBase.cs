using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.ModelMethods
{
    public class RequestBase
    {
        public Guid UID { get; set; }
        public string Certificate { get; set; }
        public string PrivateKey { get; set; }
        public string Password { get; set; }
    }
}
