using Intex.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Intex.DAL
{
    public class IntexContext : DbContext
    {
        public IntexContext() : base("IntexContext")
        {

        }

  
        public DbSet<ClientEmployee> ClientEmployees { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Compound> Compounds { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TestMaterial> TestMaterials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<OrderTest> OrderTests { get; set; }

        public System.Data.Entity.DbSet<Intex.Models.Backlog> Backlogs { get; set; }

        public System.Data.Entity.DbSet<Intex.Models.CreateWorkOrder> CreateWorkOrders { get; set; }

        public System.Data.Entity.DbSet<Intex.Models.Report> Reports { get; set; }

        public System.Data.Entity.DbSet<Intex.Models.Compoundlog> Compoundlogs { get; set; }
    }
}
