using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.WorkoutTracker.API.DataTransferObjects.Training;

namespace src.WorkoutTracker.API.Service.Contracts
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingDTO>> GetTrainingsAsync(bool trackChanges);
        Task<TrainingDTO> GetTrainingAsync(Guid id, bool trackChanges);
        Task<TrainingDTO> CreateTrainingAsync(CreateTrainingDTO dto);
        Task<TrainingDTO> UpdateTrainingAsync(UpdateTrainingDTO dto);
        Task DeleteTrainingAsync(Guid id);
    }
}