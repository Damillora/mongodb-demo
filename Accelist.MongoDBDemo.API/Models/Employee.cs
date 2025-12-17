
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Accelist.MongoDBDemo.API.Models;

public class Employee
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string EmployeeName { get; set; } = "";

    public string EmployeeNumber { get; set; } = "";

    public string? IDCardSerial { get; set; }

    public EmployeeAddress? Address { get; set; }
}

public class EmployeeAddress
{
    public string Line1 { get; set; }

    public string Kota { get; set; }
}
