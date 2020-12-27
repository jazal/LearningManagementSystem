using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Courses;
using LearningManagementSystem.Repositories.Employees;
using LearningManagementSystem.Repositories.Employees.Dtos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository repository, ICourseRepository courseRepository, IMapper mapper)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var employees = _repository.GetAll();
            return View(employees);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CreateEmployeeDto input)
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
            var employeeDto = _repository.GetById(id);
            return View(employeeDto);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeDto input)
        {
            var updatedEmployee = _repository.Edit(input.Id, input);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deletedEmployee = _repository.Delete(id);
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