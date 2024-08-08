using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contactList_BE.Data.Tables
{
    public class Profile
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string MPK { get; set; }
        public int? UserID { get; set; }
    }
}
