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
        //передать музыканта!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        ConcertRepository concertRepository = new ConcertRepository();

        public ConcertWindow()
        {
            InitializeComponent();
            listBoxConcerts.ItemsSource = concertRepository.Concerts;
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
            listBoxConcerts.ItemsSource=concertRepository.Concerts;
        }
    }
}
