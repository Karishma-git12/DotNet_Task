using System.ComponentModel.DataAnnotations;

namespace Developer_Task.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Display(Name = "Classes")]
        public string? Class { get; set; }
       
        [Display(Name = "Subjects")]
        public string? Subjects { get; set; }

    }
}
