using System.ComponentModel;

namespace Hospital.Models
{
    public class Doctor : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set; }
        public DoctorType DoctorType { get; set; }
        public User User { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
