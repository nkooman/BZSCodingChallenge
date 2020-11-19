using System.Collections.Generic;
using BZSCodingChallenge.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BZSCodingChallenge.Controllers
{
    public class ContactController : Controller
    {
        private readonly IWebHostEnvironment env;

        public ContactController(IWebHostEnvironment env) => this.env = env;

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(ContactFormModel formModel)
        {
            if (ModelState.IsValid == true)
            {
                var responsesPath = env.ContentRootPath + "/responses.json";

                List<ContactFormModel> models = JsonConvert.DeserializeObject<List<ContactFormModel>>(System.IO.File.ReadAllText(responsesPath)) ?? new List<ContactFormModel>();

                models.Add(formModel);

                System.IO.File.WriteAllText(responsesPath, JsonConvert.SerializeObject(models));

                // Quick way to clear the form for this challenge.
                return Redirect("/");
            }

            return View();
        }
    }
}
