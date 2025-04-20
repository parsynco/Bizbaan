using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Parsyn.Apps.Company.Data.Models.Entity;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location;
using Parsyn.Apps.Company.Data.Models.Entity.Config;
using Parsyn.Apps.Company.Data.Models.Entity.Forms;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Data.Models.Entity.Reactions;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Contexts
{
    public class PDBContext : DbContext
    {

        public PDBContext()
        {
            // Design-time constructor
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=188.40.192.230,1433;Initial Catalog=bizbaan;User=sa;Password=&UJMmju7;MultipleActiveResultSets=true;Encrypt=False;");
        }


        public DbSet<UserModel> User { get; set; }
        public DbSet<MediaModel> Media { get; set; }
        public DbSet<SeoModel> Seo { get; set; }
        public DbSet<ArticleModel> Article { get; set; }
        public DbSet<ArticleCategoryModel> ArticleCategory { get; set; }
        public DbSet<VisitModel> Visit { get; set; }
        public DbSet<CommentModel> Comment { get; set; }
        public DbSet<LikeModel> Like { get; set; }
        public DbSet<ContactUsModel> ContactUs { get; set; }
        public DbSet<SocialMediaModel> SocialMedia { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<FaqCatModel> FaqCategory { get; set; }
        public DbSet<FaqModel> Faq { get; set; }
        public DbSet<PagesModel> Pages { get; set; }
        public DbSet<FormModel> Forms { get; set; }
        public DbSet<OptionsModel> Options { get; set; }


        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
        public DbSet<RolePermissionModel> RolePermissions { get; set; }



        /**********BIZBAAN SECTION***************/
        public DbSet<AdCategoryModel> AdCategories { get; set; }
        public DbSet<AdImageModel> AdImages { get; set; }
        public DbSet<AdModel> Ads { get; set; }
        public DbSet<ZipModel> Zipcodes { get; set; }
        public DbSet<SubscribeModel> Subscribe { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleModel>()
               .Property(x => x.Id)
               .UseIdentityColumn(seed: 5000);
            modelBuilder.Entity<ArticleCategoryModel>()
               .Property(x => x.Id)
               .UseIdentityColumn(seed: 6000);
            modelBuilder.Entity<ContactUsModel>()
               .Property(x => x.Id)
               .UseIdentityColumn(seed: 7000);

            modelBuilder.Entity<ArticleModel>()
                .HasOne(e => e.ArticleCategory)
                .WithMany(e => e.Articles)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
        public static readonly ILoggerFactory PropertyAppLoggerFactory =
          LoggerFactory.Create(builder =>
              builder.AddFilter((category, level) =>
                  category == DbLoggerCategory.Database.Command.Name && (level == LogLevel.Warning)));
    }
}
