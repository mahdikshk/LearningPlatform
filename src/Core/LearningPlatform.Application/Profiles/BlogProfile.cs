using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningPlatform.Application.DTO.BlogDTOs;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.Profiles;
internal class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<CreateBlogDTO,Blog>().ReverseMap();
        CreateMap<UpdateBlogDTO,Blog>().ReverseMap();
        CreateMap<BlogDTO,Blog>().ReverseMap();
    }
}
