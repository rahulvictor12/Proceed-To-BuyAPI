using Microsoft.AspNetCore.Mvc;
using ProceedToBuyMicroservice.Model;
using ProceedToBuyMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceedToBuyController : ControllerBase
    {
        IRepository<Cart> _repository;
        public ProceedToBuyController(IRepository<Cart> repository)
        {
            _repository = repository;
        }
        // GET: api/<ProceedToBuyController>
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return _repository.GetCart();
        }

        // GET api/<ProceedToBuyController>/5
        [HttpGet("{id}")]
        public List<Cart> Get(int id)
        {
            List<Cart> cart = _repository.GetCart();
            return cart.Where(x => x.CustomerId == id).ToList();
        }

        // POST api/<ProceedToBuyController>
        [HttpPost]
        public Boolean Post([FromBody] Cart _cart)
        {
            return _repository.AddToCart(_cart);
        }

        // PUT api/<ProceedToBuyController>/5
        [HttpPut("GetWishList/{id}")]
        public IEnumerable<VendorWishlist> GetWishList(int id)
        {
            return _repository.GetWishlist(id);
        }

        [Route("WishList")]
        [HttpPost]
        public IActionResult WishList(int customerId, int productId)
        {
            
            _repository.AddToWishList(customerId, productId);
            return Ok("Success");
        }
        [Route("DeleteAll/{id}")]
        [HttpGet]
        public IActionResult DeleteAll(int id)
        {
           
            if (_repository.DeleteCustomerCart(id))
                return Ok("Success");
            return BadRequest("Failed");
        }

        [Route("DeleteCart/{id}")]
        [HttpDelete]
        public IActionResult DeleteByCartId(int id)
        {
           
            if (_repository.DeleteCartById(id))
                return Ok("Success");
            return BadRequest("Failed");
        }
    }
}
