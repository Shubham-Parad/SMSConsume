using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMSConsume.Models;
using System.Security.Claims;
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
            u.Urole = "empty";
            string url = "https://localhost:7186/api/Auth/SignIn/";
            var jsondata = JsonConvert.SerializeObject(u);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if(response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Raw API Response: " + responseData);  // Log the response data

                try
                {
                    var authenticatedUser = JsonConvert.DeserializeObject<Users>(responseData);
                    if (authenticatedUser != null)
                    {
                        if (authenticatedUser.Urole == "Admin")
                        {
                            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, u.UserId.ToString()) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetString("Admin", u.UserId.ToString());
                            return RedirectToAction("AdminDashboard");
                        }
                        else if (authenticatedUser.Urole == "Teacher")
                        {
                            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, u.UserId.ToString()) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetString("Teacher", u.UserId.ToString());
                            return RedirectToAction("TeacherDashboard");
                        }
                        else if (authenticatedUser.Urole == "Parent")
                        {
                            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, u.UserId.ToString()) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetString("Parent", u.UserId.ToString());
                            return RedirectToAction("ParentDashboard");
                        }
                        else if (authenticatedUser.Urole == "Student")
                        {
                            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, u.UserId.ToString()) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetString("Student", u.UserId.ToString());
                            return RedirectToAction("StudentDashboard");
                        }
                        else if (authenticatedUser.Urole == "Librarian")
                        {
                            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, u.UserId.ToString()) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetString("Librarian", u.UserId.ToString());
                            return RedirectToAction("LibrarianDashboard");
                        }
                        else
                        {
                            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, u.UserId.ToString()) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetString("Accountant", u.UserId.ToString());
                            return RedirectToAction("AccountantDashboard");
                        }
                    }
                }
                catch (JsonReaderException ex)
                {
                    Console.WriteLine($"JSON parsing error: {ex.Message}");
                    ViewBag.ErrorMessage = "Invalid response from server.";
                    return View();
                }
                
            }
            else
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                Console.WriteLine($"Response content: {responseContent}");

                ViewBag.ErrorMessage = "Invalid credentials or an error occurred.";
            }
            return View();
        }

        public IActionResult SignUp(Users u)
        {
            string url = "https://localhost:7186/api/Auth/SignUp/";
            var jsondata = JsonConvert.SerializeObject(u);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Sign-up successful. Please sign in.";
                return RedirectToAction("SignIn");
            }
            else
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                Console.WriteLine($"Response content: {responseContent}");

                ViewBag.ErrorMessage = "Sign-up failed or an error occurred.";
            }
            return View();
        }
    }
}



