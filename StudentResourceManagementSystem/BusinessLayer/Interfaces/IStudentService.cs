using DataTransferObject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IStudentService
    {
        void CreateStudent(StudentDTO studentDTO);
        ICollection<StudentDTO> ListStudent();
        StudentDTO StudentDetails(Guid uId, int id);
        void DeleteStudent(Guid uId, int id);
        void UpdateStudent(Guid uId, int id, StudentDTO studentDTO);
    }
}
