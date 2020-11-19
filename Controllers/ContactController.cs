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
                System.IO.File.WriteAllText(env.ContentRootPath + "/responses.json", JsonConvert.SerializeObject(formModel));

                // Quick way to clear the form for this challenge.
                return Redirect("/");
            }

            return View();
        }
    }
}
