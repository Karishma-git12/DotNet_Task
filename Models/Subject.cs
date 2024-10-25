using System.ComponentModel.DataAnnotations;
namespace Developer_Task.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Class")]
        public int StudentClassId { get; set; }
        public StudentClass? StudentClass { get; set; }
        [Display(Name = "Language")]
        public int LanguageId { get; set; }
        public Language? Language { get; set; }

    }
}
