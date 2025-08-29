using Microsoft.EntityFrameworkCore;
using BlazorServerAuthenticationAndAuthorization.Models; // << QUESTA È LA RIGA DA AGGIUNGERE

namespace BlazorServerAuthenticationAndAuthorization.Authentication
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }

        public DbSet<Prenotazione> Prenotazioni { get; set; }
    }
}
