using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GK_Desktop
{
    public class transaction
    {
        public Guid trans_id { get; set; }
        public BigInteger account_id { get; set; }
        public DateTime happend_time { get; set; }
        public string action_desc { get; set; }
        public string note { get; set; }
    }
}
