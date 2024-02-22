using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.Interfaces
{
    public interface IZoneRepository
    {
        List<Zona> UcitajZone();
        Zona UcitajZonu(int zonaId);
        bool PostojiZona(int zonaId);
        void SmanjiMesto(int zonaId, int brojKarata);
        bool Dostupna(int zonaId); 
        bool Sacuvaj(); 
    }
}
