using CustomerAPI.Contexts;
using CustomerAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        HttpClient httpClient = new HttpClient();
        
        private readonly CustomerManageDbContext _context;

        public CustomersController(CustomerManageDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers/GetCustomers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.Include(c => c.Addresses).Include(c => c.Phones).ToListAsync();

            foreach (Customer customer in customers)
            {
                if (IsUnusualName(customer.Name))
                    customer.UnUsualName = true;
            }

         

            return Ok(customers);
        }
        // GET: api/Customers/GetCustomerDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetails(int id)
        {
            var customer = _context.Customers
                .Where(customer => customer.Id == id)
                .FirstOrDefault();

           

            return Ok(customer);
        }

       
        [HttpPut]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {

            Customer updatedCustomer = await _context.Customers.FirstOrDefaultAsync(c=>c.Id == customer.Id);
            updatedCustomer.Name = customer.Name;
            updatedCustomer.Surname = customer.Surname;
            updatedCustomer.SocialSecurityNumber = customer.SocialSecurityNumber;
            updatedCustomer.Email = customer.Email;
            updatedCustomer.Gender = customer.Gender;
            updatedCustomer.Addresses = customer.Addresses;
            updatedCustomer.Phones = customer.Phones;
            _context.SaveChanges();
            return Ok(updatedCustomer);
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {

           

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        public bool IsUnusualName(string name)
        {
            // Count the number of occurrences of each vowel in the name
            int aCount = 0;
            int eCount = 0;
            int ıCount = 0;
            int iCount = 0;
            int oCount = 0;
            int öCount = 0;
            int uCount = 0;
            int üCount = 0;

            string controlName = name.ToLower();

            for (int i = 0; i < controlName.Length; i++)
            {
                switch (controlName[i])
                {
                    case 'a':
                        aCount++;
                        break;
                    case 'e':
                        eCount++;
                        break;

                    case 'ı':
                        ıCount++;
                        break;

                    case 'i':
                        iCount++;
                        break;
                    case 'o':
                        oCount++;
                        break;

                    case 'ö':
                        öCount++;
                        break;

                    case 'u':
                        uCount++;
                        break;

                    case 'ü':
                        üCount++;
                        break;

                }
            }

            // Return true if at least 3 of the same vowels are present
            return (aCount >= 3 || eCount >= 3 || iCount >= 3 || oCount >= 3 || uCount >= 3 || ıCount >= 3 || öCount >= 3 || üCount >= 3 );
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            Customer customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
