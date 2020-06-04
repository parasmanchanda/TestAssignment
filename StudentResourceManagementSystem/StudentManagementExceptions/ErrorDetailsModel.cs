using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StudentManagementSystemException
{
    /// <summary>
    /// Error details class to send a JSON format of the error occured
    /// i.e. its status code and error message 
    /// </summary>
    public class ErrorDetailsModel
    {
        public HttpStatusCode ErrorStatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
