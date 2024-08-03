using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class EmailDTO
    {
        public string To { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public string Appointment { get; set; }
        public bool IsConfirmed { get; set; }   
    }
}
