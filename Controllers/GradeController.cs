using Microsoft.AspNetCore.Mvc;
using SchoolDbCoreWebAPI.Models;
using SchoolDbCoreWebAPI.Services;

namespace SchoolDbCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GradeController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public GradeController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllGrades()
        {
            return Ok(_context.Grades.ToList());
        }

        [HttpGet("{grdId}")]
        public async Task<IActionResult> GetGradeById(int grdId)
        {
            GradeDAL grdDal = new GradeDAL(_context);
            Grade grd = null;

            try
            {
                grd = grdDal.GetGradeById(grdId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (grd == null)
                return NotFound();

            return Ok(grd);
        }

        [HttpPost]
        public IActionResult AddGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
            return Ok(1);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGrade(int id, Grade grade)
        {
            var existingGrade = _context.Grades.FirstOrDefault(g => g.GradeId == id);
            if (existingGrade == null)
                return NotFound();

            existingGrade.GradeName = grade.GradeName;
            existingGrade.Section = grade.Section;
            existingGrade.Description = grade.Description;

            _context.SaveChanges();
            return Ok(1);
        }
    }
}