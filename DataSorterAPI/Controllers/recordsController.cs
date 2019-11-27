using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Hosting;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using DataSorter;

namespace DataSorterAPI.Controllers
{
    public class recordsController : ApiController
    {

        // GET: records/*sortBy*
        [Route("records/{pSortBy}")]
        public HttpResponseMessage GetPeople(string pSortBy)
        {
            List<Person> lPeople = Program.BuildPersonList(HostingEnvironment.MapPath("~/InputFiles/Pipe.txt"), HostingEnvironment.MapPath("~/InputFiles/Comma.txt"), HostingEnvironment.MapPath("~/InputFiles/Space.txt"));

            switch (pSortBy.ToLower())
            {
                case "gender": lPeople = Program.sortByGender(lPeople); break;
                case "birthdate": lPeople = Program.sortByBirthDate(lPeople); break;
                case "name": lPeople = Program.sortByName(lPeople); break;
            }

            List<Models.PersonViewModel> lPeopleViewModel = new List<Models.PersonViewModel>();
            foreach(var person in lPeople)
            {
                lPeopleViewModel.Add(new Models.PersonViewModel(person.LastName, person.FirstName, person.PersonGender.ToString(), person.FavoriteColor, person.DateOfBirth));
            }

            var jsonPeople = JsonConvert.SerializeObject(lPeopleViewModel);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonPeople, Encoding.UTF8, "application/json");
            return response;
        }

        // POST: records/
        [Route("records/")]
        public IHttpActionResult PostNewPerson(Models.PersonViewModel pPerson)
        {

            if (ModelState.IsValid)
            {

                using (StreamWriter sw = File.AppendText(HostingEnvironment.MapPath("~/InputFiles/Pipe.txt")))
                {
                    sw.WriteLine(pPerson.LastName + "|" + pPerson.FirstName + "|" + pPerson.PersonGender + "|" + pPerson.FavoriteColor + "|" + pPerson.DateOfBirth.ToShortDateString());
                }

                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
