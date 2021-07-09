using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Models
{
    public class DbContacts
    {
        [Key]
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string phoneCell { get; set; }
        public string phoneOffice { get; set; }
        public string email { get; set; }
        public string address { get; set; }


    }
}
