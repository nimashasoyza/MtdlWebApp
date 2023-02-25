using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DataAcces;
using WebApp.DataAcces.Entities;
using WebApp.Exceptions;
using WebApp.ViewModels.RequestModels;
using WebApp.ViewModels.ResponseModels;

namespace WebApp.Services
{
    public class AssignmentService : IAssignmentService
    {
        private AppDbContext _context;

        public AssignmentService(AppDbContext context)
        {
            _context = context;
        }


        public int Add(AssignmentAddRequest request)
        {
            if (request.UserId <= 0)
                throw new AppException("UserId is Required");

            var data = new Assignment
            {
                Description = request.Description,
                Title = request.Title,
                UserId = request.UserId,
                PassMark = request.PassMark,
                VideoId = 0
            };

            var entity = _context.Add(data);
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public List<AssigmentReponse> GetByUserId(int userId)
        {
            var assignments = _context.Assignment.Where(i => i.UserId == userId).ToList();
            if (assignments != null && assignments.Any())
            {
                List<AssigmentReponse> results = new List<AssigmentReponse>();

                List<int> ids = assignments.Select(i => i.Id).ToList();
                var questionaire = GetQuestionaire(ids);

                return assignments.Select(i => new AssigmentReponse
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    VideoId = i.VideoId,
                    PassMark = i.PassMark,
                    UserId = i.UserId,
                    Questionaire = questionaire.ContainsKey(i.Id) ? questionaire[i.Id] : null
                }).ToList();

            }
            return null;
        }

        private Dictionary<int, List<QuestionRequest>> GetQuestionaire(List<int> ids)
        {
            if (ids.Any())
            {
                Dictionary<int, List<QuestionRequest>> results = new Dictionary<int, List<QuestionRequest>>();
                foreach (var id in ids)
                {
                    var questions = _context.Questions.Where(i => i.AssignmentId == id).ToList();
                    if (questions != null && questions.Any())
                    {
                        var values = questions.Select(i => new QuestionRequest
                        {
                            Question = i.Question,
                            TrueAnswer = i.TrueAnswer,
                            FalseAnswer1 = i.FalseAnswer1,
                            FalseAnswer2 = i.FalseAnswer2,
                            FalseAnswer3 = i.FalseAnswer3,
                            Id = i.Id
                        }).ToList();

                        results.Add(id, values);
                    }
                }
                return results;
            }
            return null;
        }

        public void Update(AssigmentReponse assignmentUpdateRequest)
        {
            var entity =_context.Assignment.FirstOrDefault(i => i.Id == assignmentUpdateRequest.Id);
            if (entity == null)
                throw new AppException("no assignment created for this id.");

            entity.Title = assignmentUpdateRequest.Title;
            entity.Description = assignmentUpdateRequest.Description;
            entity.PassMark = assignmentUpdateRequest.PassMark;
            entity.VideoId = assignmentUpdateRequest.VideoId;

            List<Questions> questionAddEntities = new List<Questions>();
            List<Questions> questionUpdateEntities = new List<Questions>();
            if (assignmentUpdateRequest.Questionaire != null && assignmentUpdateRequest.Questionaire.Any())
            {
                foreach (var Question in assignmentUpdateRequest.Questionaire)
                {
                    var exitItem = _context.Questions.FirstOrDefault(i => i.Id == Question.Id);
                    if (exitItem != null)
                    {
                        exitItem.Question = Question.Question;
                        exitItem.TrueAnswer = Question.TrueAnswer;
                        exitItem.FalseAnswer1 = Question.FalseAnswer1;
                        exitItem.FalseAnswer2 = Question.FalseAnswer2;
                        exitItem.FalseAnswer3 = Question.FalseAnswer3;

                        questionUpdateEntities.Add(exitItem);
                    }
                    else
                    {
                        var questionEntity = new Questions
                        {
                            AssignmentId = entity.Id,
                            FalseAnswer1 = Question.FalseAnswer1,
                            FalseAnswer2 = Question.FalseAnswer2,
                            FalseAnswer3 = Question.FalseAnswer3,
                            Question = Question.Question,
                            TrueAnswer = Question.TrueAnswer
                        };
                        questionAddEntities.Add(questionEntity);
                    }
                }
            }

            _context.Update(entity);

            if (questionAddEntities.Any())
                _context.AddRange(questionAddEntities);
            if (questionUpdateEntities.Any())
                _context.UpdateRange(questionUpdateEntities);


            _context.SaveChanges();
        }
    }
}
