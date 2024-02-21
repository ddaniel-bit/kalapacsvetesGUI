using System;
using System.Collections.Generic;
using System.IO;
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

namespace kalapacsvetesGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Versenyző> versenyzok = new List<Versenyző>();
        public MainWindow()
        {
            InitializeComponent();
            
            StreamReader sr = new StreamReader("Selejtezo2012.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                versenyzok.Add(new Versenyző(sr.ReadLine()));
            }
            List<string> nevek = new List<string>();
            foreach (var item in versenyzok)
            {
                nevek.Add(item.Nev);
            }
            cbVersenyzok.ItemsSource = nevek;
        }

        private void cbVersenyzok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVersenyzok.SelectedIndex != -1)
            {
                lblCsoport.Content = versenyzok[cbVersenyzok.SelectedIndex].Csoport;
                lblNemzet.Content = versenyzok[cbVersenyzok.SelectedIndex].Nemzet;
                lblKod.Content = versenyzok[cbVersenyzok.SelectedIndex].Kod;
                lblSorozat.Content = $"{versenyzok[cbVersenyzok.SelectedIndex].D1};{versenyzok[cbVersenyzok.SelectedIndex].D2};{versenyzok[cbVersenyzok.SelectedIndex].D3}";
                lblEredmeny.Content = versenyzok[cbVersenyzok.SelectedIndex].Eredmeny;

                LoadAndDisplayImage(versenyzok[cbVersenyzok.SelectedIndex].Kod);

            }
        }
        private void LoadAndDisplayImage(string kod)
        {
            try
            {
                //string[] imageFiles = Directory.GetFiles(folderPath, "*.png"); // Csak PNG formátumokat kezelünk, kiegészítheted más formátumokkal

                BitmapImage bitmap = new BitmapImage(new Uri($"../../../Images/{kod}.png", UriKind.Relative));
                imgZaszlo.Source = bitmap;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt: {ex.Message}");
            }
        }
    }
}
