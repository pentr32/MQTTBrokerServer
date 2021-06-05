using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MeasurementsContext : DbContext
    {
        private const string connectionString = "server=192.168.42.14;port=3306;database=mqttdb;user=mqttdbuser;password=P@ssw0rd";
        //private const string connectionString = "server=192.168.42.14;port=3306;database=mqqtdb;uid=mqttdbuser@localhost;pwd=P@ssw0rd;";

        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

    }
}
