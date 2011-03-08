using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class WebmasterModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string ATM { get; set; }
        public string Bank { get; set; }
        public string CompanyName { get; set; }
        public string TaxCode { get; set; }
        public int AccountType { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
        public int Status { get; set; }
        public string VerifyCode { get; set; }

    }
}