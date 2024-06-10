using LoadDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LoadDB.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly PRN211_1Context _context;

        public IndexModel(PRN211_1Context context)
        {
            _context = context;
        }

        public IList<Student> Students;

        public IList<Department> Departs { get; set; }
        public void OnGet()
        {
            Students = _context.Students.Include(d => d.Depart).ToList();
            Departs = _context.Departments.ToList();
        }

        public void OnPost(IList<Department> selected)
        {
           if(selected.Any()) {
            Console.WriteLine(selected.First());
            }
        }
    }
}
