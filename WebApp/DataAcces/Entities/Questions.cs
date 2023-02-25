namespace WebApp.DataAcces.Entities
{
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string TrueAnswer { get; set; }
        public string FalseAnswer1 { get; set; }
        public string FalseAnswer2 { get; set; }
        public string FalseAnswer3 { get; set; }
        public int AssignmentId { get; set; }
    }
}
