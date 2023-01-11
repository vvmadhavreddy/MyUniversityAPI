using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MyUniversityAPI.Models
{
    public class YearWiseFeesStatus
    {
        [BsonElement("Year_One")]
        public string FirstYear { get; set; }

        [BsonElement("Year_Two")]
        public string SecondYear { get; set; }

        [BsonElement("Year_Three")]
        public string ThirdYear { get; set; }

        [BsonElement("Year_Four")]
        public string FourthYear { get; set; }
    }
}