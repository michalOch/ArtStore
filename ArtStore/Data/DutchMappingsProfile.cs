using ArtStore.Data.Entities;
using ArtStore.ViewModels;
using AutoMapper;

namespace ArtStore.Data
{
    public class DutchMappingsProfile : Profile
    {
        public DutchMappingsProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember( o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
    }
}
