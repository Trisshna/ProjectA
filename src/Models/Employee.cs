using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystemApplication.Models
{
    public class Employee
    {

        [Key]
        [Display(Name = "Employee ID")]
        [Required]
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Please enter an Employee's name")]
        public string EmployeeName { get; set; }


        [Required(ErrorMessage = "Please enter the Date OF Birth")]
        public DateTime DateOfBirth { get; set; }

        [Range(18,300)]
        public int Age
        {
            get { return (DateTime.Today - DateOfBirth).Days / 365; }
        }


        [Required(ErrorMessage = "Please enter an Employee's Mail ID")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Employee MailID")]
        public string MailID { get; set; }

        [Required(ErrorMessage = "Please enter your Gender")]
        public string Gender { get; set; }

        

        [Required(ErrorMessage = "Please enter the Blood Group")]
        public string Bloodgroup { get; set; }


        [Required(ErrorMessage = "Please enter the phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Please enter the Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the Boarding Point")]
        [Display(Name = "Boarding Point")]
        public string BoardingPoint { get; set; }
    }
}
