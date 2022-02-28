using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistrationForm.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}
