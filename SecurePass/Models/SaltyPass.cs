using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass.Models
{
    public class SaltyPass
    {
        public string Salt { get; set; }
        public string Hashpassword { get; set; }
    }
}
