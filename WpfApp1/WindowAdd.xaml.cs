using System.Windows;

namespace WpfApp1
{
    public partial class WindowAdd : Window
    {
        public string NoteContent { get; private set; }

        public WindowAdd()
        {
            InitializeComponent();
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            NoteContent = NoteText.Text;

            DialogResult = true;

        }
    }
}