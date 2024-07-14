using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Identity.Pages.Authentication
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [BindProperty]
       public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            [Compare("Name", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmName { get; set; }
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Id.ToString() };
                var result = await _userManager.CreateAsync(user, Input.Name);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }               
            }
            return Page();
        }
    }
}
