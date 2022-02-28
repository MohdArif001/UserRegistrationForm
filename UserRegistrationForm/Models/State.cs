using System;
using System.Collections.Generic;

#nullable disable

namespace UserRegistrationForm.Models
{
    public partial class State
    {
        public State()
        {
            Customers = new HashSet<Customer>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
       
    }
}
