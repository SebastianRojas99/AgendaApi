using AgendaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Data
{
    public class AgendaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User karen = new User()
            {
                Id = 1,
                FirstName = "Karen",
                LastName = "Lasot",
                Password = "Pa$$w0rd",
                UserName = "karenbailapiola@gmail.com",
                Rol = Models.Enum.Rol.Admin,
            };
            User luis = new User()
            {
                Id = 2,
                FirstName = "Luis Gonzalez",
                LastName = "Gonzales",
                Password = "lamismadesiempre",
                UserName = "elluismidetotoras@gmail.com",
            };

            Contact jaimitoC = new Contact()
            {
                Id = 1,
                Name = "Jaimito",
                Number = "341457896",
                Description = "Plomero",
                UserId = karen.Id,
            };

            Contact pepeC = new Contact()
            {
                Id = 2,
                Name = "Pepe",
                Number = "34156978",
                Description = "Papa",
                UserId = luis.Id,
            };

            Contact mariaC = new Contact()
            {
                Id = 3,
                Name = "Maria",
                Number = "341457896",
                Description = "Jefa",
                UserId = karen.Id,
            };

            modelBuilder.Entity<User>().HasData(
                karen, luis);

            modelBuilder.Entity<Contact>().HasData(
                 jaimitoC, pepeC, mariaC
                 );

            modelBuilder.Entity<User>()
              .HasMany<Contact>(u => u.Contacts)
              .WithOne(c => c.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
