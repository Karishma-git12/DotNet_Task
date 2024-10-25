using Developer_Task.Models;
using Developer_Task.Repository.IRepository;
using Developer_Task.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Developer_Task.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            var subjects = _unitOfWork.Subject.GetAll(orderBy: query => query.OrderByDescending(t => t.Id),includeProperties: "StudentClass,Language").ToList();
        
            return View(subjects);
        }

        public IActionResult AddSubject()
        {
            SubjectVM subjectVM = new SubjectVM()
            {
                Subject = new Subject(),
                StudentClassList = _unitOfWork.StudentClass.GetAll().Select(cl => new SelectListItem()
                {
                    Text = cl.Name,
                    Value = cl.Id.ToString()
                }),
                LanguageList = _unitOfWork.Language.GetAll().Select(cl => new SelectListItem()
                {
                    Text = cl.Name,
                    Value = cl.Id.ToString()
                }),

            };
            return View(subjectVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSubject(SubjectVM subjectVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subject.Add(subjectVM.Subject);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Data added successfully!" });
            }
            else
            {
                subjectVM = new SubjectVM()
                {
                    StudentClassList = _unitOfWork.StudentClass.GetAll().Select(cl => new SelectListItem()
                    {
                        Text = cl.Name,
                        Value = cl.Id.ToString()
                    }),
                    LanguageList = _unitOfWork.Language.GetAll().Select(cl => new SelectListItem()
                    {
                        Text = cl.Name,
                        Value = cl.Id.ToString()
                    }),

                };
                return View(subjectVM);
            }

            
        }
    }
}
