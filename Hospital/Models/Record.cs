using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public enum RecordStatus
    {
        PENDING,
        CANCELED,
        COMPLETED
    }

    public class Record : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public RecordStatus Status { get; set; }
        public DateTime DateTime { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
