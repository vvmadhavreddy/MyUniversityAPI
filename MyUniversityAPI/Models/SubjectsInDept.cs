using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MyUniversityAPI.Models
{
    public class SubjectsInDept
    {
        [BsonElement("Year_One")]
        public SubjectsPerYear FirstYearSubjects { get; set; }

        [BsonElement("Year_Two")]
        public SubjectsPerYear SecondYearSubjects { get; set; }

        [BsonElement("Year_Three")]
        public SubjectsPerYear ThirdYearSubjects { get; set; }

        [BsonElement("Year_Four")]
        public SubjectsPerYear FourthYearSubjects { get; set; }
    }
}