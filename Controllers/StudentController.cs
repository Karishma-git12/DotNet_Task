using Developer_Task.Data;
using Developer_Task.Models;
using Developer_Task.Repository;
using Developer_Task.Repository.IRepository;
using Developer_Task.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Developer_Task.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddStudent()
        {
            StudentVM studentVM = new StudentVM()
            {
                Student = new Student(),
                StudentClassList = _unitOfWork.StudentClass.GetAll().Select(cl => new SelectListItem()
                {
                    Text = cl.Name,
                    Value = cl.Id.ToString()
                })
            };
            return View(studentVM);
        }
        // POST: AddStudent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(StudentVM studentVm)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
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
                    studentVm.Student.ImageUrl = @"\images\students\" + fileName + extension;
                }
                _unitOfWork.Student.Add(studentVm.Student);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Data added successfully!" });

            }
            else
            {
                studentVm = new StudentVM()
                {
                    StudentClassList = _unitOfWork.StudentClass.GetAll().Select(cl => new SelectListItem()
                    {
                        Text = cl.Name,
                        Value = cl.Id.ToString()
                    }),
                };
                return View(studentVm);
            }


        }

        #region Api
        [HttpGet]
        public IActionResult GetAll()
        {
            var studentList = _unitOfWork.Student.GetAll(orderBy: query => query.OrderByDescending(t => t.Id), includeProperties: "StudentClass");
            var result = studentList.Select(s => new
            {
                s.ImageUrl,
                s.Name,
                s.Age,
                StudentClassName = s.StudentClass != null ? s.StudentClass.Name : "N/A",
                s.RollNumber
            }).ToList();
            return Json(new { data = result });
        }
        #endregion
    }
}
