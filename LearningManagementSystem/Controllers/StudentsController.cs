using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Courses;
using LearningManagementSystem.Repositories.Students;
using LearningManagementSystem.Repositories.Students.Dtos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _repository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository repository, ICourseRepository courseRepository, IMapper mapper)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        
        public ActionResult Index()
        {
            var students = _repository.GetAll();
            return View(students);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CreateStudentDto input)
        {
            if (ModelState.IsValid)
            {
                var created = _repository.Create(input);

                if (created != null)
                    return RedirectToAction("Index");
            }

            return View(input);
        }

        public ActionResult Edit(int id)
        {
            var subject = _repository.GetById(id);
            return View(subject);
        }

        [HttpPost]
        public ActionResult Edit(StudentDto input)
        {
            var updatedSubject = _repository.Edit(input.Id, input);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deletedStudent = _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetAllCourses()
        {
            var courses = _courseRepository.GetAll();
            var courseDtos = _mapper.Map<List<Course>, List<CourseDto>>(courses);

            return Json(new { courseDtos }, JsonRequestBehavior.AllowGet);
        }

    }
}