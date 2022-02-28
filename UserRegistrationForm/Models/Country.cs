using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistrationForm.Models
{
    public partial class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
