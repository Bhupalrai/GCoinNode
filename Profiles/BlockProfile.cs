using AutoMapper;
using GcoinNode.Dtos;
using GcoinNode.Models;

namespace GcoinNode.Profiles
{
    public class BlockProfile : Profile
    {
        public BlockProfile()
        {
            CreateMap<Block, BlockDto>();
            CreateMap<BlockDto, Block>();
        }
    }

}
