using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class ScheduleViewModel
    {
        public TimeOnly Time { get; set; }
        public bool IsEnabled { get; set; }
    }
}
