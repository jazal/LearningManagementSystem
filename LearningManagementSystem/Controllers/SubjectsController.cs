using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Courses;
using LearningManagementSystem.Repositories.Subjects;
using LearningManagementSystem.Repositories.Subjects.Dtos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectRepository _repository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectRepository repository,  
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var subjects = _repository.GetAll();
            var subjectDtos = _mapper.Map<List<Subject>, List<SubjectDto>>(subjects);
            return View(subjectDtos);
        }

        public ActionResult Register()
        {
            var courses = _courseRepository.GetAll();
            var courseDtos = _mapper.Map<List<Course>, List<CourseDto>>(courses);

            return View(courseDtos);
        }

        [HttpPost]
        public ActionResult Register(SubjectDto model)
        {
            if (ModelState.IsValid)
            {
                var subject = _mapper.Map<SubjectDto, Subject>(model);

                var created = _repository.Create(subject);

                if (created != null)
                    return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var subjectDto = _repository.GetById(id);
            return View(subjectDto);
        }

        [HttpPost]
        public ActionResult Edit(SubjectDto input)
        {
            var subject = _mapper.Map<SubjectDto, Subject>(input);
            var updatedSubject = _repository.Edit(input.Id, subject);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deletedSubject = _repository.Delete(id);
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