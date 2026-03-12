using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
