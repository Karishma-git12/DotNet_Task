using Developer_Task.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Developer_Task.ViewModel
{
    public class SubjectVM
    {
        public Subject Subject { get; set; }
        [Display(Name ="Class")]
        public IEnumerable<SelectListItem>? StudentClassList { get; set; }
        [Display(Name = "Language")]
        public IEnumerable<SelectListItem>? LanguageList { get; set; }
    }
}
