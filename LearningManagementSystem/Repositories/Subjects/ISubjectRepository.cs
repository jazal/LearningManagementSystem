using LearningManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Repositories.Subjects
{
    public interface ISubjectRepository
    {
        Subject Create(Subject subject);

        List<Subject> GetAll();

        Subject GetById(int id);

        bool Delete(int id);

        Subject Edit(int id, Subject subject);
    }
}