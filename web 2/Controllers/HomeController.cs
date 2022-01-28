using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using web_2.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Recept");
            var collection = database.GetCollection<Recepts>("recept");

            List<Recepts> recept = collection.Find(r => true).ToList();

            return View(recept);
        }

        public IActionResult Create()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Ingredienser");
            var collection = database.GetCollection<Ingrediens>("ingredienser");

            List<Ingrediens> ingredienser = collection.Find(i => true).ToList();

            return View(ingredienser);
        }

        [HttpPost]
        public IActionResult Create(Recepts recept)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Recept");
            var collection = database.GetCollection<Recepts>("recept");

            collection.InsertOne(recept);

            return Redirect("/Home");
        }
        public IActionResult Show(string Id)
        {
            ObjectId receptId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Recept");
            var collection = database.GetCollection<Recepts>("recept");

            Recepts recept = collection.Find(r => r.Id == receptId).FirstOrDefault();

            return View(recept);

        }

        [HttpPost]
        public IActionResult DeleteRecept(string Id)
        {
            ObjectId receptId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Recept");
            var collection = database.GetCollection<Recepts>("recept");

            collection.DeleteOne(r => r.Id == receptId);

            return Redirect("/Home/");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
