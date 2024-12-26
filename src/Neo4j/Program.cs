//https://github.com/neo4j-examples/movies-dotnet-neo4jclient
//docker run  --name testneo4j  -p7474:7474 -p7687:7687  -d -v c:/neo4j/data:/data -v c:/neo4j/logs:/logs  -v c:/neo4j/import:/var/lib/neo4j/import  -v c:/neo4j/plugins:/plugins --env NEO4J_AUTH=neo4j/test  neo4j:latest

using Neo4j.Driver;
using Neo4j.Models;
using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var url = "http://localhost:7474";
var user = "neo4j";
var password = "your_password";
var client = new GraphClient(new Uri("http://localhost:7474"), "neo4j", "your_password");
client.ConnectAsync().Wait();

var query = client.Cypher.Match("(m:Movie)<-[:ACTED_IN]-(a:Person)")
   .Return((m, a) => new { movie = m.As<Movie>().title, cast = Return.As<string>("collect(a.name)") }).Limit(100);
var data = query.ResultsAsync.Result.ToList();
//You can see the cypher query here when debugging


var nodes = new List<NodeResult>();
var rels = new List<object>();
int i = 0, target;
foreach (var item in data)
{
    nodes.Add(new NodeResult { title = item.movie, label = "movie" });
    target = i;
    i++;
    if (!string.IsNullOrEmpty(item.cast))
    {
        var casts = JsonConvert.DeserializeObject<JArray>(item.cast);
        foreach (var cast in casts)
        {
            var source = nodes.FindIndex(c => c.title == cast.Value<string>());
            if (source == -1)
            {
                nodes.Add(new NodeResult { title = cast.Value<string>(), label = "actor" });
                source = i;
                i += 1;
            }
            rels.Add(new { source = source, target = target });
        }
    }
}

var result = (new { nodes = nodes, links = rels });

// Console.ReadKey();

/*
// Подключение к Neo4j
var driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "your_password"));
var session = driver.AsyncSession();

// Пример создания узла
await session.ExecuteWriteAsync(async tx =>
{
await tx.RunAsync("CREATE (a:Person {name: 'Charlie', age: 35})");
});

// Пример чтения узлов
var result = await session.ExecuteReadAsync(async tx =>
{
var res = await tx.RunAsync("MATCH (a:Person) RETURN a.name AS name, a.age AS age");
return await res.ToListAsync(record => new
{
    Name = record["name"].As <string>(),
    Age = record["age"].As<int>()
});
});

foreach (var person in result)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}

// Закрытие сессии и драйвера
await session.CloseAsync();
await driver.CloseAsync();
*/