using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyUniversityAPI.Models;
using MyUniversityAPI.Models.DBSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyUniversityAPI.Services
{
    public class StudentsService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentsService(IOptions<UnivStudsDBSettings> UnivStudentsDB)
        {
            MongoClient mongoClient = new MongoClient(UnivStudentsDB.Value.ConnectionString);

            IMongoDatabase mongoDeptsDB = mongoClient.GetDatabase(UnivStudentsDB.Value.DatabaseName);

            _students = mongoDeptsDB.GetCollection<Student>(UnivStudentsDB.Value.CollectionName);
        }

        public async Task<List<Student>> GetAsync() =>
        await _students.Find(_ => true).ToListAsync();

        public async Task<Student?> GetAsync(int id) =>
            await _students.Find(x => x.StudentID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Student newStudent) =>
            await _students.InsertOneAsync(newStudent);

        public async Task UpdateAsync(int id, Student updatedStudent) =>
            await _students.ReplaceOneAsync(x => x.StudentID == id, updatedStudent);

        public async Task RemoveAsync(int id) =>
            await _students.DeleteOneAsync(x => x.StudentID == id);
    }
}
