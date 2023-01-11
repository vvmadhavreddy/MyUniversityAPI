using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyUniversityAPI.Models
{
    public class YearWiseSubMarks
    {
        [BsonElement("Sub_001")]
        public int FirstSubject { get; set; }

        [BsonElement("Sub_002")]
        public int SecondSubject { get; set; }
    }
}
