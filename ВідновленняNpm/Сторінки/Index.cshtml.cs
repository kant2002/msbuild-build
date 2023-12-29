using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ВідновленняNpm.Сторінки
{
    public class МодельГоловної : PageModel
    {
        private readonly ILogger<МодельГоловної> _logger;

        public МодельГоловної(ILogger<МодельГоловної> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
