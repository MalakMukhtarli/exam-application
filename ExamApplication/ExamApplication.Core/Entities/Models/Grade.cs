﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApplication.Core.Entities.Models;

public class Grade :  BaseEntity, ISoftDeletedEntity, IActiveEntity
{
    public Grade()
    {
        PupilGrades = new HashSet<PupilGrade>();
        LessonGrades = new HashSet<LessonGrade>();
    }

    [Required]
    [Column(TypeName = "numeric(2,0)")]
    public int Value { get; set; }

    public virtual ICollection<PupilGrade> PupilGrades { get; set; }
    public virtual ICollection<LessonGrade> LessonGrades { get; set; }
    public bool Deleted { get; set; }
    public bool Active { get; set; }
}