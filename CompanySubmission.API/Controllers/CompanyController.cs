using CompanySubmission.API.Data;
using CompanySubmission.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanySubmission.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CompanyController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> PostCompany([FromForm] CompanyInfo company, IFormFile npwpFile, IFormFile powerFile)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            if (string.IsNullOrEmpty(_env.WebRootPath))
            {
                _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            string uploads = Path.Combine(_env.WebRootPath, "uploads\\" + company.Id);

            if (npwpFile != null)
            {
                Directory.CreateDirectory(uploads + "\\NPWP");
                var path = Path.Combine(uploads + "\\NPWP", Path.GetFileName(npwpFile.FileName));
                using var stream = System.IO.File.Create(path);
                await npwpFile.CopyToAsync(stream);
                company.NPWPFilePath = npwpFile.FileName;
            }

            if (powerFile != null)
            {
                Directory.CreateDirectory(uploads + "\\Power");
                var path = Path.Combine(uploads + "\\Power", Path.GetFileName(powerFile.FileName));
                using var stream = System.IO.File.Create(path);
                await powerFile.CopyToAsync(stream);
                company.PowerOfAttorneyFilePath = powerFile.FileName;
            }

            _context.Companies.Update(company);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Success" });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            var companies = await _context.Companies.ToListAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        
    }
}
