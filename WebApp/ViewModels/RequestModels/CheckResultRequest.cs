using System.Collections.Generic;

namespace WebApp.ViewModels.RequestModels
{
    public class CheckResultRequest
    {
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
        public List<AnswerRequest> Answers { get; set; }
    }

    public class AnswerRequest
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
