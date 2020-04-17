using API.DTOs;
using AutoMapper;
using core.Entities;
using System;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductValueResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductValueResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(source.PictureUrl== "" || source.PictureUrl ==null) {
                return null;
            }
            else {
                return _configuration["ApiUrl"]+source.PictureUrl;
            }
        }
    }
}