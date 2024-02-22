using F1GrandPrixApi.Data;
using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.Models;
using Microsoft.EntityFrameworkCore;
using Scrypt; 

namespace F1GrandPrixApi.Repository
{
    public class KupciRepository : IKupciRepository
    {
        DataContext context;

        public KupciRepository(DataContext context)
        {
            this.context = context;
        }

        public Kupac UlogujKupca(string email, string sifra)
        {
            //Log In
            ScryptEncoder encoder = new ScryptEncoder();
           
            Kupac kupac = context.kupci.Where(k => k.email == email).FirstOrDefault();

            if (kupac == null)
                return null;

            try
            {
                if (encoder.Compare(sifra, kupac.sifra))
                    return kupac;
            }
            catch (Exception)
            {
                return null; 
            }

            return null; 
        }

        public bool KreirajKupca(Kupac kupac)
        {
            //Sign Up
            ScryptEncoder encoder = new ScryptEncoder();
            kupac.sifra = encoder.Encode(kupac.sifra); 

            context.Add(kupac);
            return Sacuvaj(); 
        }

        public List<Drzava> UcitajDrzave()
        {
            return context.drzave.ToList(); 
        }

        public bool PostojiKupac(int kupacId)
        {
            return context.kupci.Any(k => k.id == kupacId);
        }

        public Kupac UcitajKupca(int kupacId)
        {
            return context.kupci.Where(k => k.id == kupacId).FirstOrDefault();
        }

        public List<Kupac> UcitajKupce()
        {
            return context.kupci.ToList();
        }

        public List<Rezervacija> UcitajRezervacijeKupca(int kupacId)
        {
            return context.rezervacije.Where(r => r.KupacId == kupacId).ToList();
        }

        public bool ZauzetMejl(string mail)
        {
            return context.kupci.Any(k => k.email == mail); 
        } 

        public bool ZauzetPromoKod(string promoKod)
        {
            return context.kupci.Any(k => k.promoKod == promoKod); 
        }


        public Drzava UcitajDrzavu(int drzavaId)
        {
            return context.drzave.Where(d => d.id == drzavaId).FirstOrDefault(); 
        }

        public bool IskoristiPromoKod(int kupacId, string promoKod)
        {
            Kupac kupac = context.kupci.Where(k => k.promoKod == promoKod).FirstOrDefault();

            if (kupac == null || kupac.id == kupacId || kupac.iskoriscenPromoKod == true)
                return false;

            Kupac prijatelj = context.kupci.Where(k => k.id == kupacId).FirstOrDefault();

            if (prijatelj == null)
                return false;

            prijatelj.promoPopust = true;
            kupac.iskoriscenPromoKod = true;

            context.Update(kupac);
            context.Update(prijatelj);

            return Sacuvaj(); 
        }



        public bool Sacuvaj()
        {
            int sacuvano = context.SaveChanges();
            return sacuvano > 0; 
        }

      
    }
}
