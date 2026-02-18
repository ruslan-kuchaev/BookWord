using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wood.Pages;

[Authorize] 
public class CartModel : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }
}
