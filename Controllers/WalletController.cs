using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;

namespace SMS_MVCDTO.Controllers
{
    public class WalletController : Controller
    {
        private readonly IWalletService _wallet;
        public WalletController(IWalletService wallet)
        {
            _wallet = wallet;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
