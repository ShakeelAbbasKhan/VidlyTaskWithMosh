using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult New()
        {
            var membershipTypes = _db.MembershipTypes.ToList();
            var viewModel = new CustomerFormVM
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        //[HttpPost]
        //public IActionResult New(CustomerFormVM customerFormVM)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _db.Customers.Add(customerFormVM.Customer);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(customerFormVM);
        //    }

        //}

        [HttpPost]
        public IActionResult New(int Id, string Name, DateTime DOB, bool IsSubs, byte MemberShip)
        {
            var obj = new Customer();
            if (Id==0)
            {
                obj.Name = Name;
                obj.Birthdate = DOB;
                obj.IsSubscribedToNewsletter = IsSubs;
                obj.MembershipTypeId = MemberShip;
                _db.Customers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }
        public IActionResult Index()
        {
            
            var data = _db.Customers.Include(c=>c.MembershipType);
            if (data==null)
            {
                return NotFound();
            }
            return View(data.ToList());
        }
        public IActionResult Delete(int id)
        {

           var result = _db.Customers.Where(c=>c.Id==id).FirstOrDefault();
            if (result==null)
            {
                return NotFound();
            }
            _db.Customers.Remove(result);
            _db.SaveChanges();
            return Ok(result);
        }

       
        [HttpGet]
        public IActionResult GetCustomer()
        {

            var data = _db.Customers.Include(c => c.MembershipType);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToList());
        }
        public ActionResult Details(int id)
        {
            var customer = _db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }
    }
}
