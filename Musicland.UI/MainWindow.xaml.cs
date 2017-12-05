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
using Musicland.Classes;

namespace Musicland.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Musician musician;
        public MainWindow()
        {
            InitializeComponent();

            musician =
                new Musician
                {
                    Name = "Lady Gaga",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Name ="The Fame",
                            Year =2008,
                            Genre ="Pop",
                            Songs = new List<Song>
                            {
                                new Song { Title="Poker Face", Duration=240 },
                                new Song { Title="Paparazzi", Duration=200 }
                            }
                        },
                        new Album
                        {
                            Name ="Joanne",
                            Year =2016,
                            Genre ="Pop",
                            Songs = new List<Song>
                            {
                                new Song { Title="Million Reasons", Duration=233 },
                                new Song { Title="Joanne", Duration=210 }
                            }
                        }
                    }
                };
            musician.Concerts = new List<Concert>
            {
                new Concert
                {
                  City = "Moscow",
                  Date = new DateTime(2017, 11, 1),
                  Tickets = 123,
                  Album = musician.Albums[0]
                },
                new Concert
                {
                  City = "Las Vegas",
                  Date = new DateTime(2017, 10, 11),
                  Tickets = 54,
                  Album = musician.Albums[1]
                }
            };
        }

        private void buttonAlbums_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "Lady Gaga")
            {
                listBoxAlbums.ItemsSource = musician.Albums;
            }
        }

        private void listBoxAlbums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item=listBoxAlbums.SelectedItem as Album;
            listBoxSongs.ItemsSource = item.Songs;
        }

        private void buttonConcerts_Click(object sender, RoutedEventArgs e)
        {
            ConcertWindow concertWindow = new ConcertWindow();
            if (textBoxName != null) concertWindow.ShowDialog();
            else MessageBox.Show("Fill in the textbox!");
        }
    }
}
