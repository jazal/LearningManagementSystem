using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Models.Enums;
using LearningManagementSystem.Repositories.AssignmentSubmissions;
using LearningManagementSystem.Repositories.Courses;
using LearningManagementSystem.Repositories.Employees;
using LearningManagementSystem.Repositories.Employees.Dtos;
using LearningManagementSystem.Repositories.Subjects;
using LearningManagementSystem.Repositories.Subjects.Dtos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IAssignmentSubmissionRepository _assignmentSubmissionRepository;

        public EmployeesController(IEmployeeRepository repository, 
            ICourseRepository courseRepository, 
            IMapper mapper, 
            ISubjectRepository subjectRepository,
            IAssignmentSubmissionRepository assignmentSubmissionRepository)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _mapper = mapper;
            _subjectRepository = subjectRepository;
            _assignmentSubmissionRepository = assignmentSubmissionRepository;
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
        
        public JsonResult GetAllSubjects()
        {
            var subjects = _subjectRepository.GetAll();
            var subjectDtos = _mapper.Map<List<Subject>, List<SubjectDto>>(subjects);

            return Json(new { subjectDtos }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Corrections(int employeeid)
        {
            var employeeDto = _repository.GetById(employeeid);
            
            if(employeeDto.Designation == Designation.Lecturer)
            {
                if (employeeDto.SubjectId.HasValue)
                {
                    var subjectId = employeeDto.SubjectId.Value;
                    var assignments = _assignmentSubmissionRepository.GetAllBySubjectId(subjectId);
                    return View(assignments);
                }
            }
            return Content("There is no subject allocated for you");
        }

        public JsonResult AssignGrade(int assignmentSubmissionId, float grade, int employeeId)
        {
            var updated = _assignmentSubmissionRepository.UpdateGrade(assignmentSubmissionId, grade, employeeId);

            return Json(new { updated }, JsonRequestBehavior.AllowGet);
        }

        public void DownloadAssignment(string fileName)
        {
            var fileExtension = fileName.Split('.')[1].Trim();

            Response.Clear();
            Response.ContentType = "application/" + fileExtension;
            Response.AppendHeader("Content-Disposition", String.Format("{0}; filename={0}", fileName));
            Response.TransmitFile(string.Format(@"C:\Attachments\Submissions\{0}", fileName));
            Response.End();
        }
    }
}