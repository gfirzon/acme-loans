//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcmeLoans.EFDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Applicant
    {
        public int ApplicantID { get; set; }
        public string SSN { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
    }
}