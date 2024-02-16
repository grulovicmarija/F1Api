using F1GrandPrixApi.Data;
using F1GrandPrixApi.Interfaces;
using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.Repository
{
    public class ZoneRepository :IZoneRepository
    {
        DataContext context;
        public ZoneRepository(DataContext context)
        {
            this.context = context;
        }

        public bool PostojiZona(int zonaId)
        {
            return context.zone.Any(z => z.id == zonaId);
        }

        public void SmanjiMesto(int zonaId)
        {
            var zona = context.zone.Where(z => z.id == zonaId).FirstOrDefault();
            zona.preostaloMesta = zona.preostaloMesta - 1;
            context.Update(zona);
            Sacuvaj(); 
        }
        public bool Sacuvaj()
        {
            int sacuvano = context.SaveChanges();
            return sacuvano > 0;
        }
        public List<Zona> UcitajZone()
        {
            return context.zone.ToList();
        }

        public Zona UcitajZonu(int zonaId)
        {
            return context.zone.Where(z => z.id == zonaId).FirstOrDefault();
        }

        public bool Dostupna(int zonaId)
        {
            var zona = context.zone.Where(z => z.id == zonaId).FirstOrDefault();
            return zona.preostaloMesta > 0; 
        }
    }
}
