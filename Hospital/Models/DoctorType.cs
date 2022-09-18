﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class DoctorType : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
