using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMSConsume.Models;
using System.Security.Claims;
using System.Text;

namespace SMSConsume.Controllers
{
    public class AdminController : Controller
    {
        HttpClient client;

        public AdminController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            string url = "https://localhost:7238/api/Teacher/AddTeacher";
            var jsondata = JsonConvert.SerializeObject(teacher);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Teacher Added Successfully";
                return RedirectToAction("AdminDashboard", "Admin");
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong please try again later";
                return View();
            }
        }
        public IActionResult AddClass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClass(Classes c)
        {
            string url = "https://localhost:7238/api/Class/AddClass";
            var jsondata = JsonConvert.SerializeObject(c);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Class Added Successfully";
                return RedirectToAction("AdminDashboard","Admin");
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong please try again later or Contact the system Admin";
                return View();
            }

        }

        public IActionResult AddParent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddParent(Parent p)
        {
            string url = "https://localhost:7238/api/Parent/AddParent";
            var jsondata = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.PostAsync(url, content).Result;
            if (message.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Parent Added Successfully";
                return RedirectToAction("AdminDashboard","Admin");
            }
            else
            {
                TempData["Msg"] = "Something went wrong.";
                return View();
            }
        }

        public IActionResult AdmitStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdmitStudent(Student s)
        {

            string url = "https://localhost:7238/api/Student/AddStudent";
            var jsondata = JsonConvert.SerializeObject(s);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.PostAsync(url, content).Result;
            if (message.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Student Added Successfully";
                return RedirectToAction("AdminDashboard","Admin");

            }
            else
            {
                return View();

            }

        }

        public IActionResult AddSubjects()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSubjects(Subject sub)
        {
            string url = "https://localhost:7238/api/Subject/AddSubject";
            var jsondata = JsonConvert.SerializeObject(sub);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Subject Added Succesfully";
                return RedirectToAction("AdminDashboard", "Admin");
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong Please Try Again Later";
                return View();

            }

        }

        public IActionResult AddTimetable()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddTimetable(Timetable tt)
        {
            string url = "https://localhost:7238/api/Timetable/AddTimetable";
            var jsondata = JsonConvert.SerializeObject(tt);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "TimeTable Added Successfully";
                return RedirectToAction("AddTimetable");
            }
            else
            {
                TempData["Msg"] = "Couldn't add Timetable please try again";
                return View();
            }

        }
    }
}
