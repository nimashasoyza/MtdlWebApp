using System.Collections.Generic;

namespace WebApp.ViewModels.ResponseModels
{
    public class AssigmentReponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PassMark { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }

        public List<QuestionRequest> Questionaire { get; set; }
    }

    public class QuestionRequest
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string TrueAnswer { get; set; }
        public string FalseAnswer1 { get; set; }
        public string FalseAnswer2 { get; set; }
        public string FalseAnswer3 { get; set; }
    }
}
