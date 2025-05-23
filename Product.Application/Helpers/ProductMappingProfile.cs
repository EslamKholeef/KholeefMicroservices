using AutoMapper;
using Product.Application.Commands.CreateCommand;
using Product.Application.Commands.UpdateCommand;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Helpers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductCommand, ProductModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); //Eslam: Ignore Id if it's auto-generated or handled elsewhere

            CreateMap<UpdateProductCommand, ProductModel>();
        }
    }
}
