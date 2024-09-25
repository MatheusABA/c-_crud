using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.Employees;
using Microsoft.EntityFrameworkCore;

namespace crud.Data;

public class AppDbContext : DbContext
{
    // DbSet -> instruct EF to transform Employee Class into a Database Table
    DbSet<Employee> Employees {get; set;}


    // connection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "Data Source=Company.sqlite");
        base.OnConfiguring(optionsBuilder);
        
    }

}
