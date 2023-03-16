namespace Papasi.Services;

public interface IIdentityDbInitializer
{
    Task SeedDatabaseWithAdminUserAsync();
}