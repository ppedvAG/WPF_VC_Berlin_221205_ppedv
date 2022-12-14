using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Vorbereitung
            this.DataContext= this;
        }

        public ObservableCollection<PKW> PKWListe{ get; set; } = new ObservableCollection<PKW>()
        {
            new PKW() {Hersteller="Audi", Model="Auto", Preis=23000}, 
            new PKW() {Hersteller="VW", Model="Auto1", Preis=25000}, 
        };

        private void Btn_ControlTemplate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button funktioniert");
        }

        private void Btn_Löschen_Click(object sender, RoutedEventArgs e)
        {
            //Löschen des PKWs, welcher in dem Button-Tag liegt
            PKWListe.Remove((sender as Button).Tag as PKW);
        }
    }
}
