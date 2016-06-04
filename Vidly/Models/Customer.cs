using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {   //Primary Key
        public int Id { get; set; }
        //Makes table not nullable (have to enter value)
        [Required(ErrorMessage = "Please enter customer's name.")]
        //data anotations
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //Naviagation Property -from one type to another
        public MembershipType MembershipType { get; set; }

        //foreignKey - dont want to load the whole membership object
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        
    }
}