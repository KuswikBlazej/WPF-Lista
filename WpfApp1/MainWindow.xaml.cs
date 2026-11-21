
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Xml.Serialization;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Note> notes =
            new ObservableCollection<Note>();

        string filePath = "notatki.xml";

        public MainWindow()
        {
            InitializeComponent();

            NotesList.ItemsSource = notes;

            LoadNotes();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd window = new WindowAdd();

            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                string content = window.NoteContent;

                if (!string.IsNullOrWhiteSpace(content))
                {
                    notes.Add(new Note(content));
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Pliki XML (*.xml)|*.xml";
            dialog.FileName = "notatki.xml";
            dialog.Title = "Zapisz notatki";

            if (dialog.ShowDialog() == true)
            {

                XmlSerializer serializer =
                   new XmlSerializer(typeof(ObservableCollection<Note>));

                using (FileStream fs = new FileStream(
                    dialog.FileName, FileMode.Create))
                {
                    serializer.Serialize(fs, notes);
                }

                filePath = dialog.FileName;

                MessageBox.Show("Notatki zapisane!");

            }
        }

        private void LoadNotes()
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer =
                    new XmlSerializer(typeof(ObservableCollection<Note>));

                using (FileStream fs = new FileStream(
                    filePath, FileMode.Open))
                {
                    var loadedNotes =
                        (ObservableCollection<Note>)
                        serializer.Deserialize(fs);

                    notes.Clear();

                    foreach (Note note in loadedNotes)
                    {
                       notes.Add(note);
                    }
                    }
                }

            }
        }
    }
}
