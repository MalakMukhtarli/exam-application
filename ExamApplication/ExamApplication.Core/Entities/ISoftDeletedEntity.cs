namespace ExamApplication.Core.Entities;

public interface ISoftDeletedEntity
{
    bool Deleted { get; set; }
}