using AutoMapper;
using LearningManagementSystem.Repositories.Attachments;
using LearningManagementSystem.Repositories.Attachments.Dtos;
using LearningManagementSystem.Repositories.Subjects;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class AttachmentsController : Controller
    {
        private readonly IAttachmentRepository _repository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public AttachmentsController(IAttachmentRepository repository, ISubjectRepository subjectRepository, IMapper mapper)
        {
            _repository = repository;
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        // GET: Attachments
        public ActionResult Index(int employeeId)
        {
            var attachmentDtos = _repository.GetAllByEmployeeId(employeeId);
            return View(attachmentDtos);
        }

        public ActionResult Register(int employeeId, int courseId)
        {
            var attachmentDtos = _repository.GetAllByEmployeeId(employeeId);
            return View();
        }

        [HttpPost]
        public ActionResult Register(CreateAttachmentDto input, HttpPostedFileBase newFile, int courseId)
        {
            if (ModelState.IsValid)
            {
                var fileName = $"{input.Title.Replace(" ", string.Empty)}_{input.EmployeeId}_{DateTime.Now.ToString("ddMMyyyyhhmmsstt")}.{newFile.FileName.Split('.')[1].Trim()}";
                
                if (newFile != null && newFile.ContentLength > 0)
                {
                    string root = @"C:\Attachments";

                    if (!Directory.Exists(root))
                        Directory.CreateDirectory(root);

                    root = root + "\\" + fileName;
                   
                    newFile.SaveAs(root);
                }
                input.AttachmentFileName = fileName;
                var created = _repository.Create(input);

                if (created != null)
                    return RedirectToAction("Index", "Attachments", new { employeeId = input.EmployeeId, courseId = courseId });
            }

            return View(input);
        }

        public JsonResult GetSubjectsByCourseId(int courseId)
        {
            var subjectDtos = _subjectRepository.GetSubjectsByCourseId(courseId);

            return Json(new { subjectDtos }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id, int courseId)
        {
            var deletedAttachment = _repository.Delete(id);
            return RedirectToAction("Index", "Attachments", new { employeeId = id, courseId = courseId });
        }

        public ActionResult Edit(int employeeId, int courseId, int attachmentId)
        {
            var attachment = _repository.GetById(attachmentId);
            return View(attachment);
        }

        [HttpPost]
        public ActionResult Edit(AttachmentDto input, HttpPostedFileBase newFile, int courseId)
        {
            var fileName = input.AttachmentFileName;

            if (newFile != null && newFile.ContentLength > 0)
            {
                fileName = $"{input.Title.Replace(" ", string.Empty)}_{input.EmployeeId}_{DateTime.Now.ToString("ddMMyyyyhhmmsstt")}.{newFile.FileName.Split('.')[1].Trim()}";

                string root = @"C:\Attachments";

                if (!Directory.Exists(root))
                    Directory.CreateDirectory(root);

                root = root + "\\" + fileName;

                newFile.SaveAs(root);
            }
            input.AttachmentFileName = fileName;

            var updatedSubject = _repository.Edit(input.Id, input);
            return RedirectToAction("Index", "Attachments", new { employeeId = input.EmployeeId, courseId = courseId });
        }
    }
}