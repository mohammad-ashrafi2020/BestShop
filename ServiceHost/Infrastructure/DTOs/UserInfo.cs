using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Infrastructure.DTOs
{
    public class UserInfo
    {
        public string PhoneNumber { get; set; }
        public string ImageName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int WalletAmount { get; set; }
    }
}
