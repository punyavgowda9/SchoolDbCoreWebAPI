using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDbCoreWebAPI.Models
{
    [Table("Student")]   
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public int GradeId { get; set; }
    }
}