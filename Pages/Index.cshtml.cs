using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StatsdClient;

namespace dotnetcoresample.Pages;

public class IndexModel : PageModel
{    
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var dogstatsdConfig = new StatsdConfig { };

        using (var dsd = new DogStatsdService())
        {
            dsd.Configure(dogstatsdConfig);
            dsd.Increment("page.views");
        }
    }
}
