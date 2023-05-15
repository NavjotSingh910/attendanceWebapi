using System.ComponentModel.DataAnnotations;

namespace attendaceAppWebApi.DTOs
{
    public class StudentShowDto
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }
        public int? RollNumber { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        public DateTime? GraduationDate { get; set; }

    }
}
