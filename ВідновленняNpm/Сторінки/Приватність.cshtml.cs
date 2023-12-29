using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ВідновленняNpm.Сторінки
{
    public class МодельПриватності : PageModel
    {
        private readonly ILogger<МодельПриватності> _logger;

        public МодельПриватності(ILogger<МодельПриватності> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
