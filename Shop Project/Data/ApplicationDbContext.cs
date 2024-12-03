using Microsoft.EntityFrameworkCore;
using Shop_Project.Models;

namespace Shop_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {

        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Shop_details> Shop_Details { get; set; }

    }
}
