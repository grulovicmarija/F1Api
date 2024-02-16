using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.Interfaces
{
    public interface IKupciRepository
    {
        List<Kupac> UcitajKupce();

        Kupac UlogujKupca(string email, string sifra); 
        Kupac UcitajKupca(int kupacId);

        List<Rezervacija> UcitajRezervacijeKupca(int kupacId);
        bool PostojiKupac(int kupacId);
        bool KreirajKupca(Kupac kupac);

        bool ZauzetMejl(string mail);


        bool ZauzetPromoKod(string promoKod); 
        bool Sacuvaj();
        Drzava UcitajDrzavu(int drzavaId);
        bool IskoristiPromoKod(int kupacId, string promoKod);
        public List<Drzava> UcitajDrzave();
    }
}
