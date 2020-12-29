using LearningManagementSystem.Repositories.ApplicationUsers;
using LearningManagementSystem.Repositories.AssignmentSubmissions;
using LearningManagementSystem.Repositories.AssignmentSubmissions.Dtos;
using LearningManagementSystem.Repositories.Attachments;
using LearningManagementSystem.Repositories.Students;
using LearningManagementSystem.Repositories.Subjects;
using LearningManagementSystem.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    [Authorize]
    public class StudentProfileController : Controller
    {
        private readonly IApplicationUserRepository _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IAssignmentSubmissionRepository _assignmentSubmissionRepository;

        public StudentProfileController(IApplicationUserRepository repository,
            IStudentRepository studentRepository,
            ISubjectRepository subjectRepository,
            IAttachmentRepository attachmentRepository,
            IAssignmentSubmissionRepository assignmentSubmissionRepository)
        {
            _repository = repository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _attachmentRepository = attachmentRepository;
            _assignmentSubmissionRepository = assignmentSubmissionRepository;
        }

        // GET: StudentProfile
        public ActionResult Index()
        {
            var currentuserId = User.Identity.GetUserId();
            var user = _repository.GetUserById(currentuserId);

            if (!user.IsStudent)
                return View("Unauthorized");

            var student = _studentRepository.GetStudentByCurrentUserId(user.Id);
            var subjectDtos = _subjectRepository.GetSubjectsByCourseId(student.CourseId);
            student.Course.Subjects = subjectDtos;
            return View(student);
        }

        public ActionResult Submission(int studentId, int courseId, int subjectId)
        {
            var student = _studentRepository.GetById(studentId);
            var subject = _subjectRepository.GetById(subjectId);
            var attachments = _attachmentRepository.GetBySubjectId(subjectId);
            return View(new ViewAttachmentsForStudentVM
            {
                Student = student,
                Subject = subject,
                Attachments = attachments
            });
        }

        public ActionResult UploadFile(HttpPostedFileBase newFile, int studentId, int attachmentId, int subjectId)
        {
            var fileName = $"studentId_{studentId}_attachmentId_{attachmentId}_subjectId_{subjectId}_{DateTime.Now.ToString("ddMMyyyyhhmmsstt")}.{newFile.FileName.Split('.')[1].Trim()}";

            if (newFile != null && newFile.ContentLength > 0)
            {
                string root = @"C:\Attachments\Submissions";

                if (!Directory.Exists(root))
                    Directory.CreateDirectory(root);

                root = root + "\\" + fileName;

                newFile.SaveAs(root);
            }

            var created = _assignmentSubmissionRepository.Create(new CreateAssignmentSubmissionDto {
                StudentId = studentId,
                AttachmentId = attachmentId,
                SubjectId = subjectId,
                CreatedDate = DateTime.Now,
                FileName = fileName,
            });

            return View("Index", "Home");
        }

        public void DownloadAssignment(string fileName)
        {
            var fileExtension = fileName.Split('.')[1].Trim();

            Response.Clear();
            Response.ContentType = "application/" + fileExtension;
            Response.AppendHeader("Content-Disposition", String.Format("{0}; filename={0}", fileName));
            Response.TransmitFile(string.Format(@"C:\Attachments\{0}", fileName));
            Response.End();
        }

    }
}