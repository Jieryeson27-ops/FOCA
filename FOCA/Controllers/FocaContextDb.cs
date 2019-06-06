﻿using FOCA.Plugins;
using MetadataExtractCore.Diagrams;
using System;
using System.Data.Entity;

namespace FOCA.Controllers
{
    public class FocaContextDb : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<FilesITem> Files { get; set; }
        public DbSet<DomainsItem> Domains { get; set; }
        public DbSet<ComputersItem> Computers { get; set; }
        public DbSet<ComputerIPsItem> ComputerIps { get; set; }
        public DbSet<ComputerDomainsItem> ComputerDomain { get; set; }
        public DbSet<Limits> Limits { get; set; }
        public DbSet<RelationsItem> Relations { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<IPsItem> Ips { get; set; }
        public DbSet<HttpMapTypesFiles> HttpMapTypesFiles { get; set; }
        public DbSet<Plugin> Plugins { get; set; }

        public FocaContextDb() : base()
        { }

        public FocaContextDb(string connectionString) : base(connectionString)
        { }

        public static bool IsDatabaseAvailable(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            try
            {
                using (FocaContextDb context = new FocaContextDb(connectionString))
                {
                    context.Database.CreateIfNotExists();
                    context.Database.Connection.Open();
                    context.Database.Connection.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }

}
