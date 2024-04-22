using System;
using System.Collections.Generic;

namespace _22_NguyenThaiThinh_Assignment2.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string? Password { get; set; }
        public string? ContactName { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
