
namespace WpfApp1
{
    public class Note
    {
        public string Content { get; set; }

        public Note()
        {
            Content = "";
        }

        public Note(string content)
        {
            Content = content;
        }
    }
}
