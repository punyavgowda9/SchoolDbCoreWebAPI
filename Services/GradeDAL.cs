using SchoolDbCoreWebAPI.Models;

namespace SchoolDbCoreWebAPI.Services
{
    public class GradeDAL
    {
        private readonly SchoolDbContext _context;

        public GradeDAL(SchoolDbContext context)
        {
            _context = context;
        }

        public Grade GetGradeById(int grdId)
        {
            return _context.Grades.FirstOrDefault(g => g.GradeId == grdId);
        }
    }
}