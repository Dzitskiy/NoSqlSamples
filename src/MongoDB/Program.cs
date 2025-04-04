// http://media.mongodb.org/zips.json

using MongoDB.Driver;
using MongoDB.Models;

var dbClient = new MongoClient("mongodb://admin:password@localhost:27017");

IMongoDatabase db = dbClient.GetDatabase("otus");
IMongoCollection<User> users = db.GetCollection<User>("Users");

users.InsertOne(new User
{
    Age = 20,
    User_name = "Alice",
    Phone = "+4991234589",
    _id = Guid.NewGuid().ToString().ToLower(),
    Company = new Company
    {
        Name = "Otus",
        Email = "tom@otus.ru",
        Startwork = DateTime.Now.AddDays(-10)
    }
}); ;

/*
var indexKeysDefinition = Builders<User>.IndexKeys.Ascending(x => x.User_name);
users.Indexes.CreateOne(new CreateIndexModel<User>(indexKeysDefinition));
*/

var u = users.Find<User>(x => x.Company.Startwork <= DateTime.Now).ToList();

foreach (var user in u)
{
    Console.WriteLine(user.User_name + ", " + "age: " + user.Age + " phone: " + user.Phone);
}

Console.ReadKey();