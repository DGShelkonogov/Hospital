using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Drug : INotifyPropertyChanged
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
