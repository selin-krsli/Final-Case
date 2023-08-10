
using AutoMapper;
using BuildingManagementSystem.Data;

namespace BuildingManagementSystem.Schema;

public class MapperConfig:Profile
{
    public MapperConfig()
    {
        CreateMap<ResidentRequest, Resident>();  //POST&PUT
        CreateMap<Resident, ResidentResponse>(); //GET

        CreateMap<FlatRequest, Flat>();
        CreateMap<Flat, FlatResponse>();

        CreateMap<InvoiceRequest, Invoice>();
        CreateMap<Invoice, InvoiceResponse>();

        CreateMap<InvoiceTypeRequest, InvoiceType>();
        CreateMap<InvoiceType, InvoiceTypeResponse>();

        CreateMap<CardInformationRequest, CardInformation>();
        CreateMap<CardInformation, CardInformationResponse>();

        CreateMap<MessageRequest, Message>();
        CreateMap<Message, CardInformationResponse>();

        CreateMap<PaymentRequest, Payment>();
        CreateMap<Payment, PaymentResponse>()
                 .ForMember(dest=>dest.ResidentName, opt=>opt.MapFrom(src=>src.Resident.FirstName + " " + src.Resident.LastName));

        CreateMap<VehicleRequest, Vehicle>();
        CreateMap<Vehicle, VehicleResponse>();

        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();

        CreateMap<UserLogRequest, UserLog>();
        CreateMap<UserLog, UserLogResponse>();
    }
}
