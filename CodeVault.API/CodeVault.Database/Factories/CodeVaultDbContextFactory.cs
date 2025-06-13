using CodeVault.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class CodeVaultDbContextFactory : IDesignTimeDbContextFactory<CodeVaultDbContext>
{
    public CodeVaultDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CodeVaultDbContext>();
        optionsBuilder.UseNpgsql("User Id=postgres.bxrzklssvzsfcumpuowk;Password=ocTnPcv5uNezDabR;Server=aws-0-us-east-2.pooler.supabase.com;Port=5432;Database=postgres");

        return new CodeVaultDbContext(optionsBuilder.Options);
    }
}