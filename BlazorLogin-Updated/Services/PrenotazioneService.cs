using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorServerAuthenticationAndAuthorization.Models;
using BlazorServerAuthenticationAndAuthorization.Authentication;

namespace BlazorServerAuthenticationAndAuthorization.Services
{
    public class PrenotazioneService
    {
        private readonly AuthDbContext _context;
        private const int MaxSeats = 40;
        private static readonly TimeSpan ReservationDuration = TimeSpan.FromHours(2);

        public PrenotazioneService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreaPrenotazioneAsync(Prenotazione prenotazione)
        {
            // definisco in C# inizio e fine del nuovo intervallo
            var newStart = prenotazione.Ora;
            var newEnd = prenotazione.Ora.Add(ReservationDuration);

            // carico DAL DB solo le prenotazioni per la stessa data
            var todaysBookings = await _context.Prenotazioni
                .Where(p => p.Data == prenotazione.Data)
                .ToListAsync();

            // sommo in memoria i posti dei bookings che SI SOVRAPPONGONO al nuovo
            var reservedSeats = todaysBookings
                .Where(p =>
                    // inizio esistente < fine nuova pren.  AND
                    p.Ora < newEnd
                    // fine esistente > inizio nuova pren.
                    && p.Ora
                        .Add(ReservationDuration) > newStart
                )
                .Sum(p => p.NumeroPersone);

            // se l’occupazione totale eccede la capienza, rifiuto
            if (reservedSeats + prenotazione.NumeroPersone > MaxSeats)
                return false;

            // altrimenti salvo e torno true
            _context.Prenotazioni.Add(prenotazione);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
