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
            comboBoxSearch.Items.Add("Month");
            comboBoxSearch.Items.Add("Year");
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
            if ((comboBoxSearch.Text != null) || (textBoxSearch.Text!=null))
            {
                if (comboBoxSearch.Text == "City")
                {                   
                    var city = textBoxSearch.Text;
                    listBoxConcerts.ItemsSource = null;
                    listBoxConcerts.ItemsSource = concertRepository.SearchCity(city).Where(c => c.Musician.Id == musician.Id);

                    comboBoxSearch.Text = null;
                    textBoxSearch.Text = null;
                }

                if (comboBoxSearch.Text == "Month")
                {
                    var month = textBoxSearch.Text;
                    if (int.Parse(month) >= 1 || int.Parse(month) <= 12)
                    {
                        listBoxConcerts.ItemsSource = null;
                        listBoxConcerts.ItemsSource = concertRepository.SearchMonth(month).Where(m => m.Musician.Id == musician.Id);
                        comboBoxSearch.Text = null;
                        textBoxSearch.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Enter a number in the range from 1 to 12");
                    }
                }
                if (comboBoxSearch.Text == "Year")
                {
                    var year = textBoxSearch.Text;
                    listBoxConcerts.ItemsSource = null;
                    listBoxConcerts.ItemsSource = concertRepository.SearchYear(year).Where(y => y.Musician.Id == musician.Id);

                    comboBoxSearch.Text = null;
                    textBoxSearch.Text = null;
                }
               
            }
            else
            {
                MessageBox.Show("Choose a parametr or fill in a textbox");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshItemsSource();
        }
    }
}
