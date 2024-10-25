using Developer_Task.Models;
using System.ComponentModel.DataAnnotations;

namespace Developer_Task.ViewModel
{
    public class TeacherViewModel
    {
        public Teacher Teacher { get; set; }
        public List<StudentClass>? AvailableClasses { get; set; }
        [Display(Name ="Classes")]
        public List<int>? SelectedClassIds { get; set; } 
        public List<Subject>? AvailableSubjects { get; set; }
        [Display(Name = "Subjects")]
        public List<int>? SelectedSubjectIds { get; set; }
        public string? ClassNames { get; set; }
        public string? SubjectNames { get; set; }

    }
}
