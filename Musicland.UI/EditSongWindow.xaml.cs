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
    /// Логика взаимодействия для EditSongWindow.xaml
    /// </summary>
    public partial class EditSongWindow : Window
    {
        public Album album { get; set; }
        SongRepository songRepository = new SongRepository();


        public EditSongWindow()
        {
            InitializeComponent();
        }
        
        public void RefreshItemsSource()
        {
            listboxSongs.ItemsSource = null;
            listboxSongs.ItemsSource = songRepository.Songs.Where(s => s.Album.Id == album.Id);
            textBoxTitle.Text = null;
            textBoxDuration.Text = null;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((textBoxTitle.Text != null) && (textBoxDuration.Text != null))
                {
                    Song song = new Song
                    {
                        Title = textBoxTitle.Text,
                        Duration = int.Parse(textBoxDuration.Text)
                    };
                    songRepository.Add(album, song);
                    RefreshItemsSource();
                }
                else MessageBox.Show("Fill all fields!");
            }
            catch
            {
                MessageBox.Show("Fill all fields!");
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = listboxSongs.SelectedItem as Song;
            if (item != null)
            {
                songRepository.Delete(item);
                RefreshItemsSource();
            }
            else MessageBox.Show("Select a song!");
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var item = listboxSongs.SelectedItem as Song;
            if (item != null)
            {
                string title = textBoxTitle.Text;
                int duration = int.Parse(textBoxDuration.Text);
                songRepository.Update(item, title, duration);
                RefreshItemsSource();
            }
            else MessageBox.Show("Select a song!");
        }

        private void listboxSongs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listboxSongs.SelectedItem as Song;
            if (item != null)
            {
                textBoxTitle.Text = item.Title;
                textBoxDuration.Text = item.Duration.ToString();
            }
        }
        
    }
}
