using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SMS_MVCDTO.Views.Home
{
    public class Signup : PageModel
    {
        private readonly ILogger<Signup> _logger;

        public Signup(ILogger<Signup> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}