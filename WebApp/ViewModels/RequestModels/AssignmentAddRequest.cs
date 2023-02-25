namespace WebApp.ViewModels.RequestModels
{
    public class AssignmentAddRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PassMark { get; set; }
        public int UserId { get; set; }
    }
}
