using System.Data.Entity.Migrations;
using UamTTA.Storage;

namespace UamTTA.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<UamTTAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UamTTAContext context)
        {
        }
    }
}