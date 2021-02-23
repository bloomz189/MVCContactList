using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContactDTO
    {
        public int ID { get; set; }

        [Display(Name="Company Name:")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Address:")]
        public string CompanyAddress { get; set; }
        [Display(Name = "Company Phone:")]
        public int? CompanyTel { get; set; }
        [Display(Name = "Contact Person:")]
        public string ContactPerson { get; set; }
    }
}
