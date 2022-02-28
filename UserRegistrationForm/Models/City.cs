using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistrationForm.Models
{
    public partial class City
    {
        public City()
        {
            Customers = new HashSet<Customer>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
