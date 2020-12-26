using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Courses;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var course = _repository.GetAll();
            var courseDtos = _mapper.Map<List<Course>, List<CourseDto>>(course);
            return View(courseDtos);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CourseDto model)
        {
            if (ModelState.IsValid)
            {
                var course = _mapper.Map<CourseDto, Course>(model);

                var created = _repository.Create(course);

                if (created != null)
                    return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var course = _repository.GetById(id);
            var courseDto = _mapper.Map<Course, CourseDto>(course);
            return View(courseDto);
        }

        [HttpPost]
        public ActionResult Edit(CourseDto courseDto)
        {
            var course = _mapper.Map<CourseDto, Course>(courseDto);
            var updatedCourses = _repository.Edit(courseDto.Id, course);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var course = _repository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}