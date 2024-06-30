namespace ExamApplication.Business.Models.Pupils;

public class PupilDto : BaseDto
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Grade { get; set; }
}