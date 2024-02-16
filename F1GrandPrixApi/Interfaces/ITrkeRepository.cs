using F1GrandPrixApi.Models;

namespace F1GrandPrixApi.Interfaces
{
    public interface ITrkeRepository
    {
        List<Trka> UcitajTrke();
        Trka UcitajTrku(int trkaId);

        bool PostojiTrka(int trkaId);

        List<Ucesce> UcitajUcesca(int trkaId);

    }
}
