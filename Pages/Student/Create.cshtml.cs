using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformation.Data;
using StudentInformation.Model;

namespace StudentInformation.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly StudentInformationContext _context;

        public CreateModel(StudentInformationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student_Info Student_Info { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student_Info.Add(Student_Info);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
