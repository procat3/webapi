//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIProcat.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsValidEmail { get; set; }
        public string PracticeNumber { get; set; }
        public string CellphonNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
