using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student()
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subcriped = viewModel.Subcriped,
            };
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task <IActionResult> List() 
        {
            var students=await _dbContext.Students.ToListAsync();
            return View(students);
        }
    }
}
