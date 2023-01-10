using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SMS_MVCDTO.Views.Shared
{
    public class _Navigation : PageModel
    {
        private readonly ILogger<_Navigation> _logger;

        public _Navigation(ILogger<_Navigation> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}