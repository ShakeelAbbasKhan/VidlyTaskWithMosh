using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;   
        }


        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCustomer(int id,Customer customer)
        {
            var updateCustomer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if(updateCustomer == null)
            {
                return BadRequest();
            }
            updateCustomer.Name = customer.Name;
            updateCustomer.Birthdate = customer.Birthdate;
            updateCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            updateCustomer.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var deleteCustomer = _context.Customers.SingleOrDefault( x => x.Id == id);
            if (deleteCustomer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(deleteCustomer);
            _context.SaveChanges();
            return Ok();
        }
    }
}
