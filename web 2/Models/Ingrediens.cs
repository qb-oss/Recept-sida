using MongoDB.Bson;


namespace web_2.Models
{
    public class Ingrediens
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Smak { get; set; }

    }
}
