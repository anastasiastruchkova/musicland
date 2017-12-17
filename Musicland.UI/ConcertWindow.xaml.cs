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
using System.Windows.Shapes;
using Musicland.Classes;

namespace Musicland.UI
{
    /// <summary>
    /// Логика взаимодействия для ConcertWindow.xaml
    /// </summary>
    public partial class ConcertWindow : Window
    {
        public Musician musician { get; set; }
        ConcertRepository concertRepository = new ConcertRepository();

        public ConcertWindow()
        {
            InitializeComponent();
            listBoxConcerts.ItemsSource = concertRepository.Concerts;
            comboBoxSearch.Items.Add("City");
        }

        private void buttonTicket_Click(object sender, RoutedEventArgs e)
        {
            var item = listBoxConcerts.SelectedItem as Concert;
            if (item != null)
            {
                foreach (Concert concert in concertRepository.Concerts)
                {
                    if ((item.Date == concert.Date) && (item.City==concert.City))
                    {
                        concertRepository.BuyTicket(concert);
                        RefreshItemsSource();
                    }
                }
            }
            else MessageBox.Show("Choose a concert!");
        }

        public void RefreshItemsSource()
        {
            listBoxConcerts.ItemsSource = null;
            listBoxConcerts.ItemsSource=concertRepository.Concerts.Where(c=>c.Musician.Id==musician.Id);
        }

        private void listBoxConcerts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listBoxConcerts.SelectedItem as Concert;
            if (item != null)
            {
                if (item.Tickets == 0)
                { 
                    buttonTicket.IsEnabled = false;
                    MessageBox.Show("No available tickets!");
                }
                else buttonTicket.IsEnabled = true;
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxSearch.Text=="City")
            {
                var city = textBoxSearch.Text;
                listBoxConcerts.ItemsSource = null;
                listBoxConcerts.ItemsSource = concertRepository.Search(city).Where(c => c.Musician.Id == musician.Id);
                
                comboBoxSearch.Text = null;
                textBoxSearch.Text = null;
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshItemsSource();
        }
    }
}
