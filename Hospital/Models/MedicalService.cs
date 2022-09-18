using System.ComponentModel;

namespace Hospital.Models
{
    public class MedicalService : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
