using ExamApplication.Business.Exceptions;
using ExamApplication.Business.Models.LessonGrades;
using ExamApplication.Business.Models.Teachers;
using ExamApplication.Business.Services.Grades;
using ExamApplication.Business.Services.Lessons;
using ExamApplication.Core.Entities.Models;
using ExamApplication.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Business.Services.Teachers;

public class TeacherManager : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IGradeService _gradeService;
    private readonly ILessonService _lessonService;
    private readonly IRepositoryAsync<LessonGradeTeacher> _lessonGradeTeacherRepository;

    public TeacherManager(ITeacherRepository teacherRepository, ILessonService lessonService,
        IGradeService gradeService, IRepositoryAsync<LessonGradeTeacher> lessonGradeTeacherRepository)
    {
        _teacherRepository = teacherRepository;
        _lessonService = lessonService;
        _gradeService = gradeService;
        _lessonGradeTeacherRepository = lessonGradeTeacherRepository;
    }

    public async Task<List<TeacherDto>> GetAllAsync()
    {
        var teachers = await _teacherRepository.GetQuery()
            .Where(x => x.Active)
            .Include(x => x.LessonGradeTeachers.Where(y => !y.Deleted))
            .ThenInclude(x => x.LessonGrade)
            .ThenInclude(lg => lg.Lesson)
            .Include(x => x.LessonGradeTeachers.Where(y => !y.Deleted))
            .ThenInclude(x => x.LessonGrade)
            .ThenInclude(lg => lg.Grade).ToListAsync();
        
            var teacherDtos = teachers
                .Select(x => new TeacherDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    LessonGrades = x.LessonGradeTeachers
                        .Where(y => !y.Deleted)
                        .GroupBy(y => y.LessonGrade.Lesson)
                        .Select(g => new LessonGradeForTeacher
                        {
                            Id = g.First().LessonGrade.Id,
                            Lesson = g.Key.Name,
                            Grades = g.Select(y => y.LessonGrade.Grade.Value).ToList()
                        })
                        .ToList()
                })
                .ToList();

        return teacherDtos;
    }

    public async Task<List<TeacherDto>> GetAllForSelectAsync()
    {
        var teachers = await _teacherRepository.GetQuery().Where(x => x.Active)
            .Select(x => new TeacherDto
            {
                Id = x.Id, 
                Name = x.Name, 
                Surname = x.Surname, 
            })
            .ToListAsync();

        return teachers;
    }

    public async Task<int> CreateAsync(SaveTeacherRequest request)
    {
        if (request is null)
            throw new BadHttpRequestException("Məlumatlar doldurulmayıb");

        var teacher = new Teacher
        {
            Name = request.Name,
            Surname = request.Surname
        };

        var newTeacher = await _teacherRepository.AddAsync(teacher);

        return newTeacher.Id;
    }

    public async Task CreateLessonGradeTeacherAsync(int teacherId, SaveLessonGradeTeacherRequest request)
    {
        if (request is null)
            throw new BadHttpRequestException("Məlumatlar doldurulmayıb");

        var isExistTeacher = await _teacherRepository.GetQuery().AnyAsync(x => x.Id == teacherId);

        if (!isExistTeacher)
            throw new NotFoundException("Müəllim mövcud deyil");

        var lessonGradeTeachers = new List<LessonGradeTeacher>();

        foreach (var lessonGradeId in request.LessonGradeIds)
        {
            var lessonGrade = await _lessonService.CheckByLessonGradeIdAsync(lessonGradeId);

            var isExistLessonGradeTeacher = await _lessonGradeTeacherRepository.GetQuery()
                .AnyAsync(x => x.TeacherId == teacherId 
                               && x.LessonGradeId == lessonGrade.Id
                               );

            if (isExistLessonGradeTeacher)
                throw new DuplicateConflictException(
                    $"Bu müəllim, seçdiyiniz dərs və sinif üçün daha əvvəl əlavə edilmişdir");

            lessonGradeTeachers.Add(new LessonGradeTeacher { 
                TeacherId = teacherId, 
                LessonGradeId = lessonGrade.Id 
            });
        }

        await _lessonGradeTeacherRepository.AddRangeAsync(lessonGradeTeachers);
    }

    public async Task<TeacherDto> GetByIdAsync(int teacherId)
    {
        var teacher = await _teacherRepository.GetQuery().Where(x => x.Active && x.Id == teacherId)
            .Include(x => x.LessonGradeTeachers)
            .ThenInclude(x => x.LessonGrade)
            .ThenInclude(x => x.Grade)
            .Include(x => x.LessonGradeTeachers)
            .ThenInclude(x => x.LessonGrade)
            .ThenInclude(x => x.Lesson)
            .Select(x => new TeacherDto
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                LessonGrades = x.LessonGradeTeachers
                    .Where(y => !y.Deleted)
                    .GroupBy(y => y.LessonGrade.Lesson)
                    .Select(g => new LessonGradeForTeacher
                    {
                        Id = g.First().LessonGrade.Id,
                        Lesson = g.Key.Name,
                        Grades = g.Select(y => y.LessonGrade.Grade.Value).ToList()
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

        if (teacher is null)
            throw new NotFoundException("Belə bir mmüəllim tapılmadı");

        return teacher;
    }

    public async Task<int> UpdateAsync(int teacherId, List<UpdateTeacherRequest> requests)
    {
        var teacher = await _teacherRepository.GetQuery().Where(x => x.Active && x.Id == teacherId)
            .Include(x => x.LessonGradeTeachers)
            .ThenInclude(x => x.LessonGrade)
            .ThenInclude(x => x.Grade)
            .Include(x => x.LessonGradeTeachers)
            .ThenInclude(x => x.LessonGrade)
            .ThenInclude(x => x.Lesson)
            .FirstOrDefaultAsync();

        if (teacher is null)
            throw new NotFoundException("Belə bir mmüəllim tapılmadı");

        var newLessonGradeTeachers = new List<LessonGradeTeacher>();
        var deleteLessonGradeTeachers = new List<LessonGradeTeacher>();

        foreach (var request in requests)
        {
            await _lessonService.CheckByIdAsync(request.LessonId);
            await _gradeService.CheckByIdAsync(request.GradeId);

            var lessonGrade = await _lessonService.CheckByGradeIdAsync(request.LessonId, request.GradeId);

            var lessonGradeTeacher =
                teacher.LessonGradeTeachers.FirstOrDefault(
                    x => x.LessonGradeId == lessonGrade.Id
                    );

            if (lessonGradeTeacher is null)
            {
                newLessonGradeTeachers.Add(new LessonGradeTeacher
                    { 
                        TeacherId = teacherId, 
                        LessonGradeId = lessonGrade.Id
                    });
            }
        }

        foreach (var lessonGradeTeacher in teacher.LessonGradeTeachers)
        {
            var lessonGradeTeacherCheck = requests.Any(
                x =>
                x.LessonId == lessonGradeTeacher.LessonGrade.LessonId &&
                x.GradeId == lessonGradeTeacher.LessonGrade.GradeId
                );

            if (!lessonGradeTeacherCheck)
                deleteLessonGradeTeachers.Add(lessonGradeTeacher);
        }

        await _lessonGradeTeacherRepository.BeginTransaction();

        await _lessonGradeTeacherRepository.AddRangeAsync(newLessonGradeTeachers);
        await _lessonGradeTeacherRepository.DeleteRangeAsync(deleteLessonGradeTeachers);

        await _lessonGradeTeacherRepository.Commit();

        return teacherId;
    }

    public async Task DeleteAsync(int teacherId)
    {
        var teacher = await _teacherRepository.GetQuery().Where(x => x.Active && x.Id == teacherId)
            .Include(x => x.LessonGradeTeachers)
            .ThenInclude(x => x.LessonGrade)
            .ThenInclude(x => x.Grade)
            .Include(x => x.LessonGradeTeachers)
            .ThenInclude(x => x.LessonGrade)
            .ThenInclude(x => x.Lesson)
            .FirstOrDefaultAsync();

        if (teacher is null)
            throw new NotFoundException("Belə bir mmüəllim tapılmadı");

        await _lessonGradeTeacherRepository.BeginTransaction();

        await _teacherRepository.DeleteAsync(teacher);
        await _lessonGradeTeacherRepository.DeleteRangeAsync(teacher.LessonGradeTeachers.ToList());

        await _lessonGradeTeacherRepository.Commit();
    }
}