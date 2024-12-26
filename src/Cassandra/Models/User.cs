using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassandra.Models
{
    public partial class User
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_bcity { get; set; }
    }
    public partial class User
    {
        public User(int user_id, String user_name, String user_bcity)
        {
            this.user_id = user_id;
            this.user_name = user_name;
            this.user_bcity = user_bcity;
        }

        public override String ToString()
        {
            return String.Format(" {0} | {1} | {2} ", user_id, user_name, user_bcity);
        }
    }
}
