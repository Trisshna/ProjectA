using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystemApplication.Models
{
    public class AllocateVehicle
    {
        [Key]
        public int AllocateVehicleID { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Boarding Point")]
        public string BoardingPoint { get; set; }

        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        [Display(Name = "Driver Contact Number")]
        public string DriverContactNumber { get; set; }

        [Display(Name = "Vehicle Number")]
        public string VehicleNumber { get; set; }
    }
}
