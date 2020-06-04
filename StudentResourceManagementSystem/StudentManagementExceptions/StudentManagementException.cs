using Newtonsoft.Json;
using StudentManagementSystemException;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StudentManagementExceptions
{
    public class StudentManagementException : Exception
    {
        /// <summary>
        /// Custom exception class for throwing the custom exception at run time
        /// </summary>
        [JsonProperty("errorDetailsModel")]
        public ErrorDetailsModel ErrorDetailsModel { get; set; }

        /// <summary>
        /// This constructor is used to set the HttpStatusCode and error message values
        /// </summary>
        /// <param name="errorCode">HttpStatusCode instance</param>
        /// <param name="errorMessage">Error message to be displayed</param>
        public StudentManagementException(HttpStatusCode errorCode, string errorMessage)
        {
            ErrorDetailsModel exception = new ErrorDetailsModel();
            exception.ErrorStatusCode = errorCode;
            exception.ErrorMessage = errorMessage;
            ErrorDetailsModel = exception;
        }
    }
}
