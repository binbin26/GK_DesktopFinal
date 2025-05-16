using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GK_Desktop
{
    public class bank_account
    {
        public BigInteger account_id { get; set; }
        public string owner_name { get; set; }
        public string owner_address { get; set; }
        public string owner_phone { get; set; }
        public double balance { get; set; }
        public string account_type { get; set; }
        public string password { get; set; }
    }
}
