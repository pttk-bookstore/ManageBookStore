﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore.DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MiniBookStoreEntities : DbContext
    {
        public MiniBookStoreEntities()
            : base("name=MiniBookStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Bill_Detail> Bill_Detail { get; set; }
        public virtual DbSet<Bill_Type> Bill_Type { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Book_Inventory> Book_Inventory { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Discount_Code> Discount_Code { get; set; }
        public virtual DbSet<Discount_Type> Discount_Type { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee_Account> Employee_Account { get; set; }
        public virtual DbSet<Page_Wage> Page_Wage { get; set; }
        public virtual DbSet<Regulation> Regulations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<WareHouse> WareHouses { get; set; }
        public virtual DbSet<WareHouse_Detail> WareHouse_Detail { get; set; }
    }
}