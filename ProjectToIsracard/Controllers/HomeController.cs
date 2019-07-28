using ProjectToIsracard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjectToIsracard.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PartialRepositoriesList(string s)
        {

            Repository repository = Functions.Functions.GetGitHubRepositories(s);
           
            return View(repository);
        }

        [HttpGet]

        public ActionResult BookmarkedRepositories()
        {
            List<Item> bookmarkedRepositories = (List<Item>)Session["bookmarkedRepositories"];

            return View(bookmarkedRepositories);
        }
        public void AddToSession(int id,string name , string avatar_url)
        {
            Item item = new Item() {id=id, name= name ,owner=new Owner() {avatar_url= avatar_url } };
           
            List<Item> items = new List<Item>();
            List<Item> bookmarkedRepositories = (List<Item>)Session["bookmarkedRepositories"];
            if (bookmarkedRepositories == null)
            {
                bookmarkedRepositories = new List<Item>();
            }
            foreach (var i in bookmarkedRepositories)
            {
                if (i.id==item.id)
                {
                    return;
                }
            }
            bookmarkedRepositories.Add(item);
            Session.Add("bookmarkedRepositories", bookmarkedRepositories);

           
          
        }


 
    }
}
