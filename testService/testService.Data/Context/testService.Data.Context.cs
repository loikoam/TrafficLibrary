using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testService.Data.Models;

namespace testService.Data.Context
{
    public class TestServiceContext : DbContext
    {
        public TestServiceContext() : base("SampleDbConnection")
        {
        }

        public DbSet<BookDb> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)  //нужно использовать базовый метод, очень полезно и другой вопрос когда его вызывать
        {
            base.OnModelCreating(modelBuilder);

            var entity = modelBuilder.Entity<BookDb>();

            //using Fluent API
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(255).IsUnicode();
            entity.Property(x => x.Price).IsRequired();



        }
    }
}
