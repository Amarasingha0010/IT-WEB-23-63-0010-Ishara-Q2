using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentInformation.Data;
using StudentInformation.Model;

namespace StudentInformation.Pages.Course
{
    public class IndexModel : PageModel
    {
        private readonly StudentInformation.Data.StudentInformationContext _context;

        public IndexModel(StudentInformation.Data.StudentInformationContext context)
        {
            _context = context;
        }

        public IList<Course_Info> Course_Info { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Course_Info = await _context.Course_Info.ToListAsync();
        }
    }
}
