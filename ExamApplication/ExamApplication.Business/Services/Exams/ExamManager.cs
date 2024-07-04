using ExamApplication.Business.Exceptions;
using ExamApplication.Business.Models.Exams;
using ExamApplication.Business.Models.PupilExams;
using ExamApplication.Business.Services.Lessons;
using ExamApplication.Business.Services.Pupils;
using ExamApplication.Core.Entities.Models;
using ExamApplication.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Business.Services.Exams;

public class ExamManager : IExamService
{
    private readonly IExamRepository _examRepository;
    private readonly ILessonService _lessonService;
    private readonly IPupilService _pupilService;
    private readonly IRepositoryAsync<PupilExam> _pupilExamRepository;

    public ExamManager(IExamRepository examRepository, ILessonService lessonService,
        IPupilService pupilService, IRepositoryAsync<PupilExam> pupilExamRepository)
    {
        _examRepository = examRepository;
        _lessonService = lessonService;
        _pupilService = pupilService;
        _pupilExamRepository = pupilExamRepository;
    }

    public async Task<List<ExamDto>> GetAll()
    {
        var exams = await _examRepository.GetQuery()
            .Where(x => x.Active)
            .Include(x => x.LessonGrade)
            .ThenInclude(x => x.Grade)
            .Include(x => x.LessonGrade)
            .ThenInclude(x => x.Lesson)
            .Include(x => x.PupilExams.Where(y => y.Active))
            .ThenInclude(x => x.Pupil)
            .Where(x => x.LessonGrade.Lesson.Active && x.LessonGrade.Grade.Active)
            .ToListAsync();

        var examDto = exams.Select(x =>
            new ExamDto
            {
                Id = x.Id,
                ExamDate = x.ExamDate,
                LessonCode = x.LessonGrade.Lesson.Code,
                PupilExams = x.PupilExams.Select(y => new PupilExamDto
                        { Id = y.Id, PupilNumber = y.Pupil.Number, Mark = y.Mark }).ToList()
            }).ToList();

        return examDto;
    }

    public async Task<int> Create(SaveExamRequest request)
    {
        if (request is null)
            throw new BadHttpRequestException("Məlumatlar doldurulmayıb");

        // await _lessonService.CheckByIdAsync(request.LessonId);
        // await _gradeService.CheckByIdAsync(request.GradeId);

        // var lessonGrade = await _lessonService.CheckByGradeIdAsync(request.LessonId, request.GradeId);
        var lessonGrade = await _lessonService.CheckByLessonGradeIdAsync(request.LessonGradeId);

        var pupilGrades = await _pupilService.GetByGradeId(lessonGrade.GradeId);

        var exam = new Exam
        {
            ExamDate = request.ExamDate,
            LessonGradeId = lessonGrade.Id,
            PupilExams = pupilGrades.Select(x => new PupilExam { PupilId = x.PupilId }).ToList()
        };

        var newExam = await _examRepository.AddAsync(exam);

        return newExam.Id;
    }

    public async Task<ExamDto> GetById(int examId)
    {
        var exam = await _examRepository.GetQuery().Where(x => x.Active && x.Id == examId)
            .Include(x => x.LessonGrade)
            .ThenInclude(x => x.Grade)
            .Include(x => x.LessonGrade)
            .ThenInclude(x => x.Lesson)
            .Include(x => x.PupilExams)
            .ThenInclude(x => x.Pupil)
            .Select(x => new ExamDto
            {
                Id = x.Id,
                ExamDate = x.ExamDate,
                LessonCode = x.LessonGrade.Lesson.Code,
                PupilExams = x.PupilExams
                    .Select(y => new PupilExamDto { Id = y.Id, PupilNumber = y.Pupil.Number, Mark = y.Mark }).ToList()
            })
            .FirstOrDefaultAsync();

        if (exam is null)
            throw new NotFoundException("Belə bir imtahan tapılmadı");

        return exam;
    }

    public async Task<int> Update(int examId, UpdateExamRequest request)
    {
        var exam = await _examRepository.GetQuery().FirstOrDefaultAsync(x => x.Active && x.Id == examId);

        if (exam is null)
            throw new NotFoundException("Belə bir imtahan tapılmadı");

        exam.ExamDate = request.ExamDate;

        await _examRepository.UpdateAsync(exam);

        return examId;
    }

    public async Task<int> UpdatePupilExam(UpdatePupilExamRequest request)
    {
        var pupilExam = await _pupilExamRepository.GetQuery()
            .FirstOrDefaultAsync(x => x.Active && x.Id == request.PupilExamId);

        if (pupilExam is null)
            throw new NotFoundException("Belə bir imtahan tapılmadı");

        pupilExam.Mark = request.Mark;

        await _pupilExamRepository.UpdateAsync(pupilExam);

        return request.PupilExamId;
    }

    public async Task Delete(int examId)
    {
        var exam = await _examRepository.GetQuery().Where(x => x.Active && x.Id == examId)
            .Include(x => x.PupilExams.Where(x => !x.Deleted && x.Mark == 0))
            .FirstOrDefaultAsync();
        if (exam is null)
            throw new NotFoundException("Belə bir imtahan tapılmadı");

        await _examRepository.BeginTransaction();

        await _examRepository.DeleteAsync(exam);
        await _pupilExamRepository.DeleteRangeAsync(exam.PupilExams.ToList());

        await _examRepository.Commit();
    }
}