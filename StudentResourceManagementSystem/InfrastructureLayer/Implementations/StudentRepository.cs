using Entities;
using InfrastructureLayer.ContextClass;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Implementations
{
    public class StudentRepository :  GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentManagementContext context) : base(context)
        {

        }
    }
}
