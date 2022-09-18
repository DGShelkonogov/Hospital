using System.Collections.Generic;
using System.ComponentModel;

namespace Hospital.Models
{
    public class Treatment : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public MedicalService MedicalService { get; set; }
        public Doctor Author { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; } = new List<Drug>();

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
