using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentInformation.Data;
using StudentInformation.Model;

namespace StudentInformation.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly StudentInformation.Data.StudentInformationContext _context;

        public IndexModel(StudentInformation.Data.StudentInformationContext context)
        {
            _context = context;
        }

        public IList<Student_Info> Student_Info { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student_Info = await _context.Student_Info
                .Include(s => s.Course).ToListAsync();
        }
    }
}
