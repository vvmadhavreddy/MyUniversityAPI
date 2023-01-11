using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MyUniversityAPI.Enums;

namespace MyUniversityAPI.Models
{
    public class Department
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }

        [BsonElement("Dept_ID")]
        public int DepartmentID { get; set; }

        [BsonElement("Dept_Name")]
        public DeptEnum DepartmentName { get; set; }

        [BsonElement("Dept_HOD")]
        public string DepartmentHOD { get; set; }

        [BsonElement("Subjects")]
        public SubjectsInDept AllYearSubjects { get; set; }
    }
}