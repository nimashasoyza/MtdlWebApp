using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels.RequestModels;
using WebApp.ViewModels.ResponseModels;

namespace WebApp.Services
{
    public interface IAssignmentService
    {
        int Add(AssignmentAddRequest assignmentAddRequest);
        List<AssigmentReponse> GetByUserId(int userId);
        void Update(AssigmentReponse assignmentUpdateRequest);
    }
}
