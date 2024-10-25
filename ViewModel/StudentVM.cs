using Developer_Task.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Developer_Task.ViewModel
{
    public class StudentVM
    {
        public Student Student { get; set; }
        [Display(Name = "Class")]
        public IEnumerable<SelectListItem>? StudentClassList { get; set; }
    }
}
