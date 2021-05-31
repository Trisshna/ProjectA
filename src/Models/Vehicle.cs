using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystemApplication.Models
{
    public class Vehicle
    {
        [Key]
        [Required(ErrorMessage ="Please enter the Vehicle ID")]
        [Display(Name = "Vehicle ID")]
        public int VehicleID { get; set; }


        [Required(ErrorMessage = "Please enter the Vehicle Number")]
        [Display(Name = "Vehicle Number")]
        public string VehicleNumber { get; set; }


        [Required(ErrorMessage = "Please enter the Driver's Name")]
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        [Required(ErrorMessage = "Please enter the Driver's Contact Number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string DriverContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter the Location")]
        public string Location { get; set; }

        [Required(ErrorMessage ="Please enter the Capacity of the vehicle")]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "Seats Available")]
        public int AvailableSeats { get; set; }

        [Required]
        public bool IsAC { get; set; }

        public ICollection<Route> Routes { get; set; }
    }
}
