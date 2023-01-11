using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyUniversityAPI.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }

        [BsonElement("StudID")]
        public int StudentID { get; set; }

        [BsonElement("Dept")]
        public string Department { get; set; }

        [BsonElement("Year")]
        public int YearStudying { get; set; }

        [BsonElement("Marks")]
        public YearWiseMarks Marks { get; set; }

        [BsonElement("FeesStatus")]
        public YearWiseFeesStatus FeeStatus { get; set; }
    }
}