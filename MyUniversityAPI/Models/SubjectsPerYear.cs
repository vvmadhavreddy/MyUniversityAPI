using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MyUniversityAPI.Models
{
    public class SubjectsPerYear
    {
        [BsonElement("Sub_001")]
        public string FirstSubject { get; set; }

        [BsonElement("Sub_002")]
        public string SecondSubject { get; set; }
    }
}