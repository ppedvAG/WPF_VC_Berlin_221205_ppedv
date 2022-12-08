using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace MVVM.Model
{
    //Der Model-Teil beinhaltet alle Modelklassen und evtl. Klassen, welche nur mit diesen interagieren.
    //Keine Model-Klasse darf einen Referenz auf den ViewModel- oder den Model-Teil beinhalten
    public class Person
    {
        #region Statische Member
        //Statische Liste zum Speichern der Personenobjekte
        public static ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        //Statische Methode zum Laden der Personenobjekte (ruft StartViewModel auf)
        public static void LadePersonenAusDb()
        {
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Nass", Geburtsdatum = new DateTime(1999, 5, 23), Geschlecht = Gender.Weiblich, Verheiratet = true, Lieblingsfarbe = Colors.CornflowerBlue });
            Personenliste.Add(new Person() { Vorname = "Rainer", Nachname = "Zufall", Geburtsdatum = new DateTime(1977, 4, 2), Geschlecht = Gender.Männlich, Verheiratet = false, Lieblingsfarbe = Colors.IndianRed });
        }
        #endregion

        //Properties
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public bool Verheiratet { get; set; }
        public Color Lieblingsfarbe { get; set;}
        public Gender Geschlecht { get; set; }
        public int Kinder { get; set; }


        //Parameterloser Konstruktor (für Standart-Vorbelegung)
        public Person()
        {
            this.Vorname = String.Empty;
            this.Nachname = String.Empty;
            this.Geburtsdatum = DateTime.Now;
        }

        //Kopierkonstruktor (für 1-zu-1-Kopien)
        public Person(Person altePerson)
        {
            this.Vorname = altePerson.Vorname;
            this.Nachname = altePerson.Nachname;
            this.Geschlecht = altePerson.Geschlecht;
            this.Verheiratet = altePerson.Verheiratet;
            this.Lieblingsfarbe = altePerson.Lieblingsfarbe;

            this.Geburtsdatum = new DateTime(altePerson.Geburtsdatum.Year, altePerson.Geburtsdatum.Month, altePerson.Geburtsdatum.Day);
        }

        
    }
}