namespace Luppy.Models;

public class UserDatabaseConfiguration
{
    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
    public required string UsersCollectionName { get; set; }
}
