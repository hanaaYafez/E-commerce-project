using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace FinalProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        [HttpGet]
        public IActionResult Register() 
        { 
            return View(new RegistrationViewModel());
        }
       
        [HttpPost]
        public IActionResult Register(RegistrationViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists in the database
                if (_dbContext.Customers.Any(c => c.Email == customerViewModel.Email))
                {
                    ModelState.AddModelError("Email", "Email is already registered.");
                    return View(customerViewModel);
                }
                // Validate the image
                var validationResult = new ValidateImageAttribute().GetValidationResult(customerViewModel.cust_Pic, new ValidationContext(customerViewModel));
                if (validationResult != ValidationResult.Success)
                {
                    ModelState.AddModelError(nameof(customerViewModel.cust_Pic), validationResult.ErrorMessage);
                    return View(customerViewModel);
                }
                var customer = new Customer
                {
                    Name = customerViewModel.Name,
                    Address = customerViewModel.Address,
                    PhoneNumber = customerViewModel.PhoneNumber,
                    Email = customerViewModel.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(customerViewModel.Password),
                    ConfirmationPassword = BCrypt.Net.BCrypt.HashPassword(customerViewModel.Password),
                    // Assign the image file name to the customer's profile picture property
                    cust_Pic = customerViewModel.cust_Pic
                };

                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                return RedirectToAction("Login", "Customer");
            }
            return View(customerViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = _dbContext.Customers.FirstOrDefault(u => u.Email == model.Email);

                // Check if user exists and the hashed password matches
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
                    // Store the user's name in the session
                    HttpContext.Session.SetString("username", user.CustomerName);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password");
                }
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult customercarthistory()
        {
            var customerId = HttpContext.Session.GetInt32("userid");
            List<Order> orlist = _dbContext.orders.Where(i => i.CustomerID == (int)customerId).ToList();
            List<Product>pro=new List<Product>();
            foreach (Order o in orlist)
            {
                Product p = _dbContext.products.FirstOrDefault(i => i.ProductID == o.ProductID);
                pro.Add(p);
            }

            return View(pro);
        }

    }
}
