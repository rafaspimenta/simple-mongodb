using Luppy.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Luppy.Services;
public class UserService
{
    private readonly IMongoCollection<User> _usersCollection;

    public UserService(IOptions<UserDatabaseConfiguration> userConfig)
    {
        var client = new MongoClient(userConfig.Value.ConnectionString);
        var database = client.GetDatabase(userConfig.Value.DatabaseName);
        _usersCollection = database.GetCollection<User>(userConfig.Value.UsersCollectionName);
    }

    public async Task<IList<User>> GetUsersAsync() => await _usersCollection.Find(user => true).ToListAsync();

    public async Task<User> GetUserAsync(string id) => await _usersCollection.Find(user => user.Id == id).FirstOrDefaultAsync();

    public async Task CreaterAsync(User newUser) => await _usersCollection.InsertOneAsync(newUser);

    public async Task ReplaceAsync(string id, User newUser) => await _usersCollection.ReplaceOneAsync(newUser => newUser.Id == id, newUser);

    //delete async
    public async Task DeleteAsync(string id) => await _usersCollection.DeleteOneAsync(user => user.Id == id);
}
