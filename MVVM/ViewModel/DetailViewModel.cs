using MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace MVVM.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        //Command-Properties
        public CustomCommand OkCmd { get; set; }
        public CustomCommand AbbruchCmd { get; set; }

        //Property, welche die neue oder zu bearbeitende Person beinhaltet
        private Person neuePerson;
        public Person NeuePerson
        {
            get { return neuePerson; }
            set
            {
                neuePerson = value;
                OnPropertyChanged();
                OnAllPersonPropertiesChanged();
            }
        }

        //Person-Properties zum Anbinden (nötig für Validierung)
        public string Vorname { get => NeuePerson.Vorname; set => NeuePerson.Vorname = value; }
        public string Nachname { get => NeuePerson.Nachname; set => NeuePerson.Nachname = value; }
        public DateTime Geburtsdatum { get => NeuePerson.Geburtsdatum; set => NeuePerson.Geburtsdatum = value; }
        public bool Verheiratet { get => NeuePerson.Verheiratet; set => NeuePerson.Verheiratet = value; }
        public Color Lieblingsfarbe { get => NeuePerson.Lieblingsfarbe; set => NeuePerson.Lieblingsfarbe = value; }
        public Gender Geschlecht { get => NeuePerson.Geschlecht; set => NeuePerson.Geschlecht = value; }
        public int Kinder { get => NeuePerson.Kinder; set => NeuePerson.Kinder = value; }


        #region Validierung (vgl. M08_Validierung)
        public string Error
        {
            get { return String.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Vorname):
                        if (Vorname.Length == 0 || Vorname.Length > 50) return "Bitte geben Sie Ihren Vornamen ein.";
                        if (!Vorname.All(x => Char.IsLetter(x))) return "Der Vorname darf nur Buchstaben enthalten.";
                        if (Char.IsLower(Vorname.First())) return "Der Vorname muss mit einem Großbuchstaben beginnen";
                        break;

                    case nameof(Nachname):
                        if (Nachname.Length <= 0 || Nachname.Length > 50) return "Bitte geben Sie Ihren Nachnamen ein.";
                        if (!Nachname.All(x => Char.IsLetter(x))) return "Der Nachname darf nur Buchstaben enthalten.";
                        if (Char.IsLower(Nachname.First())) return "Der Nachname muss mit einem Großbuchstaben beginnen";
                        break;

                    case nameof(Geburtsdatum):
                        if (Geburtsdatum > DateTime.Now) return "Das Geburtsdatum darf nicht in der Zukunft liegen.";
                        if (DateTime.Now.Year - Geburtsdatum.Year > 150) return "Das Geburtsdatum darf nicht mehr als 150 Jahre in der Vergangenheit liegen.";
                        break;

                    case nameof(Lieblingsfarbe):
                        if (neuePerson.Lieblingsfarbe.ToString().Equals("#00000000")) return "Wählen Sie Ihre Lieblingsfarbe aus.";
                        break;

                    case nameof(Kinder):
                        if (neuePerson.Kinder < 0) return "Dieser Wert muss mindestens '0' sein.";
                        break;
                }
                return String.Empty;
            }
        }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void OnAllPersonPropertiesChanged()
        {
            OnPropertyChanged(nameof(Vorname));
            OnPropertyChanged(nameof(Nachname));
            OnPropertyChanged(nameof(Geburtsdatum));
            OnPropertyChanged(nameof(Lieblingsfarbe));
            OnPropertyChanged(nameof(Verheiratet));
            OnPropertyChanged(nameof(Kinder));
        }
        #endregion

        //Konstruktoren
        public DetailViewModel()
        {
            NeuePerson = new Person();

            //OK-Command (Bestätigung)
            OkCmd = new CustomCommand
                (
                    //Exe:
                    p =>
                    {
                        //Nachfrage auf Korrektheit der Daten per MessageBox
                        string ausgabe = NeuePerson.Vorname + " " + NeuePerson.Nachname + " (" + NeuePerson.Geschlecht + ")\n" + NeuePerson.Geburtsdatum.ToShortDateString() + "\n" + NeuePerson.Lieblingsfarbe.ToString();
                        ausgabe += NeuePerson.Verheiratet ? "\nIst Verheiratet" : "";
                        if (MessageBox.Show(ausgabe + "\nÜbernehmen?", "Neue Person", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //Setzen des DialogResults des Views (welches per Parameter übergeben wurde) auf true, damit das ListView weiß, dass es weiter
                            //machen kann (d.h. die neuen Person einfügen bzw. austauschen)
                            (p as Window).DialogResult = true;
                            //Schließen des Views
                            (p as Window).Close();
                        }
                    }
                );

            //Abbruch-Cmd
            AbbruchCmd = new CustomCommand
                (
                    //Exe: Schließen des Fensters
                    p => (p as Window).Close()
                );
        }
    }
}
