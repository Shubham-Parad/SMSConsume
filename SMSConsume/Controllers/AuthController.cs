using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMSConsume.Models;
using System.Text;

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
        public IActionResult SignIn(Users u)
        {
            string url = "https://localhost:7186/api/Auth/SignIn/";
            var jsondata = JsonConvert.SerializeObject(u);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                if (u.Urole == "Admin")
                {
                    return RedirectToAction("Index");
                }
                else if (u.Urole == "Student")
                {
                    return RedirectToAction("Index");
                }
                else if (u.Urole == "Teacher")
                {
                    return RedirectToAction("Index");
                }
                else if (u.Urole == "Parent")
                {
                    return RedirectToAction("Index");
                }
                else if (u.Urole == "Accountant")
                {
                    return RedirectToAction("Index");
                }
                else if (u.Urole == "Librarian")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}
