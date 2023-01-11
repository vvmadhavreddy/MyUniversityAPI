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
    public class DepartmentsService
    {
        private readonly IMongoCollection<Department> _departments;

        public DepartmentsService(IOptions<UnivDeptsDBSettings> univDepartmentsDBSettings)
        {
            MongoClient mongoClient = new MongoClient(univDepartmentsDBSettings.Value.ConnectionString);

            IMongoDatabase mongoDeptsDB = mongoClient.GetDatabase(univDepartmentsDBSettings.Value.DatabaseName);

            _departments = mongoDeptsDB.GetCollection<Department>(univDepartmentsDBSettings.Value.CollectionName);
        }

        public async Task<List<Department>> GetAsync() =>
        await _departments.Find(_ => true).ToListAsync();

        public async Task<Department?> GetAsync(int id) =>
            await _departments.Find(x => x.DepartmentID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Department newDept) =>
            await _departments.InsertOneAsync(newDept);

        public async Task UpdateAsync(int id, Department updatedDept) =>
            await _departments.ReplaceOneAsync(x => x.DepartmentID == id, updatedDept);

        public async Task RemoveAsync(int id) =>
            await _departments.DeleteOneAsync(x => x.DepartmentID == id);
    }
}