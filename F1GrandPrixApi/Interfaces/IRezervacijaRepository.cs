using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.Interfaces
{
    public interface IRezervacijaRepository
    {
        bool KreirajRezervaciju(Rezervacija rezervacija);
        bool OtkaziRezervaciju(Rezervacija rezervacija);
        Rezervacija UcitajRezervaciju(int kupacId, int trkaId);
        List<Rezervacija> UcitajRezervacijeKupca(int kupacId);
        bool PostojiRezervacija(int kupacId, int trkaId);
        bool AzurirajRezervaciju(Rezervacija rezervacija);
        Rezervacija UcitajRezervacijuPremaTokenu(string email, string token);
        void PonovoObracunajPopust(int kupacId);
        bool Sacuvaj();
    }
}
