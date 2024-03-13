using Login_Page.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace Login_Page.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentService _studentService;


        public HomeController(ILogger<HomeController> logger, StudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        public IActionResult Index()
        {

            TempData["username"] = HttpContext.Session.GetString("s1");
            TempData["theres"] = HttpContext.Session.GetString("s2"); 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Users> data()
        {
            var users = new List<Users>()
            {
                new Users {Id=1,UserName ="Maya",password ="123", status=1},
                new Users {Id=2,UserName ="Lara",password="456", status=0},
                new Users {Id=3,UserName = "Faisal",password="789", status=1}
            };

            return users;
        }

        public IActionResult login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult verify(Users user)
        {
            var u = data();
            var match = u.FirstOrDefault(x => x.UserName.Equals(user.UserName));

            if (match != null && match.password.Equals(user.password))
            {
                TempData["message"] = match.UserName;
                HttpContext.Session.SetString("s1", match.UserName);

                if (match.status == 1)
                {
                    var jsonResponse = JsonConvert.SerializeObject(new { Value = match, Message = "Login successful" });

                    // Parse the JSON string using JObject
                    JObject json = JObject.Parse(jsonResponse);

                    // Access the "Message" property
                    string messageVar = json["Message"].ToString();

                    HttpContext.Session.SetString("s2", messageVar);

                    return RedirectToAction("Index");
                }
                else
                {
                    var jsonResponse = JsonConvert.SerializeObject(new { Value = match, Message = "Account is not active" });

                    // Parse the JSON string using JObject
                    JObject json = JObject.Parse(jsonResponse);

                    // Access the "Message" property
                    string messageVar = json["Message"].ToString();

                    HttpContext.Session.SetString("s2", messageVar);

                    return RedirectToAction("Index");

                }
            }

            else
            {
                //return Ok("NO account");
                @TempData["message"] = "login failed";
                return RedirectToAction("login");
            }
        }


        public IActionResult form ()
        {
            return View();
        }


        [HttpPost]
        public IActionResult storedata(Student student)
        {
           _studentService.AddStudent(student);

            return RedirectToAction("dataTable");
            
        }
        
        public IActionResult dataTable()
        {
            ViewBag.Students = _studentService.GetStudents();
            return View();
        }


        public IActionResult EditData(Student student)
        {
            ViewBag.Student = student;
            _studentService.DeleteStudent(student);
            return View();
        }

    }
}