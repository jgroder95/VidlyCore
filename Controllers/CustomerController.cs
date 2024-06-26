using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyCore.Models;
using VidlyCore.ViewModels;

namespace VidlyCore.Controllers
{
    public class CustomerController : Controller
    {
        public readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public IActionResult New()
        {
            var customerViewModel = new CustomerViewModel()
            {
                Customer = new Customer(),
                MembershipType = _context.MembershipTypes.ToList()
                
            };
            return View("CustomerForm", customerViewModel);
        }
        
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customerViewModel = new CustomerViewModel()
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", customerViewModel);
        }

        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel()
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customer.BirthDate = customer.BirthDate;
            }


            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var FoundCustomer = _context.Customers.SingleOrDefault(m => m.Id == id);

            if (FoundCustomer != null)
            {
                var customerViewModel = new CustomerViewModel()
                {
                    Customer = FoundCustomer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("Delete", customerViewModel);
            }
            else
            {
                RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(CustomerViewModel viewModel)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == viewModel.Customer.Id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
