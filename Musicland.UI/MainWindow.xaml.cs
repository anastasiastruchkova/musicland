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
    /// 

    public partial class MainWindow : Window
    {
        MusicianRepository musicianRepository = new MusicianRepository();
        AlbumRepository albumRepository = new AlbumRepository();

        public MainWindow()
        {
            InitializeComponent();
            mediaElementBeatles.Play();
            foreach(Musician musician in musicianRepository.Musicians)
            {
                comboBoxName.Items.Add(musician);
            }
        }

        private void buttonAlbums_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxName.SelectedItem != null)
            {
                var item = comboBoxName.SelectedItem as Musician;
                foreach (Musician musician in musicianRepository.Musicians)
                {
                    if (item.Name == musician.Name)
                    {
                        listBoxAlbums.ItemsSource = musician.Albums;
                    }
                }
            }
            else MessageBox.Show("Choose a musician!");
        }

        private void listBoxAlbums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listBoxAlbums.SelectedItem as Album;
            if (item != null)
            {
                foreach (Album album in albumRepository.Albums)
                {
                    if (item.Name == album.Name) listBoxSongs.ItemsSource = album.Songs;
                }
            }
        }

        private void buttonConcerts_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxName != null)
            {
                ConcertWindow concertWindow = new ConcertWindow();
                concertWindow.musician = comboBoxName.SelectedItem as Musician;
                concertWindow.listBoxConcerts.ItemsSource = concertWindow.musician.Concerts;
                concertWindow.ShowDialog();
            }
            else MessageBox.Show("Choose a musician!");
        }

        private void buttonCRUD_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxName != null)
            {
                CRUDWindow crudWindow = new CRUDWindow();
                crudWindow.musician = comboBoxName.SelectedItem as Musician;
                crudWindow.listboxAlbums.ItemsSource = crudWindow.musician.Albums;
                crudWindow.ShowDialog();
            }
            else MessageBox.Show("Choose a musician!");
        }

        private void comboBoxName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBoxAlbums.ItemsSource = null;
            listBoxSongs.ItemsSource = null;
            //kbmb
        }
    }
}
