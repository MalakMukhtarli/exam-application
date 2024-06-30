namespace ExamApplication.Core.Entities;

public abstract class CommonEntity : BaseEntity, 
                            ISoftDeletedEntity, IActiveEntity, 
                            ICreatedDateEntity, IUpdatedDateEntity
{
    public bool Deleted { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}