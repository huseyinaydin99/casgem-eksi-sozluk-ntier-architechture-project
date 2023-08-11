using EksiSozluk.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=eksisozluk.database.windows.net;initial catalog=eksisozluk_2;User Id=eksisozluk;Password=eksi123.");
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = eksisozluk_2; Integrated Security = True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<TermsOfUse> TermsOfUses { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<AdminMessage> AdminMessages { get; set; }
    }
}
