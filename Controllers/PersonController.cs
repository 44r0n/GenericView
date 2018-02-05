using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViewGenerator.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewGenerator.Controllers
{
    public class PersonController:Controller
    {
        private IList<object> people;

        // GET: Person
        public ActionResult Index()
        {
            people = new List<object>()
            {
                new Person("Maria",12),
                new Person("Jhon",3)
            };
            List<string> Properties = new List<string>
            {
                "Name",
                "Age"
            };

            IList<TagBuilder> actions = new List<TagBuilder>();
            foreach(Person person in people)
            {
                TagBuilder builder = new TagBuilder("button");
                builder.AddCssClass("btn btn-primary");
                builder.InnerHtml.Append("Say my name");
                builder.Attributes.Add("onclick","alert(\'"+person.Name+"\')");
                actions.Add(builder);
            }
            ViewBag.Properties = Properties;
            ViewBag.Actions = actions;
            return View("View",people);
        }
    }
}