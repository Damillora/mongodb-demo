using Accelist.MongoDBDemo.API.Database;
using Accelist.MongoDBDemo.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Accelist.MongoDBDemo.API.Services;

public class EmployeeService
{
    private readonly IMongoCollection<Employee> employeeCollection;

    public EmployeeService(
        IOptions<MongoDBDatabaseSettings> databaseSettings
    )
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

        var employeeCollection = mongoDatabase.GetCollection<Employee>(databaseSettings.Value.CollectionNames["Employee"]);

        this.employeeCollection = employeeCollection;
    }

    public async Task<List<Employee>> GetAsync() =>
        await employeeCollection.Find(_ => true).ToListAsync();

    public async Task<Employee?> GetAsync(string id) =>
        await employeeCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Employee employee) =>
        await employeeCollection.InsertOneAsync(employee);

    public async Task UpdateAsync(string id, Employee updateEmployee) =>
        await employeeCollection.ReplaceOneAsync(x => x.Id == id, updateEmployee);

    public async Task RemoveAsync(string id) =>
        await employeeCollection.DeleteOneAsync(x => x.Id == id);
}
