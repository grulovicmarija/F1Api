using AutoMapper;
using F1GrandPrixApi.DataTransferObjects;
using F1GrandPrixApi.Models;

namespace F1GrandPrixApi
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //navodimo sve mapping profile koje cemo koristiti
            //mapiranje se vrsi izmedju Data Transfer objekata i originalnih objekata


            //CreateMap<Trka, TrkaDto>().ReverseMap();
            CreateMap<Trka, TrkaDto>();
            CreateMap<TrkaDto, Trka>();
            CreateMap<Grad, GradDto>();
            CreateMap<GradDto, Grad>();
            CreateMap<Kupac, KupacDto>();
            CreateMap<KupacDto, Kupac>();
            CreateMap<Drzava, DrzavaDto>();
            CreateMap<DrzavaDto, Drzava>();
            CreateMap<Zona, ZonaDto>();
            CreateMap<ZonaDto, Zona>();
            CreateMap<Rezervacija, RezervacijaDto>();
            CreateMap<RezervacijaDto, Rezervacija>();
            CreateMap<RezervacijaSendDto, Rezervacija>();
            CreateMap<Rezervacija, RezervacijaSendDto>();
            CreateMap<UcesnikDto, Ucesnik>();
            CreateMap<Ucesnik, UcesnikDto>();
        

        }
    }
}
