using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using web_2.Models;

namespace web_2.Controllers
{
    public class IngrediensController : Controller
    {
        //Den här vissar all ingrediencer
        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Ingredienser");
            var collection = database.GetCollection<Ingrediens>("ingredienser");

            List<Ingrediens> ingredienser = collection.Find(i => true).ToList();

            return View(ingredienser);
        }
        //Det här är UI för att skapa en ingrediens
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ingrediens ingredienser)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Ingredienser");
            var collection = database.GetCollection<Ingrediens>("ingredienser");

            collection.InsertOne(ingredienser);

            return Redirect("/Ingrediens");
        }
        //Den här vissar enskilda ingredienser
        public IActionResult Show(string Id)
        {
            ObjectId ingredienserId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Ingredienser");
            var collection = database.GetCollection<Ingrediens>("ingredienser");

            Ingrediens ingredienser = collection.Find(i => i.Id == ingredienserId).FirstOrDefault();

            return View(ingredienser);
        }
        //Raderar ingredienser
        [HttpPost]
        public IActionResult DeleteIngrediens(string Id)
        {
            ObjectId ingredienserId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Ingredienser");
            var collection = database.GetCollection<Ingrediens>("ingredienser");

            collection.DeleteOne(i => i.Id == ingredienserId);

            return Redirect("/Home");

        }
    }
}
