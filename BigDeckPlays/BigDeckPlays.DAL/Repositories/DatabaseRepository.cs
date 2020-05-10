using BigDeckPlays.Shared.Models;
using BigDeckPlays.DAL.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;


namespace BigDeckPlays.DAL.Repositories
{
    public interface IDatabaseRepository
    {
    }
    
    public class DatabaseRepository : DbContext, IDatabaseRepository
    {
        public virtual DbSet<CardDb> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=bigdeckplays;Username=postgres;Password=secret_db_password");
        }

        // public static DbContextOptions GetOptions()
        // {
        //     var options = new DbContextOptions();
        //     var connectionString = "";
        //     var dbPassword = "";
 
        //     var builder = new NpgsqlConnectionStringBuilder(connectionString)
        //     {
        //         Password = dbPassword
        //     };
        //     return DbContextOptions.UseNpgsql(builder.ConnectionString);
        // }
    }
}
