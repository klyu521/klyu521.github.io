using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Requests
    {
        /// <summary>
        /// The automatically generated ID in the database. This is the PRIMARY KEY.
        /// </summary>
        [Key]
        public int ID { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
     
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
       
        [Required]
        [Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }
      
        [Required]
        [Display(Name = "Unit Number")]
        public int UnitNumber { get; set; }
        
        [Required(ErrorMessage = "Explanation"), StringLength(80, ErrorMessage = "Input can be less than 80 Characters")] 
        public string Explanation { get; set; }

        [Required]
        public bool Permission { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} UnitNumber = {UnitNumber} {Explanation} Permission = {Permission}";
        }
    }
}