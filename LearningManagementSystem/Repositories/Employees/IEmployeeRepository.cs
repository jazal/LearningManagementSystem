using LearningManagementSystem.Repositories.Employees.Dtos;
using System.Collections.Generic;

namespace LearningManagementSystem.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        EmployeeDto Create(CreateEmployeeDto input);

        List<EmployeeDto> GetAll();

        EmployeeDto GetById(int id);

        bool Delete(int id);

        EmployeeDto Edit(int id, EmployeeDto subject);
    }
}