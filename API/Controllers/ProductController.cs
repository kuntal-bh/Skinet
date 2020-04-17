using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using core.Specifications;
using infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseApiController
    {
        
       
        private readonly IGenericRepository<Product> _productrepository;
        private readonly IGenericRepository<ProductBrand> _productbrandrepository;
        private readonly IGenericRepository<ProductType> _producttyperepository;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productrepository , 
                                 IGenericRepository<ProductBrand> productbrandrepository,
                                 IGenericRepository<ProductType> producttyperepository, 
                                 IMapper mapper)
        {
            _productrepository = productrepository;
           _productbrandrepository = productbrandrepository;
           _producttyperepository = producttyperepository;
           _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts()
        {
            var spec = new ProductWithBrandsAndTypes();
            var products = await _productrepository.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDTO>>(products)) ;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof( ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        
        {
            var spec = new ProductWithBrandsAndTypes(id);
            var product = await _productrepository.GetEntityBySpec(spec);
            if(product == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Product, ProductToReturnDTO>(product)) ;
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() {
            var ProductBrands = await _productbrandrepository.ListAllAsync();
            return Ok(ProductBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() {
            var ProductTypes = await _producttyperepository.ListAllAsync();
            return Ok(ProductTypes);
        }
    }
}
