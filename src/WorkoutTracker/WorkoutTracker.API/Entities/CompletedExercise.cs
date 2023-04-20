using System.ComponentModel.DataAnnotations.Schema;
namespace src.WorkoutTracker.API.Entities;
public class CompletedExercise
{
    public Guid Id { get; set; }
    public Exercise Exercise { get; set; }
    public Guid ExerciseId { get; set; }
    public string RepetitionCount { get; set; }
    [NotMapped]
    public int[] RepetitionCountArray
    {
        get
        {
            return Array.ConvertAll(RepetitionCount.Split(';'), int.Parse);
        }
        set
        {
            RepetitionCount = String.Join(";", value.Select(p => p.ToString()).ToArray());
        }
    }
    public Training Training { get; set; }
    public Guid TrainingId { get; set; }
}