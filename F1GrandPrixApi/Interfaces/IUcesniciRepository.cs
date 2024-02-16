using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.Interfaces
{
    public interface IUcesniciRepository
    {
        List<Ucesnik> UcitajUcesnike();
        Ucesnik UcitajUcesnika(int ucesnikId);
        bool PostojiUcesnik(int ucesnikId);
    }
}
