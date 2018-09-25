using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplicants.Models
{
    public class ApplicantViewModel
    {
        [DisplayName("ID")]
        public int ApplicantId { get; set; }
        public string SSN { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Birthday")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Street")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int StateID { get; set; }
        public string Zip { get; set; }
        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }
        [DisplayName("Cell Phone")]
        public string MobilePhone { get; set; }
        public string EMail { get; set; }

        public string DisplayBirthday { get; set; }
        [DisplayName("State")]
        public string StateName { get; set; }
    }
}