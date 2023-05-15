using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace attendaceAppWebApi.DTOs
{
    public class CreateStudentDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


        public string Phone { get; set; }

        public int RollNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string City { get; set; }


        public string State { get; set; }


        public string ZipCode { get; set; }

    
        public DateTime EnrollmentDate { get; set; }

    
        public DateTime? GraduationDate { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
