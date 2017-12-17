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
        
        public CRUDWindow()
        {
            InitializeComponent(); 

            foreach (Musician musician in musicianRepository.Musicians)
            {
                comboBoxName1.Items.Add(musician);
            }
        }

        public void RefreshItemsSource()
        {
            listboxAlbums.ItemsSource = null;
            listboxAlbums.ItemsSource = albumRepository.Albums;
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
                albumRepository.Add(album);
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

        

        private void comboBoxName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxName1.SelectedItem != null)
            {
                var item = comboBoxName1.SelectedItem as Musician;
                foreach (Musician musician in musicianRepository.Musicians)
                {
                    if (item.Name == musician.Name)
                    {
                        listboxAlbums.ItemsSource = musician.Albums;
                    }
                }
            }
            else MessageBox.Show("Choose a musician!");
        }
    }
}
