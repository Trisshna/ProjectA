using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystemApplication.Models
{
    public class Route
    {

        [Key]
        [Required]
        public int RouteId { get; set; }


        [Required(ErrorMessage = "Please enter the Route Number ")]
        [Display(Name = "Route Number")]
        public int RouteNumber { get; set; }

        [Required(ErrorMessage = "Please enter the Starting point")]
        [Display(Name = "Starting Point")]
        public string StartingPoint { get; set; }

        [Required(ErrorMessage = "Please enter the Ending point")]
        [Display(Name = "Ending Point")]
        public string EndingPoint { get; set; }

        [Required(ErrorMessage = "Please enter the First stop")]
        public string Stop1 { get; set; }

        [Required(ErrorMessage = "Please enter the Second stop")]
        public string Stop2 { get; set; }

        [Required(ErrorMessage = "Please enter the Third stop")]
        public string Stop3 { get; set; }

        [Required(ErrorMessage = "Please enter the Driver's Name")]
        public string DriverName { get; set; }

        [Required(ErrorMessage = "Please enter the Driver's Contact Number")]
        public string DriverContactNumber { get; set; }

        [Required]
        public string VehicleNumber { get; set; }
        public Vehicle Vehicles { get; set; }
    }
}
