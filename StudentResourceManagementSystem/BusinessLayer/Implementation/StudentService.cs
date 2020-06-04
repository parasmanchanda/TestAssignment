using AutoMapper;
using BusinessLayer.Interfaces;
using DataTransferObject.Models;
using Entities;
using InfrastructureLayer.Interfaces;
using StudentManagementExceptions;
using StudentManagementSystemException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BusinessLayer.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// This method uses unit of work to add a student object with
        /// data transfer object to entities mapping
        /// </summary>
        /// <param name="studentDTO">Student DTO object</param>
        public void CreateStudent(StudentDTO studentDTO)
        {
            var userDetails = _unitOfWork.UserRepository.FindBy(x => x.Id == studentDTO.CreatedBy
                                                    && x.Id == studentDTO.UpdatedBy)
                                         .FirstOrDefault();
            var phoneCode = _unitOfWork.CountryCodeRepository.FindBy(x => x.Id == studentDTO.CountryCodeId)
                                                             .FirstOrDefault();
 
            if (userDetails == null || phoneCode == null)
            {
                throw new StudentManagementException(System.Net.HttpStatusCode.NotFound, "Enter correct user or country code id");
            }

            if (studentDTO.Resources.Count == 0)
            {
                throw new StudentManagementException(System.Net.HttpStatusCode.NotFound, "Atlease one resource is required");
            }

            var student = _mapper.Map<Student>(studentDTO);
            student.UId = Guid.NewGuid();
            student.CountryCodeId = phoneCode.Id;
            student.CreatedOn = DateTime.Now;
            student.UpdatedOn = DateTime.Now;

            _unitOfWork.StudentRepository.Add(student);
            _unitOfWork.Save();
        }

        /// <summary>
        /// This method uses unit of work to list all the student objects from 
        /// the student entity and maps it into data transfer object
        /// </summary>
        ///<return>List of student DTO objects</return>
        public ICollection<StudentDTO> ListStudent()
        {
            var students = _unitOfWork.StudentRepository.GetAll();
            if (students.Count() == 0)
            {
                throw new StudentManagementException(HttpStatusCode.NotFound, "No data found");
            }
            var listStudentsDTO = new List<StudentDTO>();
            _mapper.Map(students, listStudentsDTO);
            return listStudentsDTO;
        }

        /// <summary>
        /// This method uses unit of work to get a student object from 
        /// the student entity and maps it into data transfer object based on its id
        /// </summary>
        /// <param name="uId">Used to compare the guid of a student object</param>
        /// <param name="id">Used to compare the id of a student object</param>
        /// <returns>student DTO object</returns>
        public StudentDTO StudentDetails(Guid uId, int id)
        {
            var student = _unitOfWork.StudentRepository.FindBy(x => x.UId == uId && x.Id == id)
                                                         .FirstOrDefault();
            if (student == null)
            {
                throw new StudentManagementException(HttpStatusCode.NotFound, "No data found");
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return studentDTO;
        }

        /// <summary>
        /// This method is used to delete an object from student entity
        /// </summary>
        /// <param name="uId">Provides the guid for the student to be deleted</param>
        /// <param name="id">Provides the id for the student to be deleted</param>
        public void DeleteStudent(Guid uId, int id)
        {
            var student = _unitOfWork.StudentRepository.FindBy(x => x.UId == uId && x.Id == id)
                                                         .FirstOrDefault();
            if (student == null)
            {
                throw new StudentManagementException(HttpStatusCode.NotFound, "NoData");
            }
            _unitOfWork.StudentRepository.Delete(student);
            _unitOfWork.Save();
        }

        /// <summary>
        /// This method is used to update a student's object
        /// </summary>
        /// <param name="uId">Provides the student guidId to be updated</param>
        /// <param name="id">Provides the student object to be updated</param>
        /// <param name="studentDTO">Provides the student data transfer object to be updated</param>
        public void UpdateStudent(Guid uId, int id, StudentDTO studentDTO)
        {
            var student = _unitOfWork.StudentRepository.FindBy(x => x.UId == uId && x.Id == id)
                                                         .FirstOrDefault();
            var userDetails = _unitOfWork.UserRepository.FindBy(x => x.Id == studentDTO.UpdatedBy)
                                                        .FirstOrDefault();
            var phoneCode = _unitOfWork.CountryCodeRepository.FindBy(x => x.Id == studentDTO.CountryCodeId)
                                                             .FirstOrDefault();
            if (student == null || userDetails == null || phoneCode == null)
            {
                throw new StudentManagementException(HttpStatusCode.NotFound, "NoData");
            }
             _mapper.Map<StudentDTO, Student>(studentDTO, student);
            student.CountryCodeId = phoneCode.Id;
            student.UpdatedBy = userDetails.Id;
            _unitOfWork.StudentRepository.Edit(student);
            _unitOfWork.Save();
        }
    }
}
