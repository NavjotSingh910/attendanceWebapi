using System;
using System.ComponentModel.DataAnnotations;

namespace attendanceAppWebApi.DTOs
{
    public class StudentRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public int StudentId { get; set; }

       
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

    
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int RollNumber { get; set; }
        public string State { get; set; }

        public string ZipCode { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public DateTime? GraduationDate { get; set; }
        
    }
}
