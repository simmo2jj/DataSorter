using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DataSorter;
using Newtonsoft.Json;

namespace DataSorterAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult SortedPeople(string sortBy)
        {
            List<Models.PersonViewModel> lPeople = new List<Models.PersonViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62143/records/");
                //HTTP GET
                var responseTask = client.GetAsync(sortBy);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultJson = result.Content.ReadAsStringAsync();
                    resultJson.Wait();
                     lPeople = JsonConvert.DeserializeObject<List<Models.PersonViewModel>>(resultJson.Result);

                }
            }
            return View(lPeople);
        }

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(Models.PersonViewModel pPerson)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62143/records");

                var postTask = client.PostAsJsonAsync<Models.PersonViewModel>("records", pPerson);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(pPerson);
        }
    }
}
