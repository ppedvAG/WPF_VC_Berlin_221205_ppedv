using System;
using System.Collections.Generic;
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

namespace Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            if (Cbb_Auswahl.SelectedItem != null)
                Lbl_Output.Content = (Cbb_Auswahl.SelectedItem as ComboBoxItem).Content;

            Tbx_Input.Text = Sdr_Wert.Value.ToString();
        }

        private void Schließen_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Möchtest du das Fenster wirklich schließen?", "Beenden", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }

        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow =  new MainWindow();

            newWindow.Title = "Neues Fenster";

            newWindow.Show();
        }

        private void Dialog_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new MainWindow();

            newWindow.Title = "Neues Dialog-Fenster";

            if (newWindow.ShowDialog() == true)
                Lbl_Output.Content = "OKAY";
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; 
            this.Close();
        }
    }
}
