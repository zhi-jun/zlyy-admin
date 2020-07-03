using System;
using Admin.EntityFrameworkCore.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZLYY.Utils.Collections;

namespace Admin.Migrator
{
    class Program
    {
        private static bool _quietMode;
        static void Main(string[] args)
        {
            ParseArgs(args);
            var ret = DoMigration();
            var exitCode = Convert.ToInt32(ret);
            if (_quietMode)
            {
                Environment.Exit(exitCode);
                return;
            }
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
            Environment.Exit(exitCode);
        }

        private static object DoMigration()
        {
            Console.WriteLine("Database connection: " + AppConfigurations.Configuration.GetConnectionString("Default"));
            Console.WriteLine("Continue to migration for this database?(Y/N):");
            var command = Console.ReadLine();
            if (command?.ToLower() != "y")
            {
                Console.WriteLine("Migration canceled.");
                return false;
            }
            try
            {
                Console.WriteLine("Database migration started...");
                var dbContext = new AppDbContextFactory().CreateDbContext(null);
                dbContext.Database.Migrate();
                Console.WriteLine("Database migration completed.");
                Console.WriteLine("Database seed started...");
                var seeder = new AppDbSeeder(dbContext);
                seeder.Seed();
                Console.WriteLine("Database seed completed.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured during migration:");
                Console.WriteLine(e);
                return false;
            }
        }

        private static void ParseArgs(string[] args)
        {
            if (args.IsNullOrEmpty())
            {
                return;
            }

            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-q":
                        _quietMode = true;
                        break;
                }
            }
        }
    }
}
