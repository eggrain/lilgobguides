using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lilgobguides.Pages.Secret;

[Authorize]
public class SecretModel : PageModel
{
    public void OnGet()
    {
    }
}
