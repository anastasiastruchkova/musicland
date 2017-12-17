using Musicland.Classes;
using System.Windows;
using System.Windows.Controls;

namespace Musicland.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    //public delegate void GetMusician(Musician artist);

    public partial class MainWindow : Window
    {

        MusicianRepository musicianRepository = new MusicianRepository();
        AlbumRepository albumRepository = new AlbumRepository();

        
        //public GetMusician OnGetMusician;

        public MainWindow()
        {

            InitializeComponent();
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
            foreach(Album album in albumRepository.Albums)
            {
                if (item.Name==album.Name) listBoxSongs.ItemsSource = album.Songs;
            }
            
        }

        private void buttonConcerts_Click(object sender, RoutedEventArgs e)
        {
            ConcertWindow concertWindow = new ConcertWindow();
            if (comboBoxName != null) concertWindow.ShowDialog();
            else MessageBox.Show("Choose a musician!");
        }

        private void buttonCRUD_Click(object sender, RoutedEventArgs e)
        {
            CRUDWindow crudWindow = new CRUDWindow();
            if (comboBoxName != null)
            {
                //crudWindow.albumRepository.Albums=albumRepository.MusicianAlbums(comboBoxName.SelectedItem as Musician);
                //artist = comboBoxName.SelectedItem as Musician;
                //OnGetMusician?.Invoke(comboBoxName.SelectedItem as Musician);
                crudWindow.ShowDialog();
            }
            else MessageBox.Show("Choose a musician!");
        }

        
    }
}
