using Microsoft.EntityFrameworkCore;
using SouthWestContractors.Application.Contracts;
using SouthWestContractors.Domain.Common;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Persistence
{
    public class SouthWestContractorsDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public SouthWestContractorsDbContext(DbContextOptions<SouthWestContractorsDbContext> options)
           : base(options)
        {

        }

        public SouthWestContractorsDbContext(DbContextOptions<SouthWestContractorsDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Galery> Galeries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractorCategory>()
            .HasKey(t => new { t.ContractorId, t.CategoryId });

            modelBuilder.Entity<ContractorCategory>()
                .HasOne(pt => pt.Contractor)
                .WithMany(p => p.ContractorCategories)
                .HasForeignKey(pt => pt.ContractorId);

            modelBuilder.Entity<ContractorCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.ContractorCategories)
                .HasForeignKey(pt => pt.CategoryId);

           


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SouthWestContractorsDbContext).Assembly);
            //seed data, added through migrations
            var plumbingGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var electricalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var woodworkingGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var tileGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var galery1Guid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DD1}");
            var galery2Guid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A2}");
            var galery3Guid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284A3}");


            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = plumbingGuid,
                Name = "Plumbing"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = woodworkingGuid,
                Name = "Woodworking"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = electricalGuid,
                Name = "Electrical"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = tileGuid,
                Name = "Tile"
            });

            modelBuilder.Entity<Galery>().HasData(new Galery
            {
                ContractorId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8A}"),
                GaleryId = galery1Guid,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                Description = "uno",
            });

            modelBuilder.Entity<Galery>().HasData(new Galery
            {
                ContractorId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8A}"),
                GaleryId = galery2Guid,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                Description = "dos",
            });
            modelBuilder.Entity<Galery>().HasData(new Galery
            {
                ContractorId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                GaleryId = galery3Guid,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                Description = "tres",
            });

            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                ContractorId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8A}"),
                UserId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "John",
                LastName = "Egbert"
            }); ;

            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                ContractorId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                UserId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C01}"),
                Name = "Mark",
                LastName = "Johnson"
            });

            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                ContractorId= Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529318}"),
                UserId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "Mike",
                LastName = "Romanov",
            });

            modelBuilder.Entity<ContractorCategory>().HasData(new ContractorCategory
            {
                ContractorId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8A}"),
                CategoryId = plumbingGuid,
            });
            modelBuilder.Entity<ContractorCategory>().HasData(new ContractorCategory
            {
                ContractorId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                CategoryId = electricalGuid,
            });
            modelBuilder.Entity<ContractorCategory>().HasData(new ContractorCategory
            {
                ContractorId= Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529318}"),
                CategoryId = tileGuid,
            });
            modelBuilder.Entity<ContractorCategory>().HasData(new ContractorCategory
            {
                ContractorId= Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529318}"),
                CategoryId = plumbingGuid,
            });


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.GetLoginUserName();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.GetLoginUserName();
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);

        }


    }
}
