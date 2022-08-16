using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseInfrastructure.Models;
using DatabaseInfrastructure.UnitOfWorks;

namespace ApiTest.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerDto customerDto)
        {
            var product = new Products
            {
                Name = "Milk",
                Description = "Rich in Vitamin A, B, C, D, K"
            };
            var model = new Customers
            {
                Email = customerDto.Email,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName
            };

            model.AddProduct(product);
            _unitOfWork.CustomerRepository.Add(model);

            _unitOfWork.CommitToDatabase();

            return Ok(model.Id);
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var responds = _unitOfWork.CustomerRepository.GetAll();
            var respondsDtos = new List<CreateCustomerDto>();
            
            foreach (var item in responds.Result)
            {
                var productDtos = new List<ProductDto>();
                foreach (var product in item.Products)
                {
                    productDtos.Add(new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description
                    });
                }
                respondsDtos.Add(new CreateCustomerDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    ProductDtos= productDtos
                });
            }

            return Ok(respondsDtos);
        }
    }
}
