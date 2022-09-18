using System.Collections.Generic;
using System.ComponentModel;

namespace Hospital.Models
{
    public class Patient : INotifyPropertyChanged
    {
        public int Id { get; set; }
            
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Policy { get; set; }
        public string Registration { get; set; }

        public User User { get; set; }

        public virtual ICollection<MedicalService> MedicalServices { get; set; } = new List<MedicalService>();

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
