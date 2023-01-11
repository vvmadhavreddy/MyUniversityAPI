using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyUniversityAPI.Models
{
    public class YearWiseMarks
    {
        [BsonElement("Year_One")]
        public YearWiseSubMarks FirstYear { get; set; }

        [BsonElement("Year_Two")]
        public YearWiseSubMarks SecondYear { get; set; }

        [BsonElement("Year_Three")]
        public YearWiseSubMarks ThirdYear { get; set; }

        [BsonElement("Year_Four")]
        public YearWiseSubMarks FourthYear { get; set; }
    }
}
