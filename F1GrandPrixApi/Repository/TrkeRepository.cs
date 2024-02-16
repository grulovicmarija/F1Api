using F1GrandPrixApi.Data;
using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.Models;
using Microsoft.EntityFrameworkCore;

namespace F1GrandPrixApi.Repository
{
    public class TrkeRepository : ITrkeRepository
    {
        DataContext context;

        public TrkeRepository(DataContext context)
        {
            this.context = context;
        }

        public bool PostojiTrka(int trkaId)
        {
            return context.trke.Any(t => t.id == trkaId);
        }

        public List<Trka> UcitajTrke()
        {
            return context.trke.Include(t => t.grad).ToList();
        }

        public Trka UcitajTrku(int trkaId)
        {
            return context.trke.Include(t => t.grad).Where(t => t.id == trkaId).FirstOrDefault();
        }

        public List<Ucesce> UcitajUcesca(int trkaId)
        {
            return context.ucesca.Where(u => u.TrkaId == trkaId).Include(u => u.ucesnik).ThenInclude(uc => uc.drzava).ToList(); 
        }
    }
}
