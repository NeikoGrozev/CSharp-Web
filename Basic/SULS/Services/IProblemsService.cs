using SULS.ViewModels.Problems;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void CreateProblem(string name, int point);

        DetailsViewModel GetDetailProblem(string id);
    }
}
