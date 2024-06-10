using LoadDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDB.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly PRN211_1Context _1Context;

        public DeleteModel(PRN211_1Context _1Context)
        {
            this._1Context = _1Context;
        }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
            }
            else
            {
                var x = _1Context.Students.Find(id);
                if (x == null) ;
                else
                {
                    _1Context.Students.Remove(x);
                    _1Context.SaveChanges();
                }
            }
            return RedirectToPage("Index");
        }
    }
}
