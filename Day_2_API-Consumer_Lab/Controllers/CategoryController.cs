using Day_2_API_Consumer_Lab.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Day_2_API_Consumer_Lab.Controllers
{
    public class CategoryController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Category
        public ActionResult Index()
        {
            
           HttpResponseMessage Response= client.GetAsync("https://localhost:44373/api/category/1").Result;
             string Message = Response.Content.ReadAsStringAsync().Result;
            //ViewBag.Result = Message;
            // ViewBag.Result = Response.Content.ReadAsStringAsync().Result;
           
            Category cat= JsonConvert.DeserializeObject<Category>(Message);
            ViewBag.Result =cat;
            return View();
        }

        public ActionResult GetAll()
        {
            HttpResponseMessage Response = client.GetAsync("https://localhost:44373/api/category").Result;
            string Message = Response.Content.ReadAsStringAsync().Result;

          List<Category> cat=  JsonConvert.DeserializeObject < List<Category>>(Message);
            ViewBag.Result = cat;
            return View();
        }

        public ActionResult AddCategory()
        {
            Category cat = new Category() { Id=6,Name="Joice"};
             string Request =JsonConvert.SerializeObject(cat);

            StringContent RequestBody = new StringContent(Request,Encoding.UTF8,"Application/Json");

            HttpResponseMessage Response = client.PostAsync("https://localhost:44373/api/category",RequestBody).Result;

            if (Response.IsSuccessStatusCode)
            {
                ViewBag.Result = "Added";
            }
            else
            {
                ViewBag.Result = "Not Added";
            }
            return RedirectToAction("GetAll");
        }
    }
}