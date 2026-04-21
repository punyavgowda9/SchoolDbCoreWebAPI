using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDbCoreWebAPI.Models
{
    [Table("Grade")]
    public class Grade
    {
        public int GradeId { get; set; }
        public string? GradeName { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
    }
}
