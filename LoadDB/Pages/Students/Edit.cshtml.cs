using LoadDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LoadDB.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly PRN211_1Context _Context;

        public EditModel(PRN211_1Context context)
        {
            this._Context = context;
        }

        [BindProperty]
        public Student student { get; set; }

        public List<Department> departments { get; set; }
        public IActionResult OnGet(int? id)
        {
            var x = _Context.Students.Find(id);
            //departments = _Context.Departments.ToList();
            ViewData["Dept"] = new SelectList(_Context.Departments, "Id", "Name");
            if (x == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                student = x;
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid || student ==null || _Context.Students == null) {
                return RedirectToPage();
            }
            var x = _Context.Students.Find(student.Id);
            if(x == null)
            {
                return RedirectToPage();
            }

            x.Name = student.Name;
            x.Dob = student.Dob;
            x.Gender = student.Gender;
            x.Gpa = student.Gpa;
            x.DepartId = student.DepartId;

            _Context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
