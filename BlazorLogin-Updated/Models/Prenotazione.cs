using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorServerAuthenticationAndAuthorization.Models;
using BlazorServerAuthenticationAndAuthorization.Services;

namespace BlazorServerAuthenticationAndAuthorization.Models
{
    public class Prenotazione
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        [Phone]
        public string Cellulare { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public TimeSpan Ora { get; set; }

        [Required]
        public int NumeroPersone { get; set; }

        [Required]
        public string Username { get; set; } // Per collegare la prenotazione all'utente
    }
}
