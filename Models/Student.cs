using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Developer_Task.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int? Age { get; set; }

        [Display(Name = "Roll Number")]
        [Required(ErrorMessage = "Roll Number is required")]
        public string RollNumber { get; set; }
        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Class")]
        public int StudentClassId { get; set; }
        public StudentClass? StudentClass { get; set; }
    }
}
