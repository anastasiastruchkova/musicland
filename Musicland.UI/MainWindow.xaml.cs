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
        MusicianRepository musicianRepository = new MusicianRepository();
        AlbumRepository albumRepository = new AlbumRepository();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAlbums_Click(object sender, RoutedEventArgs e)
        {
            foreach(Musician musician in musicianRepository.Musicians)
            {
                if (textBoxName.Text == "Lady Gaga")
                {
                    listBoxAlbums.ItemsSource = musician.Albums;
                }
            }
           
        }

        private void listBoxAlbums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //kdfkfs

            var item = listBoxAlbums.SelectedItem as Album;
            foreach(Album album in albumRepository.Albums)
            {
                if (item==album) listBoxSongs.ItemsSource = album.Songs;
            }
            
        }

        private void buttonConcerts_Click(object sender, RoutedEventArgs e)
        {
            ConcertWindow concertWindow = new ConcertWindow();
            if (textBoxName != null) concertWindow.ShowDialog();
            else MessageBox.Show("Fill in the textbox!");
        }
    }
}
