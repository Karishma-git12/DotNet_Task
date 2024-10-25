using Developer_Task.Models;
using Developer_Task.Repository.IRepository;
using Developer_Task.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Developer_Task.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TeacherController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        private string GetClassNames(string classIds)
        {
            if (string.IsNullOrEmpty(classIds))
                return string.Empty;

            var ids = classIds.Split(',').Select(id => int.Parse(id.Trim())).ToList();
            var classNames = _unitOfWork.StudentClass.GetAll()
                .Where(sc => ids.Contains(sc.Id))
                .Select(sc => sc.Name)
                .ToList();

            return string.Join(", ", classNames);
        }

        private string GetSubjectNames(string subjectIds)
        {
            if (string.IsNullOrEmpty(subjectIds))
                return string.Empty;

            var ids = subjectIds.Split(',').Select(id => int.Parse(id.Trim())).ToList();
            var subjectNamesWithLanguages = _unitOfWork.Subject.GetAll(includeProperties: "Language")
        .Where(s => ids.Contains(s.Id))
        .Select(s => $"{s.Name} ({s.Language.Name})")
        .ToList();

            return string.Join(", ", subjectNamesWithLanguages);
        }
        public IActionResult Index()
        {
    
            var teachers = _unitOfWork.Teacher.GetAll(
                orderBy: query => query.OrderByDescending(t => t.Id)
            ).ToList();

           
            var teacherViewModels = teachers.Select(teacher => new TeacherViewModel
            {
                Teacher = teacher,
                SelectedClassIds = teacher.Class?.Split(',').Select(int.Parse).ToList() ?? new List<int>(),
                ClassNames = GetClassNames(teacher.Class),
                SubjectNames = GetSubjectNames(teacher.Subjects)
            }).ToList();

            return View(teacherViewModels);
        }

        public IActionResult AddTeacher()
        {
            var classes = _unitOfWork.StudentClass.GetAll().ToList();
            var subjects = _unitOfWork.Subject.GetAll(includeProperties: "Language").ToList();
            var viewModel = new TeacherViewModel
            {
                AvailableClasses = classes,
                SelectedClassIds = new List<int>(),
                AvailableSubjects = subjects,
                SelectedSubjectIds = new List<int>(),
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTeacher(TeacherViewModel teacherVM)
        {


            if (teacherVM.SelectedClassIds == null || teacherVM.SelectedClassIds.Count == 0)
            {

                return Json(new { success = false, message = "Please select at least one class." });
            }

            if (teacherVM.SelectedSubjectIds == null || teacherVM.SelectedSubjectIds.Count == 0)
            {
                return Json(new { success = false, message = "Please select at least one subject." });

            }
            if (teacherVM == null)
                return Json(new { success = false, message = "Invalid data" });
            if (!ModelState.IsValid) return Json(new { success = false, message = "Invalid data" });
            var webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                var fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\students");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                teacherVM.Teacher.ImageUrl = @"\images\teachers\" + fileName + extension;
            }
            teacherVM.Teacher.Class = string.Join(",", teacherVM.SelectedClassIds);
            teacherVM.Teacher.Subjects = string.Join(",", teacherVM.SelectedSubjectIds);
            _unitOfWork.Teacher.Add(teacherVM.Teacher);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Data added successfully!" });
        }
    }
}
