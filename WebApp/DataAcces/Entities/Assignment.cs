namespace WebApp.DataAcces.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PassMark { get; set; }
        public int UserId { get; set; }
    }
}
