using F1GrandPrixApi.Data;
using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.Models;
using Microsoft.EntityFrameworkCore;

namespace F1GrandPrixApi.Repository
{
    public class RezervacijaRepository : IRezervacijaRepository
    {

        DataContext context;

        public RezervacijaRepository(DataContext context)
        {
            this.context = context;
        }

        public bool KreirajRezervaciju(Rezervacija rezervacija)
        {
            context.Add(rezervacija);
            return Sacuvaj();
        }

        public bool OtkaziRezervaciju(Rezervacija rezervacija)
        {
            context.rezervacije.Remove(rezervacija);

            Zona zona = context.zone.Where(z => z.id == rezervacija.ZonaId).FirstOrDefault();
            zona.preostaloMesta += rezervacija.brojKarata;
            context.Update(zona); 

            return Sacuvaj();
        }

        public void PonovoObracunajPopust(int kupacId)
        {
            List<Rezervacija> rezervacije = context.rezervacije.Where(r=> r.KupacId == kupacId).ToList();

            if (rezervacije == null) return;
            else if (rezervacije.Count == 0) return; 


            int begin = 0; 


            foreach(Rezervacija rez in rezervacije)
            {
                rez.popust = begin;
                begin += 10; 
            }

            context.rezervacije.UpdateRange(rezervacije);
            Sacuvaj(); 
        }

        public Rezervacija UcitajRezervaciju(int kupacId, int trkaId)
        {
            return context.rezervacije.Where(r => r.KupacId == kupacId && r.TrkaId == trkaId && r.aktivna == true).FirstOrDefault();
        }

        public List<Rezervacija> UcitajRezervacijeKupca(int kupacId)
        {
            return context.rezervacije.Include(r => r.kupac).Include(r => r.trka).Include(r => r.zona).Where(r => r.KupacId == kupacId && r.aktivna == true).ToList(); 
        }

        public Rezervacija UcitajRezervacijuPremaTokenu(string email, string token)
        {
            return context.rezervacije.Include(r => r.kupac).Where(r => r.token == token && r.kupac.email == email).FirstOrDefault();
        }

        public bool PostojiRezervacija(int kupacId, int trkaId)
        {
            return context.rezervacije.Any(r => r.KupacId == kupacId && r.TrkaId == trkaId && r.aktivna == true); 
        }

        public bool AzurirajRezervaciju(Rezervacija rezervacija)
        {
            context.Update(rezervacija);
            return Sacuvaj(); 
        }
   
        public bool Sacuvaj()
        {
            int sacuvano = context.SaveChanges();
            return sacuvano > 0;
        }


    }
}
