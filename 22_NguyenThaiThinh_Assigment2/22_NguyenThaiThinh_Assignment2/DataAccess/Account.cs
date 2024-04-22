using System;
using System.Collections.Generic;

namespace _22_NguyenThaiThinh_Assignment2.DataAccess
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public bool Type { get; set; }
    }
}
