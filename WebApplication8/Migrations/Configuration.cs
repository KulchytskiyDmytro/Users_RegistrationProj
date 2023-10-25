
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace WebApplication8.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication8.Models.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}