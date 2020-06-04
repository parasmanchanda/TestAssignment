using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataTransferObject.Models;
using Microsoft.AspNetCore.Mvc;
using StudentManagementExceptions;
using StudentManagementSystemException;

namespace StudentResourceManagementSystem.Controllers
{ 
    [ApiController]
    [Route("api/student")]
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// This post method is used to add a student data transfer object 
        /// </summary>
        /// <param name="student">Student data transfer object to be added</param>
        /// <returns>Http status 200 if student gets added</returns>
        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentDTO student)
        {
            try
            {
                _studentService.CreateStudent(student);
            }
            catch (StudentManagementException exception)
            {
                return new ObjectResult(exception.ErrorDetailsModel);
            }
            return Ok();
        }

        /// <summary>
        /// This student method is used to return list of all student in Database
        /// </summary>
        /// <returns>Http status 200 with student data transfer object</returns>
        [HttpGet]
        public IActionResult StudentDetails([FromQuery(Name = "UId")]Guid? uId, [FromQuery(Name = "Id")]int? id)
        {
            dynamic students;
            try
            {
                if (uId == null && id == null)
                {
                    students = _studentService.ListStudent();
                }
                else
                {
                    students = _studentService.StudentDetails((Guid)uId, (int)id);                    
                }
            }
            catch (StudentManagementException exception)
            {
                return new ObjectResult(exception.ErrorDetailsModel);
            }
            return Ok(students);
        }

        /// <summary>
        /// This delete method is used to delete a student 
        /// </summary>
        /// <param name="uId">Used to compare the guid of a student object</param>
        /// <param name="id">Used to compare the id of a student object</param>
        /// <returns>Http status 200 with "Data deleted" message if student is deleted else 
        /// "no data found" message is displayed</returns>
        [HttpDelete]
        public IActionResult DeleteStudent([FromQuery(Name = "UId")]Guid uId, [FromQuery(Name = "Id")]int id)
        {
            try
            {
                _studentService.DeleteStudent(uId, id);
            }
            catch (StudentManagementException exception)
            {
                return new ObjectResult(exception.ErrorDetailsModel);
            }
            return Ok("Data Deleted");
        }

        /// <summary>
        /// This update method is used to update a student
        /// </summary>
        /// <param name="uId">Used to compare the guid of an student object</param>
        /// <param name="id">Used to compare the id of an student object</param>
        /// <param name="customer">Provides the student data transfer object to be updated</param>
        /// <returns>Http status 200 if updated successfully
        /// otherwise "No data found" message is displayed</returns>
        [HttpPut]
        public IActionResult EditStudent([FromQuery(Name = "UId")]Guid uId, [FromQuery(Name = "Id")]int id, [FromBody] StudentDTO student)
        {
            try
            {
                _studentService.UpdateStudent(uId, id, student);
            }
            catch (StudentManagementException exception)
            {
                return new ObjectResult(exception.ErrorDetailsModel);
            }
            return Ok(student);
        }
    }
}