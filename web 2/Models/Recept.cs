using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Recepts
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public int Portioner { get; set; }
        public int[] IAmount { get; set; }
        public string[] IMot { get; set; }
        public string[] IType { get; set; }
        public string Howto { get; set; }

    }
}