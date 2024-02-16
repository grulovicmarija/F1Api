using F1GrandPrixApi.Data;
using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.Models;
using Microsoft.EntityFrameworkCore;

namespace F1GrandPrixApi.Repository
{

    public class UcesniciRepository : IUcesniciRepository
    {
        DataContext context;
        public UcesniciRepository(DataContext context)
        {
            this.context = context;            
        }

        public bool PostojiUcesnik(int ucesnikId)
        {
            return context.trke.Any(u => u.id == ucesnikId);
        }

        public Ucesnik UcitajUcesnika(int ucesnikId)
        {
            return context.ucesnici.Where(u => u.id == ucesnikId).FirstOrDefault();
        }

        public List<Ucesnik> UcitajUcesnike()
        {
            return context.ucesnici.Include(u => u.drzava).ToList();
        }
    }
}
