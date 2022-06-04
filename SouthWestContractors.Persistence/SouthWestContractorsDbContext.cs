using Microsoft.EntityFrameworkCore;
using SouthWestContractors.Application.Contracts;
using SouthWestContractors.Domain.Common;
using SouthWestContractors.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Persistence
{
    public class SouthWestContractorsDbContext : DbContext
    {
        //private readonly ILoggedInUserService _loggedInUserService;

        public SouthWestContractorsDbContext(DbContextOptions<SouthWestContractorsDbContext> options)
           : base(options)
        {
        }

        //public SouthWestContractorsDbContext(DbContextOptions<SouthWestContractorsDbContext> options, ILoggedInUserService loggedInUserService)
        //    : base(options)
        //{
        //    _loggedInUserService = loggedInUserService;
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Galery> Galeries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SouthWestContractorsDbContext).Assembly);
            //seed data, added through migrations
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = concertGuid,
                Name = "Plumbing"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = musicalGuid,
                Name = "Woodworking"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = playGuid,
                Name = "Electrical"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = conferenceGuid,
                Name = "Tile"
            });

            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                ContractorId = Guid.NewGuid(),
                UserId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "John",
                LastName = "Egbert",
               // ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
            });

            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                ContractorId = Guid.NewGuid(),
                UserId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Name = "Mark",
                LastName = "Johnson",
            });

            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                ContractorId= Guid.NewGuid(),
                UserId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "Mike",
                LastName = "Romanov",
            });

          

            modelBuilder.Entity<Galery>().HasData(new Galery
            {
                Id = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                Description = "uno",
            });

            modelBuilder.Entity<Galery>().HasData(new Galery
            {
                Id = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                Description = "dos",
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
                        // entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        // entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);

        }
    }
}
