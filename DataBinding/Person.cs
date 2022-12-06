using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding
{
    public class Person : INotifyPropertyChanged
    {
       
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        private int alter;
        public int Alter 
        { 
            get => alter;
            set 
            { 
                alter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        public List<DateTime> WichtigeTage { get; set; } = new List<DateTime>()
        {
            DateTime.Now,
            new DateTime(2003, 5, 12),
        };

        public override string ToString()
        {
            return $"{Vorname} {Nachname} ({Alter})";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
