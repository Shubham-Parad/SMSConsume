using Microsoft.AspNetCore.Mvc;

namespace SMSConsume.Controllers
{
    public class AuthController : Controller
    {
        HttpClient client;
        public AuthController()
        {

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
