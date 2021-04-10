namespace TestApp.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string LinkLong { get; set; }
        public string LinkShort { get; set; }
        public Link() { }
        public Link(string linkLong, string linkShort)
        {
            this.LinkLong = linkLong;
            this.LinkShort = linkShort;
        }
    }
}