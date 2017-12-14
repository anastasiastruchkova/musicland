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
    /// Логика взаимодействия для CRUDWindow.xaml
    /// </summary>
    public partial class CRUDWindow : Window
    {
        AlbumRepository albumRepository = new AlbumRepository();
        MusicianRepository musicianRepository = new MusicianRepository();
        SongRepository songRepository = new SongRepository();

        public Musician musician { get; set; }

        public CRUDWindow()
        {
            InitializeComponent();
        }

        public void RefreshItemsSource()
        {
            listboxAlbums.ItemsSource = null;
            listboxAlbums.ItemsSource = albumRepository.Albums.Where(a=>a.Musician.Id==musician.Id);
            textboxName.Text = null;
            textboxYear.Text = null;
            textboxGenre.Text = null;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((textboxName.Text!=null) && (textboxYear.Text!=null) && (textboxGenre.Text!=null))
            {
                Album album = new Album
                {
                    Name = textboxName.Text,
                    Year = int.Parse(textboxYear.Text),
                    Genre = textboxGenre.Text
                };
                albumRepository.Add(musician, album);
                RefreshItemsSource();
            }
            else MessageBox.Show("Fill all fields!");
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = listboxAlbums.SelectedItem as Album;
            if (item != null)
            {
                albumRepository.Delete(item);
                RefreshItemsSource();
            }
            else MessageBox.Show("Select an album!");
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var item = listboxAlbums.SelectedItem as Album;
            if (item != null)
            {
                string name = textboxName.Text;
                int year = int.Parse(textboxYear.Text);
                string genre = textboxGenre.Text;
                albumRepository.Update(item, name, year, genre);
                RefreshItemsSource();
            }
            else MessageBox.Show("Select an album!");
        }

        private void listboxAlbums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listboxAlbums.SelectedItem as Album;
            if (item != null)
            {
                textboxName.Text = item.Name;
                textboxYear.Text = item.Year.ToString();
                textboxGenre.Text = item.Genre;
            }
        }

        private void EditSongs_Click(object sender, RoutedEventArgs e)
        {
            if (listboxAlbums.SelectedItem != null)
            {
                EditSongWindow editSongWindow = new EditSongWindow();
                editSongWindow.album = listboxAlbums.SelectedItem as Album;
                editSongWindow.listboxSongs.ItemsSource = songRepository.Songs.Where(s=>s.Album.Id==editSongWindow.album.Id);
                editSongWindow.ShowDialog();
            }
            else MessageBox.Show("Choose an album!");
        }
        
    }
}
