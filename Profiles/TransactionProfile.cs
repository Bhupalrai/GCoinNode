using AutoMapper;
using GcoinNode.Dtos;
using GcoinNode.Models;

namespace GcoinNode.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionReadDto>();
            CreateMap<TransactionCreateDto, Transaction>();
            CreateMap<TransactionReadDto, Transaction>();
            CreateMap<Transaction, TransactionCreateDto>();
        }
    }

}
